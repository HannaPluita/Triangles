using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triangles.UserUI.UserExceptions;

namespace Triangles.UserUI
{
    public class ParserString
    {
        public string EnteredStr = "";
        public string[] EntryStrings = new string[PARAMETERS_NUMBER];

        protected string _name;
        protected double[] _sides = new double[SIDES_NUMBER];

        #region    Public constants
        public readonly char[] CharsForTrim = new char[] { '\t', ' ', SEPARATOR };
        public const char SEPARATOR = ',';

        public const string MESSAGE_TARGET_SITE = "Exception Target Site is ";
        public const string MESSAGE_SOURCE = "Exception Source is ";
        public const string MESSAGE_ERROR = "Error in data inputting.";

        public const byte SIDES_NUMBER = 3;
        public const byte PARAMETERS_NUMBER = Application.ARGS_TO_ACCEPT;
        #endregion

        #region    Constructors
        public ParserString()
        {
        }

        public ParserString(string input)
        {
            EnteredStr = input;
        }

        public ParserString(string[] input)
        {
            for(int i = 0; i < PARAMETERS_NUMBER; ++i)
            {
                EntryStrings[i] = input[i]; 
            }
        }

        public ParserString(ParserString parser)
            :this(parser.EnteredStr)
        {
            _name = parser._name;
            for (int i = 0; i < SIDES_NUMBER; ++i)
            {
                _sides[i] = parser._sides[i];
            }
        }
        #endregion

        #region    Properties
        public string Name
        {
            get => _name;
        }

        public double[] Sides
        {
            get
            {
                double[] result = new double[SIDES_NUMBER];
                _sides.CopyTo(result, 0);
                return result;
            }
        }

        #endregion

        public static string InputString()    //Get user's entry string from console
        {
            return Console.ReadLine();
        }

        public string[] GetSubStrings(string fullEnteredStr)
        {
            string[] result = new string[PARAMETERS_NUMBER];

            if (fullEnteredStr != null && fullEnteredStr.Contains(SEPARATOR))
            {
                result = fullEnteredStr.Split(new char[] { SEPARATOR }, PARAMETERS_NUMBER, StringSplitOptions.RemoveEmptyEntries);

                foreach(string item in result)
                {
                    item.Trim(CharsForTrim);
                }
            }
            return result;
        }

        public string[] GetSubstrings()
        {
            return GetSubStrings(EnteredStr);
        }

        #region    Set name of triangle

        public bool SetName(string input)
        {
            bool assign = false;

            if(!string.IsNullOrEmpty(input) && input.Trim(CharsForTrim) != "")
            {
                _name = input.Trim(CharsForTrim);
                assign = true;
            }

            return assign;
        }

        public bool SetParsedName()     //Set name field of ParserString class
        {
            bool setParsed = false;

            if (!SetName(EntryStrings[0]))
            {
                if (SetName(ConsoleEntering.GetNotNullStringForName()))
                {
                    setParsed = true;
                }
                {
                    OutputResults.OutputOneMessage(OutputResults.APP_CANNOT_PROCESS);
                }
            }
            else
            {
                setParsed = true;
            }

            return setParsed;
        }
        #endregion

        #region    Set sides of triangle

        public bool GetOneDoubleValue(string input, out double result) //Give two attempts to enter if one arg failed
        {
            bool assign = false;

            input = ConsoleEntering.GetNonZeroStringForSides(Application.ATTEMPT_COUNT);
            if(TryParseSide(input, out result))     // The first attempt is successful
            {
                Console.WriteLine(OutputResults.CORRECT_DATA);
                assign = true;
            }
            else // The first attempt failed
            {
                OutputResults.OutputCorrectFormatInfo();
                Console.WriteLine(String.Concat(ConsoleEntering.ENTER, ConsoleEntering.SIDE, ConsoleEntering.REAL_FORMAT));
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine(ConsoleEntering.INCORRECT_ENTRY);
                }

                if(TryParseSide(input, out result))  //  The second attempt is successful
                {
                    Console.WriteLine(OutputResults.CORRECT_DATA);
                    assign = true;
                }
                else
                {
                    OutputResults.OutputOneMessage(OutputResults.INCORRECT_DATA);    //  The second attempt failed
                    OutputResults.OutputOneMessage(OutputResults.NOT_REAL);
                    OutputResults.OutputOneMessage(OutputResults.APP_CANNOT_PROCESS);
                }
            }

            return assign;
        }

        protected bool TryParseSide(string input, out double result)
        {
            bool assign = false;
            result = 0.0;
            if(input != null)
            {
                input = input.Trim(new char[] { SEPARATOR });
                if (double.TryParse(input, out result) && Math.CheckValues.IsPositive(result))
                {
                    assign = true;
                }
            }

            return assign;
        }

        public bool SetOneSide(string input, out double side)
        {
            bool assign = false;
            side = 0.0;

            if(!TryParseSide(input, out side))   //Not read value from args
            {
                if (GetOneDoubleValue(input, out side))
                {
                    assign = true;
                }
            }
            else
            {
                 assign = true;
            }

            return assign;
        }

        public bool SetSides(string[] stringArr)
        {
            bool assign = true;
            double[] results = new double[SIDES_NUMBER];

            if (stringArr.Length == SIDES_NUMBER)
            {
                for (int i = 0; i < SIDES_NUMBER; ++i)
                {
                     if(!SetOneSide(stringArr[i], out results[i]))
                     {
                        assign = false;
                     }
                    else
                    {
                        _sides[i] = results[i];
                    }
                }
            }

            return assign;
        }

        public bool SetParsedSides()     //Set side fields of ParserString class
        {
            bool setParsed = false;

            string[] strArgs = new string[SIDES_NUMBER];

            for(int i = 1; i < SIDES_NUMBER +1; ++i)
            {
                strArgs[i - 1] = EntryStrings[i];
            }

            if (!SetSides(strArgs))
            {
                OutputResults.OutputOneMessage(OutputResults.APP_CANNOT_PROCESS);
            }
            else
            {
                setParsed = true;
            }

            return setParsed;
        }

        #endregion

        public bool AllParse()   
        {
            return SetParsedName() && SetParsedSides();
        }
    }
}
