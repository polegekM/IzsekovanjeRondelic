using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Web.Infrastructure
{
    public static class WebServiceURIHelper
    {
        private static string BaseWebServiceURI
        {
            get
            {
                return WebConfigurationManager.AppSettings["BaseWebService"].ToString();
            }
        }

        private static string WebServiceUserURL
        {
            get
            {
                return BaseWebServiceURI + WebConfigurationManager.AppSettings["UserController"].ToString();
            }
        }

        private static string WebServiceProductURL
        {
            get
            {
                return BaseWebServiceURI + WebConfigurationManager.AppSettings["ProductController"].ToString();
            }
        }

        public static string SignIn(string username, string pass)
        {
            return WebServiceUserURL + "LogIn?username=" + username + "&password=" + pass;
        }

        public static string GetProducts()
        {
            return WebServiceProductURL + "GetProducts";
        }

        public static string SaveProduct()
        {
            return WebServiceProductURL + "SaveProduct";
        }

        public static string GetSlugsSum(int length, int width, decimal radius, decimal edgeLength, decimal edgeWidth, decimal minDistanceItem)
        {
            return WebServiceProductURL + "GetSlugsSum?length=" + length + "&width=" + width + "&radius=" + radius + "&edgeLength=" + edgeLength + "&edgeWidth=" + edgeWidth + "&minDistanceItem=" + minDistanceItem;
        }
    }
}