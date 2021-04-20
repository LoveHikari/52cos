/**
 * 会员信息
 * 
 */

using System;
using System.Data;
using Com.Cos.Bll;

namespace Com.Cos.Admin.Pages.MemberManage
{
    /// <summary>
    /// 会员列表
    /// </summary>
    public partial class MemberInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void BindData()
        {
            DataTable memberTable = MemberBll.Instance.GetList("").Tables[0];
            repMember.DataSource = memberTable;
            repMember.DataBind();
        }

        #region 方法
        /// <summary>
        /// 设置性别图标
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        protected string SetGender(string gender)
        {
            switch (gender)
            {
                case "1":
                    return "fa-mars-double";
                case "0":
                    return "fa-venus-double";
                default:
                    return "fa-venus-mars";
            }
        }
        #endregion
    }
}