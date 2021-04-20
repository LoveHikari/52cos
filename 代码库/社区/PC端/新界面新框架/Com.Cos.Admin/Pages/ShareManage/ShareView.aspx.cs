using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Admin.Pages.ShareManage
{
    public partial class ShareView : BasePage
    {
        protected string show;
        #region 属性
        /// <summary>
        /// 分享实体
        /// </summary>
        protected ExchangeEntity ExchangeEntity { get; set; }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string exId = Context.Request.QueryString["ExId"];   //分享id
                show = Context.Request.QueryString["Show"];  //view、editor
                ExchangeEntity exchangeEntity = ExchangeBll.Instance.GetModel(int.Parse(exId));
                this.ExchangeEntity = exchangeEntity;

                BindQueuePerson();
            }
        }
        #region 私有方法
        /// <summary>
        /// 绑定排队人员
        /// </summary>
        private void BindQueuePerson()
        {
            DataTable exPersonTable = ExchangePersonBll.Instance.GetList($"Status>0 AND Examine='0' AND ExId='{ExchangeEntity.Id}'").Tables[0];
            repQueuePerson.DataSource = exPersonTable;
            repQueuePerson.DataBind();
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
            DataTable sysTable = SysParaBll.Instance.GetSysParaTable("examine");
            var records = sysTable.AsEnumerable().Where(a => a["RefValue"].ToString() == examine);
            DataTable rsl = records.AsDataView().ToTable();
            return rsl.Rows[0]["RefText"].ToString();
        }
        
        #endregion
    }
}