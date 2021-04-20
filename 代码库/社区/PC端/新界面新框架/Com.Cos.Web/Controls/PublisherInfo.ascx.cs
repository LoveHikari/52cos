using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Web.Controls
{
    /// <summary>
    /// 详细页中的右边发布人信息
    /// </summary>
    public partial class PublisherInfo : System.Web.UI.UserControl
    {
        private string _userId;
        private MemberEntity memberEntity; 
        /// <summary>
        /// 发帖人id
        /// </summary>
        public string UserId
        {
            get
            {
                return _userId;
            }

            set
            {
                _userId = value;
            }
        }
        /// <summary>
        /// //发帖人
        /// </summary>
        protected MemberEntity MemberEntity
        {
            get
            {
                return memberEntity ?? MemberBll.Instance.GetModel(Convert.ToInt32(this._userId));
            }

            set
            {
                memberEntity = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}