using System;
using System.Collections.Generic;
using System.Text;

namespace TMath
{
    public struct TMatrix4 : IEquatable<TMatrix4>
    {
        /// <summary>
        ///  <para>A 2D float array that stores the matrix</para>
        ///  <br> | M[0, 0] M[0, 1] M[0, 2] M[0, 3] | </br><para /> 
        ///  | M[1, 0] M[1, 1] M[1, 2] M[1, 3] | <para /> 
        ///  | M[2, 0] M[2, 1] M[2, 2] M[2, 3] | <para /> 
        ///  | M[3, 0] M[3, 1] M[3, 2] M[3, 3] | <para /> 
        ///  <br> | M11 M12 M13 M14 | </br><para /> 
        ///  | M21 M22 M23 M24 | <para /> 
        ///  | M31 M32 M33 M34 | <para /> 
        ///  | M41 M42 M43 M44 | <para /> 
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
        public TVector4 FirstRow
        {
            get => new TVector4(M[0, 0], M[0, 1], M[0, 2], M[0, 3]);
            set
            {
                M[0, 0] = value.X;
                M[0, 1] = value.Y;
                M[0, 2] = value.Z;
                M[0, 3] = value.W;
            }
        }

        /// <summary>
        /// The vector formed from the first column of the matrix
        /// </summary>
        public TVector4 FirstColumn
        {
            get => new TVector4(M[0, 0], M[1, 0], M[2, 0], M[3, 0]);
            set
            {
                M[0, 0] = value.X;
                M[1, 0] = value.Y;
                M[2, 0] = value.Z;
                M[3, 0] = value.W;
            }
        }

        /// <summary>
        /// The vector formed from the second row of the matrix
        /// </summary>
        public TVector4 SecondRow
        {
            get => new TVector4(M[1, 0], M[1, 1], M[1, 2], M[1, 3]);
            set
            {
                M[1, 0] = value.X;
                M[1, 1] = value.Y;
                M[1, 2] = value.Z;
                M[1, 3] = value.W;
            }
        }

        /// <summary>
        /// The vector formed from the second column of the matrix
        /// </summary>
        public TVector4 SecondColumn
        {
            get => new TVector4(M[0, 1], M[1, 1], M[2, 1], M[3, 1]);
            set
            {
                M[0, 1] = value.X;
                M[1, 1] = value.Y;
                M[2, 1] = value.Z;
                M[3, 1] = value.W;
            }
        }

        /// <summary>
        /// The vector formed from the third row of the matrix
        /// </summary>
        public TVector4 ThirdRow
        {
            get => new TVector4(M[2, 0], M[2, 1], M[2, 2], M[2, 3]);
            set
            {
                M[2, 0] = value.X;
                M[2, 1] = value.Y;
                M[2, 2] = value.Z;
                M[2, 3] = value.W;
            }
        }

        /// <summary>
        /// The vector formed from the third column of the matrix
        /// </summary>
        public TVector4 ThirdColumn
        {
            get => new TVector4(M[0, 2], M[1, 2], M[2, 2], M[3, 2]);
            set
            {
                M[0, 2] = value.X;
                M[1, 2] = value.Y;
                M[2, 2] = value.Z;
                M[3, 2] = value.W;
            }
        }

        /// <summary>
        /// The vector formed from the fourth row of the matrix
        /// </summary>
        public TVector4 FourthRow
        {
            get => new TVector4(M[3, 0], M[3, 1], M[3, 2], M[3, 3]);
            set
            {
                M[3, 0] = value.X;
                M[3, 1] = value.Y;
                M[3, 2] = value.Z;
                M[3, 3] = value.W;
            }
        }

        /// <summary>
        /// The vector formed from the fourth column of the matrix
        /// </summary>
        public TVector4 FourthColumn
        {
            get => new TVector4(M[0, 3], M[1, 3], M[2, 3], M[3, 3]);
            set
            {
                M[0, 3] = value.X;
                M[1, 3] = value.Y;
                M[2, 3] = value.Z;
                M[3, 3] = value.W;
            }
        }

        /// <summary>
        /// The identity matrix
        /// </summary>
        public static TMatrix4 Identity => _identity;

