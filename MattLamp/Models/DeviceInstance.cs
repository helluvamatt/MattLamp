using System;
using MattLamp.Config;

namespace MattLamp.Models
{
    internal class DeviceInstance : IEquatable<DeviceInstance>
    {
        public DeviceInstance(Device deviceClass, string path, string manufacturer, string product, string serial)
        {
            Path = path;
            DeviceClass = deviceClass;
            Manufacturer = manufacturer;
            Product = product;
            Serial = serial;
        }

        public string Path { get; }
        public Device DeviceClass { get; }
        public string Manufacturer { get; }
        public string Product { get; }
        public string Serial { get; }

        public override int GetHashCode()
        {
            return Path.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as DeviceInstance;
            return Equals(other);
        }

        public bool Equals(DeviceInstance other)
        {
            return other != null && other.Path == Path;
        }

        public static bool operator ==(DeviceInstance a, DeviceInstance b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (ReferenceEquals(a, null)) return false;
            if (ReferenceEquals(b, null)) return false;
            return a.Path == b.Path;
        }

        public static bool operator !=(DeviceInstance a, DeviceInstance b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} ({2:X4}:{3:X4}:{4:X4}) #{5}", Manufacturer, Product, DeviceClass.VID, DeviceClass.PID, DeviceClass.Revision, Serial);
        }
    }
}
