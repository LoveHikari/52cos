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
    /// 用户中心
    /// </summary>
    public partial class Dashboard : BasePage2
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
            // 用户中心
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
            // 初始化评论
            DataTable replyTable = ReplyBll.Instance.GetList(10, $"User_id='{User_id}'", "ReleaseTime DESC");
            DataTable commentTable = new DataTable();
            commentTable.Columns.Add("workId");
            commentTable.Columns.Add("type");
            commentTable.Columns.Add("cover");
            commentTable.Columns.Add("WorksTitle");
            foreach (DataRow dataRow in replyTable.Rows)
            {
                DataRow dr = commentTable.NewRow();
                dr["workId"] = dataRow["workId"];
                dr["type"] = dataRow["type"];
                if (dataRow["type"].ToString() == "works")  //作品
                {
                    WorksEntity worksEntity = WorksBll.Instance.GetModel(int.Parse(dataRow["workId"].ToString()));
                    dr["cover"] = worksEntity.cover;
                    dr["WorksTitle"] = worksEntity.WorksTitle;
                }
                if (dataRow["type"].ToString() == "reprint")  //合作
                {
                    CooperationEntity cooperationEntity = CooperationBll.Instance.GetModel(int.Parse(dataRow["workId"].ToString()));
                    dr["cover"] = cooperationEntity.cover;
                    dr["WorksTitle"] = cooperationEntity.title;
                }
                if (dataRow["type"].ToString() == "activity")  //活动
                {
                    ActivityEntity activityEntity = ActivityBll.Instance.GetModel(int.Parse(dataRow["workId"].ToString()));
                    dr["cover"] = activityEntity.cover;
                    dr["WorksTitle"] = activityEntity.title;
                }
            }
            repComment.DataSource = commentTable;
            repComment.DataBind();
            //初始化文章
            dt = WorksBll.Instance.GetList(10, $"User_id='{User_id}'", "ReleaseTime DESC");
            repArticle.DataSource = dt;
            repArticle.DataBind();
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
            if (int.Parse(integral) > 0)
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