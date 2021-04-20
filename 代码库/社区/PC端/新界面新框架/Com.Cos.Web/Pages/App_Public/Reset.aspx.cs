using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Web.Pages.App_Public
{
    /// <summary>
    /// 重设密码
    /// </summary>
    public partial class Reset : System.Web.UI.Page
    {
        protected string token = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string type = Context.Request.QueryString["type"];
                token = Context.Request.QueryString["token"];
                DateTime nowTime = DateTime.Now;
                DataTable dt = MemberBll.Instance.GetList("code='" + token + "'").Tables[0];
                if (dt.Rows[0]["Activation"].ToString() != "2")
                {
                    count.InnerHtml = "链接已失效";
                }
                else if ((nowTime - Convert.ToDateTime(dt.Rows[0]["Reg_time"])).Minutes > 3*60)
                {
                    count.InnerHtml = "链接已过期";
                }
                else
                {
                    MemberEntity memberEntity = MemberBll.Instance.GetModel(Convert.ToInt32(dt.Rows[0]["User_id"]));
                    email.InnerText = memberEntity.Email;
                }
            }
        }
    }
}