        static TMatrix4 _identity = new TMatrix4(1f, 0f, 0f, 0f,
                                                 0f, 1f, 0f, 0f,
                                                 0f, 0f, 1f, 0f,
                                                 0f, 0f, 0f, 1f);

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

        #region  dumb stupid and i hate it

        // public Vector3F Rotation
        // {
        //     get => new Vector3F(M21, M22, M23);
        //     set 
        //     {
        //         M21 = value.X;
        //         M22 = value.Y;
        //         M23 = value.Z;
        //     }
        // }

        #endregion 

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
        /// <param name = "m14"> First row, fourth column </param>
        /// <param name = "m21"> Second row, first column  </param>
        /// <param name = "m22"> Second row, second column </param>
        /// <param name = "m23"> Second row, third column  </param>
        /// <param name = "m24"> Second row, fourth column </param>
        /// <param name = "m31"> Third row, first column  </param>
        /// <param name = "m32"> Third row, second column </param>
        /// <param name = "m33"> Third row, third column  </param>
        /// <param name = "m34"> Third row, fourth column </param>
        /// <param name = "m41"> Fourth row, first column  </param>
        /// <param name = "m42"> Fourth row, second column </param>
        /// <param name = "m43"> Fourth row, third column  </param>
        /// <param name = "m44"> Fourth row, fourth column </param>
        public TMatrix4(float m11, float m12, float m13, float m14, float m21,
                        float m22, float m23, float m24, float m31, float m32,
                        float m33, float m34, float m41, float m42, float m43,
                        float m44)
        {
            M = new double[4, 4]
            {
                                { m11, m12, m13, m14 },
                                { m21, m22, m23, m24 },
                                { m31, m32, m33, m34 },
                                { m41, m42, m43, m44 }
            };
        }
        /// <summary>
        /// Constructor for the matrix. Takes 4 vector4s
        /// </summary>
        /// <param name = "x"> Vector4 for the first row </param>
        /// <param name = "y"> Vector4 for the second row </param>
        /// <param name = "z"> Vector4 for the third row </param>
        /// <param name = "w"> Vector4 for the fourth row </param>
        public TMatrix4(TVector4 x, TVector4 y, TVector4 z, TVector4 w)
        {
            M = new double[4, 4]
            {
                { x.X, x.Y, x.Z, x.W },
                { y.X, y.Y, y.Z, y.W },
                { z.X, z.Y, z.Z, z.W },
                { w.X, w.Y, w.Z, w.W },
            };
        }

        /// <summary>
        /// Constructor for the matrix. Takes a 2D float array
        /// </summary>
        /// <param name = "m"> 2D float array for populating the matrix </param>
        public TMatrix4(double[,] m)
        {
            M = new double[4, 4];
            M = m;
        }

        /// <summary>
        /// Creates a rotation in the X axis
        /// </summary>
        /// <param name = "radians"> The angle in radians </param>
        /// <param name = "outMat"> The resulting matrix </param>
        /// <param name = "outMat"> If the values put in the matrix should be rounded  </param>
        public static void CreateRotationX(double radians, out TMatrix4 outMat, bool round = true)
        {
            outMat = _identity;

            double val1 = TMath.Cos(radians);
            double val2 = TMath.Sin(radians);

            if (round)
            {
                val1 = val1 == -0f ? 0f : val1;
                val2 = val2 == -0f ? 0f : val2;
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    outMat.M[i, j] = i == j && i < 3 && i > 0 ? val1 :
                                    i == 1 && j == 2 ? -val2 :
                                    i == 2 && j == 1 ? val2 :
                                    i == j ? 1f : 0f;
                }
            }

            // outMat.M[0,0] = 1f;
            // outMat.M[0,1] = 0f;
            // outMat.M[0,2] = 0f;
            // outMat.M[0,3] = 0f;

            // outMat.M[1,0] = 0f;
            // outMat.M[1,1] = val1;
            // outMat.M[1,2] = val2;
            // outMat.M[1,3] = 0f;

            // outMat.M[2,0] = 0f;
            // outMat.M[2,1] = -val2;
            // outMat.M[2,2] = val1;
            // outMat.M[2,3] = 0f;

            // outMat.M[3,0] = 0f;
            // outMat.M[3,1] = 0f;
            // outMat.M[3,2] = 0f;
            // outMat.M[3,3] = 1f;
        }

