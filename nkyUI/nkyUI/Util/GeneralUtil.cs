using Avalonia;
using System;

namespace nkyUI.Util
{
    public static class GeneralUtil
    {
        public static double DistanceTo(this Point p, Point q)
        {
            var a = p.X - q.X;
            var b = p.Y - q.Y;
            var distance = Math.Sqrt(a * a + b * b);
            return distance;
        }
    }
}