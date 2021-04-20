using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Web.Pages.AuthorManage
{
    /// <summary>
    /// 稿件
    /// </summary>
    public partial class AuthorWorks : BasePage
    {
        private string userId = "";
        protected MemberEntity MemberEntity { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userId = Context.Request.QueryString["id"];
                if (!string.IsNullOrEmpty(userId))
                {
                    this.MemberEntity = MemberBll.Instance.GetModel(int.Parse(userId));
                    BindData();
                }
            }
        }

        #region 私有方法

        private void BindData()
        {
            DataTable dt = WorksBll.Instance.GetList($"User_id='{userId}' and status='1'");
            repArticle.DataSource = dt;
            repArticle.DataBind();
        }
        #endregion
        #region 方法
        /// <summary>
        /// 获取封面地址
        /// </summary>
        /// <param name="cover">封面id</param>
        /// <returns></returns>
        protected string GetCover(string cover)
        {
            if (!string.IsNullOrEmpty(cover))
            {
                SmallImgEntity smallImgEntity = SmallImgBll.Instance.GetModel(Convert.ToInt32(cover));
                return smallImgEntity.ImgUrl;
            }
            return "";
        }
        #endregion
    }
}