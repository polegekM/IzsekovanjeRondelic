using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityLib.Exceptions;
using UtilityLib.Helpers;
using UtilityLib.Resources;
using Web.Infrastructure;

namespace Web
{
    public partial class Login : System.Web.UI.Page
    {
        Authentication auth;

        protected void Page_Init(object sender, EventArgs e)
        {
            auth = new Authentication();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated) Response.Redirect("~/Home.aspx");
        }

        protected void CallbackLogin_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            string message = "";
            string username = "";
            string password = "";

            bool signInSuccess = false;
            try
            {
                if (e.Parameter =="SignInUserCredentials")
                {
                    username = CommonMethods.Trim(txtUsername.Text);
                    password = CommonMethods.Trim(txtPassword.Text);
                }

                if (username != "" && password != "")
                {
                    signInSuccess = auth.Authenticate(username, password);
                }

            }
            catch (UserCredentialsException ex)
            {
                message = ex.Message;
            }
            catch (Exception ex)
            {
                CommonMethods.LogThis(ex.Message + "\r\n" + ex.Source + "\r\n" + ex.StackTrace);
                message = ExceptionsRes.res_01;
            }

            if (!signInSuccess)
            {
                LoginCallback.JSProperties["cpResult"] = message;
            }
        }
    }
}