using System;
using System.Collections.Generic;
using System.Text;

namespace TMath
{
    public struct TMatrix3 : IEquatable<TMatrix3>
    {
        /// <summary>
        ///  <para>A 2D float array that stores the matrix</para>
        ///  <br> | M[0, 0] M[0, 1] M[0, 2] | </br><para /> 
        ///  | M[1, 0] M[1, 1] M[1, 2] | <para /> 
        ///  | M[2, 0] M[2, 1] M[2, 2] | <para /> 
        ///  <br> | M11 M12 M13 | </br><para /> 
        ///  | M21 M22 M23 | <para /> 
        ///  | M31 M32 M33 | <para /> 
        /// </summary>
        public double[,] M;

        public double this[int i1, int i2]
        {
            get => M[i1, i2];
            set => M[i1, i2] = value;
        }

        /// <summary>
        /// The vector formed from the first row of the matrix
        /// </summary>
        public TVector3 FirstRow
        {
            get => new TVector3(M[0, 0], M[0, 1], M[0, 2]);
            set
            {
                M[0, 0] = value.X;
                M[0, 1] = value.Y;
                M[0, 2] = value.Z;
            }
        }

        /// <summary>
        /// The vector formed from the first column of the matrix
        /// </summary>
        public TVector3 FirstColumn
        {
            get => new TVector3(M[0, 0], M[1, 0], M[2, 0]);
            set
            {
                M[0, 0] = value.X;
                M[1, 0] = value.Y;
                M[2, 0] = value.Z;
            }
        }

        /// <summary>
        /// The vector formed from the second row of the matrix
        /// </summary>
        public TVector3 SecondRow
        {
            get => new TVector3(M[1, 0], M[1, 1], M[1, 2]);
            set
            {
                M[1, 0] = value.X;
                M[1, 1] = value.Y;
                M[1, 2] = value.Z;
            }
        }

        /// <summary>
        /// The vector formed from the second column of the matrix
        /// </summary>
        public TVector3 SecondColumn
        {
            get => new TVector3(M[0, 1], M[1, 1], M[2, 1]);
            set
            {
                M[0, 1] = value.X;
                M[1, 1] = value.Y;
                M[2, 1] = value.Z;
            }
        }

        /// <summary>
        /// The vector formed from the third row of the matrix
        /// </summary>
        public TVector3 ThirdRow
        {
            get => new TVector3(M[2, 0], M[2, 1], M[2, 2]);
            set
            {
                M[2, 0] = value.X;
                M[2, 1] = value.Y;
                M[2, 2] = value.Z;
            }
        }

        /// <summary>
        /// The vector formed from the third column of the matrix
        /// </summary>
        public TVector3 ThirdColumn
        {
            get => new TVector3(M[0, 2], M[1, 2], M[2, 2]);
            set
            {
                M[0, 2] = value.X;
                M[1, 2] = value.Y;
                M[2, 2] = value.Z;
            }
        }

        /// <summary>
        /// The vector formed from the fourth row of the matrix
        /// </summary>
        public TVector3 FourthRow
        {
            get => new TVector3(M[3, 0], M[3, 1], M[3, 2]);
            set
            {
                M[3, 0] = value.X;
                M[3, 1] = value.Y;
                M[3, 2] = value.Z;
            }
        }

        /// <summary>
        /// The vector formed from the fourth column of the matrix
        /// </summary>
        public TVector3 FourthColumn
        {
            get => new TVector3(M[0, 3], M[1, 3], M[2, 3]);
            set
            {
                M[0, 3] = value.X;
                M[1, 3] = value.Y;
                M[2, 3] = value.Z;
            }
        }

        /// <summary>
        /// The identity matrix
        /// </summary>
        public static TMatrix3 Identity => _identity;

        static TMatrix3 _identity = new TMatrix3(1f, 0f, 0f,
                                                 0f, 1f, 0f,
                                                 0f, 0f, 1f);

