using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triangles.Logic;
using Triangles.Logic;

namespace Triangles.UserUI
{
    public static class OutputResults
    {
        #region    Constants
        public const string NAME = "Name";
        public const string SIDES = "Sides";
        public const string TRIANGLE = "Triangle =>";
        public const string SQUARE = "Square";
        
        public const string ENTRY_SEPARATOR = " separator expected between data entries.";
        public const string INPUT_SEQUENCE = "Input sequence for one triangle: <Name>,<Side_1>,<Side_2>,<Side_3>";

        public const string DUBLICATE_KEY = "This name of triangle already exists. Please, enter another name.";
        public const string IMPOSSIBLE_TO_NAME = "It is impossible to add the entry to the dictionary";
        public const string INCORRECT_DATA = "The data you have entered is incorrect.";
        public const string CORRECT_DATA = "The data you have entered is in correct format.";
        public const string NOT_REAL = "Your have entered a string of not real number format.";
        public const string NOT_ONE_STRING = "One-string entry data expected.";
        public const string CAN_RESTART = "You can restart the application with entry data as parameter.";
        public const string APP_CANNOT_PROCESS = "The application cannot process data in a similar format";
        public const string NULL_ENTRY_PARAMETERS = "The application cannot process data with null entry parameters.";
        public const string ASK_CONTINUE_WITH_CONSOLE = "Do you want to continue with console entered data?";

        public const string FINISH = "The app working is finished.";

        public const string FORMAT_REQUIREMENTS = "Expected a positive number in real numeric format.";
        public const string MAX = "Maximum allowable value is ";
        public const double MAX_VALUE = double.MaxValue;
        #endregion
        
        public static void ShowTriangleWithSquare(this IViewableTriangle view, string name = "")
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(name))
            {
                sb.AppendFormat("{0}  {1}: {2}  {3}: ", TRIANGLE, NAME, name, SIDES);
            }

            sb.AppendFormat("{0}  {1}: ", TRIANGLE, SIDES);

            foreach(double side in view.Sides)
            {
                sb.AppendFormat("{0} ", side);
            }
            sb.Remove(sb.Length - 1, 1);

            sb.AppendFormat("  {0}: {1:F4}", SQUARE, view.Square);

            Console.WriteLine(sb);
        }

        public static void ShowTrianglesIEnumerator(this IViewable view, string message = "")
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(message))
            {
                sb.AppendLine(message);
            }

            foreach (KeyValuePair<string, IViewableTriangle> item in view.TriangleDictionary)
            {
                sb.AppendFormat("{0}: {1};  {2}: ", NAME, item.Key, SIDES);

                foreach (double side in item.Value.Sides)
                {
                    sb.AppendFormat("{0}; ", side);
                }

                sb.AppendFormat("  {0}: {1:F3};", SQUARE, item.Value.Square);
                sb.AppendLine();
            }

            Console.WriteLine(sb);
        }

        public static void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void OutputMessageSet(params string[] strings)
        {
            StringBuilder sb = new StringBuilder();
            foreach(string s in strings)
            {
                sb.Append(s);
            }
            Console.WriteLine(sb.ToString());
        }

        public static void OutputCorrectFormatInfo(string firstMessage = "")
        {
            if(firstMessage != string.Empty)
            {
                Console.WriteLine(firstMessage);
            }

            Console.WriteLine(FORMAT_REQUIREMENTS);
            Console.WriteLine(String.Concat(MAX, MAX_VALUE));
        }
        
    }

}
