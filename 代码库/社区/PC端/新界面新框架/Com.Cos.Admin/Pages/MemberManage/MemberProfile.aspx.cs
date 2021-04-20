using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Admin.Pages.MemberManage
{
    /// <summary>
    /// 会员详情页
    /// </summary>
    public partial class MemberProfile : BasePage
    {
        #region 属性
        protected MemberEntity MemberEntity { get; set; }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userId = Context.Request.QueryString["id"];
                if (userId != "")
                {
                    this.MemberEntity = MemberBll.Instance.GetModel(Convert.ToInt32(userId));
                }
            }
        }
    }
}