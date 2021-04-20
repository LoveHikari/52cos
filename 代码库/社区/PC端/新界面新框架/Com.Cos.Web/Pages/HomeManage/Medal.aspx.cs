using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Web.Pages.HomeManage
{
    /// <summary>
    /// 勋章
    /// </summary>
    public partial class Medal : BasePage2
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

        private void BindData()
        {
            //勋章列表
            DataTable medalDataTable = MedalBll.Instance.GetAllList();
            repMedal.DataSource = medalDataTable;
            repMedal.DataBind();
            //我的勋章列表
            DataTable dt = PersonMedalBll.Instance.GetList("pm.userId='" + User_id + "'");
            repMyMedal.DataSource = dt;
            repMyMedal.DataBind();
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