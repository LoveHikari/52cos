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
    /// 资料
    /// </summary>
    public partial class Author : BasePage
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
                }
            }
        }

        #region 方法
        /// <summary>
        /// 获得作者的文章数
        /// </summary>
        /// <returns></returns>
        protected string GetArticleNum()
        {
            //文章数=作品数+合作数+活动数
            //1.取作品数
            DataTable worksTable = WorksBll.Instance.GetList("User_id='" + MemberEntity.User_id + "' and status='1'");
            int worksNum = worksTable.Rows.Count;
            //2.取合作数
            DataTable cooTable = CooperationBll.Instance.GetList("User_id='" + MemberEntity.User_id + "'");
            int cooNum = cooTable.Rows.Count;
            //3.取活动数
            DataTable activityTable = ActivityBll.Instance.GetList("User_id='" + MemberEntity.User_id + "'");
            int activityNum = activityTable.Rows.Count;

            return worksNum + cooNum + activityNum + "";
        }
        /// <summary>
        /// 获得作者的评论数
        /// </summary>
        /// <returns></returns>
        protected string GetReplyNum()
        {
            DataTable replyTable = ReplyBll.Instance.GetList("User_id='" + MemberEntity.User_id + "'");
            return replyTable.Rows.Count.ToString();
        }
        #endregion
    }
}