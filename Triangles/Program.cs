using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triangles.UserUI;
using Triangles.Logic;

namespace Triangles
{
    class Program
    {
        static void Main(string[] args)
        {
            Application appTest = new Application();
            appTest.DemonstrateTrianglesCollectionOrdering();

            if(args.Length == 0)     //Arguments are not assidned. The user is prompted to continue with console entry data.
            {
                OutputResults.OutputMessage(OutputResults.NULL_ENTRY_PARAMETERS);

                if (!Input.AskContinue(OutputResults.ASK_CONTINUE_WITH_CONSOLE))  //User does not want to continue with console entry data
                {
                    OutputResults.OutputMessage(OutputResults.FINISH);
                    Input.Wait();

                    return;
                }

                Parser parser = new Parser();        //User want to continue with console entering

                bool ifContinue = true;

                while (ifContinue)
                {
                    ifContinue = parser.Process();
                }

                Input.Wait();

                return;
            }
            //Arguments are assigned. 
            if (args.Length < Application.ARGS_TO_ACCEPT)
            {
                OutputResults.OutputMessage(Application.ERR_TOO_FEW_ARGS);
                OutputResults.OutputMessage(Application.RESTART);
                Input.Wait();

                return;
            }

            string[] argsResult;

            Parser app = new Parser();

            if (!app.GetNecessaryArgs(args, out argsResult))
            {
                OutputResults.OutputMessage(Application.ERR_TOO_FEW_ARGS);
                OutputResults.OutputMessage(Application.RESTART);
                Input.Wait();

                return;
            }

            app.Process(argsResult);
            OutputResults.OutputMessage(OutputResults.CAN_RESTART);
            OutputResults.OutputMessage(OutputResults.FINISH);
            Input.Wait();
            return;
        }
    }
}
