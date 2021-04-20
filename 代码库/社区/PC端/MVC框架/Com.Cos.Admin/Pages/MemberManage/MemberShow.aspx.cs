using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Common;
using Com.Cos.Models;

namespace Com.Cos.Admin.Pages.MemberManage
{
    public partial class MemberShow : System.Web.UI.Page
    {
        private readonly Com.Cos.IBLL.IMemberService _memberService;

        private int _id;
        private Com.Cos.Models.Member _member;

        public Member Member
        {
            get { return _member; }
            set { _member = value; }
        }

        public MemberShow()
        {
            _memberService = new Com.Cos.BLL.MemberService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _id = Context.Request.QueryString.Get("id").ToInt32();
                BindData();
            }
        }

        private void BindData()
        {
            _member = _memberService.Find(_id);
        }
    }
}