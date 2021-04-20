using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;

namespace Com.Cos.Web.Pages.ShowManage
{
    /// <summary>
    /// 选择收货地址
    /// </summary>
    public partial class SelectAddress : System.Web.UI.Page
    {
        protected string userId;
        protected string exId;
        protected string type;
        protected string classId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userId = Context.Request.QueryString["uid"];
                exId = Context.Request.QueryString["exId"];
                type = Context.Request.QueryString["t"];
                classId = Context.Request.QueryString["classId"];
                BindData();
            }
        }

        private void BindData()
        {
            DataTable addressTable = MailingAddressBll.Instance.GetList("UserId='"+userId+"' and status='1'").Tables[0];
            repAddress.DataSource = addressTable;
            repAddress.DataBind();

        }
    }
}