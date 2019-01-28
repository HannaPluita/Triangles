using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangles.Logic
{
    public interface IViewableTriangle
    {
        double[] Sides { get; }

        double Square { get; }
    }
}
