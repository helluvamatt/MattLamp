using System;
using System.Collections.Generic;
using System.Linq;
using MattLamp.Properties;
using MattLamp.Models;
using MattLamp.Interop;
using Microsoft.Win32.SafeHandles;
using System.Threading;
using System.Collections.Concurrent;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using NLog;
using MattLamp.Config;
using System.Configuration;

namespace MattLamp
{
    internal class DeviceManager : IDisposable
    {
        private const int STRING_SIZE_LIMIT = 1024;

        private static readonly TimeSpan LOOP_DELAY = TimeSpan.FromMilliseconds(100);

        private ILogger _Logger;
        private DeviceCollection _DeviceConfig;

        private Thread _Thread;
        private bool _Running = true;

        private List<UsbDevice> _CurrentDevices = new List<UsbDevice>();
        private UsbDevice _ActiveDevice;
        private IOpenDevice _ActiveOpenDevice;
        private object _LockObject = new { };

        private LedConfig _CurrentLedConfig;

        private ConcurrentQueue<byte[]> _MessageQueue = new ConcurrentQueue<byte[]>();

        public event EventHandler<DeviceEventArgs> DeviceAdded;
        public event EventHandler<DeviceEventArgs> DeviceRemoved;
        public event EventHandler<DeviceReadyEventArgs> DeviceReady;
        public event EventHandler<KeyConfigReceivedEventArgs> KeyConfigReceived;
        public event EventHandler<LedConfigReceivedEventArgs> LedConfigReceived;
        public event EventHandler<LedStatusReceivedEventArgs> LedStatusReceived;

        public DeviceManager()
        {
            _Logger = LogManager.GetCurrentClassLogger();
            _DeviceConfig = ConfigurationManager.GetSection("devices") as DeviceCollection;
        }

        public void Init()
        {
            _Logger.Info("Starting...");
            _Thread = new Thread(_DeviceSearchThread);
            _Thread.IsBackground = true;
            _Thread.Name = "DeviceManager worker thread";
            _Thread.Start();
        }

        public void SetActiveDevice(DeviceInstance device, bool requestConfigs = true)
        {
            lock (_LockObject)
            {
                if (_ActiveOpenDevice != null)
                {
                    if (!_ActiveOpenDevice.IsDisposed) _ActiveOpenDevice.Dispose();
                    _ActiveOpenDevice = null;
                    _CurrentLedConfig = null;
                }

                _MessageQueue = new ConcurrentQueue<byte[]>();
                _ActiveDevice = _CurrentDevices.FirstOrDefault(d => d.Instance == device);

                if (_ActiveDevice != null)
                {
                    _Logger.Info("Connecting to device: {0} ...", _ActiveDevice);
                    _ActiveOpenDevice = _ActiveDevice.Open();
                    _MessageQueue.Enqueue(CreateSimpleMessage(hid_pkt_req.HID_PKT_REQ_LED_COUNT));
                    _MessageQueue.Enqueue(CreateSimpleMessage(hid_pkt_req.HID_PKT_REQ_CONFIG_KEY_GET));
                }
            }
        }

        public bool IsDeviceConnected => _ActiveDevice != null && _ActiveOpenDevice != null && !_ActiveOpenDevice.IsDisposed;

        public void SetLedConfig(LedConfig ledConfig)
        {
            byte[] msg = new byte[32];
            msg[0] = (byte)hid_pkt_req.HID_PKT_REQ_CONFIG_LED_SET;
            Array.Copy(ledConfig.ToUnmanaged(), 0, msg, 1, 31);
            _MessageQueue.Enqueue(msg);
        }

        public void CommitLedConfig()
        {
            byte[] msg = CreateSimpleMessage(hid_pkt_req.HID_PKT_REQ_COMMIT_LED_CONFIG);
            _MessageQueue.Enqueue(msg);
        }

        public void SetKeyConfig(KeyConfig keyConfig)
        {
            byte[] msg = {
                (byte)hid_pkt_req.HID_PKT_REQ_CONFIG_KEY_SET,
                (byte)keyConfig.Action,
                keyConfig.Param1,
                keyConfig.Param2
            };
            _MessageQueue.Enqueue(msg);
        }

