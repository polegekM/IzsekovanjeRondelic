using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Infrastructure;

namespace Web
{
    public partial class Home : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Master.PageHeadlineTitle = Title;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}