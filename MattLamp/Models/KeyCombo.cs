using System;
using System.Linq;
using System.Collections.Generic;
using MattLamp.Properties;

namespace MattLamp.Models
{
    /// <summary>
    /// Single object type for passing a key combination
    /// </summary>
    public class KeyCombo
    {
        public byte KeyCode { get; set; }
        public Modifiers Modifier { get; set; }

        public KeyCombo() { }

        public KeyCombo(byte keyCode, Modifiers modifier)
        {
            KeyCode = keyCode;
            Modifier = modifier;
        }

        public override string ToString()
        {
            var strs = new List<string>();
            if (Modifier.HasFlag(Modifiers.LCTRL) || Modifier.HasFlag(Modifiers.RCTRL)) strs.Add(Resources.Ctrl);
            if (Modifier.HasFlag(Modifiers.LSHIFT) || Modifier.HasFlag(Modifiers.RSHIFT)) strs.Add(Resources.Shift);
            if (Modifier.HasFlag(Modifiers.LALT) || Modifier.HasFlag(Modifiers.RALT)) strs.Add(Resources.Alt);
            if (Modifier.HasFlag(Modifiers.LGUI) || Modifier.HasFlag(Modifiers.RGUI)) strs.Add(Resources.Win);
            strs.Add(QuantumKeyTable.KeyCodeToString(KeyCode));
            return string.Join(" + ", strs);
        }
    }

    /// <summary>
    /// The enumeration of possible modifiers.
    /// </summary>
    [Flags]
    public enum Modifiers : byte
    {
        LCTRL = 1,
        LSHIFT = 2,
        LALT = 4,
        LGUI = 8,
        RCTRL = 16,
        RSHIFT = 32,
        RALT = 64,
        RGUI = 128
    }

    public class Key
    {
        public Key(byte keyCode, string name)
        {
            KeyCode = keyCode;
            Name = name;
        }

        public byte KeyCode { get; }

        public string Name { get; }

        public override bool Equals(object obj)
        {
            var other = obj as Key;
            return other != null && other.KeyCode == KeyCode;
        }

        public override int GetHashCode()
        {
            return KeyCode;
        }
    }

