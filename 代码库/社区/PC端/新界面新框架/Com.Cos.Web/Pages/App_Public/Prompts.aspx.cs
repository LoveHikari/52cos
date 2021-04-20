using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Utility;

namespace Com.Cos.Web.Pages.App_Public
{
    /// <summary>
    /// 退出账号
    /// </summary>
    public partial class Prompts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CookieHelper cookieHelper = new CookieHelper("52cos");
                cookieHelper.DeleteCookie("user_id");
                cookieHelper.DeleteCookie("pwd");
                Session["UserInfo"] = null;
            }
        }
    }
}