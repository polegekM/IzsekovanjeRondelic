using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLib.Models
{
    public class ResponseAPIModel<T>
    {
        private T responseContent;

        public bool IsRequestSuccesful
        {
            get;
            set;
        }

        public string ValidationError { get; set; }

        public string ValidationErrorAppSide { get; set; }

        public T Content
        {
            get { return responseContent; }

            set { responseContent = value; }
        }
    }
}
