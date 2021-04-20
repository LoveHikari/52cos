using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.BLL;

namespace Com.Cos.Admin.Pages.ExchangeManage
{
    public partial class ExchangeList : System.Web.UI.Page
    {
        private readonly Com.Cos.IBLL.IExchangeService _exchangeService;

        public ExchangeList()
        {
            _exchangeService = new ExchangeService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private  void BindData()
        {
            var exchages = _exchangeService.GetAllExchange();
            this.repExchage.DataSource = exchages;
            this.repExchage.DataBind();
        }
        
    }
}