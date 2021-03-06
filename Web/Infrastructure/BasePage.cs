﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtilityLib.Helpers;
using UtilityLib.Models;

namespace Web.Infrastructure
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!Request.IsAuthenticated) RedirectHome();
        }

        /// <summary>
        /// If the user doesn't have rights for opening page than we redirect user to Login page
        /// </summary>
        protected void RedirectHome()
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void ShowModal(string title, string message, bool yesNo)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Common", String.Format("ShowModal('{0}', '{1}', {2});", title, message, (yesNo ? "1" : "0")), true);
        }

        protected DatabaseConnection GetDatabaseConnection()
        {
            return new DatabaseConnection();
        }

        protected T CheckModelValidation<T>(ResponseAPIModel<T> instance)
        {
            object obj = default(T);

            if (!instance.IsRequestSuccesful)
            {
                string requestFailedError = "";

                if (!String.IsNullOrEmpty(instance.ValidationError))
                {
                    instance.ValidationError = instance.ValidationError.Replace("'", "");
                    instance.ValidationError = instance.ValidationError.Replace("\\", "\\\\");
                    instance.ValidationError = instance.ValidationError.Replace("\r\n", "");
                    requestFailedError = instance.ValidationError;
                }
                else if (!String.IsNullOrEmpty(instance.ValidationErrorAppSide))
                    requestFailedError = instance.ValidationErrorAppSide.Replace("\r\n", "");

                CommonMethods.LogThis(requestFailedError);
                ShowModal("Napaka!", requestFailedError, false);

                return (T)obj;
            }
            else
            {
                obj = instance.Content;
            }

            return (T)obj;
        }
    }
}