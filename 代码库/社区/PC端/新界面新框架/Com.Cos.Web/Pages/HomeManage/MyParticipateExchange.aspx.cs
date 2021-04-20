using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;

namespace Com.Cos.Web.Pages.HomeManage
{
    /// <summary>
    /// 我参与的兑换
    /// </summary>
    public partial class MyParticipateExchange : BasePage2
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
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            DataTable dt = ExchangePersonBll.Instance.GetList("m.User_id='"+User_id+"' AND ep.Status='1' AND e.Status='1'", "ep.AddTime DESC").Tables[0];
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
}