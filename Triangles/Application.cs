using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triangles.Logic;
using Triangles.Logic;
using Triangles.UserUI;

namespace Triangles
{
    public class Application: IViewable
    {
        #region    Constants | Readonly
        public const char SEPARATOR = ';';
        public const char EMPTY_SPACE = ' ';
        public const byte ARGS_TO_ACCEPT = 4;
        public const byte SIDES_NUMBER = 3;
        public const string DATA_ENTERED = "Data for a triangle are entered successful.";
        public const string ERR_WRONG_DATA = "Your data is of incorrect format.";
        public const string RESTART = "Please, restart the application with the required number of input parameters.";
        public const string ERR_NOT_TRIANGLE = "Values your have entered for a triangle's sides do not fit for a triangle.";
        public const string ERR_TOO_FEW_ARGS = "Too few arguments for the application to work.";
        public const string ERR_UNEXPECTED = "An unexpected application error occurred.";

        public readonly Dictionary<string, Triangle> TestTriangles = new Dictionary<string, Triangle>()
        {
            {"Triangle 1", new Triangle(23.1, 56.7, 70.5)},
            {"Triangle 2", new Triangle(26.4, 46.8, 31.9)},
            {"Triangle 3", new Triangle(13.3, 16.5, 17.4)},
            {"Triangle 4", new Triangle(2.8, 1.7, 3.9)},
            {"Triangle 5", new Triangle(10.2, 6.3, 7.7)},
        };
        #endregion

        protected Dictionary<string, Triangle> _triangles = new Dictionary<string, Triangle>();
        protected string _name;
        protected double[] _sides = new double[SIDES_NUMBER];
        protected string[] _entries = new string[ARGS_TO_ACCEPT];
        protected string _enteredLine = "";

        public Application()
        {
        }

        public Application(string input)
        {
            _enteredLine = input;
        }

        public Application(string[] input)
        {
            for (int i = 0; i < ARGS_TO_ACCEPT; ++i)
            {
                _entries[i] = input[i];
            }
        }

        public Application(Application app)
            :this(app._entries)
        {
            _enteredLine = app._enteredLine;
            _sides = app._sides;
            _name = app._name;

            Dictionary<string, Triangle> bufTriangles = app._triangles.ToDictionary(
                entry => entry.Key,
                entry => (Triangle)entry.Value.Clone());
            _triangles = bufTriangles;
        }

        public string Name
        {
            get { return _name; }
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

        public double Square
        {
            get
            {
                Triangle triangle = new Triangle(Sides);

                return triangle.Square;
            }
        }

        public IEnumerable<KeyValuePair<string, IViewableTriangle>> TriangleDictionary
        {
            get
            {
                return _triangles.ToDictionary(
                    entry => entry.Key,
                    entry => (IViewableTriangle)entry.Value.Clone());
            }
        }

        public bool GetNecessaryArgs(string[] args, out string[] results)                        //Get only ARGS_TO_ACCEPT arguments
        {
            string[] argsResult = new string[ARGS_TO_ACCEPT];

            if(args == null || args.Length == 0 || args.Length < ARGS_TO_ACCEPT)
            {
                results = argsResult;

                return false;
            }

            for (int i = 0; i < ARGS_TO_ACCEPT; ++i)
            {
                argsResult[i] = args[i];
            }

            results = argsResult;

            return true;
        }

        protected string[] GetSubarrayForSidesAssigning(string[] args)
        {
            if (args.Length == SIDES_NUMBER + 1)
            {
                string[] results = new string[SIDES_NUMBER];

                for (int i = 0; i < SIDES_NUMBER; ++i)
                {
                    results[i] = args[i + 1];
                    results[i] = results[i].Trim(SEPARATOR);
                }

                return results;
            }

            return null;
        }

        protected bool GetSplittedFromInputSidesLine(string inputSides, out string[] sidesLines) 
        {
            sidesLines = new string[SIDES_NUMBER];

            if (string.IsNullOrEmpty(inputSides) && !inputSides.Contains(SEPARATOR))
            {
                OutputResults.OutputMessage(ERR_WRONG_DATA);
                return false;
            }

            sidesLines = inputSides.Split(new char[] { SEPARATOR }, SIDES_NUMBER, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < sidesLines.Length; ++i)
            {
                if (string.IsNullOrEmpty(sidesLines[i]))
                {
                    OutputResults.OutputMessage(ERR_TOO_FEW_ARGS);
                    return false;
                }

                sidesLines[i] = sidesLines[i].Trim(EMPTY_SPACE);

                if (sidesLines[i] == string.Empty)
                {
                    OutputResults.OutputMessage(ERR_TOO_FEW_ARGS);
                    return false;
                }
            }

            return true;
        }

        public void DemonstrateTrianglesCollectionOrdering()
        {
            _triangles = TestTriangles;

            (this as IViewable).ShowTrianglesIEnumerator("Triangles are not sorted:");

            if(OrderBySquare(true))
            {
                (this as IViewable).ShowTrianglesIEnumerator("Triangles are ordered by square in ascending order:");
            }

            if (OrderBySquare(false))
            {
                (this as IViewable).ShowTrianglesIEnumerator("Triangles are ordered by square in descending order:");
            }

            Input.Wait();
        }

        protected bool OrderBySquare(bool ascending = true)
        {
            if (_triangles == null || _triangles.Count <= 1)
            {
                return false;
            }

            if (ascending)
            {
                var dictVarAsc = from pair in _triangles
                    orderby pair.Value.GetSquare() ascending
                    select pair;

                Dictionary<string, Triangle> bufA = new Dictionary<string, Triangle>();

                foreach (KeyValuePair<string, Triangle> item in dictVarAsc.AsEnumerable())
                {
                    bufA.Add(item.Key, item.Value);
                }

                _triangles = bufA;

                return true;
            }

            var dictVarDes = from pair in _triangles
                             orderby pair.Value.GetSquare() descending
                select pair;

            Dictionary<string, Triangle> bufD = new Dictionary<string, Triangle>();

            foreach (KeyValuePair<string, Triangle> pair in dictVarDes)
            {
                bufD.Add(pair.Key, pair.Value);
            }

            _triangles = bufD;

            return true;
        }
    }
}
