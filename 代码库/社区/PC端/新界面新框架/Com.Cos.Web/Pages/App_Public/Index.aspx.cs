using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Web.Pages.App_Public
{
    /// <summary>
    /// 首页
    /// </summary>
    public partial class Index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSlide();
                BindRepList();
                BindDataCoo();
                BindDataActivity();
                BindRank();
                BindHot();
                BindRand();
                BindRecommend();
                BindTop();
            }
        }

        #region 事件
        protected void repList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //判断里层repeater处于外层repeater的哪个位置（AlternatingItemTemplate，FooterTemplate，HeaderTemplate，ItemTemplate，SeparatorTemplate）
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                Repeater repcos = (Repeater)e.Item.FindControl("repcos");
                Repeater repcos2 = (Repeater)e.Item.FindControl("repcos2");

                BindData2(drv["id"].ToString(), repcos, repcos2);


            }
        }

        protected void repRankList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //判断里层repeater处于外层repeater的哪个位置（AlternatingItemTemplate，FooterTemplate，HeaderTemplate，ItemTemplate，SeparatorTemplate）
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                Repeater repRank = (Repeater)e.Item.FindControl("repRank");

                BindRank2(repRank, drv);


            }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 绑定幻灯片和大海报
        /// </summary>
        private void BindSlide()
        {
            DataTable slideTable = SlideBll.Instance.GetList(4, "Status='1' AND Sign='1'", "weight ASC,AddTime DESC,Id DESC");
            repSlide.DataSource = slideTable;
            repSlide.DataBind();
            slideTable = SlideBll.Instance.GetList(1, "Status='1' AND Sign='2'", "weight ASC,AddTime DESC,Id DESC");
            if (slideTable.Rows.Count > 0)
            {
                string s = $"<div class=\"header-layer\" style=\"width: auto; height: 520px; background: url({slideTable.Rows?[0]["ImgUrl"]}) no-repeat; background-size: auto 100%;\"></div>";
                litPoster.Text = s;
            }
            
        }
        /// <summary>
        /// 绑定外层repeater
        /// </summary>
        private void BindRepList()
        {
            DataTable noteTypeTable = SysParaBll.Instance.GetSysParaTable("noteType");
            repList.DataSource = noteTypeTable;
            repList.DataBind();
        }
        /// <summary>
        /// 根据外层repeater绑定内部的两个repeater
        /// </summary>
        /// <param name="WorksType"></param>
        /// <param name="repcos"></param>
        /// <param name="repcos2"></param>
        private void BindData2(string worksType, Repeater repcos, Repeater repcos2)
        {
            //初始化cos/日常/绘画/摄影
            DataTable cosTable = WorksBll.Instance.GetList(3, "WorksType='" + worksType + "'", "ReleaseTime DESC,GoodNo DESC");  //获得最新赞最多的3条数据
            repcos.DataSource = cosTable;
            repcos.DataBind();
            cosTable = WorksBll.Instance.GetList(8, "WorksType='" + worksType + "'", "ReleaseTime DESC");  //获得最新的8条数据
            repcos2.DataSource = cosTable;
            repcos2.DataBind();
        }
        /// <summary>
        /// 初始化合作
        /// </summary>
        private void BindDataCoo()
        {
            //初始化合作
            //DataTable cosTable = CooperationBll.Instance.GetList(3, "", "ReleaseTime DESC");
            //repCoo.DataSource = cosTable;
            //repCoo.DataBind();
            //cosTable = CooperationBll.Instance.GetList(8, "", "ReleaseTime DESC");  //获得最新的8条数据
            //repCoo2.DataSource = cosTable;
            //repCoo2.DataBind();
        }
        /// <summary>
        /// 初始化活动
        /// </summary>
        private void BindDataActivity()
        {
            //初始化活动
            DataTable cosTable = ActivityBll.Instance.GetList(3, "", "ReleaseTime DESC");
            repAct.DataSource = cosTable;
            repAct.DataBind();
            cosTable = ActivityBll.Instance.GetList(8, "", "ReleaseTime DESC");  //获得最新的8条数据
            repAct2.DataSource = cosTable;
            repAct2.DataBind();
        }
        /// <summary>
        /// 初始化排行榜
        /// </summary>
        private void BindRank()
        {
            #region Mydt
            DateTime dtNow = DateTime.Now;
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("type");
            dt.Columns.Add("typeText");
            dt.Columns.Add("order");
            dt.Columns.Add("startTime");
            dt.Columns.Add("endTime");

            int weeks = DateFormat.GetWeekOfYear(dtNow);
            DateTime dtWeekSt, dtWeekEd;
            DateFormat.ReturnDateWeek(dtNow, out dtWeekSt, out dtWeekEd);
            DataRow dr = dt.NewRow();
            dr["id"] = 1;
            dr["type"] = "week";
            dr["typeText"] = "周";
            dr["order"] = weeks;
            dr["startTime"] = dtWeekSt.ToString("yyyy-MM-dd") + " 00:00:00";
            dr["endTime"] = dtWeekEd.ToString("yyyy-MM-dd") + " 23:59:59";
            dt.Rows.Add(dr);

            int months = dtNow.Month;
            string dtSt, dtEd;
            DateFormat.ReturnDateMonth(dtNow.Year, dtNow.Month, out dtSt, out dtEd);
            dr = dt.NewRow();
            dr["id"] = 2;
            dr["type"] = "month";
            dr["typeText"] = "月";
            dr["order"] = months;
            dr["startTime"] = dtSt + " 00:00:00";
            dr["endTime"] = dtEd + " 23:59:59";
            dt.Rows.Add(dr);

            int ranks = Convert.ToInt32(Math.Ceiling(dtNow.Month / 3.0));
            DateTime dtQuarterSt, dtQuarterEd;
            DateFormat.ReturnDatetQuarter(dtNow, out dtQuarterSt, out dtQuarterEd);
            dr = dt.NewRow();
            dr["id"] = 3;
            dr["type"] = "rank";
            dr["typeText"] = "季";
            dr["order"] = ranks;
            dr["startTime"] = dtQuarterSt.ToString("yyyy-MM-dd") + " 00:00:00";
            dr["endTime"] = dtQuarterEd.ToString("yyyy-MM-dd") + " 23:59:59";
            dt.Rows.Add(dr);

            int years = dtNow.Year;
            dr = dt.NewRow();
            dr["id"] = 4;
            dr["type"] = "year";
            dr["typeText"] = "年";
            dr["order"] = years;
            dr["startTime"] = dtNow.Year + "-1-1" + " 00:00:00";
            dr["endTime"] = dtNow.Year + "-12-31" + " 23:59:59";
            dt.Rows.Add(dr);
            #endregion

            repRankList.DataSource = dt;
            repRankList.DataBind();
        }
        private void BindRank2(Repeater repRank, DataRowView drv)
        {
            //1.周/月/季/年排行榜
            DataTable dt = WorksBll.Instance.GetList(5, $"ReleaseTime>='{drv["startTime"]}' AND ReleaseTime<='{drv["endTime"]}'", "ReleaseTime DESC");
            repRank.DataSource = dt;
            repRank.DataBind();
        }
        /// <summary>
        /// 初始化今日热门
        /// </summary>
        private void BindHot()
        {
            DateTime nowTime = DateTime.Now;
            string firstDay = nowTime.ToString("yyyy-MM-dd") + " 00:00:00";
            string lastDay = nowTime.ToString("yyyy-MM-dd") + " 23:59:59";
            DataTable cosTable = WorksBll.Instance.GetList(3, " ReleaseTime>'" + firstDay + "' AND ReleaseTime<'" + lastDay + "'", "GoodNo DESC");  //获得本日赞最多的3条数据
            repHot.DataSource = cosTable;
            repHot.DataBind();
        }
        /// <summary>
        /// 初始化随机推荐
        /// </summary>
        private void BindRand()
        {
            DataTable cosTable = WorksBll.Instance.GetRandList(11, "", "WorksId");
            repRand.DataSource = cosTable;
            repRand.DataBind();
        }
        /// <summary>
        /// 初始化推荐
        /// </summary>
        private void BindRecommend()
        {
            DataTable cosTable = WorksBll.Instance.GetList(8, "Status>0 AND Recommend='1'", "ReleaseTime DESC");
            repRecommend.DataSource = cosTable;
            repRecommend.DataBind();
        }
        /// <summary>
        /// 初始化排头
        /// </summary>
        private void BindTop()
        {
            DataTable dt = WorksBll.Instance.GetList(4, "Status>0 AND Sticky='1'", "ReleaseTime DESC");
            repTop.DataSource = dt;
            repTop.DataBind();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 修改标题
        /// </summary>
        /// <param name="refText"></param>
        /// <returns></returns>
        protected string Gettitle(string refText)
        {
            string title = String.Empty;
            switch (refText)
            {
                case "cos":
                    title = "COS图集";
                    break;
                case "日常":
                    title = "日常图集";
                    break;
                case "绘画":
                    title = "绘画作品";
                    break;
                case "轻小说":
                    title = "轻小说";
                    break;
                default:
                    title = "其他";
                    break;
            }
            return title;
        }
        /// <summary>
        /// 修改样式
        /// </summary>
        /// <param name="refText"></param>
        /// <returns></returns>
        protected string GetStyle(string refText)
        {
            string style = String.Empty;
            switch (refText)
            {
                case "cos":
                    style = "fa fa-picture-o";
                    break;
                case "日常":
                    style = "fa fa-header";
                    break;
                case "绘画":
                    style = "fa fa-gamepad";
                    break;
                case "摄影":
                    style = "fa fa-video-camera";
                    break;
                default:
                    style = "fa fa-picture-o";
                    break;
            }
            return style;
        }
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
                return smallImgEntity.ImgUrl?.Replace("\\", "/");
            }
            return "";
        }
        /// <summary>
        /// 获取评论数
        /// </summary>
        /// <param name="workId">作品id</param>
        /// <returns></returns>
        protected string GetCommentNumber(string workId)
        {
            DataTable dt = ReplyBll.Instance.GetList("workId='" + workId + "'");
            return dt.Rows.Count.ToString();
        }
        /// <summary>
        /// 获取发布时间
        /// </summary>
        /// <param name="releaseTime">发布时间</param>
        /// <returns></returns>
        protected string GetTime(string releaseTime)
        {
            DateTime dt = Convert.ToDateTime(releaseTime);
            DateTime nowDt = DateTime.Now;
            TimeSpan ts = nowDt - dt;

            if (ts.Days >= 365)
            {
                return ts.Days / 365 + "年前";
            }
            if (ts.Days >= 30)
            {
                return ts.Days / 30 + "月前";
            }
            if (ts.Days >= 1)
            {
                return ts.Days + "天前";
            }
            if (ts.Hours >= 1)
            {
                return ts.Hours + "小时前";
            }
            if (ts.Minutes >= 1)
            {
                return ts.Minutes + "分钟前";
            }
            return (int)(ts.TotalSeconds * 1000) + "秒前";
        }
        #endregion

    }
}