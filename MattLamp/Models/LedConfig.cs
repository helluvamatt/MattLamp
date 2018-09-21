using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MattLamp.Models
{
    internal class LedConfig
    {
        public byte Mode { get; }

        public byte ColorLen { get; }

        public Color[] Colors { get; }

        public uint Timeout1 { get; }

        public ushort Timeout2 { get; }

        public LedConfig(byte[] unmanaged)
        {
            if (unmanaged.Length != 31) throw new ArgumentException("Data length is invalid.");
            Mode = (byte)((uint)unmanaged[0] & 0xF);
            ColorLen = Math.Min((byte)8, (byte)(((uint)unmanaged[0] & 0xF0) >> 4));
            Colors = new Color[ColorLen];
            for (byte i = 0; i < ColorLen; i++)
            {
                // Struct on device is in this order: GRB
                Colors[i] = Color.FromArgb(
                    unmanaged[2 + i * 3],
                    unmanaged[1 + i * 3],
                    unmanaged[3 + i * 3]);
            }
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(unmanaged, 25, 4);
                Array.Reverse(unmanaged, 29, 2);
            }
            Timeout1 = BitConverter.ToUInt32(unmanaged, 25);
            Timeout2 = BitConverter.ToUInt16(unmanaged, 29);
        }

        public LedConfig(byte mode, Color[] colors, uint timeout1, ushort timeout2)
        {
            if (mode > (LedEffectMode.Modes.Count() - 1)) throw new ArgumentOutOfRangeException("mode");
            if (colors.Length > 8) throw new ArgumentOutOfRangeException("colors");
            Mode = mode;
            ColorLen = (byte)colors.Length;
            Colors = colors;
            Timeout1 = timeout1;
            Timeout2 = timeout2;
        }

        public byte[] ToUnmanaged()
        {
            byte[] unmanaged = new byte[31];
            unmanaged[0] = (byte)((((uint)Mode & 0xF)) + ((((uint)(ColorLen & 0xF)) << 4)));
            for (byte i = 0; i < 8; i++)
            {
                if (i < ColorLen)
                {
                    // Struct on device is in this order: GRB
                    unmanaged[1 + i * 3] = Colors[i].G;
                    unmanaged[2 + i * 3] = Colors[i].R;
                    unmanaged[3 + i * 3] = Colors[i].B;
                }
                else
                {
                    unmanaged[1 + i * 3] = unmanaged[2 + i * 3] = unmanaged[3 + i * 3] = 0;
                }
            }
            byte[] timeout1 = BitConverter.GetBytes(Timeout1);
            byte[] timeout2 = BitConverter.GetBytes(Timeout2);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(timeout1);
                Array.Reverse(timeout2);
            }
            Array.Copy(timeout1, 0, unmanaged, 25, 4);
            Array.Copy(timeout2, 0, unmanaged, 29, 2);
            return unmanaged;
        }

        public override bool Equals(object obj)
        {
            var other = obj as LedConfig;
            return other != null && ByteArrayEquals(ToUnmanaged(), other.ToUnmanaged());
        }

        public override int GetHashCode()
        {
            return ToUnmanaged().GetHashCode();
        }

        private static bool ByteArrayEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) return false;
            }
            return true;
        }
    }
}
