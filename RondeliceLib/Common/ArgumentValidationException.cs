using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlugsLib.Common
{
    public class ArgumentValidationException :Exception
    {
        public ArgumentValidationException(string message)
         : base(message)
        {
        }

        public ArgumentValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
