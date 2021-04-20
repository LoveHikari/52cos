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
    /// 评分集
    /// </summary>
    public partial class AuthorRates : BasePage
    {
        private string userId = "";
        private string page = "";
        private int index;
        protected MemberEntity MemberEntity { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userId = Context.Request.QueryString["id"];
                page = Context.Request.QueryString["page"];  //页码
                if (page == null || int.Parse(page) <= 1)
                {
                    index = 1;
                }
                else
                {
                    index = int.Parse(page);
                }
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
            DataTable cosTable = WorksBll.Instance.GetListByPage("", "ReleaseTime DESC", 40 * (index - 1) + 1, 40 * index);
            repWork.DataSource = cosTable;
            repWork.DataBind();
            //设置页码
            int count = WorksBll.Instance.GetRecordCount("");
            GetPages(count);

            nextpage.HRef = $"/Pages/ShowManage/ShowList.aspx?id={userId}&page={index + 1}";
        }
        /// <summary>
        /// 设置页码
        /// </summary>
        /// <param name="count">记录数</param>
        private void GetPages(int count)
        {
            count = (int)Math.Ceiling(count / 40.0);
            string s = "<select id=\"pagination-9818\" class=\"form-control\">";
            for (int i = 1; i <= count; i++)
            {
                string http = $"/Pages/ShowManage/AuthorRates.aspx?id={userId}&page={i}";
                if (i == index)
                {
                    s += $"<option selected value=\"{http}\">第 {i} 页</option>";
                }
                else
                {
                    s += $"<option value=\"{http}\">第 {i} 页</option>";
                }

            }
            s += "</select>";
            litPages.Text = s;
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
        /// <summary>
        /// 获取评论数
        /// </summary>
        /// <param name="workId">作品id</param>
        /// <returns></returns>
        protected string GetCommentNumber(string workId)
        {
            DataTable dt = ReplyBll.Instance.GetList("workId='" + workId + "'");
            return dt.Rows.Count.ToString();
        }
        #endregion
    }
}