using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triangles.Logic;
using Triangles.Math;

namespace Triangles.Math
{
    public static class Ordering
    {
        public static void OrderBySquare(this Dictionary<string, Triangle> dict, bool ifAscending = true)
        {
            Dictionary<string, Triangle> dictForOrder = new Dictionary<string, Triangle>();

            if (ifAscending)
            {
                var dictVar = from pair in dict
                              orderby pair.Value.GetSquare() ascending
                              select pair;

                foreach (KeyValuePair<string, Triangle> pair in dictVar)
                {
                    dictForOrder.Add(pair.Key, pair.Value);
                }
            }
            else
            {
                var dictVar = from pair in dict
                              orderby pair.Value.GetSquare() descending
                              select pair;

                foreach (KeyValuePair<string, Triangle> pair in dictVar)
                {
                    dictForOrder.Add(pair.Key, pair.Value);
                }
            }

            dict = dictForOrder;
        }

    }
}