    /// <summary>
    /// Quantum key table from qmk_firmware: keycode.h
    /// 
    /// Some codes have been omitted
    /// </summary>
    public static class QuantumKeyTable
    {
        private static readonly Dictionary<byte, string> _keyTable = new Dictionary<byte, string>
        {
            { 0x00, "None" },
            { 0x04, "A" },
            { 0x05, "B" },
            { 0x06, "C" },
            { 0x07, "D" },
            { 0x08, "E" },
            { 0x09, "F" },
            { 0x0A, "G" },
            { 0x0B, "H" },
            { 0x0C, "I" },
            { 0x0D, "J" },
            { 0x0E, "K" },
            { 0x0F, "L" },
            { 0x10, "M" },
            { 0x11, "N" },
            { 0x12, "O" },
            { 0x13, "P" },
            { 0x14, "Q" },
            { 0x15, "R" },
            { 0x16, "S" },
            { 0x17, "T" },
            { 0x18, "U" },
            { 0x19, "V" },
            { 0x1A, "W" },
            { 0x1B, "X" },
            { 0x1C, "Y" },
            { 0x1D, "Z" },
            { 0x1E, "1" },
            { 0x1F, "2" },
            { 0x20, "3" },
            { 0x21, "4" },
            { 0x22, "5" },
            { 0x23, "6" },
            { 0x24, "7" },
            { 0x25, "8" },
            { 0x26, "9" },
            { 0x27, "0" },
            { 0x28, "ENTER" },
            { 0x29, "ESCAPE" },
            { 0x2A, "BACKSPACE" },
            { 0x2B, "TAB" },
            { 0x2C, "SPACE" },
            { 0x2D, "-" },
            { 0x2E, "=" },
            { 0x2F, "[" },
            { 0x30, "]" },
            { 0x31, "\\" },
            { 0x32, "#" },
            { 0x33, ";" },
            { 0x34, "'" },
            { 0x35, "GRAVE" },
            { 0x36, "," },
            { 0x37, "." },
            { 0x38, "/" },
            { 0x39, "CAPSLOCK" },
            { 0x3A, "F1" },
            { 0x3B, "F2" },
            { 0x3C, "F3" },
            { 0x3D, "F4" },
            { 0x3E, "F5" },
            { 0x3F, "F6" },
            { 0x40, "F7" },
            { 0x41, "F8" },
            { 0x42, "F9" },
            { 0x43, "F10" },
            { 0x44, "F11" },
            { 0x45, "F12" },
            { 0x46, "PSCREEN" },
            { 0x47, "SCROLLLOCK" },
            { 0x48, "PAUSE" },
            { 0x49, "INSERT" },
            { 0x4A, "HOME" },
            { 0x4B, "PG UP" },
            { 0x4C, "DELETE" },
            { 0x4D, "END" },
            { 0x4E, "PG DOWN" },
            { 0x4F, "RIGHT" },
            { 0x50, "LEFT" },
            { 0x51, "DOWN" },
            { 0x52, "UP" },
            { 0x53, "NUM LOCK" },
            { 0x54, "/" },
            { 0x55, "*" },
            { 0x56, "-" },
            { 0x57, "+" },
            { 0x58, "ENTER" },
            { 0x59, "1" },
            { 0x5A, "2" },
            { 0x5B, "3" },
            { 0x5C, "4" },
            { 0x5D, "5" },
            { 0x5E, "6" },
            { 0x5F, "7" },
            { 0x60, "8" },
            { 0x61, "9" },
            { 0x62, "0" },
            { 0x63, "." },
            { 0x64, "\\" },
            { 0x65, "APPLICATION" },
            { 0x66, "POWER" },
            { 0x67, "=" },
            { 0x68, "F13" },
            { 0x69, "F14" },
            { 0x6A, "F15" },
            { 0x6B, "F16" },
            { 0x6C, "F17" },
            { 0x6D, "F18" },
            { 0x6E, "F19" },
            { 0x6F, "F20" },
            { 0x70, "F21" },
            { 0x71, "F22" },
            { 0x72, "F23" },
            { 0x73, "F24" },
            { 0x74, "EXECUTE" },
            { 0x75, "HELP" },
            { 0x76, "MENU" },
            { 0x77, "SELECT" },
            { 0x78, "STOP" },
            { 0x79, "AGAIN" },
            { 0x7A, "UNDO" },
            { 0x7B, "CUT" },
            { 0x7C, "COPY" },
            { 0x7D, "PASTE" },
            { 0x7E, "FIND" },
            { 0x7F, "MUTE" },
            { 0x80, "VOL UP" },
            { 0x81, "VOL DOWN" },
            { 0x85, "," },
            { 0x86, "=" },
            { 0xA5, "SYSTEM POWER" },
            { 0xA6, "SYSTEM SLEEP" },
            { 0xA7, "SYSTEM WAKE" },
            { 0xA8, "MUTE" },
            { 0xA9, "VOL UP" },
            { 0xAA, "VOL DOWN" },
            { 0xAB, "NEXT" },
            { 0xAC, "PREV" },
            { 0xAD, "STOP" },
            { 0xAE, "PLAY/PAUSE" },
            { 0xAF, "SELECT" },
            { 0xB0, "EJECT" },
            { 0xB1, "MAIL" },
            { 0xB2, "CALCULATOR" },
            { 0xB3, "MY COMPUTER" },
            { 0xB4, "WWW SEARCH" },
            { 0xB5, "WWW HOME" },
            { 0xB6, "WWW BACK" },
            { 0xB7, "WWW FORWARD" },
            { 0xB8, "WWW STOP" },
            { 0xB9, "WWW REFRESH" },
            { 0xBA, "WWW FAVORITES" },
            { 0xBB, "FAST FORWARD" },
            { 0xBC, "REWIND" },
            { 0xC0, "FN0 " },
            { 0xC1, "FN1," },
            { 0xC2, "FN2," },
            { 0xC3, "FN3," },
            { 0xC4, "FN4," },
            { 0xC5, "FN5," },
            { 0xC6, "FN6," },
            { 0xC7, "FN7," },
            { 0xC8, "FN8," },
            { 0xC9, "FN9," },
            { 0xCA, "FN10" },
            { 0xCB, "FN11" },
            { 0xCC, "FN12" },
            { 0xCD, "FN13" },
            { 0xCE, "FN14" },
            { 0xCF, "FN15" },
            { 0xD0, "FN16" },
            { 0xD1, "FN17" },
            { 0xD2, "FN18" },
            { 0xD3, "FN19" },
            { 0xD4, "FN20" },
            { 0xD5, "FN21" },
            { 0xD6, "FN22" },
            { 0xD7, "FN23" },
            { 0xD8, "FN24" },
            { 0xD9, "FN25" },
            { 0xDA, "FN26" },
            { 0xDB, "FN27" },
            { 0xDC, "FN28" },
            { 0xDD, "FN29" },
            { 0xDE, "FN30" },
            { 0xDF, "FN31" },
            { 0xE0, "Left Control" },
            { 0xE1, "Left Shift" },
            { 0xE2, "Left Alt" },
            { 0xE3, "Left Win" },
            { 0xE4, "Right Control" },
            { 0xE5, "Right Shift" },
            { 0xE6, "Right Alt" },
            { 0xE7, "Right Win" },
        };

        public static IEnumerable<Key> GetKeys()
        {
            return _keyTable.Select(kvp => new Key(kvp.Key, kvp.Value)).OrderBy(k => k.KeyCode);
        }

        public static Key GetKey(byte keyCode)
        {
            if (_keyTable.ContainsKey(keyCode)) return new Key(keyCode, _keyTable[keyCode]);
            return null;
        }

        public static string KeyCodeToString(byte keyCode)
        {
            return _keyTable.ContainsKey(keyCode) ? _keyTable[keyCode] : string.Format("0x{0:X2}", keyCode);
        }
    }
}
