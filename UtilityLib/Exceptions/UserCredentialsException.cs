using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLib.Exceptions
{
    public class UserCredentialsException : Exception
    {
        public UserCredentialsException(string message)
          : base(message)
        {
        }

        public UserCredentialsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
