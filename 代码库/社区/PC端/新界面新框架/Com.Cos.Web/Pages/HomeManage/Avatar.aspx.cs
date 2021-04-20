using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Web.Pages.HomeManage
{
    /// <summary>
    /// 我的头像
    /// </summary>
    public partial class Avatar :Page
    {
        //#region 属性
        //protected string User_id
        //{
        //    set { ViewState["UserId"] = value; }
        //    get { return ViewState["UserId"] == null ? base.User_id : ViewState["UserId"].ToString(); }
        //}
        //protected MemberEntity MemberEntity
        //{
        //    set { ViewState["MemberEntity"] = value; }
        //    get
        //    {
        //        return ViewState["MemberEntity"] == null
        //            ? MemberBll.Instance.GetModel(Convert.ToInt32(this.User_id))
        //            : ViewState["MemberEntity"] as MemberEntity;
        //    }
        //}

        //#endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}