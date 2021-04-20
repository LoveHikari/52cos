using System;
using Com.Cos.Utility;

namespace Com.Cos.Web
{
    public class BasePage2:BasePage
    {
        protected const string LOGIN_PAGE = "/login.html";
        public BasePage2()
        {
            Load += new EventHandler(BasePage2_Load);
        }
        void BasePage2_Load(object sender, EventArgs e)
        {
            //if (Session["UserInfo"] == null)
            //{
            //    CookieHelper cookieHelper = new CookieHelper("52cos");
            //    cookieHelper.DeleteCookie("user_id");
            //    cookieHelper.DeleteCookie("pwd");
            //    string strAppRoot = GetRootURI();
            //    string strUrl = strAppRoot + LOGIN_PAGE;
            //    Response.Redirect(strUrl, true);
            //}

        }
    }
}