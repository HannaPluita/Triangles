using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triangles.Math;

namespace Triangles.Logic
{
    public class Triangle: IComparable<Triangle>
    {
        #region    Protected
        protected double _a;
        protected double _b;
        protected double _c;
        #endregion

        #region    Public const
        public const string TRIANGLE = "Sides:";
        public const char SEPARATOR_FRONT = '<';
        public const char SEPARATOR_BACK = '>';
        #endregion

        #region    Constructors
        public Triangle()
            :this(0.1, 0.1, 0.1)
        {
        }

        public Triangle(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public Triangle(double[] sides)
            :this(sides[0], sides[1], sides[2])
        { }

        public Triangle(Triangle triang)
            :this(triang._a, triang._b, triang._c)
        {
        }
        #endregion

        #region    Properties
        public double A
        {
            get => _a;
        }

        public double B
        {
            get => _b;
        }

        public double C
        {
            get => _c;
        }
        #endregion 

        public override string ToString()
        {
            return string.Format("{5} {3}{0}, {1}, {2}{4}", TRIANGLE, _a, _b, _c, SEPARATOR_FRONT, SEPARATOR_BACK);
        }

        public int CompareTo(Triangle other)
        {
            //If other is not valid object reference, this object is greater.
            if(other == null)
            {
                return 1;
            }
            return this.GetSquare().CompareTo(other.GetSquare());    
        }
    }
}
