using System;

namespace TMath
{
    public struct TPoint : IEquatable<TPoint>
    {
        public float X;
        public float Y;

        public TPoint(float x, float y)
        {
            X = x;
            Y = y;
        }

        public TPoint(int x, int y)
        {
            X = (int)x;
            Y = (int)y;
        }

        public TPoint(int value)
        {
            X = (int)value;
            Y = (int)value;
        }

        public TVector2 ToVector2() => new TVector2(X, Y);

        public static bool operator ==(TPoint a, TPoint b) => ((a.X == b.X) && (a.Y == b.Y)); 

        public static bool operator !=(TPoint a, TPoint b) => !(a == b); 

        public bool Equals(TPoint other)
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

            return Equals((TPoint)obj);
        }

        // override object.GetHashCode
        public override int GetHashCode() => ((int)X ^ (int)Y);

        public override string ToString() => string.Format("X {0}, Y {1}", X, Y); 
    }
}
