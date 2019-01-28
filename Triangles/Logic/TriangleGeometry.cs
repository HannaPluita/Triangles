using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangles.Logic
{
    public abstract class TriangleGeometry: IViewableTriangle
    {
        public const double SIDES_COUNT = 3;
        
        protected double _a;
        protected double _b;
        protected double _c;

        public double A
        {
            get { return _a; }
        }

        public double B
        {
            get { return _b; }
        }

        public double C
        {
            get { return _c; }
        }

        public double Square
        {
            get { return this.GetSquare(); }
        }

        public double[] Sides
        {
            get
            {
                return new double[] { _a, _b, _c };
            }
        }

        public bool IsTriangle()
        {
            if ((_a < 0) || (_b < 0) || (_c < 0))
            {
                return false;
            }

            if((_a < _b + _c) && (_b < _a + _c) && (_c < _a + _b))
            {
                return true;
            }
            return false;
        }

        public static bool IsTriangle(double a, double b, double c)
        {
            Triangle t = new Triangle(a,b,c);

            return t.IsTriangle();
        }

        public static bool IsTriangle(double[] values)
        {
            if (values == null || values.Length != SIDES_COUNT)
            {
                return false;
            }

            Triangle t = new Triangle(values);

            return t.IsTriangle();
        }

        public double GetPerimeter()
        {
            return A + B + C;
        }

        public double GetSemiperimeter()
        {
            return GetPerimeter() / 2;
        }

        public double GetSquare()
        {
            double p = GetSemiperimeter();

            return System.Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
    }
}
