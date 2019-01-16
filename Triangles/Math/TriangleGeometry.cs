using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triangles.Logic;

namespace Triangles.Math
{
    public static class TriangleGeometry
    {
        public static double GetPerimeter(this Triangle trian)
        {
            double result = 0.0;
            if(trian != null)
            {
                result = trian.A + trian.B + trian.C;
            }
            return result;
        }

        public static double GetSemiperimeter(this Triangle trian)
        {
            double result = 0.0;
            if (trian != null)
            {
                result = GetPerimeter(trian)/2;
            }
            return result;
        }

        public static double GetSquare(this Triangle trian)
        {
            double p = trian.GetSemiperimeter();
            return System.Math.Sqrt(p * (p - trian.A) * (p - trian.B) * (p - trian.C));
          }
    }
}
