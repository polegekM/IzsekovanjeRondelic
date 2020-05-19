using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using UtilityLib.Exceptions;
using UtilityLib.Helpers;
using UtilityLib.Models;
using UtilityLib.Models.User;
using UtilityLib.Resources;

namespace Web.Infrastructure
{
    public class Authentication
    {
        DatabaseConnection db;

        public Authentication()
        {
            db = new DatabaseConnection();
        }

        public bool Authenticate(string username, string password)
        {
            ResponseAPIModel<UserModel> user = null;
            password = CommonMethods.Base64Encode(password);
            user = db.SignIn(username, password);

            if (!user.IsRequestSuccesful)
                throw new UserCredentialsException(user.ValidationError);

            SerializeUser(user.Content);

            return true;
        }

        private void SerializeUser(UserModel user)
        {
            if (user != null)
            {
                string sessionExpires = ConfigurationManager.AppSettings["SessionTimeoutInMinutes"].ToString();

                
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                string userData = serializer.Serialize(user);
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                     1,
                     Guid.NewGuid().ToString(),
                     DateTime.Now,
                     DateTime.Now.AddMinutes(CommonMethods.ParseDouble(sessionExpires)),
                     false,
                     userData);

                string encTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket) { HttpOnly = false, Expires = DateTime.Now.AddMonths(1) };
                HttpContext.Current.Response.Cookies.Add(faCookie);
            }
            else
                throw new UserCredentialsException(ExceptionsRes.res_01);
        }
    }
}