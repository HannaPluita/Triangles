using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangles.UserUI
{
    public static class Input
    {
        #region    Constants
        public const string PLEASE_ENTER = "Please, enter ";
        public const string SIDE = "three sides of the triangle ";
        public const string NAME = "a name of the triangle ";
        public const string NONZERO = "as a positive nonzero value ";
        public const string NOTNULL = "as not empty string value. ";
        public const string REAL_FORMAT = "in a positive real number format.";
        public const string NONZERO_DATA = "Your data entry is not null";
        public const string DATA_PROCESSING = "Data is taken for processing...";
        public const string DATA_NOT_ACCEPTED = "Your data is not accepted.";
        public const string INCORRECT_ENTRY = "You have entered an incorrect entry.";
        public const string TRY_AGAIN = "Please, try again.";
        public const string INCORRECT_DATA = "You have entered incorrect data.";
        public const string FORMAT_SIDES = "Input format: <Side1>;<Side2>;<Side3> or <Side1> <Side2> <Side3>";
        public const string EMPTY_DATA = "Empty data. The process completed.";

        public const string YES = "yes";
        public const char Y_CHAR = 'y'; 
        #endregion

        /// <summary>
        /// The method for entering a string with one value by user. 
        /// </summary>
        /// <param name="forSides">If true - get a string for a triangle's side, if false - get a string for a triangle's name.</param>
        /// <param name="resultForSides">The resulting input line.</param>
        /// <returns>An entered by user string</returns>
        public static bool GetNonZeroString(bool forSides, out string resultForSides)    //Try to get a not null string from console
        {
            resultForSides = string.Empty;

            if (forSides)
            {
                Console.WriteLine(String.Concat(PLEASE_ENTER, SIDE, NONZERO, REAL_FORMAT));
                Console.WriteLine(FORMAT_SIDES);
            }
            else
            {
                Console.WriteLine(String.Concat(PLEASE_ENTER, NAME, NOTNULL));
            }

            string input = Console.ReadLine();

            if (forSides)
            {
                if (String.IsNullOrEmpty(input) && input.Trim(Parser.EMPTY_SPACE, Parser.SEPARATOR) == string.Empty)
                {
                    Console.Write(INCORRECT_ENTRY);

                    return false;
                }

                resultForSides = input.Trim(Parser.EMPTY_SPACE, Parser.SEPARATOR);
                Console.WriteLine(string.Format("{0}: {1}", NONZERO_DATA, input));
                Console.WriteLine(DATA_PROCESSING);

                return true;
            }
            else
            {
                if (String.IsNullOrEmpty(input) && input.Trim(Parser.SEPARATOR, Parser.EMPTY_SPACE) == string.Empty)
                {
                    Console.Write(INCORRECT_ENTRY);

                    return false;
                }

                resultForSides = input.Trim(Parser.SEPARATOR, Parser.EMPTY_SPACE);
                Console.WriteLine(string.Format("{0}: {1}", NONZERO_DATA, input));
                
                return true;
            }
        }

        public static void Wait()
        {
            Console.ReadKey();
        }

        public static bool AskContinue(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }

            string input = Console.ReadLine();

            if (input.ToLower() == YES || input.ToLower() == Y_CHAR.ToString())
            {
                return true;
            }

            return false;
        }

    }
}
