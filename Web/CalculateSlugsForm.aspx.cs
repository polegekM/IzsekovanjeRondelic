using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityLib.Helpers;
using Web.Infrastructure;

namespace Web
{
    public partial class CalculateSlugsForm : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Master.PageHeadlineTitle = Title;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            var model = CheckModelValidation(GetDatabaseConnection().GetSlugsSum(
                CommonMethods.ParseInt(txtLength.Text),
                CommonMethods.ParseInt(txtWidth.Text),
                CommonMethods.ParseDecimal(txtRadius.Text),
                CommonMethods.ParseDecimal(txtLengthEdge.Text),
                CommonMethods.ParseDecimal(txtWidthEdge.Text),
                CommonMethods.ParseDecimal(txtMinDistanceSlugs.Text)));

            if (model != null)
                Response.Redirect("SlugsTable.aspx");
        }
    }
}