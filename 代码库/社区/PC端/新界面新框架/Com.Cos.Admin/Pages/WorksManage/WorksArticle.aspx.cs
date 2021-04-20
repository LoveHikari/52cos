using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Admin.Pages.WorksManage
{
    /// <summary>
    /// 作品详情页
    /// </summary>
    public partial class WorksArticle : BasePage
    {
        #region 属性
        protected WorksEntity WorksEntity { get; set; }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Context.Request.QueryString["id"];
                if (id != "")
                {
                    this.WorksEntity = WorksBll.Instance.GetModel(Convert.ToInt32(id));
                    BindData();
                }
            }
        }

        #region 私有方法
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void BindData()
        {
            //初始化标签
            string[] labels = WorksEntity.LabelDesc.Split(',');
            string s = "";
            foreach (string label in labels)
            {
                s += $"<button class=\"btn btn-white btn-xs\" type=\"button\">{label}</button>";
            }
            litLabel.Text = s;

            //初始化评论区
            DataTable dt = ReplyBll.Instance.GetList("workid='" + WorksEntity.WorksId + "'");
            repReply.DataSource = dt;
            repReply.DataBind();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 获取发布时间
        /// </summary>
        /// <param name="time">发布时间</param>
        /// <returns></returns>
        protected string GetTime(string time)
        {
            DateTime dt = Convert.ToDateTime(time);
            DateTime nowDt = DateTime.Now;
            TimeSpan ts = nowDt - dt;

            if (ts.Days >= 365)
            {
                return ts.Days / 365 + "年前";
            }
            if (ts.Days >= 30)
            {
                return ts.Days / 30 + "月前";
            }
            if (ts.Days >= 1)
            {
                return ts.Days + "天前";
            }
            if (ts.Hours >= 1)
            {
                return ts.Hours + "小时前";
            }
            if (ts.Minutes >= 1)
            {
                return ts.Minutes + "分钟前";
            }
            return (int)(ts.TotalSeconds * 1000) + "秒前";
        }
        #endregion
    }
}