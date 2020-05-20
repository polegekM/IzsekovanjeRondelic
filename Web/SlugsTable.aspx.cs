using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Infrastructure;

namespace Web
{
    public partial class SlugsTable : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Master.PageHeadlineTitle = Title;
            GridViewSlugs.Settings.GridLines = GridLines.Both;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewSlugs.DataBind();
            }
        }

        protected void GridViewSlugs_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).DataSource = CheckModelValidation(GetDatabaseConnection().GetProducts());
        }
    }
}