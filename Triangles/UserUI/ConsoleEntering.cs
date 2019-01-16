using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangles.UserUI
{
    public static class ConsoleEntering
    {
        #region    Constants
        public const string ENTER = "Please, enter ";
        public const string SIDE = "a side of the triangle ";
        public const string NAME = "a name of the triangle ";
        public const string NONZERO = "as a positive nonzero value ";
        public const string NOTNULL = "as not empty string value. ";
        public const string REAL_FORMAT = "in real number format.";
        public const string NONZERO_DATA = "Your data entry is nonzero.";
        public const string DATA_ACCEPTED = "Your data accepted.";
        public const string DATA_NOT_ACCEPTED = "Your data is not accepted.";
        public const string INCORRECT_ENTRY = "You have entered empty string. It is incorrect entry for this application.";
        public const string TRY_AGAIN = "Please, try again.";
        #endregion

        public static string GetNonZeroStringForSides(byte attemptsCount = Application.ATTEMPT_COUNT)    //Try to get a nonzero string from console
        {
            string result = string.Empty;

            bool contin = true;

            byte attemptIndex = 0;

            while(contin && attemptIndex < attemptsCount)
            {
                Console.WriteLine(String.Concat(ENTER, SIDE, NONZERO, REAL_FORMAT));

                string input = Console.ReadLine();

                if(String.IsNullOrEmpty(input))
                {
                    Console.Write(INCORRECT_ENTRY);
                }
                else
                {
                    Console.WriteLine(NONZERO_DATA, input);
                    result = input;
                    contin = false;
                }

                if(contin)
                {
                    Console.WriteLine(TRY_AGAIN);
                }

                ++attemptIndex;
            }

            if (String.IsNullOrEmpty(result))
            {
                Console.WriteLine("You have entered incorrect data.");
            }
            return result;
        }

        public static string GetNotNullStringForName(byte attemptsCount = Application.ATTEMPT_COUNT)    //Try to get a nonzero string from console
        {
            string result = string.Empty;

            bool contin = true;

            byte attemptIndex = 0;

            while (contin && attemptIndex < attemptsCount)
            {
                Console.WriteLine(String.Concat(ENTER, NAME, NOTNULL));

                string input = Console.ReadLine();

                if (String.IsNullOrEmpty(input))
                {
                    Console.Write(INCORRECT_ENTRY);
                }
                else
                {
                    Console.WriteLine(DATA_ACCEPTED);
                    result = input;
                    contin = false;
                }

                if (contin)
                {
                    Console.WriteLine(TRY_AGAIN);
                }

                ++attemptIndex;
            }

            if (String.IsNullOrEmpty(result))
            {
                Console.WriteLine("DATA_NOT_ACCEPTED");
            }
            return result;
        }
    }
}
