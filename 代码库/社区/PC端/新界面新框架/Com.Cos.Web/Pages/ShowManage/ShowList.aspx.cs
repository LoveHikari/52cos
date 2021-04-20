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
    public partial class ShowList : BasePage
    {
        protected string type = "";
        private string page = "";
        private int index;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                type = Context.Request.QueryString["type"];  //类型
                page = Context.Request.QueryString["page"];  //页码

                if (int.Parse(page) <= 1)
                {
                    index = 1;
                }
                else
                {
                    index = int.Parse(page);
                }
                if (type == "")
                {
                    throw new AppDomainUnloadedException("未捕捉到查询条件");
                }
                BindData();
            }
        }

        #region 私有方法
        private void BindData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("userId");
            dt.Columns.Add("WorksId");
            dt.Columns.Add("type");
            dt.Columns.Add("workstype");
            dt.Columns.Add("type2");
            dt.Columns.Add("WorksTitle");
            dt.Columns.Add("cover");
            dt.Columns.Add("nickname");
            dt.Columns.Add("Portrait");
            dt.Columns.Add("ReleaseTime");
            //取类型
            DataTable sysTable = SysParaBll.Instance.GetSysParaTable("noteType");
            string[] noteTypes = sysTable.AsEnumerable().Select(r => r.Field<string>("RefValue")).ToArray();
            if (type == "works")
            {
                DataTable cosTable = WorksBll.Instance.GetListByPage("", "ReleaseTime DESC", 40 * (index - 1) + 1, 40 * index);
                foreach (DataRow dataRow in cosTable.Rows)
                {
                    DataRow dr = dt.NewRow();
                    dr["userId"] = dataRow["User_id"];
                    dr["WorksId"] = dataRow["WorksId"];
                    dr["type"] = "works";
                    dr["workstype"] = dataRow["workstype"];
                    dr["type2"] = dataRow["type2"];
                    dr["WorksTitle"] = dataRow["WorksTitle"];
                    dr["cover"] = dataRow["cover"];
                    dr["nickname"] = dataRow["nickname"];
                    dr["Portrait"] = dataRow["Portrait"];
                    dr["ReleaseTime"] = dataRow["ReleaseTime"];
                    dt.Rows.Add(dr);
                }
                int count = WorksBll.Instance.GetRecordCount("");
                GetPages(count);
            }
            else if (noteTypes.Contains(type)) //是否是作品
            {
                string typeId = sysTable.AsEnumerable().Where(p => p.Field<string>("RefValue") == type).ToArray()[0][0].ToString();
                DataTable cosTable = WorksBll.Instance.GetListByPage($"WorksType='{typeId}'", "ReleaseTime DESC", 40 * (index - 1) + 1, 40 * index);
                foreach (DataRow dataRow in cosTable.Rows)
                {
                    DataRow dr = dt.NewRow();
                    dr["userId"] = dataRow["User_id"];
                    dr["WorksId"] = dataRow["WorksId"];
                    dr["type"] = "works";
                    dr["workstype"] = dataRow["workstype"];
                    dr["type2"] = dataRow["type2"];
                    dr["WorksTitle"] = dataRow["WorksTitle"];
                    dr["cover"] = dataRow["cover"];
                    dr["nickname"] = dataRow["nickname"];
                    dr["Portrait"] = dataRow["Portrait"];
                    dr["ReleaseTime"] = dataRow["ReleaseTime"];
                    dt.Rows.Add(dr);
                }
                int count = WorksBll.Instance.GetRecordCount($"WorksType='{typeId}'");
                GetPages(count);
            }
            else if (type == "reprint")  //合作
            {
                DataTable cosTable = CooperationBll.Instance.GetListByPage("", "ReleaseTime DESC", 40 * (index - 1) + 1, 40 * index);
                foreach (DataRow dataRow in cosTable.Rows)
                {
                    DataRow dr = dt.NewRow();
                    dr["userId"] = dataRow["User_id"];
                    dr["WorksId"] = dataRow["id"];
                    dr["type"] = "reprint";
                    dr["workstype"] = dataRow["type"];
                    dr["type2"] = "";
                    dr["WorksTitle"] = dataRow["title"];
                    dr["cover"] = dataRow["cover"];
                    dr["nickname"] = dataRow["nickname"];
                    dr["Portrait"] = dataRow["Portrait"];
                    dr["ReleaseTime"] = dataRow["ReleaseTime"];
                    dt.Rows.Add(dr);
                }
                int count = CooperationBll.Instance.GetRecordCount("");
                GetPages(count);
            }
            else if (type == "activity")  //活动
            {
                DataTable cosTable = ActivityBll.Instance.GetListByPage("", "ReleaseTime DESC", 40 * (index - 1) + 1, 40 * index);
                foreach (DataRow dataRow in cosTable.Rows)
                {
                    DataRow dr = dt.NewRow();
                    dr["userId"] = dataRow["User_id"];
                    dr["WorksId"] = dataRow["id"];
                    dr["type"] = "activity";
                    dr["workstype"] = dataRow["type"];
                    dr["type2"] = "";
                    dr["WorksTitle"] = dataRow["title"];
                    dr["cover"] = dataRow["cover"];
                    dr["nickname"] = dataRow["nickname"];
                    dr["Portrait"] = dataRow["Portrait"];
                    dr["ReleaseTime"] = dataRow["ReleaseTime"];
                    dt.Rows.Add(dr);
                }
                int count = ActivityBll.Instance.GetRecordCount("");
                GetPages(count);
            }
            else if (type == "share")  //分享
            {
                DataTable excTable = ExchangeBll.Instance.GetListByPage("", "addTime DESC", 40 * (index - 1) + 1, 40 * index).Tables[0];
                foreach (DataRow dataRow in excTable.Rows)
                {
                    MemberEntity memberEntity = MemberBll.Instance.GetModel(Convert.ToInt32(dataRow["userId"]));
                    DataRow dr = dt.NewRow();
                    dr["userId"] = dataRow["userId"];
                    dr["WorksId"] = dataRow["id"];
                    dr["type"] = "share";
                    dr["workstype"] = "";
                    dr["type2"] = "";
                    dr["WorksTitle"] = dataRow["title"];
                    dr["cover"] = dataRow["cover"];
                    dr["nickname"] = memberEntity?.nickname;
                    dr["Portrait"] = memberEntity?.Portrait;
                    dr["ReleaseTime"] = dataRow["addTime"];
                    dt.Rows.Add(dr);
                }
                int count = ExchangeBll.Instance.GetRecordCount("");
                GetPages(count);
            }
            else if (type == "rent")  //出租
            {
                DataTable excTable = RentBll.Instance.GetListByPage("", "addTime DESC", 40 * (index - 1) + 1, 40 * index).Tables[0];
                foreach (DataRow dataRow in excTable.Rows)
                {
                    MemberEntity memberEntity = MemberBll.Instance.GetModel(Convert.ToInt32(dataRow["userId"]));
                    DataRow dr = dt.NewRow();
                    dr["userId"] = dataRow["userId"];
                    dr["WorksId"] = dataRow["id"];
                    dr["type"] = "rent";
                    dr["workstype"] = "";
                    dr["type2"] = "";
                    dr["WorksTitle"] = dataRow["title"];
                    dr["cover"] = dataRow["cover"];
                    dr["nickname"] = memberEntity?.nickname;
                    dr["Portrait"] = memberEntity?.Portrait;
                    dr["ReleaseTime"] = dataRow["addTime"];
                    dt.Rows.Add(dr);
                }
                int count = RentBll.Instance.GetRecordCount("");
                GetPages(count);
            }
            repList.DataSource = dt;
            repList.DataBind();
            nextpage.HRef = $"/Pages/ShowManage/ShowList.aspx?type={type}&page={index + 1}";
        }
        /// <summary>
        /// 设置页码
        /// </summary>
        /// <param name="count">记录数</param>
        private void GetPages(int count)
        {
            count = (int)Math.Ceiling(count / 40.0);
            string s = "<select id=\"pagination-5384\" class=\"form-control\">";
            for (int i = 1; i <= count; i++)
            {
                string http = $"/Pages/ShowManage/ShowList.aspx?type={type}&page={i}";
                if (i == index)
                {
                    s += $"<option selected value=\"{http}\">第 {i} 页</option>";
                }
                else
                {
                    s += $"<option value=\"{http}\">第 {i} 页</option>";
                }

            }
            s += "</select>";
            litPages.Text = s;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 获取封面地址
        /// </summary>
        /// <param name="cover">封面id</param>
        /// <returns></returns>
        protected string GetCover(string cover)
        {
            if (!string.IsNullOrEmpty(cover))
            {
                SmallImgEntity smallImgEntity = SmallImgBll.Instance.GetModel(Convert.ToInt32(cover));
                return smallImgEntity?.ImgUrl;
            }
            return "";
        }

        protected string SetTypeTxt()
        {
            switch (type)
            {
                case "works":
                    return "作品图集";
                case "cos":
                    return "COS图集";
                case "daily":
                    return "日常图集";
                case "painting":
                    return "绘画作品";
                case "photography":
                    return "轻小说";
                case "reprint":
                    return "合作";
                case "activity":
                    return "活动";
                case "share":
                    return "兑换区";
                case "rent":
                    return "出租";
                default:
                    return "";
            }
        }
        #endregion
    }
}