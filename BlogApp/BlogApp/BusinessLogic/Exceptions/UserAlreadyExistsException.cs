﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLogic.Exceptions
{
    class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException()
        {
        }
        public UserAlreadyExistsException(string message)
        : base(message)
        {
        }
        public UserAlreadyExistsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
