using System;

namespace TMath
{
    [Serializable]
    public struct TVector2 : IEquatable<TVector2>
    {
        public double X;
        public double Y;

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
                    default:
                        break;
                }
            }
        }

        public readonly double Magnitude 
        {
            get => TMath.Sqrt(X * X + Y * Y);
        }
        public TVector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public TVector2(int x, int y)
        {

            X = x;
            Y = y;

        }

        public TVector2(double x, double y) 
        {
            X = x;
            Y = y;
        } 

        public static TVector2 Zero = new TVector2(0, 0);
        public static TVector2 One = new TVector2(1, 1);

        public static TVector2 Up = new TVector2(0, 1);
        public static TVector2 Down = new TVector2(0, -1);
        public static TVector2 Left = new TVector2(-1, 0);
        public static TVector2 Right = new TVector2(1, 0);
        public static double Dot(in TVector2 a, in TVector2 b) => (a.X * b.X) + (a.Y * b.Y);
        public void Set(int x, int y)
        { X = x; Y = y; }

        public void Set(float x, float y)
        { X = x; Y = y; }

        public void Set(double x, double y)
        { X = x; Y = y; }

        public static TVector2 Add(TVector2 vec1, TVector2 vec2) => new TVector2(vec1.X + vec2.X, vec1.Y + vec2.Y);
        public static TVector2 Subtract(TVector2 vec1, TVector2 vec2) => new TVector2(vec1.X - vec2.X, vec1.Y - vec2.Y);

        public static TVector2 Multiply(TVector2 vec1, TVector2 vec2) => new TVector2(vec1.X * vec2.X, vec1.Y * vec2.Y);
        public static TVector2 Multiply(TVector2 vec1, double scalar) => new TVector2(vec1.X * scalar, vec1.Y * scalar);
        public static TVector2 Multiply(TVector2 vec1, float scalar) => new TVector2(vec1.X * scalar, vec1.Y * scalar);
        public static TVector2 Multiply(TVector2 vec1, int scalar) => new TVector2(vec1.X * scalar, vec1.Y * scalar);

        public static TVector2 Divide(TVector2 vec1, TVector2 vec2) => new TVector2(vec1.X / vec2.X, vec1.Y / vec2.Y);
        public static TVector2 Divide(TVector2 vec1, double scalar) => new TVector2(vec1.X / scalar, vec1.Y / scalar);
        public static TVector2 Divide(TVector2 vec1, float scalar) => new TVector2(vec1.X / scalar, vec1.Y / scalar);
        public static TVector2 Divide(TVector2 vec1, int scalar) => new TVector2(vec1.X / scalar, vec1.Y / scalar);


        public static bool operator ==(TVector2 a, TVector2 b) => ((a.X == b.X) && (a.Y == b.Y));

        public static bool operator !=(TVector2 a, TVector2 b) => !(a == b);

        public static TVector2 operator +(TVector2 a) => a;
        public static TVector2 operator +(TVector2 a, TVector2 b) => Add(a, b);

        public static TVector2 operator -(TVector2 a) => new TVector2(-a.X, -a.Y);
        public static TVector2 operator -(TVector2 a, TVector2 b) => Subtract(a, b);

        public static TVector2 operator *(TVector2 a, TVector2 b) => Multiply(a, b);
        public static TVector2 operator *(TVector2 a, double b) => Multiply(a, b);
        public static TVector2 operator *(TVector2 a, float b) => Multiply(a, b);
        public static TVector2 operator *(TVector2 a, int b) => Multiply(a, b);

        public static TVector2 operator /(TVector2 a, double b) => Divide(a, b);
        public static TVector2 operator /(TVector2 a, float b) => Divide(a, b);
        public static TVector2 operator /(TVector2 a, int b) => Divide(a, b);
        public static TVector2 operator /(TVector2 a, TVector2 b) => Divide(a, b);


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
