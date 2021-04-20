using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Com.Cos.Admin.Pages.MemberManage
{
    public partial class MemberList : System.Web.UI.Page
    {
        private readonly Com.Cos.IBLL.IMemberService _memberService;
        public  MemberList()
        {
            _memberService = new Com.Cos.BLL.MemberService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            var members = _memberService.FindList().ToList();
            this.repMember.DataSource = members;
            this.repMember.DataBind();
        }
        /// <summary>
        /// 获得性别
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public string GetGender(object gender)
        {
            string sex = gender?.ToString();
            switch (sex)
            {
                case "0":
                    return "女";
                case "1":
                    return "男";
                default:
                    return "未知";
            }
            
        }
        /// <summary>
        /// 设置状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public string GetStatus(object status)
        {
            string s = status?.ToString();
            switch (s)
            {
                case "0":
                    return "停用";
                case "1":
                    return "启用";
                default:
                    return "未知";
            }
        }

    }
}