        /// <summary>
        /// Returns a matrix with rotation in the X axis
        /// </summary>
        /// <param name = "radians"> The angle in radians </param>
        public static TMatrix4 CreateRotationX(double radians, bool round = true)
        {
            TMatrix4 outMat;
            CreateRotationX(radians, out outMat, round);
            return outMat;
        }

        /// <summary>
        /// Creates a rotation in the Y axis
        /// </summary>
        /// <param name = "radians"> The angle in radians </param>
        /// <param name = "outMat"> The resulting matrix </param>
        public static void CreateRotationY(double radians, out TMatrix4 outMat, bool round = true)
        {
            outMat = _identity;

            double val1 = TMath.Cos(radians);
            double val2 = TMath.Sin(radians);

            if (round)
            {
                val1 = val1 == -0f ? 0f : val1;
                val2 = val2 == -0f ? 0f : val2;
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    outMat.M[i, j] = i == j && i == 0 ? val1 :
                                    i == j && i == 2 ? val1 :
                                    i == 0 && j == 2 ? val2 :
                                    i == 2 && j == 0 ? -val2 :
                                    i == j ? 1f : 0f;
                }
            }

            // outMat.M[0,0] = val1;
            // outMat.M[0,1] = 0f;
            // outMat.M[0,2] = val2;
            // outMat.M[0,3] = 0f;

            // outMat.M[1,0] = 0f;
            // outMat.M[1,1] = 1f;
            // outMat.M[1,2] = 0f;
            // outMat.M[1,3] = 0f;

            // outMat.M[2,0] = -val2;
            // outMat.M[2,1] = 0f;
            // outMat.M[2,2] = val1;
            // outMat.M[2,3] = 0f;