        public void SetLedAll(Color color)
        {
            byte[] msg = {
                (byte)hid_pkt_req.HID_PKT_REQ_LED_SET_ALL,
                color.R,
                color.G,
                color.B,
            };
            _MessageQueue.Enqueue(msg);
        }

        public void SetLedOne(byte index, Color color)
        {
            byte[] msg = {
                (byte)hid_pkt_req.HID_PKT_REQ_LED_SET_ONE,
                color.R,
                color.G,
                color.B,
                index,
            };
            _MessageQueue.Enqueue(msg);
        }

        public void Dispose()
        {
            _Running = false;
        }

        private void _DeviceSearchThread()
        {
            _Logger.Info("Started");
            while (_Running)
            {
                var loopStart = DateTime.Now;

                #region Device enumeration

                var devices = new List<UsbDevice>();

                var detailDataBuffer = IntPtr.Zero;
                var deviceInfoSet = IntPtr.Zero;
                try
                {
                    int listIndex = 0;
                    int lastError = 0;
                    var deviceInterfaceData = new SpDeviceInterfaceData();

                    var systemHidGuid = new Guid();
                    Hid.HidD_GetHidGuid(ref systemHidGuid);
                    deviceInfoSet = SetupApi.SetupDiGetClassDevs(ref systemHidGuid, IntPtr.Zero, IntPtr.Zero, Constants.DigcfPresent | Constants.DigcfDeviceinterface);
                    deviceInterfaceData.cbSize = Marshal.SizeOf(deviceInterfaceData);

                    while (SetupApi.SetupDiEnumDeviceInterfaces(deviceInfoSet, IntPtr.Zero, ref systemHidGuid, listIndex++, ref deviceInterfaceData) || (lastError = Marshal.GetLastWin32Error()) != Constants.ERROR_NO_MORE_ITEMS)
                    {
                        if (lastError == 0)
                        {
                            int bufferSize = 0;
                            SetupApi.SetupDiGetDeviceInterfaceDetail(deviceInfoSet, ref deviceInterfaceData, IntPtr.Zero, 0, ref bufferSize, IntPtr.Zero);
                            detailDataBuffer = Marshal.AllocHGlobal(bufferSize);
                            Marshal.WriteInt32(detailDataBuffer, (IntPtr.Size == 4) ? (4 + Marshal.SystemDefaultCharSize) : 8);
                            if (SetupApi.SetupDiGetDeviceInterfaceDetail(deviceInfoSet, ref deviceInterfaceData, detailDataBuffer, bufferSize, ref bufferSize, IntPtr.Zero))
                            {
                                var pDevicePathName = IntPtr.Add(detailDataBuffer, 4);
                                var devicePath = Marshal.PtrToStringAuto(pDevicePathName);
                                
                                // Get device capabilities (to determine usage page)
                                using (var hidHandle = Kernel32.CreateFile(devicePath, 0, Constants.FileShareRead | Constants.FileShareWrite, IntPtr.Zero, Constants.OpenExisting, 0, 0))
                                {
                                    var preparsedData = IntPtr.Zero;
                                    try
                                    {
                                        preparsedData = new IntPtr();
                                        Hid.HidD_GetPreparsedData(hidHandle, ref preparsedData);
                                        var caps = new HidpCaps();
                                        Hid.HidP_GetCaps(preparsedData, ref caps);

                                        var attrs = new HiddAttributes();
                                        Hid.HidD_GetAttributes(hidHandle, ref attrs);

                                        // Only add the device if it has our VID, PID, and RAW usage page
                                        var deviceClass = FindDeviceClass(attrs.VendorID, attrs.ProductID, attrs.VersionNumber, caps.UsagePage);
                                        if (deviceClass != null)
                                        {
                                            var manufacturer = new StringBuilder(STRING_SIZE_LIMIT);
                                            var product = new StringBuilder(STRING_SIZE_LIMIT);
                                            var serial = new StringBuilder(STRING_SIZE_LIMIT);
                                            Hid.HidD_GetManufacturerString(hidHandle, manufacturer, STRING_SIZE_LIMIT);
                                            Hid.HidD_GetProductString(hidHandle, product, STRING_SIZE_LIMIT);
                                            Hid.HidD_GetSerialNumberString(hidHandle, serial, STRING_SIZE_LIMIT);
                                            var device = new UsbDevice(new DeviceInstance(deviceClass, devicePath, manufacturer.ToString(), product.ToString(), serial.ToString()), caps);
                                            devices.Add(device);
                                        }
                                    }
                                    finally
                                    {
                                        // Free up the memory before finishing
                                        if (preparsedData != IntPtr.Zero) Hid.HidD_FreePreparsedData(preparsedData);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _Logger.Error(ex, "Error scanning for devices:");
                    devices.Clear();
                }
                finally
                {
                    // Clean up the unmanaged memory allocations and free resources held by the windows API
                    if (detailDataBuffer != IntPtr.Zero) Marshal.FreeHGlobal(detailDataBuffer);
                    if (deviceInfoSet != IntPtr.Zero) SetupApi.SetupDiDestroyDeviceInfoList(deviceInfoSet);
                }

                var addedDevices = devices.Except(_CurrentDevices);
                var removedDevices = _CurrentDevices.Except(devices);

                _CurrentDevices = devices;

                if (DeviceRemoved != null)
                {
                    foreach (var dev in removedDevices)
                    {
                        _Logger.Info("Device removed: {0}", dev);
                        DeviceRemoved(this, new DeviceEventArgs(dev.Instance));
                    }
                }
                if (DeviceAdded != null)
                {
                    foreach (var dev in addedDevices)
                    {
                        _Logger.Info("Device added: {0}", dev);
                        DeviceAdded(this, new DeviceEventArgs(dev.Instance));
                    }
                }

                #endregion

                #region Active device I/O

                // If we receive a request to change the active device while we are processing messages, we need to stop immediately because they are about to become invalid
                {
                    byte[] msg;
                    while (true)
                    {
                        byte[] response = null;

                        // Block until SetActiveDevice finishes
                        lock (_LockObject)
                        {
                            // If we created a new message queue in the call to SetActiveDevice, this will return false and we'll break out of the loop
                            if (_ActiveDevice == null || !_MessageQueue.TryDequeue(out msg)) break;
                            try
                            {
                                response = SendDeviceRequest(_ActiveDevice, msg);
                            }
                            catch (Exception ex)
                            {
                                _Logger.Error(ex, "Error communicating with device: {0} (0x{1:X8})", ex.Message, ex.HResult);
                            }
                        }

                        if (response != null)
                        {
                            ProcessResponse(msg, response);
                        }
                        else
                        {
                            _Logger.Error("Failed to read data from device. req = {0}", FormatByteArray(msg));
                        }
                    }
                }

                // Get LED config (it may have changed)
                {
                    byte[] response = null;
                    byte[] msg = CreateSimpleMessage(hid_pkt_req.HID_PKT_REQ_CONFIG_LED_GET);

                    // Block until SetActiveDevice finishes
                    lock (_LockObject)
                    {
                        if (_ActiveDevice != null)
                        {
                            try
                            {
                                response = SendDeviceRequest(_ActiveDevice, msg);
                            }
                            catch (Exception ex)
                            {
                                _Logger.Error(ex, "Error communicating with device: {0} (0x{1:X8})", ex.Message, ex.HResult);
                            }
                        }
                    }

                    if (response != null)
                    {
                        ProcessResponse(msg, response);
                    }
                }

                // Get LED status
                {
                    byte[] response = null;
                    byte[] msg = new byte[2];
                    msg[0] = (byte)hid_pkt_req.HID_PKT_REQ_LED_STATUS;
                    msg[1] = 0;

                    var ledStatuses = new List<LedColor>();

                    do
                    {
                        lock (_LockObject)
                        {
                            if (_ActiveDevice != null)
                            {
                                try
                                {
                                    response = SendDeviceRequest(_ActiveDevice, msg);
                                }
                                catch (Exception ex)
                                {
                                    _Logger.Error(ex, "Error communicating with device: {0} (0x{1:X8})", ex.Message, ex.HResult);
                                }
                            }
                        }

                        if (response != null)
                        {
                            // Parse response
                            for (byte i = 0; i < response[1] && i < 10; i++)
                            {
                                var led = new LedColor(
                                    response[i * 3 + 2],
                                    response[i * 3 + 3],
                                    response[i * 3 + 4]
                                );
                                ledStatuses.Add(led);
                            }

                            msg[1] += 10;
                        }
                    } while (response != null && response[0] == (byte)hid_pkt_res.HID_PKT_RES_MORE);

                    LedStatusReceived?.Invoke(this, new LedStatusReceivedEventArgs(ledStatuses));
                }

                #endregion

                // Wait until the entire loop execution is at least 100ms
                var loopTime = DateTime.Now - loopStart;
                if (loopTime < LOOP_DELAY)
                {
                    var waitTime = LOOP_DELAY - loopTime;
                    Thread.Sleep(waitTime);
                }
            }
        }

        private byte[] SendDeviceRequest(UsbDevice device, byte[] request)
        {
            if (_ActiveOpenDevice == null || _ActiveOpenDevice.IsDisposed) return null;

            byte[] buffer = new byte[33];
            Array.Copy(request, 0, buffer, 1, Math.Min(32, request.Length));

            _ActiveOpenDevice.Write(buffer);
            return _ActiveOpenDevice.Read(32);
        }

        private void ProcessResponse(byte[] req, byte[] res)
        {
            if (res[0] != (byte)hid_pkt_res.HID_PKT_RES_ERR)
            {
                switch ((hid_pkt_req)req[0])
                {
                    case hid_pkt_req.HID_PKT_REQ_CONFIG_KEY_GET:
                        {
                            var keyConfig = new KeyConfig((KeyPressAction)res[1], res[2], res[3]);
                            KeyConfigReceived?.Invoke(this, new KeyConfigReceivedEventArgs(keyConfig));
                        }
                        break;
                    case hid_pkt_req.HID_PKT_REQ_CONFIG_LED_GET:
                        {
                            byte[] raw = new byte[31];
                            Array.Copy(res, 1, raw, 0, 31);
                            var ledConfig = new LedConfig(raw);
                            if (!ledConfig.Equals(_CurrentLedConfig))
                            {
                                _CurrentLedConfig = ledConfig;
                                LedConfigReceived?.Invoke(this, new LedConfigReceivedEventArgs(ledConfig));
                            }
                        }
                        break;
                    case hid_pkt_req.HID_PKT_REQ_LED_COUNT:
                        DeviceReady?.Invoke(this, new DeviceReadyEventArgs(_ActiveDevice.Instance, res[1]));
                        break;
                }
            }
            else
            {
                _Logger.Error("Device responded with error condition: req = {0} request data = {1}", (hid_pkt_req)req[0], FormatByteArray(req.Skip(1)));
            }
        }

        private byte[] CreateSimpleMessage(hid_pkt_req req)
        {
            return new byte[] { (byte)req };
        }

        private string FormatByteArray(IEnumerable<byte> bytes)
        {
            return string.Join(" ", bytes.Select(d => string.Format("{0:X2}", d)));
        }

        private Device FindDeviceClass(ushort vid, ushort pid, ushort rev, ushort usagePage)
        {
            return _DeviceConfig.Devices.FirstOrDefault(d => d.PID == pid && d.VID == vid && d.Revision == rev && d.UsagePage == usagePage);
        }

        private enum hid_pkt_req : byte
        {
            HID_PKT_REQ_PING,
            HID_PKT_REQ_CONFIG_KEY_SET,
            HID_PKT_REQ_CONFIG_KEY_GET,
            HID_PKT_REQ_CONFIG_LED_SET,
            HID_PKT_REQ_CONFIG_LED_GET,
            HID_PKT_REQ_LED_SET_ALL,
            HID_PKT_REQ_LED_SET_ONE,
            HID_PKT_REQ_LED_COUNT,
            HID_PKT_REQ_LED_STATUS,
            HID_PKT_REQ_COMMIT_LED_CONFIG
        }

        private enum hid_pkt_res : byte
        {
            HID_PKT_RES_ACK,
            HID_PKT_RES_ERR,
            HID_PKT_RES_MORE,
        }

        private class UsbDevice : IEquatable<UsbDevice>
        {
            public DeviceInstance Instance { get; }
            public HidpCaps Capabilities { get; }

            public UsbDevice(DeviceInstance instance, HidpCaps caps)
            {
                Instance = instance;
                Capabilities = caps;
            }

            public IOpenDevice Open()
            {
                return new OpenDevice(Instance.Path, Capabilities.InputReportByteLength, Capabilities.OutputReportByteLength);
            }

            public bool Equals(UsbDevice other)
            {
                return other != null && other.Instance == Instance;
            }

            public override string ToString()
            {
                return Instance.ToString();
            }

            public override bool Equals(object obj)
            {
                var other = obj as UsbDevice;
                return Equals(other);
            }

            public override int GetHashCode()
            {
                return Instance.GetHashCode();
            }

            public static bool operator ==(UsbDevice a, UsbDevice b)
            {
                if (ReferenceEquals(a, b)) return true;
                if (ReferenceEquals(a, null)) return false;
                if (ReferenceEquals(b, null)) return false;
                return a.Equals(b);
            }

            public static bool operator !=(UsbDevice a, UsbDevice b)
            {
                return !(a == b);
            }

            private class OpenDevice : IOpenDevice
            {
                private SafeFileHandle _HidHandle;
                private SafeFileHandle _ReadHandle;
                private SafeFileHandle _WriteHandle;

                private int _InputReportSize;
                private int _OutputReportSize;

                public bool IsDisposed { get; private set; } = false;

                public OpenDevice(string path, int inputReportSize, int outputReportSize)
                {
                    _InputReportSize = inputReportSize;
                    _OutputReportSize = outputReportSize;
                    _HidHandle = Kernel32.CreateFile(path, 0, Constants.FileShareRead | Constants.FileShareWrite, IntPtr.Zero, Constants.OpenExisting, 0, 0);
                    _ReadHandle = Kernel32.CreateFile(path, Constants.GenericRead, Constants.FileShareRead | Constants.FileShareWrite, IntPtr.Zero, Constants.OpenExisting, Constants.FileFlagOverlapped, 0);
                    _WriteHandle = Kernel32.CreateFile(path, Constants.GenericWrite, Constants.FileShareRead | Constants.FileShareWrite, IntPtr.Zero, Constants.OpenExisting, 0, 0);
                }

                public byte[] Read(uint toRead)
                {
                    if (IsDisposed) throw new ObjectDisposedException("");
                    if (toRead > 1024) throw new ArgumentOutOfRangeException("toRead must be at most 1024 bytes");

                    var eventObject = IntPtr.Zero;
                    var nonManagedBuffer = IntPtr.Zero;
                    var nonManagedOverlapped = IntPtr.Zero;
                    var hidOverlapped = new NativeOverlapped();
                    int read = 0;

                    try
                    {
                        // Prepare an event object for the overlapped ReadFile
                        eventObject = Kernel32.CreateEvent(IntPtr.Zero, true, false, "");

                        hidOverlapped.OffsetLow = 0;
                        hidOverlapped.OffsetHigh = 0;
                        hidOverlapped.EventHandle = eventObject;

                        // Allocate memory for the unmanaged input buffer and overlap structure.
                        nonManagedBuffer = Marshal.AllocHGlobal(_InputReportSize);
                        nonManagedOverlapped = Marshal.AllocHGlobal(Marshal.SizeOf(hidOverlapped));
                        Marshal.StructureToPtr(hidOverlapped, nonManagedOverlapped, false);

                        if (!Kernel32.ReadFile(_ReadHandle, nonManagedBuffer, _InputReportSize, ref read, nonManagedOverlapped))
                        {
                            int errorCode = Marshal.GetLastWin32Error();
                            if (errorCode != Constants.ERROR_IO_PENDING)
                            {
                                Kernel32.CancelIo(_ReadHandle);
                                Dispose(true);
                                return null;
                            }

                            // We are now waiting for the FileRead to complete
                            // Wait a maximum of 3 seconds for the FileRead to complete
                            var result = Kernel32.WaitForSingleObject(eventObject, 3000);

                            switch (result)
                            {
                                case Constants.WaitObject0:
                                    Kernel32.GetOverlappedResult(_ReadHandle, nonManagedOverlapped, ref read, false);
                                    Kernel32.ResetEvent(eventObject);
                                    break;
                                case Constants.WaitTimeout:
                                default:
                                    Kernel32.CancelIo(_ReadHandle);
                                    Dispose(true);
                                    return null;
                            }
                        }
                        // Report receieved correctly, copy the unmanaged input buffer over to the managed buffer
                        byte[] buffer = new byte[read];
                        Marshal.Copy(nonManagedBuffer, buffer, 0, read);

                        // Skip report ID (we don't use it)
                        return buffer.Skip(1).Take((int)toRead).ToArray();
                    }
                    finally
                    {
                        // Release non-managed objects before returning
                        Marshal.FreeHGlobal(nonManagedBuffer);
                        Marshal.FreeHGlobal(nonManagedOverlapped);

                        // Close the file handle to release the object
                        Kernel32.CloseHandle(eventObject);
                    }
                }

                public uint Write(byte[] toWrite)
                {
                    if (IsDisposed) throw new ObjectDisposedException("");
                    if (toWrite.Length > _OutputReportSize) throw new ArgumentOutOfRangeException($"Data is larger than the device report size. {toWrite.Length} > {_OutputReportSize}");
                    int written = 0;
                    if (!Kernel32.WriteFile(_WriteHandle, toWrite, toWrite.Length, ref written, IntPtr.Zero))
                    {
                        int errorCode = Marshal.GetLastWin32Error();
                        throw new Win32Exception("Failed to write data to device.", errorCode);
                    }

                    return (uint)written;
                }

                private void Dispose(bool disposing)
                {
                    if (!IsDisposed)
                    {
                        // Free native resources
                        _HidHandle.Close();
                        _ReadHandle.Close();
                        _WriteHandle.Close();

                        IsDisposed = true;
                    }
                }

                public void Dispose()
                {
                    if (IsDisposed) throw new ObjectDisposedException("");
                    Dispose(true);
                    GC.SuppressFinalize(this);
                }

                ~OpenDevice()
                {
                    Dispose(false);
                }
            }
        }

        internal interface IOpenDevice : IDisposable
        {
            bool IsDisposed { get; }

            byte[] Read(uint toRead);
            uint Write(byte[] toWrite);
        }
    }

    internal class DeviceEventArgs : EventArgs
    {
        public DeviceEventArgs(DeviceInstance device)
        {
            Device = device;
        }

        public DeviceInstance Device { get; }
    }

    internal class DeviceReadyEventArgs : DeviceEventArgs
    {
        public DeviceReadyEventArgs(DeviceInstance device, int deviceReportedLedCount) : base(device)
        {
            DeviceReportedLedCount = deviceReportedLedCount;
        }

        public int DeviceReportedLedCount { get; }
    }

    internal class LedConfigReceivedEventArgs : EventArgs
    {
        public LedConfigReceivedEventArgs(LedConfig ledConfig)
        {
            LedConfig = ledConfig;
        }

        public LedConfig LedConfig { get; }
    }

    internal class KeyConfigReceivedEventArgs : EventArgs
    {
        public KeyConfigReceivedEventArgs(KeyConfig keyConfig)
        {
            KeyConfig = keyConfig;
        }

        public KeyConfig KeyConfig { get; }
    }

    internal class LedStatusReceivedEventArgs : EventArgs
    {
        public LedStatusReceivedEventArgs(List<LedColor> ledStatus)
        {
            LedStatus = ledStatus;
        }

        public IReadOnlyList<LedColor> LedStatus { get; }
    }
}
