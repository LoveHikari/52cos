using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Admin.Pages.ShareManage
{
    public partial class ShareDetail : System.Web.UI.Page
    {
        #region 属性
        protected ExchangeEntity ExchangeEntity { get; set; }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Context.Request.QueryString["id"];
                if (id != "")
                {
                    this.ExchangeEntity = ExchangeBll.Instance.GetModel(Convert.ToInt32(id));
                    BindData();
                }
            }
        }

        private void BindData()
        {
            
        }
    }
}