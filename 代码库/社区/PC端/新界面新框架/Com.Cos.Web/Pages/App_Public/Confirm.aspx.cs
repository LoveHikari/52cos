using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;
using System.Data;
using Com.Cos.Entity;

namespace Com.Cos.Web.Pages.App_Public
{
    /// <summary>
    /// 邮箱激活
    /// </summary>
    public partial class Confirm : BasePage
    {
        protected string code;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string type = Context.Request.QueryString["type"];
                code = Context.Request.QueryString["code"];
                DateTime nowTime = DateTime.Now;
                DataTable dt = MemberBll.Instance.GetList("code='"+ code + "'").Tables[0];
                if (dt.Rows[0]["Activation"].ToString() == "1")
                {
                    cont.InnerHtml = "您已激活，无需再激活。<script language='javascript'>setTimeout('window.location.href = \"/login.html\"; ', 2000);</script>";
                }
                else if ((nowTime - Convert.ToDateTime(dt.Rows[0]["Reg_time"])).Minutes > 60)
                {
                    cont.InnerHtml = "激活链接已失效，点击重发邮件<a style='color: #009A61; text-decoration: none;' href='javascript:void(0);' onclick='js_method();'>重发邮件</a>";
                }
                else
                {
                    MemberEntity memberEntity = MemberBll.Instance.GetModel(Convert.ToInt32(dt.Rows[0]["User_id"]));
                    memberEntity.Activation = "1";
                    bool i = MemberBll.Instance.Update(memberEntity);
                    if (i)
                    {
                        cont.InnerHtml = "验证成功，正在跳转，请稍后...<script language='javascript'>setTimeout('window.location.href = \"/login.html\"; ', 2000);</script>";
                    }
                }

            }
        }
    }
}