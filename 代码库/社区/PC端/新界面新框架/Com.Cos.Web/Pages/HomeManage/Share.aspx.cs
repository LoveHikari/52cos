using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Com.Cos.Web.Pages.HomeManage
{
    /// <summary>
    /// 交换、出租
    /// </summary>
    public partial class Share : BasePage
    {
        protected string type;
        #region 属性
        protected string User_id
        {
            set { ViewState["UserId"] = value; }
            get { return ViewState["UserId"] == null ? base.User_id : ViewState["UserId"].ToString(); }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                type = Context.Request.QueryString["t"];
                if (type == "rent")  //出租
                {
                    
                }
                else if(type == "enchange")  //交换
                {
                    
                }
            }
        }
    }
}