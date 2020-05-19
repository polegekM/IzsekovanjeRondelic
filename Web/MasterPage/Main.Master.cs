using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Infrastructure;

namespace Web.MasterPage
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            nameInitial.InnerHtml = PrincipalHelper.GetUserPrincipal().FirstName[0].ToString();
            lblLogin.Text = PrincipalHelper.GetUserPrincipal().FirstName + " " + PrincipalHelper.GetUserPrincipal().LastName;
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            Response.Redirect("~/Login.aspx");
        }

        public string PageHeadlineTitle
        {
            get { return PageHeadline.HeaderText; }
            set { PageHeadline.HeaderText = value; }
        }
    }
}