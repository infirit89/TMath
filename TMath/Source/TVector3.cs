using System;

namespace TMath
{
    [Serializable]
    public struct TVector3 : IEquatable<TVector3>
    {
        public double X;
        public double Y;
        public double Z;

        public readonly double Magnitude 
        {
            get => TMath.Sqrt(X * X + Y * Y + Z * Z);
        }
        

        public double this[int index]
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
        }

        public TVector3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public TVector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static TVector3 Zero = new TVector3(0, 0, 0);
        public static TVector3 One = new TVector3(1, 1, 1);
        
        public static TVector3 Up = new TVector3(0, 1, 0);
        public static TVector3 Down = new TVector3(0, -1, 0);
        public static TVector3 Left = new TVector3(-1, 0, 0);
        public static TVector3 Right = new TVector3(1, 0, 0);

        public static TVector3 Multiply(TVector3 vec, TMatrix3 mat) 
        {
            TVector3 dest = new TVector3();
            dest.X = TMath.FMA(mat[0, 0], vec.X, TMath.FMA(mat[1, 0], vec.Y, mat[2, 0] * vec.Z));
            dest.Y = TMath.FMA(mat[0, 1], vec.X, TMath.FMA(mat[1, 1], vec.Y, mat[2, 1] * vec.Z));
            dest.Z = TMath.FMA(mat[0, 2], vec.X, TMath.FMA(mat[1, 2], vec.Y, mat[2, 2] * vec.Z));

            return dest;    
        }

        public static TVector3 Multiply(TVector3 vec1, TVector3 vec2) => new TVector3(vec1.X * vec2.X, vec1.Y * vec2.Y, vec1.Z * vec2.Z);
        public static TVector3 Multiply(TVector3 vec1, double scalar) => new TVector3(vec1.X * scalar, vec1.Y * scalar, vec1.Z * scalar);
        public static TVector3 Multiply(TVector3 vec1, float scalar) => new TVector3(vec1.X * scalar, vec1.Y * scalar, vec1.Z * scalar);
        public static TVector3 Multiply(TVector3 vec1, int scalar) => new TVector3(vec1.X * scalar, vec1.Y * scalar, vec1.Z * scalar);


        public static TVector3 Add(TVector3 vec1, TVector3 vec2) => new TVector3(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z);
        public static TVector3 Subtract(TVector3 vec1, TVector3 vec2) => new TVector3(vec1.X - vec2.X, vec1.Y - vec2.Y, vec1.Z - vec2.Z);

        public static TVector3 Negate(TVector3 vec) => new TVector3(-vec.X, -vec.Y, -vec.Z);

        public static TVector3 Divide(TVector3 vec1, TVector3 vec2) => new TVector3(vec1.X / vec2.X, vec1.Y / vec2.Y, vec1.Z / vec2.Z);
        public static TVector3 Divide(TVector3 vec1, double scalar) => new TVector3(vec1.X / scalar, vec1.Y / scalar, vec1.Z / scalar);
        public static TVector3 Divide(TVector3 vec1, float scalar) => new TVector3(vec1.X / scalar, vec1.Y / scalar, vec1.Z / scalar);
        public static TVector3 Divide(TVector3 vec1, int scalar) => new TVector3(vec1.X / scalar, vec1.Y / scalar, vec1.Z / scalar);

        public static double Dot(in TVector3 a, in TVector3 b) => (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);
        public static TVector3 Cross(in TVector3 a, in TVector3 b) 
        {
            double x, y, z;
            x = a.Y * b.Z - b.Y * a.Z;
            y = (a.X * b.Z - b.X * a.Z) * -1;
            z = a.X * b.Y - b.X * a.Y;
            return new TVector3(x, y, z);
        }

        public static bool operator ==(TVector3 a, TVector3 b) => ((a.X == b.X) && (a.Y == b.Y) && (a.Z == b.Z));

        public static bool operator !=(TVector3 a, TVector3 b) => !(a == b);

        public static TVector3 operator +(TVector3 a) => a;
        public static TVector3 operator +(TVector3 a, TVector3 b) => Add(a, b);
        
        public static TVector3 operator -(TVector3 a) => Negate(a);
        public static TVector3 operator -(TVector3 a, TVector3 b) => Subtract(a, b);

        public static TVector3 operator *(TVector3 a, TMatrix3 b) => Multiply(a, b);
        public static TVector3 operator *(TVector3 a, TVector3 b) => Multiply(a, b);
        public static TVector3 operator *(TVector3 a, int b) => Multiply(a, b);
        public static TVector3 operator *(TVector3 a, float b) => Multiply(a, b);
        public static TVector3 operator *(TVector3 a, double b) => Multiply(a, b); 

        public static TVector3 operator /(TVector3 a, double b) => Divide(a, b);
        public static TVector3 operator /(TVector3 a, float b) => Divide(a, b);
        public static TVector3 operator /(TVector3 a, int b) => Divide(a, b);
        public static TVector3 operator /(TVector3 a, TVector3 b) => Divide(a, b);

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
