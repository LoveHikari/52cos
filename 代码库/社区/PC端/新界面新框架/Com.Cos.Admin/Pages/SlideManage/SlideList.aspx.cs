using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;

namespace Com.Cos.Admin.Pages.SlideManage
{
    public partial class SlideList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        #region 事件
        /// <summary>
        /// 搜索按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void butSearch_OnServerClick(object sender, EventArgs e)
        {
            DataTable worksTable = SlideBll.Instance.GetList(GetQueryParams());
            repSlide.DataSource = worksTable;
            repSlide.DataBind();
        }
        #endregion
        #region 私有方法
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            DataTable slideTable = SlideBll.Instance.GetList("");
            repSlide.DataSource = slideTable;
            repSlide.DataBind();
        }
        /// <summary>
        /// 获取搜索参数
        /// </summary>
        /// <returns></returns>
        private IDictionary<string, string> GetQueryParams()
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>();
            if (this.selSign.Value != string.Empty)
            {
                queryParams.Add("Sign", this.selSign.Value);
            }
            if (this.txtText.Value != string.Empty)
            {
                queryParams.Add("Text", this.txtText.Value);
            }

            if (this.txtTime.Value != string.Empty)
            {
                queryParams.Add("Time", this.txtTime.Value);
            }
            return queryParams;
        }
        #endregion
        #region 方法
        /// <summary>
        /// 设置标志文本
        /// </summary>
        /// <param name="sign">标志</param>
        /// <returns></returns>
        protected string SetSign(string sign)
        {
            switch (sign)
            {
                case "1":
                    return "幻灯片";
                case "2":
                    return "大海报";
                default:
                    return "幻灯片";
            }
        }
        #endregion
    }
}