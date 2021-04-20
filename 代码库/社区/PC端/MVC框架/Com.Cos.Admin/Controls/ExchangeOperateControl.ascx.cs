using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Com.Cos.Admin.Controls
{
    public partial class ExchangeOperateControl : System.Web.UI.UserControl
    {
        private string _examineName;

        [Personalizable(), WebBrowsable(true), WebDescription("这是一个整形的参数"), WebDisplayName("请输入一个字符串")]
        public string ExamineName
        {
            get { return _examineName; }
            set {  _examineName= value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}