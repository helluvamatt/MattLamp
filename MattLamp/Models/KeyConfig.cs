namespace MattLamp.Models
{
    internal class KeyConfig
    {
        public KeyConfig(KeyPressAction action, KeyCombo combo)
        {
            Action = action;
            Param1 = combo?.KeyCode ?? 0;
            Param2 = (byte)(combo?.Modifier ?? 0);
        }

        public KeyConfig(KeyPressAction action, byte parm1, byte parm2 = 0)
        {
            Action = action;
            Param1 = parm1;
            Param2 = parm2;
        }

        public KeyPressAction Action { get; }
        public byte Param1 { get; }
        public byte Param2 { get; }

        public KeyCombo CreateKeyCombo()
        {
            if (Action == KeyPressAction.KeyCombo)
            {
                return new KeyCombo(Param1, (Modifiers)Param2);
            }
            return null;
        }
    }

    internal enum KeyPressAction : byte
    {
        None = 0,
        LedStep = 1,
        KeyCombo = 2,
        LedSet = 3,
        LedToggle = 4
    }
}
