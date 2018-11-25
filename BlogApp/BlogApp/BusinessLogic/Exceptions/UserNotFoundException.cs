﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLogic.Exceptions
{
    class UserNotFoundException : Exception
    {
        public UserNotFoundException()
        {
        }
        public UserNotFoundException(string message)
        : base(message)
        {
        }
        public UserNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
