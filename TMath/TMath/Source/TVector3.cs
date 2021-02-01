using System;

namespace TMath
{
    [Serializable]
    public struct TVector3 : IEquatable<TVector3>
    {
        public float X;
        public float Y;
        public float Z;

        public TVector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public TVector3(int x, int y, int z)
        {
            X = (int)x;
            Y = (int)y;
            Z = (int)z;
        }

        public static TVector3 Zero = new TVector3(0, 0, 0);
        public static TVector3 One = new TVector3(1, 1, 1);
        
        public static TVector3 Up = new TVector3(0, 1, 0);
        public static TVector3 Down = new TVector3(0, -1, 0);
        public static TVector3 Left = new TVector3(-1, 0, 0);
        public static TVector3 Right = new TVector3(1, 0, 0);

        public static float Dot(in TVector3 a, in TVector3 b) => (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);

        public static bool operator ==(TVector3 a, TVector3 b) => ((a.X == b.X) && (a.Y == b.Y) && (a.Z == b.Z));

        public static bool operator !=(TVector3 a, TVector3 b) => !(a == b);

        public static TVector3 operator +(TVector3 a) => a;
        public static TVector3 operator +(TVector3 a, TVector3 b) => new TVector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static TVector3 operator -(TVector3 a) => new TVector3(-a.X, -a.Y, -a.Z);
        public static TVector3 operator -(TVector3 a, TVector3 b) => new TVector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static TVector3 operator *(TVector3 a, TVector3 b) => new TVector3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        public static TVector3 operator /(TVector3 a, TVector3 b) => new TVector3(a.X / b.X, a.Y / b.Y, a.Z / b.Z);

        public bool Equals(TVector3 other)
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

            return Equals((TVector3)obj);
        }


        // override object.GetHashCode
        public override int GetHashCode() => ((int)X ^ (int)Y ^ (int)Z);

        public override string ToString() => string.Format("X {0}, Y {1}, Z {2}", X, Y, Z);
    }
}
