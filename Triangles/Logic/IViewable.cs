using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangles.Logic
{
    public interface IViewable: IViewableTriangle
    {
        string Name { get; }

        IEnumerable<KeyValuePair<string, IViewableTriangle>> TriangleDictionary { get; }
    }
}
