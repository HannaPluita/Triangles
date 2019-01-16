using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triangles.Logic;
using Triangles.Math;
using Triangles.UserUI;

namespace Triangles
{
    public class Application
    {
        public const byte ATTEMPT_COUNT = 2;
        public const byte ARGS_TO_ACCEPT = 4;

        public const string DATA_ENTERED = "Data for a triangle are entered successful.";
        public const string NOT_TRIANGLE = "Values your have entered for a triangle's sides do not fit for a triangle.";

        protected Dictionary<string, Triangle> _dict = new Dictionary<string, Triangle>();

        public void Run(string[] args)
        {
            ParserString parser = new ParserString(args);

            if (parser.AllParse())
            {
                OutputResults.OutputOneMessage(DATA_ENTERED);

                if (Math.CheckValues.IsTriangle(parser.Sides))
                {
                    Triangle triangle = new Triangle(parser.Sides);
                    _dict.Add(parser.Name, triangle);
                    OutputResults.ShowTriangleSquare(_dict, _dict.Last().Key);
                }
                else
                {
                    OutputResults.OutputOneMessage(NOT_TRIANGLE);
                }
            }
            else
            {
                OutputResults.OutputOneMessage(OutputResults.APP_CANNOT_PROCESS);
                OutputResults.OutputOneMessage(OutputResults.TRY_AGAIN_WITH_RESTART);
            }
            OutputResults.OutputOneMessage(OutputResults.FINISH);
        }

        public static string[] GetNecessaryArgs(string[] args)
            {
                string[] results = new string[ARGS_TO_ACCEPT];
                if (args.Length >= ARGS_TO_ACCEPT + 1)
                {
                    for (int i = 1; i <= ARGS_TO_ACCEPT; ++i)
                    {
                        results[i - 1] = args[i];
                    }
                }

                return results;
            }
    }
}
