using System;

namespace TMath
{
    [Serializable]
    public struct TVector3 : IEquatable<TVector3>
    {
        public float X;
        public float Y;
        public float Z;

        public readonly float magnitude;

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return X;
                    case 1:
                        return Y;
                    case 2:
                        return Z;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        X = value;
                        break;
                    case 1:
                        Y = value;
                        break;
                    case 2:
                        Z = value;
                        break;
                    default:
                        break;
                }
            }
        }

        public TVector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;

            magnitude = MathF.Sqrt(MathF.Pow(X, 2) * MathF.Pow(Y, 2) * MathF.Pow(Z, 2));
        }

        public TVector3(int x, int y, int z)
        {
            X = (int)x;
            Y = (int)y;
            Z = (int)z;

            magnitude = MathF.Sqrt(MathF.Pow(X, 2) * MathF.Pow(Y, 2) * MathF.Pow(Z, 2));
        }

        public TVector3(float value) 
        {
            X = value;
            Y = value;
            Z = value;

            magnitude = MathF.Sqrt(MathF.Pow(X, 2) * MathF.Pow(Y, 2) * MathF.Pow(Z, 2));
        }

        public TVector3(int value) 
        {
            X = (int)value;
            Y = (int)value;
            Z = (int)value;

            magnitude = MathF.Sqrt(MathF.Pow(X, 2) * MathF.Pow(Y, 2) * MathF.Pow(Z, 2));
        }

        public static TVector3 Zero = new TVector3(0, 0, 0);
        public static TVector3 One = new TVector3(1, 1, 1);
        
        public static TVector3 Up = new TVector3(0, 1, 0);
        public static TVector3 Down = new TVector3(0, -1, 0);
        public static TVector3 Left = new TVector3(-1, 0, 0);
        public static TVector3 Right = new TVector3(1, 0, 0);

        public static float Dot(in TVector3 a, in TVector3 b) => (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);
        public static TVector3 Cross(in TVector3 a, in TVector3 b) 
        {
            float x, y, z;
            x = a.Y * b.Z - b.Y * a.Z;
            y = (a.X * b.Z - b.X * a.Z) * -1;
            z = a.X * b.Y - b.X * a.Y;
            return new TVector3(x, y, z);
        }

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
