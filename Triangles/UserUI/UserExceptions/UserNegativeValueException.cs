using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangles.UserUI.UserExceptions
{
    class UserNegativeValueException: UserInvalidFormatException
    {
        public const string MESSAGE_ENTERED = "UserNegativeValueException: entered value ";
        public const string MESSAGE_CAUSE = "is negative.";
        public const string MESSAGE_PLEASE = "Please, enter a positive value.";

        public UserNegativeValueException()
           : base(string.Format("{0}{1}{2}",MESSAGE_ENTERED, MESSAGE_CAUSE, MESSAGE_PLEASE))
        {
        }

        public UserNegativeValueException(string inputValue)
            : base(string.Format("{0}{1}{2}{3}", MESSAGE_ENTERED, inputValue, MESSAGE_CAUSE, MESSAGE_PLEASE))
        {
            _inputValue = inputValue;
        }

        public UserNegativeValueException(string inputValue, string message)
            : base(message)
        {
            _inputValue = inputValue;
        }

        public UserNegativeValueException(string inputValue, Exception innerException)
            : base(string.Format("{0}{1}{2}{3}", MESSAGE_ENTERED, inputValue, MESSAGE_CAUSE, MESSAGE_PLEASE), innerException)
        {
        }

        public UserNegativeValueException(string inputValue, string message, Exception innerException)
            : base(message, innerException)
        {
            _inputValue = inputValue;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}", MESSAGE_ENTERED, MESSAGE_CAUSE, MESSAGE_PLEASE);
        }
    }

    
}
