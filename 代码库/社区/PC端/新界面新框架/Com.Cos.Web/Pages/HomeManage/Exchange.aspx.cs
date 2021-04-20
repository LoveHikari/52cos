using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Com.Cos.Web.Pages.HomeManage
{
    /// <summary>
    /// 交换
    /// </summary>
    public partial class Exchange : BasePage2
    {
        #region 属性
        protected string User_id
        {
            set { ViewState["UserId"] = value; }
            get { return ViewState["UserId"] == null ? base.User_id : ViewState["UserId"].ToString(); }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            // DONE 交换
            if (!IsPostBack)
            {
                
            }
        }
    }
}