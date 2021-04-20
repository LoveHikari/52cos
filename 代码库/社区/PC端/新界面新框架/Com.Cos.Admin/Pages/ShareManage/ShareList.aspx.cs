using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Api;
using Com.Cos.Bll;

namespace Com.Cos.Admin.Pages.ShareManage
{
    /// <summary>
    /// 分享列表
    /// </summary>
    public partial class ShareList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindShareList();
            }
        }
        #region 事件
        /// <summary>
        /// 绑定排队中人员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void repShareList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep = e.Item.FindControl("repQueueList") as Repeater;//找到里层的repeater对象
                DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
                string exId = rowv["Id"].ToString();
                DataTable exPersonTable = ExchangePersonBll.Instance.GetList($"Status>0 AND Examine='0' AND ExId='{exId}'").Tables[0];
                rep.DataSource = exPersonTable;
                rep.DataBind();
            }
        }
        #endregion
        #region 私有方法

        private void BindShareList()
        {
            DataTable dt = ExchangeBll.Instance.GetList("").Tables[0];
            repShareList.DataSource = dt;
            repShareList.DataBind();
        }
        #endregion
        #region 方法
        /// <summary>
        /// 获得审核标志文本
        /// </summary>
        /// <param name="examine">审核标志</param>
        /// <returns></returns>
        protected string GetExamineText(string examine)
        {
            if (examine == "")
            {
                return "";
            }
            DataTable sysTable = SysParaBll.Instance.GetSysParaTable("examine");
            var records = sysTable.AsEnumerable().Where(a => a["RefValue"].ToString() == examine);
            DataTable rsl = records.AsDataView().ToTable();
            return rsl.Rows[0]["RefText"].ToString();
        }
        /// <summary>
        /// 绑定兑换的人员
        /// </summary>
        /// <param name="exId">分享的id</param>
        /// <returns></returns>
        protected string GetExchangePerson(string exId)
        {
            DataTable exPersonTable = ExchangePersonBll.Instance.GetList($"ep.Status>0 AND ep.Examine='1' AND ExId='{exId}'", "ep.AddTime DESC").Tables[0];
            StringBuilder s = new StringBuilder();
            if (exPersonTable.Rows.Count > 0)
            {
                s.Append("<a href=\"projects.html\">");
                s.AppendFormat("<img alt=\"image\" class=\"img-circle\" src=\"{0}\" title=\"{1}\"></a>", MemberApi.GetPortraitUrl(exPersonTable.Rows[0]["User_id"].ToString()), MemberApi.GetNickname((exPersonTable.Rows[0]["User_id"].ToString())));
                s.Append("</a>");
            }
            return s.ToString();

        }
        #endregion

    }
}