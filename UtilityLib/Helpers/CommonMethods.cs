using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLib.Helpers
{
    public static class CommonMethods
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            if (!String.IsNullOrEmpty(base64EncodedData))
            {
                var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
                return Encoding.UTF8.GetString(base64EncodedBytes);
            }
            return "";
        }

        public static void LogThis(string message)
        {
            bool enableLogging = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableLogging"].ToString());

            if (enableLogging)
            {
                var directory = AppDomain.CurrentDomain.BaseDirectory;
                string sMsg = DateTime.Now + " " + message + Environment.NewLine;

                File.AppendAllText(directory + "log.txt", sMsg);
            }
        }
    }
}