            // outMat.M[3,0] = 0f;
            // outMat.M[3,1] = 0f;
            // outMat.M[3,2] = 0f;
            // outMat.M[3,3] = 1f;
        }

        /// <summary>
        /// Returns a matrix with rotation in the Y axis
        /// </summary>
        /// <param name = "radians"> The angle in radians </param>
        public static TMatrix4 CreateRotationY(double radians, bool round = true)
        {
            TMatrix4 outMat;
            CreateRotationY(radians, out outMat, round);
            return outMat;
        }

        /// <summary>
        /// Creates a rotation in the Z axis
        /// </summary>
        /// <param name = "radians"> The angle in radians </param>
        /// <param name = "outMat"> The resulting matrix </param>
        public static void CreateRotationZ(double radians, out TMatrix4 outMat, bool round = true)
        {
            outMat = _identity;

            double val1 = TMath.Cos(radians);
            double val2 = TMath.Sin(radians);

            if (round)
            {
                val1 = val1 == -0f ? 0f : val1;
                val2 = val2 == -0f ? 0f : val2;
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    outMat.M[i, j] = i == j && i < 2 ? val1 :
                                    i == 0 && j == 1 ? val2 :
                                    i == 1 && j == 0 ? -val2 :
                                    i == j ? 1f : 0f;
                }
            }

            // outMat.M[0,0] = val1;
            // outMat.M[0,1] = val2;
            // outMat.M[0,2] = 0f;
            // outMat.M[0,3] = 0f;

            // outMat.M[1,0] = -val2;
            // outMat.M[1,1] = val1;
            // outMat.M[1,2] = 0f;
            // outMat.M[1,3] = 0f;

            // outMat.M[2,0] = 0f;
            // outMat.M[2,1] = 0f;
            // outMat.M[2,2] = 1f;
            // outMat.M[2,3] = 0f;

            // outMat.M[3,0] = 0f;
            // outMat.M[3,1] = 0f;
            // outMat.M[3,2] = 0f;
            // outMat.M[3,3] = 1f;
        }

        /// <summary>
        /// Returns a matrix with rotation in the Z axis
        /// </summary>
        /// <param name = "radians"> The angle in radians </param>
        public static TMatrix4 CreateRotationZ(double radians, bool round = true)
        {
            TMatrix4 outMat;
            CreateRotationZ(radians, out outMat, round);
            return outMat;
        }


        #region Broken (probably)
        /* These 2 functions are probably broken and no one should use them
           But im too lazy to check */
        public static void CreateRotation(float radians, out TMatrix4 outMat, bool round = true)
        {
            outMat = CreateRotationX(radians, round) * CreateRotationY(radians, round) * CreateRotationZ(radians, round);
        }

        public static TMatrix4 CreateRotation(float radians, bool round = true)
        {
            TMatrix4 outMat;
            CreateRotation(radians, out outMat, round);
            return outMat;
        }

        #endregion

        /// <summary>
        /// Creates rotation in every axis assigned
        /// </summary>
        /// <param name = "radians"> vector3.x creates rotation in the x axis. vector3.y creates rotation in the y axis. vector3.z creates rotation in the z axis  </param>
        /// <param name = "outMat"> The resulting matrix </param>
        public static void CreateRotation(TVector3 radians, out TMatrix4 outMat, bool round = true)
        {
            outMat = CreateRotationX(radians.X, round) * CreateRotationY(radians.Y, round) * CreateRotationZ(radians.Z, round);
        }

        /// <summary>
        /// Returns a matrix with rotation in every axis assigned
        /// </summary>
        /// <param name = "radians"> vector3.x creates rotation in the x axis. vector3.y creates rotation in the y axis. vector3.z creates rotation in the z axis  </param>
        public static TMatrix4 CreateRotation(TVector3 radians, bool round = true)
        {
            TMatrix4 outMat;
            CreateRotation(radians, out outMat, round);
            return outMat;
        }

        /// <summary>
        /// Creates a scale in a matrix
        /// </summary>
        /// </param name ="scale"> The scale in 3 dimensions </param>
        /// </param name = "outMat"> The resulting matrix </param>
        public static void CreateScale(TVector3 scale, out TMatrix4 outMat)
        {
            double[] tempScale = new double[4] { scale.X, scale.Y, scale.Z, 1f };

            outMat = _identity;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    outMat.M[i, j] = i == j ? tempScale[i] : 0;
                }
            }
            // outMat.M[0,0] = scale.X;
            // outMat.M[0,1] = 0f;
            // outMat.M[0,2] = 0f;
            // outMat.M[0,3] = 0f;

            // outMat.M[1,0] = 0f;
            // outMat.M[1,1] = scale.Y;
            // outMat.M[1,2] = 0f;
            // outMat.M[1,3] = 0f;

            // outMat.M[2,0] = 0f;
            // outMat.M[2,1] = 0f;
            // outMat.M[2,2] = scale.Z;
            // outMat.M[2,3] = 0f;

            // outMat.M[3,0] = 0f;
            // outMat.M[3,1] = 0f;
            // outMat.M[3,2] = 0f;
            // outMat.M[3,3] = 1f;
        }

        /// <summary>
        /// Returns a scaling matrix
        /// </summary>
        /// </param name ="scale"> The scale in 3 dimensions </param>
        public static TMatrix4 CreateScale(TVector3 scale)
        {
            TMatrix4 outMat;
            CreateScale(scale, out outMat);
            return outMat;
        }

        /// <summary>
        /// Creates a translation in a matrix
        /// </summary>
        /// </param name ="scale"> The position in 3 dimensions </param>
        /// </param name = "outMat"> The resulting matrix </param>
        public static void CreatTranslation(TVector3 position, out TMatrix4 outMat)
        {
            double[] tempPos = new double[4] { position.X, position.Y, position.Z, 1f };
            outMat = _identity;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    outMat.M[i, j] = i == j ? 1f : j == 3 ? tempPos[i] : 0f;
                }
            }

            // outMat.M[0,0] = 1f;
            // outMat.M[0,1] = 0f;
            // outMat.M[0,2] = 0f;
            // outMat.M[0,3] = 0f;

            // outMat.M[1,0] = 0f;
            // outMat.M[1,1] = 1f;
            // outMat.M[1,2] = 0f;
            // outMat.M[1,3] = 0f;

            // outMat.M[2,0] = 0f;
            // outMat.M[2,1] = 0f;
            // outMat.M[2,2] = 1f;
            // outMat.M[2,3] = 0f;

            // outMat.M[3,0] = position.X;
            // outMat.M[3,1] = position.Y;
            // outMat.M[3,2] = position.Z;
            // outMat.M[3,3] = 1f;

        }

        /// <summary>
        /// Returns a translation matrix
        /// </summary>
        /// </param name ="scale"> The scale in 3 dimensions </param>
        public static TMatrix4 CreateTranslation(TVector3 position)
        {
            TMatrix4 outMat;
            CreatTranslation(position, out outMat);
            return outMat;
        }

        /// <summary>
        /// Creates an Orthographic projection put in a matrix
        /// </summary>
        /// </param name ="right"> The upper x vallue at the near plane </param>
        /// </param name = "left"> The upper x vallue at the near plane </param>
        /// </param name ="top"> The upper y vallue at the near plane </param>
        /// </param name = "bottom"> The upper y vallue at the near plane</param>
        /// </param name ="far"> The depth of the far plane </param>
        /// </param name = "near"> The depth of the near plane </param>
        /// </param name ="outMat"> The resulting matrix </param>
        public static void CreateOrthographic(float right, float left, float top, float bottom, float far, float near, out TMatrix4 outMat)
        {
            outMat = _identity;
            outMat.M[0, 0] = 2 / (right - left);
            outMat.M[0, 1] = 0f;
            outMat.M[0, 2] = 0f;
            outMat.M[0, 3] = 0f;

            outMat.M[1, 0] = 0f;
            outMat.M[1, 1] = 2 / (top - bottom);
            outMat.M[1, 2] = 0f;
            outMat.M[1, 3] = 0f;

            outMat.M[2, 0] = 0f;
            outMat.M[2, 1] = 0f;
            outMat.M[2, 2] = -2 / (far - near);
            outMat.M[2, 3] = 0f;

            outMat.M[3, 0] = -(right + left) / (right - left);
            outMat.M[3, 1] = -(top + bottom) / (top - bottom);
            outMat.M[3, 2] = -(far + near) / (far - near);
            outMat.M[3, 3] = 1f;
        }

        /// <summary>
        /// Returns an othographic projection matrix
        /// </summary>
        /// </param name ="right"> The upper x vallue at the near plane </param>
        /// </param name = "left"> The upper x vallue at the near plane </param>
        /// </param name ="top"> The upper y vallue at the near plane </param>
        /// </param name = "bottom"> The upper y vallue at the near plane</param>
        /// </param name ="far"> The depth of the far plane </param>
        /// </param name = "near"> The depth of the near plane </param>
        public static TMatrix4 CreateOrthographic(float right, float left, float top, float bottom, float far, float near)
        {
            TMatrix4 outMat;
            CreateOrthographic(right, left, top, bottom, far, near, out outMat);
            return outMat;
        }

        /// <summary>
        /// Creates an Orthographic projection from the given volume dimensions and put in a matrix
        /// </summary>
        /// </param name ="right"> The width of the viewing volume </param>
        /// </param name = "bottom"> The height of the viewing volume </param>
        /// </param name ="far"> The depth of the far plane </param>
        /// </param name = "near"> The depth of the near plane </param>
        /// </param name ="outMat"> The resulting matrix </param>
        public static void CreateOrthographic(float width, float height, float far, float near, out TMatrix4 outMat)
        {
            outMat = _identity;
            outMat.M[0, 0] = 2 / width;
            outMat.M[0, 1] = 0f;
            outMat.M[0, 2] = 0f;
            outMat.M[0, 3] = 0f;

            outMat.M[1, 0] = 0f;
            outMat.M[1, 1] = 2 / height;
            outMat.M[1, 2] = 0f;
            outMat.M[1, 3] = 0f;

            outMat.M[2, 0] = 0f;
            outMat.M[2, 1] = 0f;
            outMat.M[2, 2] = 1 / (far - near);
            outMat.M[2, 3] = 0f;

            outMat.M[3, 0] = 0f;
            outMat.M[3, 1] = 0f;
            outMat.M[3, 2] = -near / (far - near);
            outMat.M[3, 3] = 1f;
        }

        /// <summary>
        /// Returns an Orthographic projection matrix with the given volume dimensions
        /// </summary>
        /// </param name ="right"> The width of the viewing volume </param>
        /// </param name = "bottom"> The height of the viewing volume </param>
        /// </param name ="far"> The depth of the far plane </param>
        /// </param name = "near"> The depth of the near plane </param>
        /// </param name ="outMat"> The resulting matrix </param>
        public static TMatrix4 CreateOrthographic(float width, float height, float far, float near)
        {
            TMatrix4 outMat;
            CreateOrthographic(width, height, far, near, out outMat);
            return outMat;
        }

        /// <summary>
        /// Returns a 2D float array of a matrix
        /// </summary>
        /// <param name = "matrix"> The input matrix </param>
        public static double[,] ToDoubleArray(TMatrix4 matrix) => matrix.M;

        /// <summary>
        /// Returns a transposed matrix
        /// </summary>
        /// <param name = "matrix"> The input matrix </param>
        public static TMatrix4 Transpose(TMatrix4 matrix)
        {
            TMatrix4 tempMat = matrix;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrix.M[i, j] = tempMat.M[j, i];
                }
            }

            return matrix;
        }

        public TMatrix4 Transpose()
        {
            TMatrix4 tempMat;
            tempMat.M = M;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tempMat.M[i, j] = M[j, i];
                }
            }

            return tempMat;
        }

        public static bool operator ==(TMatrix4 a, TMatrix4 b)
        {
            if (a == null || b == null) { return false; }

            return ((a.M[0, 0] == b.M[0, 0]) && (a.M[0, 1] == b.M[0, 1]) && (a.M[0, 2] == b.M[0, 2]) && (a.M[0, 3] == b.M[0, 3]) && 
                    (a.M[1, 0] == b.M[1, 0]) && (a.M[1, 1] == b.M[1, 1]) && (a.M[1, 2] == b.M[1, 2]) && (a.M[1, 3] == b.M[1, 3]) && 
                    (a.M[2, 0] == b.M[2, 0]) && (a.M[2, 1] == b.M[2, 1]) && (a.M[2, 2] == b.M[2, 2]) && (a.M[2, 3] == b.M[2, 3]) &&
                    (a.M[3, 0] == b.M[3, 0]) && (a.M[3, 1] == b.M[3, 1]) && (a.M[3, 2] == b.M[3, 2]) && (a.M[3, 3] == b.M[3, 3]));
        }

        public static bool operator !=(TMatrix4 a, TMatrix4 b)
        {
            if (a == null || b == null) { return true; }
            return !(a == b);
        }

        public static bool operator >(TMatrix4 a, TMatrix4 b)
        {
            if (a == null) { return false; }
            else if (b == null) { return true; }
            return ((a.M[0, 0] > b.M[0, 0]) && (a.M[0, 1] > b.M[0, 1]) && (a.M[0, 2] > b.M[0, 2]) && (a.M[0, 3] >= b.M[0, 3]) &&
                    (a.M[1, 0] > b.M[1, 0]) && (a.M[1, 1] > b.M[1, 1]) && (a.M[1, 2] > b.M[1, 2]) && (a.M[1, 3] >= b.M[1, 3]) &&
                    (a.M[2, 0] > b.M[2, 0]) && (a.M[2, 1] > b.M[2, 1]) && (a.M[2, 2] > b.M[2, 2]) && (a.M[2, 3] >= b.M[2, 3]) &&
                    (a.M[3, 0] > b.M[3, 0]) && (a.M[3, 1] > b.M[3, 1]) && (a.M[3, 2] > b.M[3, 2]) && (a.M[3, 3] >= b.M[3, 3]));
        }
        public static bool operator <(TMatrix4 a, TMatrix4 b)
        {
            if (a == null) { return true; }
            else if (b == null) { return false; }
            return ((a.M[0, 0] < b.M[0, 0]) && (a.M[0, 1] < b.M[0, 1]) && (a.M[0, 2] < b.M[0, 2]) && (a.M[0, 3] >= b.M[0, 3]) &&
                    (a.M[1, 0] < b.M[1, 0]) && (a.M[1, 1] < b.M[1, 1]) && (a.M[1, 2] < b.M[1, 2]) && (a.M[1, 3] >= b.M[1, 3]) &&
                    (a.M[2, 0] < b.M[2, 0]) && (a.M[2, 1] < b.M[2, 1]) && (a.M[2, 2] < b.M[2, 2]) && (a.M[2, 3] >= b.M[2, 3]) &&
                    (a.M[3, 0] < b.M[3, 0]) && (a.M[3, 1] < b.M[3, 1]) && (a.M[3, 2] < b.M[3, 2]) && (a.M[3, 3] >= b.M[3, 3]));
        }
        public static bool operator <=(TMatrix4 a, TMatrix4 b)
        {
            if (a == null || b == null) { return false; }
            return ((a.M[0, 0] <= b.M[0, 0]) && (a.M[0, 1] <= b.M[0, 1]) && (a.M[0, 2] <= b.M[0, 2]) && (a.M[0, 3] >= b.M[0, 3]) &&
                    (a.M[1, 0] <= b.M[1, 0]) && (a.M[1, 1] <= b.M[1, 1]) && (a.M[1, 2] <= b.M[1, 2]) && (a.M[1, 3] >= b.M[1, 3]) &&
                    (a.M[2, 0] <= b.M[2, 0]) && (a.M[2, 1] <= b.M[2, 1]) && (a.M[2, 2] <= b.M[2, 2]) && (a.M[2, 3] >= b.M[2, 3]) &&
                    (a.M[3, 0] <= b.M[3, 0]) && (a.M[3, 1] <= b.M[3, 1]) && (a.M[3, 2] <= b.M[3, 2]) && (a.M[3, 3] >= b.M[3, 3]));
        }
        public static bool operator >=(TMatrix4 a, TMatrix4 b)
        {
            if (a == null || b == null) { return false; }
            return ((a.M[0, 0] >= b.M[0, 0]) && (a.M[0, 1] >= b.M[0, 1]) && (a.M[0, 2] >= b.M[0, 2]) && (a.M[0, 3] >= b.M[0, 3]) &&
                    (a.M[1, 0] >= b.M[1, 0]) && (a.M[1, 1] >= b.M[1, 1]) && (a.M[1, 2] >= b.M[1, 2]) && (a.M[1, 3] >= b.M[1, 3]) &&
                    (a.M[2, 0] >= b.M[2, 0]) && (a.M[2, 1] >= b.M[2, 1]) && (a.M[2, 2] >= b.M[2, 2]) && (a.M[2, 3] >= b.M[2, 3]) &&
                    (a.M[3, 0] >= b.M[3, 0]) && (a.M[3, 1] >= b.M[3, 1]) && (a.M[3, 2] >= b.M[3, 2]) && (a.M[3, 3] >= b.M[3, 3]));
        }

        public static TMatrix4 operator +(TMatrix4 a) => a;

        public static TMatrix4 operator +(TMatrix4 a, TMatrix4 b)
        {
            TMatrix4 temp;
            double[,] m = new double[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                { m[i, j] = a.M[i, j] + b.M[i, j]; }
            }
            temp = new TMatrix4(m);

            return temp;
        }

        public static TMatrix4 operator -(TMatrix4 a)
        {
            TMatrix4 temp;
            double[,] m = new double[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                { m[i, j] = -a.M[i, j]; }
            }
            temp = new TMatrix4(m);

            return temp;
        }

        public static TMatrix4 operator -(TMatrix4 a, TMatrix4 b)
        {
            TMatrix4 temp;
            double[,] m = new double[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                { m[i, j] = a.M[i, j] - b.M[i, j]; }
            }
            temp = new TMatrix4(m);

            return temp;
        }

        public static TMatrix4 operator *(TMatrix4 a, TMatrix4 b)
        {
            TMatrix4 temp;
            double[,] m = new double[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        m[i, j] += a.M[i, k] * b.M[k, j];
                    }
                }
            }

            temp = new TMatrix4(m);
            return temp;
        }
        //  => new Matrix4F(a.M[0, 0] * b.M[0, 0] + a.M[1, 0] * b.M[0, 1] + a.M[2, 0] * b.M[0, 2] + a.M[3, 0] * b.M[0, 3],
        //                                                                           a.M[0, 0] * b.M[1, 0] + a.M[1, 0] * b.M[1, 1] + a.M[2, 0] * b.M[1, 2] + a.M[3, 0] * b.M[1, 3], 
        //                                                                           a.M[0, 0] * b.M[2, 0] + a.M[1, 0] * b.M[2, 1] + a.M[2, 0] * b.M[2, 2] + a.M[3, 0] * b.M[2, 3], 
        //                                                                           a.M[0, 0] * b.M[3, 0] + a.M[1, 0] * b.M[3, 1] + a.M[2, 0] * b.M[3, 2] + a.M[3, 0] * b.M[3, 3],

        //                                                                           a.M[0, 1] * b.M[0, 0] + a.M[1, 1] * b.M[0, 1] + a.M[2, 1] * b.M[0, 2] + a.M[3, 1] * b.M[0, 3],
        //                                                                           a.M[0, 1] * b.M[1, 0] + a.M[1, 1] * b.M[1, 1] + a.M[2, 1] * b.M[1, 2] + a.M[3, 1] * b.M[1, 3], 
        //                                                                           a.M[0, 1] * b.M[2, 0] + a.M[1, 1] * b.M[2, 1] + a.M[2, 1] * b.M[2, 2] + a.M[3, 1] * b.M[2, 3], 
        //                                                                           a.M[0, 1] * b.M[3, 0] + a.M[1, 1] * b.M[3, 1] + a.M[2, 1] * b.M[3, 2] + a.M[3, 1] * b.M[3, 3],

        //                                                                           a.M[0, 2] * b.M[0, 0] + a.M[1, 2] * b.M[0, 1] + a.M[2, 2] * b.M[0, 2] + a.M[3, 2] * b.M[0, 3],
        //                                                                           a.M[0, 2] * b.M[1, 0] + a.M[1, 2] * b.M[1, 1] + a.M[2, 2] * b.M[1, 2] + a.M[3, 2] * b.M[1, 3], 
        //                                                                           a.M[0, 2] * b.M[2, 0] + a.M[1, 2] * b.M[2, 1] + a.M[2, 2] * b.M[2, 2] + a.M[3, 2] * b.M[2, 3], 
        //                                                                           a.M[0, 2] * b.M[3, 0] + a.M[1, 2] * b.M[3, 1] + a.M[2, 2] * b.M[3, 2] + a.M[3, 2] * b.M[3, 3],

        //                                                                           a.M[0, 3] * b.M[0, 0] + a.M[1, 3] * b.M[0, 1] + a.M[2, 3] * b.M[0, 2] + a.M[3, 3] * b.M[0, 3],
        //                                                                           a.M[0, 3] * b.M[1, 0] + a.M[1, 3] * b.M[1, 1] + a.M[2, 3] * b.M[1, 2] + a.M[3, 3] * b.M[1, 3], 
        //                                                                           a.M[0, 3] * b.M[2, 0] + a.M[1, 3] * b.M[2, 1] + a.M[2, 3] * b.M[2, 2] + a.M[3, 3] * b.M[2, 3], 
        //                                                                           a.M[0, 3] * b.M[3, 0] + a.M[1, 3] * b.M[3, 1] + a.M[2, 3] * b.M[3, 2] + a.M[3, 3] * b.M[3, 3]);

        public static TMatrix4 operator /(TMatrix4 a, TMatrix4 b)
        {
            TMatrix4 temp;
            double[,] m = new double[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                { m[i, j] = a.M[i, j] / b.M[i, j]; }
            }
            temp = new TMatrix4(m);

            return temp;
        }

        public bool Equals(TMatrix4 other)
        {
            if (other == null) { return false; }

            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) { return false; }

            return Equals((TMatrix4)obj);
        }

        public override int GetHashCode()
        {
            return ((int)M[0, 0] ^ (int)M[0, 1] ^ (int)M[0, 2] ^ (int)M[0, 3] ^ 
                    (int)M[1, 0] ^ (int)M[1, 1] ^ (int)M[1, 2] ^ (int)M[1, 3] ^ 
                    (int)M[2, 0] ^ (int)M[2, 1] ^ (int)M[2, 2] ^ (int)M[2, 3] ^ 
                    (int)M[3, 0] ^ (int)M[3, 1] ^ (int)M[3, 2] ^ (int)M[3, 3]);
        }

        public override string ToString()
        {
            return string.Format("M11: {0}, M12: {1}, M13: {2}, M14: {3}, \nM21: {4}, M22: {5}, M23: {6}, M24: {7}, \nM31: {8}, M32: {9}, M33: {10}, M34: {11}, \nM41: {12}, M42: {13}, M43: {14}, M44: {15}",
                                  M[0, 0], M[0, 1], M[0, 2], M[0, 3], M[1, 0], M[1, 1], M[1, 2], M[1, 3], M[2, 0], M[2, 1], M[2, 2], M[2, 3], M[3, 0], M[3, 1], M[3, 2], M[3, 3]);
        }
    }
}
