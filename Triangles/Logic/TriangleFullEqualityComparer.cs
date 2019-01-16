using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangles.Logic
{
    class TriangleFullEqualityComparer : IEqualityComparer<Triangle>
    {
        public bool Equals(Triangle first, Triangle second)
        {
            if(first == null || second == null)
            {
                return false;
            }

            bool ifEqual = false;

            if ((first.A == first.A) && (first.B == first.B) && (first.C == first.C))
            {
                ifEqual = true;
            }

            return ifEqual;
        }

        public int GetHashCode(Triangle obj)
        {
             return (int)obj.A.GetHashCode() + (int)obj.B.GetHashCode() + (int)obj.C.GetTypeCode();
        }
    }
}