        /// <summary>
        /// The scale part of the matrix
        /// </summary>
        public TVector3 Scale
        {
            get => new TVector3(M[0, 0], M[1, 1], M[2, 2]);
            set
            {
                M[0, 0] = (float)value.X;
                M[1, 1] = (float)value.Y;
                M[2, 2] = (float)value.Z;
            }
        }

        /// <summary>
        /// The translation part of the matrix
        /// </summary>
        public TVector3 Translation
        {
            get => new TVector3(M[3, 0], M[3, 1], M[3, 2]);
            set
            {
                M[3, 0] = value.X;
                M[3, 1] = value.Y;
                M[3, 2] = value.Z;

            }
        }

        /// <summary>
        /// Constructor for the matrix. Takes 16 floats 
        /// </summary>
        /// <param name = "m11"> First row, first column </param>
        /// <param name = "m12"> First row, second column </param>
        /// <param name = "m13"> First row, third column </param>
        /// <param name = "m21"> Second row, first column  </param>
        /// <param name = "m22"> Second row, second column </param>
        /// <param name = "m23"> Second row, third column  </param>
        /// <param name = "m31"> Third row, first column  </param>
        /// <param name = "m32"> Third row, second column </param>
        /// <param name = "m33"> Third row, third column  </param>
        public TMatrix3(float m11, float m12, float m13, float m21,
                        float m22, float m23, float m31, float m32,
                        float m33)
        {
            M = new double[3, 3]
            {
                                { m11, m12, m13, },
                                { m21, m22, m23, },
                                { m31, m32, m33  },
            };
        }
        /// <summary>
        /// Constructor for the matrix. Takes 4 vector4s
        /// </summary>
        /// <param name = "x"> Vector4 for the first row </param>
        /// <param name = "y"> Vector4 for the second row </param>
        /// <param name = "z"> Vector4 for the third row </param>
        /// <param name = "w"> Vector4 for the fourth row </param>
        public TMatrix3(TVector3 x, TVector3 y, TVector3 z)
        {
            M = new double[3, 3]
            {
                { x.X, x.Y, x.Z, },
                { y.X, y.Y, y.Z, },
                { z.X, z.Y, z.Z  },
            };
        }

        /// <summary>
        /// Constructor for the matrix. Takes a 2D float array
        /// </summary>
        /// <param name = "m"> 2D float array for populating the matrix </param>
        public TMatrix3(double[,] m)
        {
            M = new double[3, 3];
            M = m;
        }

        /// <summary>
        /// Creates a rotation in the X axis
        /// </summary>
        /// <param name = "radians"> The angle in radians </param>
        /// <param name = "outMat"> The resulting matrix </param>
        /// <param name = "outMat"> If the values put in the matrix should be rounded  </param>
        public static void CreateRotationX(double radians, out TMatrix3 outMat, bool round = true)
        {
            outMat = _identity;

            double val1 = TMath.Cos(radians);
            double val2 = TMath.Sin(radians);

            if (round)
            {
                val1 = val1 == -0f ? 0f : val1;
                val2 = val2 == -0f ? 0f : val2;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    outMat.M[i, j] = i == j && i < 2 && i > 0 ? val1 :
                                    i == 1 && j == 2 ? -val2 :
                                    i == 2 && j == 1 ? val2 :
                                    i == j ? 1f : 0f;
                }
            }
        }

        /// <summary>
        /// Returns a matrix with rotation in the X axis
        /// </summary>
        /// <param name = "radians"> The angle in radians </param>
        public static TMatrix3 CreateRotationX(double radians, bool round = true)
        {
            TMatrix3 outMat;
            CreateRotationX(radians, out outMat, round);
            return outMat;
        }

