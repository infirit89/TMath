using System;
using System.Collections.Generic;
using System.Text;

namespace TMath
{
    public class TMath
    {
        public static readonly double PI = Math.PI;

        public static double ToRadians(double degrees) => degrees * PI / 180;
        public static double ToDegrees(double radians) => radians * 180 / PI;

        public static double Sqrt(double a) => Math.Sqrt(a);

        public static double FMA(double x, double y, double z) => Math.FusedMultiplyAdd(x, y, z);

        public static double Max(double a, double b) => Math.Max(a, b);
        public static int Max(int a, int b) => Math.Max(a, b);
        public static float Max(float a, float b) => Math.Max(a, b);
        public static byte Max(byte a, byte b) => Math.Max(a, b);

        public static double Min(double a, double b) => Math.Min(a, b);
        public static float Min(float a, float b) => Math.Min(a, b);
        public static int Min(int a, int b) => Math.Min(a, b);
        public static byte Min(byte a, byte b) => Math.Min(a, b);

        public static double Cos(double a) => Math.Cos(a);
        public static double Sin(double a) => Math.Sin(a);
    }
}
