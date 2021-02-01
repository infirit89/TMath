using System;

namespace TMath
{
    [Serializable]
    public struct TVector2 : IEquatable<TVector2>
    {
        public float X;
        public float Y;
        public TVector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public TVector2(int x, int y)
        {
            X = (int)x;
            Y = (int)y;
        }

        public TVector2(int value) 
        {
            X = value;
            Y = value;
        }

        public TVector2(float value) 
        {
            X = value;
            Y = value;
        }

        public static float Dot(in TVector2 a, in TVector2 b) => (a.X * b.X) + (a.Y + b.Y);

        public static TVector2 Zero = new TVector2(0, 0);
        public static TVector2 One = new TVector2(1, 1);
        
        public static TVector2 Up = new TVector2(0, 1);
        public static TVector2 Down = new TVector2(0, -1);
        public static TVector2 Left = new TVector2(-1, 0);
        public static TVector2 Right = new TVector2(1, 0);

        public static bool operator ==(TVector2 a, TVector2 b) => ((a.X == b.X) && (a.Y == b.Y));

        public static bool operator !=(TVector2 a, TVector2 b) => !(a == b);

        public static TVector2 operator +(TVector2 a) => a;
        public static TVector2 operator +(TVector2 a, TVector2 b) => new TVector2(a.X + b.X, a.Y + b.Y);
        public static TVector2 operator -(TVector2 a) => new TVector2(-a.X, -a.Y);
        public static TVector2 operator -(TVector2 a, TVector2 b) => new TVector2(a.X - b.X, a.Y - b.Y);
        public static TVector2 operator *(TVector2 a, TVector2 b) => new TVector2(a.X * b.X, a.Y * b.Y);
        public static TVector2 operator /(TVector2 a, TVector2 b) => new TVector2(a.X / b.X, a.Y / b.Y);

        public bool Equals(TVector2 other)
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

            return Equals((TVector2)obj);
        }


        // override object.GetHashCode
        public override int GetHashCode() => ((int)X ^ (int)Y);

        public override string ToString() => string.Format("X {0}, Y {1}", X, Y);
    }
}
