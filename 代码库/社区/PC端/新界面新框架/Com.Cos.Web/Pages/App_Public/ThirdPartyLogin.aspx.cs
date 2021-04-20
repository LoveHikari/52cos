using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Com.Cos.Web.Pages.App_Public
{
    /// <summary>
    /// 第三方登录
    /// </summary>
    public partial class ThirdPartyLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string uu = "";
                string code1 = uu.Split('&')[0].Split('=')[1].ToString();//获得access_token

            }
        }
    }
}