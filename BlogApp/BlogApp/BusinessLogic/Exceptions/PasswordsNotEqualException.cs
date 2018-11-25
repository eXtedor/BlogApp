using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLogic.Exceptions
{
    class PasswordsNotEqualException : Exception
    {
        public PasswordsNotEqualException()
        {
        }
        public PasswordsNotEqualException(string message)
        : base(message)
        {
        }
        public PasswordsNotEqualException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
