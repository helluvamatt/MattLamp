namespace MattLamp.Models
{
    internal class LedStatus : BaseNotifyModel
    {
        public int X { get; }

        public int Y { get; }

        public int Size { get; }

        public LedStatus(int x, int y, int size)
        {
            X = x;
            Y = y;
            Size = size;
        }

        private LedColor _Color;
        public LedColor Color
        {
            get
            {
                return _Color;
            }
            set
            {
                ChangeAndNotify(ref _Color, value, () => Color);
            }
        }
    }
}
