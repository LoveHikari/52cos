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
    /// 评论
    /// </summary>
    public partial class AuthorComments : BasePage
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
            DataTable replyTable = ReplyBll.Instance.GetList($"User_id='{userId}'");
            DataTable commentTable = new DataTable();
            commentTable.Columns.Add("workId");
            commentTable.Columns.Add("type");
            commentTable.Columns.Add("cover");
            commentTable.Columns.Add("WorksTitle");
            commentTable.Columns.Add("ReplyContent");
            foreach (DataRow dataRow in replyTable.Rows)
            {
                DataRow dr = commentTable.NewRow();
                dr["workId"] = dataRow["workId"];
                dr["type"] = dataRow["type"];
                dr["ReplyContent"] = dataRow["ReplyContent"];
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