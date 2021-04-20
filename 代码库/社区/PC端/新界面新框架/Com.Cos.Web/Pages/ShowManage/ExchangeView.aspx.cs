using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Web.Pages.ShowManage
{
    /// <summary>
    /// 交换详情页
    /// </summary>
    public partial class ExchangeView : BasePage
    {
        protected string uid; //发帖人
        protected ExchangeEntity exchangeEntity;
        protected MemberEntity uMemberEntity;
        #region 属性
        protected string User_id  //登录人的id
        {
            set { ViewState["UserId"] = value; }
            get { return ViewState["UserId"] == null ? base.User_id : ViewState["UserId"].ToString(); }
        }
        /// <summary>
        /// 登录人
        /// </summary>
        protected MemberEntity MemberEntity
        {
            set { ViewState["MemberEntity"] = value; }
            get
            {
                return ViewState["MemberEntity"] == null
                    ? MemberBll.Instance.GetModel(Convert.ToInt32(User_id))
                    : ViewState["MemberEntity"] as MemberEntity;
            }
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string exId = Request.QueryString["nid"];  //交换id
                exchangeEntity = ExchangeBll.Instance.GetModel(Convert.ToInt32(exId));
                uid = exchangeEntity.UserId;
                uMemberEntity = MemberBll.Instance.GetModel(Convert.ToInt32(uid));
                PublisherInfo.UserId = uid;

                BindImage();
                BindCertificate();
            }
        }
        #region 方法
        /// <summary>
        /// 绑定凭证
        /// </summary>
        private void BindCertificate()
        {
            string img = exchangeEntity.Certificate;
            string s = "";
            if (!string.IsNullOrEmpty(img))
            {
                ImgEntity imgEntity = ImgBll.Instance.GetModel(int.Parse(img));
                s += $"<img src='{imgEntity.ImgUrl.Replace("\\", "/")}' alt=''>";
            }
            
            litCertificate.Text = s;
        }

        /// <summary>
        /// 绑定图片
        /// </summary>
        private void BindImage()
        {
            string[] imgs = exchangeEntity.Imgs.Split(',');
            string s = "";
            foreach (string t in imgs)
            {
                ImgEntity imgEntity = ImgBll.Instance.GetModel(int.Parse(t));
                s += $"<img src='{imgEntity.ImgUrl.Replace("\\", "/")}' alt=''>";
            }
            litImgList.Text = s;
        }
        #endregion

    }
}