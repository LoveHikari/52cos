using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;

namespace Com.Cos.Web.Pages.App_Master
{
    public partial class AccountMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindData();
            }
        }

        private void BindData()
        {
            DataTable dt = MenuModuleBll.Instance.GetList(0, "ParentType='0001' AND Status=1", "RefType").Tables[0];
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
}