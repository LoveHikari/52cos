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
    /// 我发布的兑换
    /// </summary>
    public partial class MyReleaseExchange : BasePage2
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
            DataTable dt = ExchangeBll.Instance.GetList("UserId='"+User_id+"' AND Status='1'").Tables[0];
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        /// <summary>
        /// 获得审核标志文本
        /// </summary>
        /// <param name="examine">审核标志</param>
        /// <returns></returns>
        protected string GetExamineText(string examine)
        {
            DataTable sysTable = SysParaBll.Instance.GetSysParaTable("examine");
            var records = sysTable.AsEnumerable().Where(a => a["RefValue"].ToString() == examine);
            DataTable rsl = records.AsDataView().ToTable();
            return rsl.Rows[0]["RefText"].ToString();
        }
    }
}