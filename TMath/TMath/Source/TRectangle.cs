using System;

namespace TMath
{
    public enum Edge
    {
        Top,
        Left,
        Bottom,
        Right
    }

    [Serializable]
    public struct TRectangle : IEquatable<TRectangle>
    {
        private static TRectangle m_EmptyRectangle = new TRectangle();

        public float X;
        public float Y;

        public float Width;
        public float Height;

        public TVector2 Position
        {
            get => new TVector2(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public TVector2 Scale
        {
            get => new TVector2(Width, Height);
            set
            {
                Width = value.X;
                Height = value.Y;
            }
        }

        public TRectangle(int x, int y, int width, int height)
        {
            X = (int)x;
            Y = (int)y;
            Width = (int)width;
            Height = (int)height;
        }

        public TRectangle(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public float Top => Y;
        public float Bottom => (Y + Height);

        public float Left => X;
        public float Right => (X + Width);

        public float GetEdge(Edge edge)
        {
            switch (edge)
            {
                case Edge.Top:
                    return Top;
                case Edge.Left:
                    return Left;
                case Edge.Bottom:
                    return Bottom;
                case Edge.Right:
                    return Right;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public TRectangle Empty => m_EmptyRectangle;

        public bool Contains(TVector2 other) => ((X <= other.X) && (other.X < (X + Width)) && ((Y <= other.Y) && (other.Y < (Y + Width))));

        public bool Contains(TRectangle other) => ((X <= other.X) && ((other.X + other.Width) < (X + Width)) && (Y <= other.Y) && ((other.Y + other.Height) < (Y + Height)));

        public bool Contains(TPoint other) => ((X <= other.X) && (other.X < (X + Width)) && ((Y <= other.Y) && (other.Y <= (Y + Height))));

        public bool Intersects(TRectangle other)
        {
            return other.Left < Right &&
                    Left < other.Right &&
                    other.Top < Bottom &&
                    Top < other.Bottom;
        }

        public static bool operator ==(TRectangle a, TRectangle b) => ((a.X == b.X) && (a.Y == b.Y) && (a.Width == b.Width) && (a.Height == b.Height));

        public static bool operator !=(TRectangle a, TRectangle b) => !(a == b);

        public static TRectangle operator +(TRectangle a) => a;
        public static TRectangle operator +(TRectangle a, TRectangle b) => new TRectangle(a.X + b.X, a.Y + b.Y, a.Width + b.Width, a.Height + b.Height);
        public static TRectangle operator -(TRectangle a) => new TRectangle(-a.X, -a.Y, -a.Width, -a.Height);
        public static TRectangle operator -(TRectangle a, TRectangle b) => new TRectangle(a.X - b.X, a.Y - b.Y, a.Width - b.Width, a.Height - b.Height);
        public static TRectangle operator *(TRectangle a, TRectangle b) => new TRectangle(a.X * b.X, a.Y * b.Y, a.Width * b.Width, a.Height * b.Height);
        public static TRectangle operator /(TRectangle a, TRectangle b) => new TRectangle(a.X / b.X, a.Y / b.Y, a.Width / b.Width, a.Height / b.Height);

        public bool Equals(TRectangle other)
        {
            if (other == null) 
                return false;

            return this == other;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) 
                return false;

            return Equals((TRectangle)obj);
        }

        // override object.GetHashCode
        public override int GetHashCode() => ((int)X ^ (int)Y ^ (int)Width ^ (int)Height);

        public override string ToString() => string.Format("X {0}, Y {1}, Width {2}, Height {3}", X, Y, Width, Height);

    }
}
