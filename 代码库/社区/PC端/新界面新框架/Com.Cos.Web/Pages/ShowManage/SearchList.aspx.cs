using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;

namespace Com.Cos.Web.Pages.ShowManage
{
    public partial class SearchList : BasePage
    {
        protected string condition = "";  //搜索条件
        protected void Page_Load(object sender, EventArgs e)
        {
            condition = Context.Request.QueryString["s"];
            BindData();
        }

        private void BindData()
        {
            DataTable worksTable = WorksBll.Instance.GetList($"WorksTitle like '%{condition}%' or WorksContent like '%{condition}%' and status='1'");
            repList.DataSource = worksTable;
            repList.DataBind();
        }
    }
}