using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using UtilityLib.Helpers;
using UtilityLib.Models;
using UtilityLib.Models.Product;
using UtilityLib.Models.User;

namespace Web.Infrastructure
{
    public class DatabaseConnection
    {
        public ResponseAPIModel<UserModel> SignIn(string username, string password)
        {
            ResponseAPIModel<UserModel> user = new ResponseAPIModel<UserModel>();
            try
            {
                user = GetResponseFromWebRequest<ResponseAPIModel<UserModel>>(WebServiceURIHelper.SignIn(username, password), "get");
            }
            catch (Exception ex)
            {
                user.ValidationErrorAppSide = ConcatenateExceptionMessage(ex);
            }
            return user;
        }

        public ResponseAPIModel<List<ProductModel>> GetProducts()
        {
            ResponseAPIModel<List<ProductModel>> user = new ResponseAPIModel<List<ProductModel>>();
            try
            {
                user = GetResponseFromWebRequest<ResponseAPIModel<List<ProductModel>>>(WebServiceURIHelper.GetProducts(), "get");
            }
            catch (Exception ex)
            {
                user.ValidationErrorAppSide = ConcatenateExceptionMessage(ex);
            }
            return user;
        }

        public ResponseAPIModel<ProductModel> GetSlugsSum(int length, int width, decimal radius, decimal edgeLength, decimal edgeWidth, decimal minDistanceItem)
        {
            ResponseAPIModel<ProductModel> user = new ResponseAPIModel<ProductModel>();
            try
            {
                user = GetResponseFromWebRequest<ResponseAPIModel<ProductModel>>(WebServiceURIHelper.GetSlugsSum(length, width, radius, edgeLength, edgeWidth, minDistanceItem), "get");
            }
            catch (Exception ex)
            {
                user.ValidationErrorAppSide = ConcatenateExceptionMessage(ex);
            }
            return user;
        }

        private T GetResponseFromWebRequest<T>(string uri, string requestMethod)
        {
            object obj = default(T);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            if (PrincipalHelper.GetUserPrincipal() != null)
                request.Headers.Add(Enums.RequestHeader.UserToken.ToString(), PrincipalHelper.GetUserPrincipal().ID.ToString());

            request.Method = requestMethod.ToUpper();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string streamString = reader.ReadToEnd();

            obj = JsonConvert.DeserializeObject<T>(streamString);

            return (T)obj;
        }

        private T PostWebRequestData<T>(string uri, string requestMethod, T objectToSerialize)
        {
            object obj = default(T);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = requestMethod.ToUpper();
            request.ContentType = "application/json; charset=utf-8";

            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                string clientData = JsonConvert.SerializeObject(objectToSerialize);
                sw.Write(clientData);
                sw.Flush();
                sw.Close();
            }


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string streamString = reader.ReadToEnd();

            obj = JsonConvert.DeserializeObject<T>(streamString);

            return (T)obj;
        }

        private string ConcatenateExceptionMessage(Exception ex)
        {
            return ex.Message + " \r\n" + ex.Source + (ex.InnerException != null ? ex.InnerException.Message + " \r\n" + ex.Source : "");
        }
    }
}