using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Web.Pages.HomeManage
{
    /// <summary>
    /// 萌币历史
    /// </summary>
    public partial class History : BasePage2
    {
        #region 属性
        protected string User_id
        {
            set { ViewState["UserId"] = value; }
            get { return ViewState["UserId"] == null ? base.User_id : ViewState["UserId"].ToString(); }
        }
        protected MemberEntity MemberEntity
        {
            set { ViewState["MemberEntity"] = value; }
            get
            {
                return ViewState["MemberEntity"] == null
                    ? MemberBll.Instance.GetModel(Convert.ToInt32(this.User_id))
                    : ViewState["MemberEntity"] as MemberEntity;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        #region 私有方法

        private void BindData()
        {
            //初始化积分列表
            DataTable dt = IntegralChangeBll.Instance.GetList(10, $"UserId='{User_id}'", "AddTime DESC").Tables[0];
            repIntCha.DataSource = dt;
            repIntCha.DataBind();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 获得积分来源
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected string GetIntegralSource(string value)
        {
            DataTable dt = SysParaBll.Instance.GetList($"RefType='integralSource' AND RefValue='{value}'");
            return dt?.Rows?[0]["RefText"].ToString();
        }
        /// <summary>
        /// 设置积分的正负符号
        /// </summary>
        /// <param name="integral"></param>
        /// <returns></returns>
        protected string SetIntegral(string integral)
        {
            if (integral == "")
            {
                return "0";
            }
            if (decimal.Parse(integral) > 0)
            {
                return "+ " + integral;
            }
            return integral;
        }

        protected string SetImg(string refValue)
        {
            if (refValue == "dailyLogin" || refValue == "reward" || refValue == "clickLike")
            {
                return "fa-user";
            }
            if (refValue == "publishedWorks" || refValue == "publishedCoo" || refValue == "comment")
            {
                return "fa-comment-o";
            }
            return "fa-cog";
        }
        #endregion
    }
}