using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangles.Math
{
    public static class CheckValues
    {
        public const double SIDES_COUNT = 3;

        public static bool IsPositive(double value)
        {
            bool positive = false;
            if(value > 0)
            {
                positive = true;
            }
            return positive;
        }

        public static bool IsTriangle( double a, double b, double c)
        {
            bool ifTrian = false;
            if((a < b + c) && (b < a + c) && (c < a + b))
            {
                ifTrian = true;
            }
            return ifTrian;
        }

        public static bool IsTriangle(double[] values)
        {
            bool triangle = false;
            if(values != null)
            {
                if(values.Select(v => v).Where(v => v > 0).Count() == SIDES_COUNT)
                {
                    triangle = IsTriangle(values[0], values[1], values[2]);
                }
            }
            return triangle;
        }
    }
}
