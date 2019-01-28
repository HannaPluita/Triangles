using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triangles.Logic;

namespace Triangles.Logic
{
    public class Triangle: TriangleGeometry, IComparable<Triangle>,  IEquatable<Triangle>
    {
        public const string SIDES = "Sides";

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

        
        public override string ToString()
        {
            return string.Format("{0}: {1} {2} {3}", SIDES, _a, _b, _c);
        }

        public int CompareTo(Triangle other)
        {
            if(other == null)      //If other is not valid object reference, this object is greater.
            {
                return 1;
            }

            return this.GetSquare().CompareTo(other.GetSquare());    
        }

        public IViewableTriangle Clone()
        {
            Triangle triangle = new Triangle(this);

            return triangle as IViewableTriangle;
        }

        public bool Equals(Triangle other)
        {
            if (other == null)
            {
                return false;
            }

            if ((this.A == other.A) && (this.B == other.B) && (this.C == other.C))
            {
                return true;
            }

            return false;
        }
       
        public override int GetHashCode()
        {
            return (int)A.GetHashCode() + (int)B.GetHashCode() + (int)C.GetTypeCode();
        }
    }
}
