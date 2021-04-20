using System;

namespace Com.Cos.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/App_Public/Index.aspx");
        }
    }
}