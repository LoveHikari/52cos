using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Api;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Web.Controls
{
    /// <summary>
    /// 详细页中的右边作者文章
    /// </summary>
    public partial class PublisherArticle : System.Web.UI.UserControl
    {
        private int _userId;
        private MemberEntity memberEntity;
        private string _type;
        /// <summary>
        /// 发帖人id
        /// </summary>
        public int UserId
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
                return memberEntity ?? MemberBll.Instance.GetModel(this._userId);
            }

            set
            {
                memberEntity = value;
            }
        }
        /// <summary>
        /// 文章类型
        /// </summary>
        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
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
            #region 作者文章
            string ss = "";
            if (_type == "works")
            {
                DataTable worksTable = WorksBll.Instance.GetList(12, "", "ReleaseTime DESC");
                foreach (DataRow dataRow in worksTable.Rows)
                {
                    ss += "<article class=\"g-phone-1-2 card xs\">";
                    ss += $"   <a class=\"card-bg\" href=\"/Pages/ShowManage/View.aspx?nid={dataRow["WorksId"]}&type=works\" title=\"{dataRow["WorksTitle"]}\" target=\"_blank\">";
                    ss += "      <div class=\"thumbnail-container\">";
                    ss += $"          <img class=\"thumbnail\" src=\"/Style/img/46201453_10.gif\" data-src=\"{WorksApi.GetCover(dataRow["cover"].ToString())}\" alt=\"{dataRow["WorksTitle"]}\" width=\"320\" height=\"180\">";
                    ss += "      </div>";
                    ss += $"      <h3 class=\"title\">{dataRow["WorksTitle"]}</h3>";
                    ss += "   </a>";
                    ss += "</article>";
                }

            }
            if (_type == "reprint")
            {
                DataTable reprintTable = CooperationBll.Instance.GetList(12, "", "ReleaseTime DESC");
                foreach (DataRow dataRow in reprintTable.Rows)
                {
                    ss += "<article class=\"g-phone-1-2 card xs\">";
                    ss += $"   <a class=\"card-bg\" href=\"/Pages/ShowManage/View.aspx?nid={dataRow["id"]}&type=reprint\" title=\"{dataRow["title"]}\" target=\"_blank\">";
                    ss += "      <div class=\"thumbnail-container\">";
                    ss += $"          <img class=\"thumbnail\" src=\"/Style/img/46201453_10.gif\" data-src=\"{WorksApi.GetCover(dataRow["cover"].ToString())}\" alt=\"{dataRow["title"]}\" width=\"320\" height=\"180\">";
                    ss += "      </div>";
                    ss += $"      <h3 class=\"title\">{dataRow["title"]}</h3>";
                    ss += "   </a>";
                    ss += "</article>";
                }
            }
            if (_type == "activity")
            {
                DataTable activityTable = ActivityBll.Instance.GetList(12, "", "ReleaseTime DESC");
                foreach (DataRow dataRow in activityTable.Rows)
                {
                    ss += "<article class=\"g-phone-1-2 card xs\">";
                    ss += $"   <a class=\"card-bg\" href=\"/Pages/ShowManage/View.aspx?nid={dataRow["id"]}&type=activity\" title=\"{dataRow["title"]}\" target=\"_blank\">";
                    ss += "      <div class=\"thumbnail-container\">";
                    ss += $"          <img class=\"thumbnail\" src=\"/Style/img/46201453_10.gif\" data-src=\"{WorksApi.GetCover(dataRow["cover"].ToString())}\" alt=\"{dataRow["title"]}\" width=\"320\" height=\"180\">";
                    ss += "      </div>";
                    ss += $"      <h3 class=\"title\">{dataRow["title"]}</h3>";
                    ss += "   </a>";
                    ss += "</article>";
                }
            }
            #endregion
            litArticle.Text = ss;
        }
    }
}