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
    /// 作品列表页
    /// </summary>
    public partial class Works : BasePage
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
            DataTable worksTable = WorksBll.Instance.GetList(GetQueryParams()); //获取作品
            repWorks.DataSource = worksTable;
            repWorks.DataBind();
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void BindData()
        {
            //初始化类型
            DataTable typeTable = SysParaBll.Instance.GetSysParaTable("noteType");
            ddlType.DataSource = typeTable;
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("不限", ""));

            //初始化列表
            DataTable worksTable = WorksBll.Instance.GetList(""); //获得所有作品
            repWorks.DataSource = worksTable;
            repWorks.DataBind();
        }
        /// <summary>
        /// 获得搜索条件
        /// </summary>
        /// <returns></returns>
        private IDictionary<string, string> GetQueryParams()
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>();
            if (txtTitle.Value != "")
            {
                queryParams.Add("title", txtTitle.Value);
            }
            if (ddlType.SelectedValue != "")
            {
                queryParams.Add("type", ddlType.SelectedValue);
            }
            if (txtNickname.Value != "")
            {
                queryParams.Add("nickname", txtNickname.Value);
            }
            if (txtEmail.Value != "")
            {
                queryParams.Add("email", txtEmail.Value);
            }
            if (txtTime.Value != "")
            {
                queryParams.Add("time", txtTime.Value);
            }
            return queryParams;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 获得类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetType(string id)
        {
            if (id != "")
            {
                SysParaEntity sysParaEntity = SysParaBll.Instance.GetModel(Convert.ToInt32(id));
                return sysParaEntity?.RefText;
            }
            return "";
        }
        #endregion

        
    }
}