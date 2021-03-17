using System;
using System.Collections.Generic;
using System.Text;

namespace TMath
{
    [Serializable]
    public struct TVector4 : IEquatable<TVector4>
    {
        public double X;
        public double Y;
        public double Z;
        public double W;

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

        public TVector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public TVector4(int x, int y, int z, int w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public TVector4(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static TVector4 Zero = new TVector4(0, 0, 0, 0);
        public static TVector4 One = new TVector4(1, 1, 1, 1);

        public static TVector4 Up = new TVector4(0, 1, 0, 1);
        public static TVector4 Down = new TVector4(0, -1, 0, 1);
        public static TVector4 Left = new TVector4(-1, 0, 0, 1);
        public static TVector4 Right = new TVector4(1, 0, 0, 1);

        public static double Dot(in TVector4 a, in TVector4 b) => (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z) + (a.W * b.W);

        public static TVector4 Multiply(TVector4 vec, TMatrix4 mat)
        {
            TVector4 dest = new TVector4();
            dest.X = TMath.FMA(mat[0, 0], vec.X, TMath.FMA(mat[1, 0], vec.Y, TMath.FMA(mat[2, 0], vec.Z, mat[3, 0] * vec.W)));
            dest.Y = TMath.FMA(mat[0, 1], vec.X, TMath.FMA(mat[1, 1], vec.Y, TMath.FMA(mat[2, 1], vec.Z, mat[3, 1] * vec.W)));
            dest.Z = TMath.FMA(mat[0, 2], vec.X, TMath.FMA(mat[1, 2], vec.Y, TMath.FMA(mat[2, 2], vec.Z, mat[3, 2] * vec.W)));
            dest.W = TMath.FMA(mat[0, 3], vec.X, TMath.FMA(mat[1, 3], vec.Y, TMath.FMA(mat[2, 3], vec.Z, mat[3, 3] * vec.W)));

            return dest;
        }

        public static TVector4 Multiply(TVector4 vec1, TVector4 vec2) => new TVector4(vec1.X * vec2.X, vec1.Y * vec2.Y, vec1.Z * vec2.Z, vec1.W * vec2.W);
        public static TVector4 Multiply(TVector4 vec1, double scalar) => new TVector4(vec1.X * scalar, vec1.Y * scalar, vec1.Z * scalar, vec1.W * scalar);
        public static TVector4 Multiply(TVector4 vec1, float scalar) => new TVector4(vec1.X * scalar, vec1.Y * scalar, vec1.Z * scalar, vec1.W * scalar);
        public static TVector4 Multiply(TVector4 vec1, int scalar) => new TVector4(vec1.X * scalar, vec1.Y * scalar, vec1.Z * scalar, vec1.W * scalar);

        public static TVector4 Add(TVector4 vec1, TVector4 vec2) => new TVector4(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z, vec1.W + vec2.W);

        public static TVector4 Subtract(TVector4 vec1, TVector4 vec2) => new TVector4(vec1.X - vec2.X, vec1.Y - vec2.Y, vec1.Z - vec2.Z, vec1.W - vec2.W);

        public static TVector4 Negate(TVector4 vec) => new TVector4(-vec.X, -vec.Y, -vec.Z, -vec.W);

        public static TVector4 Divide(TVector4 vec1, TVector4 vec2) => new TVector4(vec1.X / vec2.X, vec1.Y / vec2.Y, vec1.Z / vec2.Z, vec1.W / vec2.W);
        public static TVector4 Divide(TVector4 vec1, double scalar) => new TVector4(vec1.X / scalar, vec1.Y / scalar, vec1.Z / scalar, vec1.W / scalar);
        public static TVector4 Divide(TVector4 vec1, float scalar) => new TVector4(vec1.X / scalar, vec1.Y / scalar, vec1.Z / scalar, vec1.W / scalar);
        public static TVector4 Divide(TVector4 vec1, int scalar) => new TVector4(vec1.X / scalar, vec1.Y / scalar, vec1.Z / scalar, vec1.W / scalar);

        public static bool operator ==(TVector4 a, TVector4 b) => ((a.X == b.X) && (a.Y == b.Y) && (a.Z == b.Z) && (a.W == b.W));

        public static bool operator !=(TVector4 a, TVector4 b) => !(a == b);

        public static TVector4 operator +(TVector4 a) => a;
        public static TVector4 operator +(TVector4 a, TVector4 b) => Add(a, b);
        
        public static TVector4 operator -(TVector4 a) => Negate(a);
        public static TVector4 operator -(TVector4 a, TVector4 b) => Subtract(a, b);
        
        public static TVector4 operator *(TVector4 a, TMatrix4 b) => Multiply(a, b);
        public static TVector4 operator *(TVector4 a, TVector4 b) => Multiply(a, b);
        public static TVector4 operator *(TVector4 a, double b) => Multiply(a, b);
        public static TVector4 operator *(TVector4 a, float b) => Multiply(a, b);
        public static TVector4 operator *(TVector4 a, int b) => Multiply(a, b);

        public static TVector4 operator /(TVector4 a, int b) => Divide(a, b);
        public static TVector4 operator /(TVector4 a, float b) => Divide(a, b);
        public static TVector4 operator /(TVector4 a, double b) => Divide(a, b);
        public static TVector4 operator /(TVector4 a, TVector4 b) => Divide(a, b);

        public bool Equals(TVector4 other)
        {
            if (other == null)
                return false;
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return Equals((TVector4)obj);
        }

        public override int GetHashCode() => ((int)X ^ (int)Y ^ (int)Z ^ (int)W);

        public override string ToString() => string.Format("X {0}, Y {1}, Z {2}, W{3}", X, Y, Z, W);
    }
}
