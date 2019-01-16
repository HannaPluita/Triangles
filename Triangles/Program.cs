using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triangles.UserUI;
using Triangles.UserUI;

namespace Triangles
{
    class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application();

            string[] argsStr = Environment.GetCommandLineArgs();

            if (argsStr.Length != 0)
            {
                app.Run(Application.GetNecessaryArgs(argsStr));
            }
            else
            {
                OutputResults.OutputOneMessage(OutputResults.NULL_ENTRY_PARAMETERS);
            }

            Console.ReadLine();
        }
    }
}
