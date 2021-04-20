using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;

namespace Com.Cos.Web.Pages.HomeManage
{
    /// <summary>
    /// 文章投稿
    /// </summary>
    public partial class Contributions : BasePage2
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            DataTable dt = SysParaBll.Instance.GetSysParaTable("noteType");
            string s = "<option value=''>选择类别</option>";
            foreach (DataRow row in dt.Rows)
            {
                s += "<option value='" + row["id"] + "' title=''>"+ row["RefText"] + "</option>";
            }
            litType1.Text = s;
        }
    }
}