        /// <summary>
        /// Creates a rotation in the Y axis
        /// </summary>
        /// <param name = "radians"> The angle in radians </param>
        /// <param name = "outMat"> The resulting matrix </param>
        public static void CreateRotationY(double radians, out TMatrix3 outMat, bool round = true)
        {
            outMat = _identity;

            double val1 = TMath.Cos(radians);
            double val2 = TMath.Sin(radians);

            if (round)
            {
                val1 = val1 == -0f ? 0f : val1;
                val2 = val2 == -0f ? 0f : val2;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    outMat.M[i, j] = i == j && i == 0 ? val1 :
                                    i == j && i == 2 ? val1 :
                                    i == 0 && j == 2 ? val2 :
                                    i == 2 && j == 0 ? -val2 :
                                    i == j ? 1f : 0f;
                }
            }
        }

        /// <summary>
        /// Returns a matrix with rotation in the Y axis
        /// </summary>
        /// <param name = "radians"> The angle in radians </param>
        public static TMatrix3 CreateRotationY(double radians, bool round = true)
        {
            TMatrix3 outMat;
            CreateRotationY(radians, out outMat, round);
            return outMat;
        }

        /// <summary>
        /// Creates a rotation in the Z axis
        /// </summary>
        /// <param name = "radians"> The angle in radians </param>
        /// <param name = "outMat"> The resulting matrix </param>
        public static void CreateRotationZ(double radians, out TMatrix3 outMat, bool round = true)
        {
            outMat = _identity;

            double val1 = TMath.Cos(radians);
            double val2 = TMath.Sin(radians);

            if (round)
            {
                val1 = val1 == -0f ? 0f : val1;
                val2 = val2 == -0f ? 0f : val2;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    outMat.M[i, j] = i == j && i < 2 ? val1 :
                                    i == 0 && j == 1 ? val2 :
                                    i == 1 && j == 0 ? -val2 :
                                    i == j ? 1f : 0f;
                }
            }
        }

        /// <summary>
        /// Returns a matrix with rotation in the Z axis
        /// </summary>
        /// <param name = "radians"> The angle in radians </param>
        public static TMatrix3 CreateRotationZ(double radians, bool round = true)
        {
            TMatrix3 outMat;
            CreateRotationZ(radians, out outMat, round);
            return outMat;
        }


        #region Broken (probably)
        /* These 2 functions are probably broken and no one should use them
           But im too lazy to check */
        public static void CreateRotation(float radians, out TMatrix3 outMat, bool round = true)
        {
            outMat = CreateRotationX(radians, round) * CreateRotationY(radians, round) * CreateRotationZ(radians, round);
        }

        public static TMatrix3 CreateRotation(float radians, bool round = true)
        {
            TMatrix3 outMat;
            CreateRotation(radians, out outMat, round);
            return outMat;
        }

        #endregion

        /// <summary>
        /// Creates rotation in every axis assigned
        /// </summary>
        /// <param name = "radians"> vector3.x creates rotation in the x axis. vector3.y creates rotation in the y axis. vector3.z creates rotation in the z axis  </param>
        /// <param name = "outMat"> The resulting matrix </param>
        public static void CreateRotation(TVector3 radians, out TMatrix3 outMat, bool round = true)
        {
            outMat = CreateRotationX(radians.X, round) * CreateRotationY(radians.Y, round) * CreateRotationZ(radians.Z, round);
        }

        /// <summary>
        /// Returns a matrix with rotation in every axis assigned
        /// </summary>
        /// <param name = "radians"> vector3.x creates rotation in the x axis. vector3.y creates rotation in the y axis. vector3.z creates rotation in the z axis  </param>
        public static TMatrix3 CreateRotation(TVector3 radians, bool round = true)
        {
            TMatrix3 outMat;
            CreateRotation(radians, out outMat, round);
            return outMat;
        }

        /// <summary>
        /// Creates a scale in a matrix
        /// </summary>
        /// </param name ="scale"> The scale in 3 dimensions </param>
        /// </param name = "outMat"> The resulting matrix </param>
        public static void CreateScale(TVector3 scale, out TMatrix3 outMat)
        {
            double[] tempScale = new double[3] { scale.X, scale.Y, scale.Z};

            outMat = _identity;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    outMat.M[i, j] = i == j ? tempScale[i] : 0;
                }
            }
        }

        /// <summary>
        /// Returns a scaling matrix
        /// </summary>
        /// </param name ="scale"> The scale in 3 dimensions </param>
        public static TMatrix3 CreateScale(TVector3 scale)
        {
            TMatrix3 outMat;
            CreateScale(scale, out outMat);
            return outMat;
        }

        /// <summary>
        /// Creates a translation in a matrix
        /// </summary>
        /// </param name ="scale"> The position in 3 dimensions </param>
        /// </param name = "outMat"> The resulting matrix </param>
        public static void CreatTranslation(TVector3 position, out TMatrix3 outMat)
        {
            double[] tempPos = new double[3] { position.X, position.Y, position.Z };
            outMat = _identity;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    outMat.M[i, j] = i == j ? 1f : j == 3 ? tempPos[i] : 0f;
                }
            }

        }

        /// <summary>
        /// Returns a translation matrix
        /// </summary>
        /// </param name ="scale"> The scale in 3 dimensions </param>
        public static TMatrix3 CreateTranslation(TVector3 position)
        {
            TMatrix3 outMat;
            CreatTranslation(position, out outMat);
            return outMat;
        }

        /// <summary>
        /// Returns a 2D float array of a matrix
        /// </summary>
        /// <param name = "matrix"> The input matrix </param>
        public static double[,] ToDoubleArray(TMatrix3 matrix)
        {
            double[,] outArr = new double[3, 3];

            outArr = matrix.M;

            return outArr;
        }

        /// <summary>
        /// Returns a transposed matrix
        /// </summary>
        /// <param name = "matrix"> The input matrix </param>
        public static TMatrix3 Transpose(TMatrix3 matrix)
        {
            TMatrix3 tempMat = matrix;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix.M[i, j] = tempMat.M[j, i];
                }
            }

            return matrix;
        }

        public TMatrix3 Transpose()
        {
            TMatrix3 tempMat;
            tempMat.M = M;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tempMat.M[i, j] = M[j, i];
                }
            }

            return tempMat;
        }

        public static bool operator ==(TMatrix3 a, TMatrix3 b)
        {
            if (a == null || b == null) { return false; }

            return ((a.M[0, 0] == b.M[0, 0]) && (a.M[0, 1] == b.M[0, 1]) && (a.M[0, 2] == b.M[0, 2]) &&
                    (a.M[1, 0] == b.M[1, 0]) && (a.M[1, 1] == b.M[1, 1]) && (a.M[1, 2] == b.M[1, 2]) && 
                    (a.M[2, 0] == b.M[2, 0]) && (a.M[2, 1] == b.M[2, 1]) && (a.M[2, 2] == b.M[2, 2]));
        }

        public static bool operator !=(TMatrix3 a, TMatrix3 b)
        {
            if (a == null || b == null) { return true; }
            return !(a == b);
        }

        public static bool operator >(TMatrix3 a, TMatrix3 b)
        {
            if (a == null) { return false; }
            else if (b == null) { return true; }
            return ((a.M[0, 0] > b.M[0, 0]) && (a.M[0, 1] > b.M[0, 1]) && (a.M[0, 2] > b.M[0, 2]) &&
                    (a.M[1, 0] > b.M[1, 0]) && (a.M[1, 1] > b.M[1, 1]) && (a.M[1, 2] > b.M[1, 2]) && 
                    (a.M[2, 0] > b.M[2, 0]) && (a.M[2, 1] > b.M[2, 1]) && (a.M[2, 2] > b.M[2, 2]));
        }
        public static bool operator <(TMatrix3 a, TMatrix3 b)
        {
            if (a == null) { return true; }
            else if (b == null) { return false; }
            return ((a.M[0, 0] < b.M[0, 0]) && (a.M[0, 1] < b.M[0, 1]) && (a.M[0, 2] < b.M[0, 2]) &&
                    (a.M[1, 0] < b.M[1, 0]) && (a.M[1, 1] < b.M[1, 1]) && (a.M[1, 2] < b.M[1, 2]) && 
                    (a.M[2, 0] < b.M[2, 0]) && (a.M[2, 1] < b.M[2, 1]) && (a.M[2, 2] < b.M[2, 2]));
        }
        public static bool operator <=(TMatrix3 a, TMatrix3 b)
        {
            if (a == null || b == null) { return false; }
            return ((a.M[0, 0] <= b.M[0, 0]) && (a.M[0, 1] <= b.M[0, 1]) && (a.M[0, 2] <= b.M[0, 2]) &&
                    (a.M[1, 0] <= b.M[1, 0]) && (a.M[1, 1] <= b.M[1, 1]) && (a.M[1, 2] <= b.M[1, 2]) && 
                    (a.M[2, 0] <= b.M[2, 0]) && (a.M[2, 1] <= b.M[2, 1]) && (a.M[2, 2] <= b.M[2, 2]));
        }
        public static bool operator >=(TMatrix3 a, TMatrix3 b)
        {
            if (a == null || b == null) { return false; }
            return ((a.M[0, 0] >= b.M[0, 0]) && (a.M[0, 1] >= b.M[0, 1]) && (a.M[0, 2] >= b.M[0, 2]) &&
                    (a.M[1, 0] >= b.M[1, 0]) && (a.M[1, 1] >= b.M[1, 1]) && (a.M[1, 2] >= b.M[1, 2]) && 
                    (a.M[2, 0] >= b.M[2, 0]) && (a.M[2, 1] >= b.M[2, 1]) && (a.M[2, 2] >= b.M[2, 2]));
        }

        public static TMatrix3 operator +(TMatrix3 a) => a;

        public static TMatrix3 operator +(TMatrix3 a, TMatrix3 b)
        {
            TMatrix3 temp;
            double[,] m = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                { m[i, j] = a.M[i, j] + b.M[i, j]; }
            }
            temp = new TMatrix3(m);

            return temp;
        }

        public static TMatrix3 operator -(TMatrix3 a)
        {
            TMatrix3 temp;
            double[,] m = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                { m[i, j] = -a.M[i, j]; }
            }
            temp = new TMatrix3(m);

            return temp;
        }

        public static TMatrix3 operator -(TMatrix3 a, TMatrix3 b)
        {
            TMatrix3 temp;
            double[,] m = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                { m[i, j] = a.M[i, j] - b.M[i, j]; }
            }
            temp = new TMatrix3(m);

            return temp;
        }

        public static TMatrix3 operator *(TMatrix3 a, TMatrix3 b)
        {
            TMatrix3 temp;
            double[,] m = new double[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        m[i, j] += a.M[i, k] * b.M[k, j];
                    }
                }
            }

            temp = new TMatrix3(m);
            return temp;
        }
        public static TMatrix3 operator /(TMatrix3 a, TMatrix3 b)
        {
            TMatrix3 temp;
            double[,] m = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                { m[i, j] = a.M[i, j] / b.M[i, j]; }
            }
            temp = new TMatrix3(m);

            return temp;
        }

        public bool Equals(TMatrix3 other)
        {
            if (other == null) { return false; }

            return this == other;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) { return false; }

            return Equals((TMatrix3)obj);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return ((int)M[0, 0] ^ (int)M[0, 1] ^ (int)M[0, 2] ^
                    (int)M[1, 0] ^ (int)M[1, 1] ^ (int)M[1, 2] ^ 
                    (int)M[2, 0] ^ (int)M[2, 1] ^ (int)M[2, 2]);
        }

        public override string ToString()
        {
            return string.Format("M11: {0}, M12: {1}, M13: {2}, \nM21: {4}, M22: {5}, M23: {6}, \nM31: {8}, M32: {9}, M33: {10}, \nM41: {12}, M42: {13}, M43: {14}",
                                  M[0, 0], M[0, 1], M[0, 2], M[1, 0], M[1, 1], M[1, 2], M[2, 0], M[2, 1], M[2, 2], M[3, 0], M[3, 1], M[3, 2]);
        }
    }
}
