using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Web.Pages.NavigationManage
{
    /// <summary>
    /// 服务协议
    /// </summary>
    public partial class Agreement : System.Web.UI.Page
    {
        #region 属性
        /// <summary>
        /// 快捷导航实体
        /// </summary>
        protected QuickNavigationEntity QuickNavigationEntity
        {
            set { ViewState["QuickNavigationEntity"] = value; }
            get { return ViewState["QuickNavigationEntity"] == null ? new QuickNavigationEntity(): ViewState["QuickNavigationEntity"] as QuickNavigationEntity; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QuickNavigationEntity quickNavigationEntity = QuickNavigationBll.Instance.GetModel(1);
                this.QuickNavigationEntity = quickNavigationEntity;
            }
        }
    }
}