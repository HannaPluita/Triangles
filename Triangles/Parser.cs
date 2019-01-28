using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triangles.Logic;

namespace Triangles.UserUI
{
    public class Parser: Application
    { 
        public Parser()
        {
        }

        public Parser(string input)
        :base(input)
        {
        }

        public Parser(string[] input)
        :base(input)
        {
        }

        public Parser(Parser parser)
            : base(parser as Application)
        {
        }
        
        protected bool SetParsedName()     //Set _name field
        {
            string input = string.Empty;

            if (!Input.GetNonZeroString(false, out input) )  //Enter a name
            {
                Console.WriteLine(Input.EMPTY_DATA);
                Console.ReadLine();

                return false;
            }

            _name = input;

            return true;
        }

        protected bool SetParsedName(string input)     //Set _name field
        {
            if (!string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(input = input.Trim(SEPARATOR, EMPTY_SPACE)))  //Enter a name
            {
                _name = input;
                return true;
            }

            Console.WriteLine(Input.EMPTY_DATA);
            Console.ReadLine();

            return false;
        }

        protected bool TryParseOneSide(string input, out double result)
        {
            result = 0.0;

            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (!double.TryParse(input, out result))
            {
                return false;
            }

            if (result < 0)
            {
                return false;
            }

            return true;
        }

        protected bool SetParsedSides()                  //Set _sides field by console entering
        {
            string inputSides = string.Empty;

            if (!Input.GetNonZeroString(true, out inputSides)) //Get a string line from console 
            {
                Console.WriteLine(Input.EMPTY_DATA);

                return false;
            }

            string[] entriesSides = new string[SIDES_NUMBER]; //string[] GetSubarrayForSidesAssign(string[] args)

            if (!GetSplittedFromInputSidesLine(inputSides, out entriesSides)) //Try to assign _entries field
            {
                Console.WriteLine(Input.INCORRECT_ENTRY);
                Console.WriteLine(Input.DATA_NOT_ACCEPTED);

                return false;
            }

            for (int i = 0; i < SIDES_NUMBER; ++i) 
            {
                if (!TryParseOneSide(entriesSides[i], out _sides[i])) 
                {
                    Console.WriteLine(Input.INCORRECT_ENTRY);
                    Console.WriteLine(Input.DATA_NOT_ACCEPTED);

                    return false;
                }
            }

            Console.WriteLine(DATA_ENTERED);

            return true;
        }

        protected bool SetParsedSides(string[] argsForSides)     //Set _sides field from argument line
        {
            if (argsForSides.Length != SIDES_NUMBER)
            {
                OutputResults.OutputMessage(ERR_WRONG_DATA);
                return false;
            }

            for (int i = 0; i < SIDES_NUMBER; ++i)
            {
                if (!TryParseOneSide(argsForSides[i], out _sides[i]))
                {
                    Console.WriteLine(Input.INCORRECT_ENTRY);
                    Console.WriteLine(Input.DATA_NOT_ACCEPTED);
                    Console.ReadLine();

                    return false;
                }
            }

            return true;
        }

        protected bool AllParse()                        //Assign _name and _sides fields with console data 
        {
            return SetParsedName() && SetParsedSides();
        }

        protected bool AllParse(string[] args)           //Assign _name and _sides fields with argument line
        {
            return SetParsedName(args[0]) && SetParsedSides(GetSubarrayForSidesAssigning(args));
        }

        /// <summary>
        /// Process console entery data for one trieangle. 
        /// </summary>
        /// <returns>If the user wants to continue, returns false, else returns true.</returns>
        public bool Process()                         //Process with console data
        {
            if (!AllParse())        //User's data are incorrect
            {
                if (!Input.AskContinue(OutputResults.ASK_CONTINUE_WITH_CONSOLE))   //User don't want to continue
                {
                    OutputResults.OutputMessage(OutputResults.CAN_RESTART);
                    OutputResults.OutputMessage(OutputResults.FINISH);
                    Console.ReadLine();

                    return false;
                }

                return true;      //User want to continue
            }
            
            //OutputResults.OutputMessage(DATA_ENTERED);

            if (TriangleGeometry.IsTriangle(_sides))         
            {
                Triangle triangle = new Triangle(_sides);
                _triangles.Add(_name, triangle);

                triangle.ShowTriangleWithSquare(_name);
                OutputResults.ShowTriangleWithSquare(this as IViewable, _triangles.Last().Key);

                if (!Input.AskContinue(OutputResults.ASK_CONTINUE_WITH_CONSOLE))  //Ask about the continuation of the application 
                {
                    OutputResults.OutputMessage(OutputResults.CAN_RESTART);
                    OutputResults.OutputMessage(OutputResults.FINISH);
                    Console.ReadLine();

                    return false;         //User don't want to continue
                }

                return true;     //User want to continue
            }
            else
            {
                OutputResults.OutputMessage(ERR_NOT_TRIANGLE);

                if (!Input.AskContinue(OutputResults.ASK_CONTINUE_WITH_CONSOLE))    //Ask about the continuation of the application 
                {
                    OutputResults.OutputMessage(OutputResults.CAN_RESTART);
                    OutputResults.OutputMessage(OutputResults.FINISH);
                    Console.ReadLine();

                    return false;     //User don't want to continue
                }

                return true;          //User want to continue
            }

            if (!Input.AskContinue(OutputResults.ASK_CONTINUE_WITH_CONSOLE))
            {
                OutputResults.OutputMessage(OutputResults.CAN_RESTART);
                OutputResults.OutputMessage(OutputResults.FINISH);
                Console.ReadLine();

                return false;
            }

            return true;
        }

        public void Process(string[] args)            //Process with arguments tested by their quantity
        {
            if (!AllParse(args))
            {
                OutputResults.OutputMessage(OutputResults.APP_CANNOT_PROCESS);
                OutputResults.OutputMessage(OutputResults.CAN_RESTART);
            }
           
            OutputResults.OutputMessage(DATA_ENTERED);

            if (TriangleGeometry.IsTriangle(_sides))
            {
                Triangle triangle = new Triangle(_sides);
                _triangles.Add(_name, triangle);

                OutputResults.ShowTriangleWithSquare(this as IViewable, _triangles.Last().Key);
            }
            else
            {
                OutputResults.OutputMessage(ERR_NOT_TRIANGLE);
            }
        }
    }
}
