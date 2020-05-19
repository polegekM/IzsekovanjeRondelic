using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLib.Helpers
{
    public class ExceptionValidationHelper
    {
        private static string exceptionMessage = "";
        public static string GetExceptionSource(Exception ex)
        {
            exceptionMessage = "";
            InnerExceptionExist(ex.InnerException);
            return ex.Message + "\r\n" + (ex.InnerException != null ? exceptionMessage + "\r\n" : "");

        }

        public static void InnerExceptionExist(Exception ex)
        {
            if (ex != null)
            {
                exceptionMessage += ex.Message;

                InnerExceptionExist(ex.InnerException);
            }
        }
    }
}
