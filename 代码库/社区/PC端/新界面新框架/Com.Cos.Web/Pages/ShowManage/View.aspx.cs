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
    public partial class View : BasePage
    {
        protected string worksId;
        protected string type;
        protected MemberEntity _memberEntity; //发帖人
        #region 属性
        protected string User_id  //登录人的id
        {
            set { ViewState["UserId"] = value; }
            get { return ViewState["UserId"] == null ? base.User_id : ViewState["UserId"].ToString(); }
        }
        /// <summary>
        /// 登录人
        /// </summary>
        protected MemberEntity UMemberEntity
        {
            set { ViewState["UMemberEntity"] = value; }
            get
            {
                return ViewState["UMemberEntity"] == null
                    ? MemberBll.Instance.GetModel(Convert.ToInt32(User_id))
                    : ViewState["UMemberEntity"] as MemberEntity;
            }
        }

        protected MemberEntity MemberEntity
        {
            get
            {
                return _memberEntity;
            }

            set
            {
                _memberEntity = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                worksId = Request.QueryString["nid"];  //文章id
                type = Request.QueryString["type"];  //类型，作品（works）、合作（reprint）、活动（activity）

                Dictionary<string, string> iDi = new Dictionary<string, string>();
                switch (type)
                {
                    case "works":
                        WorksEntity worksEntity1 = WorksBll.Instance.GetModel(Convert.ToInt32(worksId) - 1);
                        WorksEntity worksEntity = WorksBll.Instance.GetModel(Convert.ToInt32(worksId));
                        WorksEntity worksEntity2 = WorksBll.Instance.GetModel(Convert.ToInt32(worksId) + 1);
                        MemberEntity = MemberBll.Instance.GetModel(Convert.ToInt32(worksEntity.User_id));
                        iDi.Add("title", worksEntity.WorksTitle);
                        iDi.Add("type", SysParaBll.Instance.GetModel(Convert.ToInt32(worksEntity.WorksType)).RefText);
                        iDi.Add("type2", (worksEntity.Type2 == "" ? "" : SysParaBll.Instance.GetModel(Convert.ToInt32(worksEntity.Type2))?.RefText));
                        iDi.Add("datetime", worksEntity.ReleaseTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        iDi.Add("time", worksEntity.ReleaseTime.ToString("yyyy年MM月dd日"));
                        iDi.Add("releaseTime", GetTime(worksEntity.ReleaseTime.ToString()));
                        iDi.Add("goodNo", worksEntity.GoodNo.ToString());
                        iDi.Add("reward", worksEntity.reward.ToString());
                        iDi.Add("nickname", MemberEntity.nickname);
                        iDi.Add("excerpt", worksEntity.worksExcerpt);
                        iDi.Add("content", worksEntity.WorksContent);
                        iDi.Add("labelDesc", worksEntity.LabelDesc);
                        iDi.Add("id1", worksEntity1?.WorksId.ToString());
                        iDi.Add("title1", worksEntity1?.WorksTitle);
                        iDi.Add("cover1", worksEntity1?.cover);
                        iDi.Add("id2", worksEntity2?.WorksId.ToString());
                        iDi.Add("title2", worksEntity2?.WorksTitle);
                        iDi.Add("cover2", worksEntity2?.cover);
                        break;
                    case "reprint":
                        CooperationEntity cooperationEntity1 = CooperationBll.Instance.GetModel(Convert.ToInt32(worksId) - 1);
                        CooperationEntity cooperationEntity = CooperationBll.Instance.GetModel(Convert.ToInt32(worksId));
                        CooperationEntity cooperationEntity2 = CooperationBll.Instance.GetModel(Convert.ToInt32(worksId) + 1);
                        MemberEntity = MemberBll.Instance.GetModel(Convert.ToInt32(cooperationEntity.User_id));
                        iDi.Add("title", cooperationEntity.title);
                        iDi.Add("type", cooperationEntity.will);
                        iDi.Add("type2", (cooperationEntity.will));
                        iDi.Add("datetime", cooperationEntity.ReleaseTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        iDi.Add("time", cooperationEntity.ReleaseTime.ToString("yyyy年MM月dd日"));
                        iDi.Add("releaseTime", GetTime(cooperationEntity.ReleaseTime.ToString()));
                        iDi.Add("goodNo", "-");
                        iDi.Add("nickname", MemberEntity.nickname);
                        iDi.Add("excerpt", cooperationEntity.excerpt);
                        iDi.Add("content", cooperationEntity.cooContent);
                        iDi.Add("labelDesc", "");
                        iDi.Add("id1", cooperationEntity1?.id.ToString());
                        iDi.Add("title1", cooperationEntity1?.title);
                        iDi.Add("cover1", cooperationEntity1?.cover);
                        iDi.Add("id2", cooperationEntity2?.id.ToString());
                        iDi.Add("title2", cooperationEntity2?.title);
                        iDi.Add("cover2", cooperationEntity2?.cover);
                        break;
                    case "activity":
                        ActivityEntity activityEntity1 = ActivityBll.Instance.GetModel(Convert.ToInt32(worksId) - 1);
                        ActivityEntity activityEntity = ActivityBll.Instance.GetModel(Convert.ToInt32(worksId));
                        ActivityEntity activityEntity2 = ActivityBll.Instance.GetModel(Convert.ToInt32(worksId) + 1);
                        MemberEntity = MemberBll.Instance.GetModel(Convert.ToInt32(activityEntity.User_id));
                        iDi.Add("title", activityEntity.title);
                        iDi.Add("type", "");
                        iDi.Add("type2", "");
                        iDi.Add("datetime", activityEntity.ReleaseTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        iDi.Add("time", activityEntity.ReleaseTime.ToString("yyyy年MM月dd日"));
                        iDi.Add("releaseTime", GetTime(activityEntity.ReleaseTime.ToString()));
                        iDi.Add("goodNo", "-");
                        iDi.Add("nickname", MemberEntity.nickname);
                        iDi.Add("excerpt", activityEntity.excerpt);
                        iDi.Add("content", activityEntity.cont);
                        iDi.Add("labelDesc", "");
                        iDi.Add("id1", activityEntity1?.id.ToString());
                        iDi.Add("title1", activityEntity1?.title);
                        iDi.Add("cover1", activityEntity1?.cover);
                        iDi.Add("id2", activityEntity2?.id.ToString());
                        iDi.Add("title2", activityEntity2?.title);
                        iDi.Add("cover2", activityEntity2?.cover);
                        break;
                    default:
                        break;
                }
                BindData(iDi);
            }
        }

        protected int commentNum = 0;  //评论数


        #region 私有方法
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void BindData(Dictionary<string, string> iDi)
        {
            //评论区
            DataTable dt = ReplyBll.Instance.GetList("type='" + type + "' and workId='"+worksId+"'");
            repReply.DataSource = dt;
            repReply.DataBind();
            commentNum = dt.Rows.Count;

            #region 左边正文区
            string s = "";
            s += "  <article id=\"post-86\" class=\" singular-post panel post-86 post type-post status-publish format-standard has-post-thumbnail hentry category-acgtuji category-hjhc tag-18 tag-19 tag-21 tag-20\">";
            s += $"                    <h2 class=\"entry-title\">{iDi["title"]}</h2>";
            s += "                    <header class=\"entry-header\">";
            s += "                        <span class=\"entry-meta post-category\" title=\"分类\">";
            s += "                            <i class=\"fa fa-folder-open\"></i>";
            s += $"                            <a href=\"moe/acgtuji.htm\" rel=\"category tag\">{iDi["type"]}</a><i class=\"split\">, </i><a href=\"moe/acgtuji/hjhc.htm\" rel=\"category tag\">{iDi["type2"]}</a>";
            s += "                        </span>";
            s += $"                        <time class=\"entry-meta post-time\" datetime=\"{iDi["datetime"]}\" title=\"{iDi["time"]}\">";
            s += "                            <i class=\"fa fa-clock-o\"></i>";
            s += $"                            {iDi["releaseTime"]}";
            s += "                        </time>";
            s += $"                        <a class=\"entry-meta post-author\" href=\"moeauthor/100002.htm\" title=\"查看 {iDi["nickname"]} 目录下的所有文章\">";
            s += "                            <i class=\"fa fa-user\"></i>";
            s += $"                            {iDi["nickname"]}";
            s += "                        </a>";
            s += "                        <span class=\"entry-meta post-views\" title=\"赞数\">";
            s += "                            <i class=\"fa fa-play-circle\"></i>";
            s += $"                            <span class=\"number\" id=\"post-views-number-86\">{iDi["goodNo"]}</span>";
            s += "                        </span>";
            s += "                        <a href=\"#comments\" class=\"entry-meta quick-comment comment-count\" data-post-id=\"86\">";
            s += "                            <i class=\"fa fa-comment\"></i>";
            s += $"                            <span class=\"comment-count-number\">{commentNum}</span>";
            s += "                        </a>";
            s += "                    </header>";
            s += "                    <div class=\"entry-body\">";
            s += "                        <div class=\"ad-container ad-below-post-title\">";
            s += "                            <script>var star_code = \"705567_0_11_48_728_90_3_1_4_ffffff_808080_808080_cccccc_D70000_0\";</script>";
            s += "                            <script charset=\"utf-8\" src=\"../vip.zhuba8.com/js/cpc2_i.js\"></script>";
            s += "                        </div>";
            s += "                        <blockquote class=\"entry-excerpt\">";
            s += $"                            {iDi["excerpt"]}";
            s += "                        </blockquote>";
            s += "                        <div class=\"entry-content content-reset\">";
            s += $"                            {iDi["content"]}";
            s += "                        </div>";
            s += "                        <div class=\"entry-circle\">";
            if (type == "works")
            {
                s += "                            <div class=\"meta meta-post-point\">";
                s += "                                <a href=\"javascript:;\" class=\"post-point-btn\" title=\"打赏 3 个CN币\" data-post-id=\"86\" data-points=\"3\">";
                s += $"                                    <div id=\"post-point-number-86\" class=\"number\">{iDi["reward"]}</div>";
                s += "                                    <div class=\"tx\">打赏</div>";
                s += "                                </a>";
                s += "                                <div class=\"box\">";
                s += "                                    <a href=\"javascript:;\" class=\"post-point-btn \" title=\"打赏 1 个CN币\" data-post-id=\"86\" data-points=\"1\">1</a><a href=\"javascript:;\" class=\"post-point-btn active\" title=\"打赏 3 个CN币\" data-post-id=\"86\" data-points=\"3\">3</a><a href=\"javascript:;\" class=\"post-point-btn \" title=\"打赏 5 个CN币\" data-post-id=\"86\" data-points=\"5\">5</a><a href=\"javascript:;\" class=\"post-point-btn \" title=\"打赏 7 个CN币\" data-post-id=\"86\" data-points=\"7\">7</a><a href=\"javascript:;\" class=\"post-point-btn \" title=\"打赏 9 个CN币\" data-post-id=\"86\" data-points=\"9\">9</a><a href=\"javascript:;\" class=\"post-point-btn \" title=\"打赏 15 个CN币\" data-post-id=\"86\" data-points=\"15\">15</a>";
                s += "                                </div>";
                s += "                            </div>";

                s += "                            <a class=\"meta meta-post-comments\" id=\"post-good-btn\" title=\"点赞\" style='top:-25px'>";
                s += "                                <button class=\"icobutton icobutton--thumbs-up\" style='top:18px'>";
                s += "                                    <span class=\"fa fa-thumbs-up\"></span>";
                s += "                                </button>";
                s += "                            </a>";
            }
            s += "                            <a class=\"meta meta-post-comments\" href=\"#respond\" id=\"post-comments-btn\" title=\"评论\">";
            s += "                                <div id=\"post-comments-number-86\" class=\"number\">";
            s += $"                                    {commentNum}";
            s += "                                </div>";
            s += "                                <div class=\"tx\">吐槽</div>";
            s += "                            </a>";
            s += "                        </div>";
            s += "                        <ul class=\"entry-source\">";
            s += $"                            <li>本作品是由 <a href=\"http://sq.52cos.com\">52cos平台社区</a> 会员 <a href=\"moeauthor/100002.htm\">{_memberEntity.nickname}</a> 的投递作品。</li>";
            s += $"                            <li>欢迎转载，但请务必注明来源地址：<a href=\"{Request.Url}\" target=\"_blank\" rel=\"nofollow\">{Request.Url}</a>。</li>";
            s += "                        </ul>";
            s += "                        <footer class=\"entry-footer\">";
            s += "                            <div class=\"entry-tags\">";
            string[] labels = iDi["labelDesc"].Split(',');
            foreach (string label in labels)
            {
                if (label != "")
                {
                    s += $"<a href=\"moetag/插画.htm\" rel=\"tag\">{label}</a>";
                }

            }
            s += "                            </div>";
            s += "                            <div class=\"entry-share\">";
            s += "                                <div class=\"bdshare_t bdsharebuttonbox\" data-tag=\"bd_share\" data-bdshare=\"{";
            s += "	'bdText':'【pixiv】每日精选插画2015.11.16 by 天才射鸡湿可乐 —— 来自 九妖萌弹幕动漫网',";
            s += "	'bdUrl':'http://www.91moe.com/moe86.html',";
            s += "	'bdPic':'http://img.91moe.com/2015/11/cd31ae1c36eb770a76dd646019fd59d5-320x180.jpg'";
            s += "}\">";
            s += "                                    <span class=\"description\">转贴到：</span>";
            s += "<a href=\"#\" class=\"bds_more\" data-cmd=\"more\"></a>";
            s += "<a href=\"#\" class=\"bds_qzone\" data-cmd=\"qzone\" title=\"分享到QQ空间\"></a>";
            s += "<a href=\"#\" class=\"bds_tsina\" data-cmd=\"tsina\" title=\"分享到新浪微博\"></a>";
            s += "<a href=\"#\" class=\"bds_tqq\" data-cmd=\"tqq\" title=\"分享到腾讯微博\"></a>";
            s += "<a href=\"#\" class=\"bds_renren\" data-cmd=\"renren\" title=\"分享到人人网\"></a>";
            s += "<a href=\"#\" class=\"bds_weixin\" data-cmd=\"weixin\" title=\"分享到微信\"></a>";
            s += "<script>window._bd_share_config={\"common\":{\"bdSnsKey\":{},\"bdText\":\"\",\"bdMini\":\"1\",\"bdMiniList\":false,\"bdPic\":\"\",\"bdStyle\":\"1\",\"bdSize\":\"16\"},\"share\":{}};with(document)0[(getElementsByTagName('head')[0]||body).appendChild(createElement('script')).src='http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion='+~(-new Date()/36e5)];</script>";
            s += "                                </div>";
            s += "                            </div>";
            s += "                            <div class=\"entry-report\">";
            s += "                                <a class=\"tooltip top\" href=\"文章问题反馈-1.htm\" tppabs=\"http://www.91moe.com/%e6%96%87%e7%ab%a0%e9%97%ae%e9%a2%98%e5%8f%8d%e9%a6%88\" target=\"_blank\" rel=\"nofollow\" title=\"资源失效提交\"><i class=\"fa fa-flag\"></i></a>";
            s += "                            </div>";
            s += "                        </footer>";
            s += "                    </div>";
            s += "                </article>";

            s += "                <nav class=\"adjacent-posts has-prev has-next row\">";
            if (iDi["id1"] != null)
            {
                s += "                    <div class=\"g-desktop-1-2\">";
                s += $"                        <a href=\"/Pages/ShowManage/View.aspx?nid={iDi["id1"]}&type=works\" class=\"left next-post\" title=\"{iDi["title1"]}\">";
                s += $"                            <img class=\"thumbnail\" src=\"/Style/img/46201453_10.gif\" data-src=\"{iDi["cover1"]}\" alt=\"{iDi["title1"]}\" width=\"320\" height=\"180\"><h2 class=\"title\"><i class=\"fa fa-arrow-circle-left\"></i>上一篇：{iDi["title1"]}</h2>";
                s += "                        </a>";
                s += "                    </div>";
            }
            else
            {
                s += "                    <div class=\"g-desktop-1-2\">";
                s += "                        <a href=\"#\" class=\"left next-post\" title=\"没有了\">";
                s += "                            <img class=\"thumbnail\" src=\"/Style/img/46201453_10.gif\" data-src=\"\" alt=\"没有了\" width=\"320\" height=\"180\"><h2 class=\"title\"><i class=\"fa fa-arrow-circle-left\"></i>上一篇：没有了</h2>";
                s += "                        </a>";
                s += "                    </div>";
            }
            if (iDi["id2"] != null)
            {
                s += "                    <div class=\"g-desktop-1-2\">";
                s += $"                        <a href=\"/Pages/ShowManage/View.aspx?nid={iDi.ContainsKey("id2")}&type=works\"  class=\"right prev-post\" title=\"{iDi["title2"]}\">";
                s += $"                            <img class=\"thumbnail\" src=\"/Style/img/46201453_10.gif\"  data-src=\"{iDi["cover2"]}\" alt=\"{iDi["title2"]}\" width=\"320\" height=\"180\"><h2 class=\"title\"><i class=\"fa fa-arrow-circle-right\"></i>下一篇：{iDi["title2"]}</h2>";
                s += "                        </a>";
                s += "                    </div>";
            }
            else
            {
                s += "                    <div class=\"g-desktop-1-2\">";
                s += "                        <a href=\"#\"  class=\"right prev-post\" title=\"没有了\">";
                s += "                            <img class=\"thumbnail\" src=\"/Style/img/46201453_10.gif\"  data-src=\"\" alt=\"没有了\" width=\"320\" height=\"180\"><h2 class=\"title\"><i class=\"fa fa-arrow-circle-right\"></i>下一篇：没有了</h2>";
                s += "                        </a>";
                s += "                    </div>";
            }

            s += "                </nav>";

            litWork.Text = s;
            #endregion

            #region 作者文章
            string ss = "";
            if (type == "works")
            {
                DataTable worksTable = WorksBll.Instance.GetList(12, "", "ReleaseTime DESC");
                foreach (DataRow dataRow in worksTable.Rows)
                {
                    ss += "<article class=\"g-phone-1-2 card xs\">";
                    ss += $"   <a class=\"card-bg\" href=\"/Pages/ShowManage/View.aspx?nid={dataRow["WorksId"]}&type=works\" title=\"{dataRow["WorksTitle"]}\" target=\"_blank\">";
                    ss += "      <div class=\"thumbnail-container\">";
                    ss += $"          <img class=\"thumbnail\" src=\"/Style/img/46201453_10.gif\" data-src=\"{GetCover(dataRow["cover"].ToString())}\" alt=\"{dataRow["WorksTitle"]}\" width=\"320\" height=\"180\">";
                    ss += "      </div>";
                    ss += $"      <h3 class=\"title\">{dataRow["WorksTitle"]}</h3>";
                    ss += "   </a>";
                    ss += "</article>";
                }

            }
            if (type == "reprint")
            {
                DataTable reprintTable = CooperationBll.Instance.GetList(12, "", "ReleaseTime DESC");
                foreach (DataRow dataRow in reprintTable.Rows)
                {
                    ss += "<article class=\"g-phone-1-2 card xs\">";
                    ss += $"   <a class=\"card-bg\" href=\"/Pages/ShowManage/View.aspx?nid={dataRow["id"]}&type=reprint\" title=\"{dataRow["title"]}\" target=\"_blank\">";
                    ss += "      <div class=\"thumbnail-container\">";
                    ss += $"          <img class=\"thumbnail\" src=\"/Style/img/46201453_10.gif\" data-src=\"{GetCover(dataRow["cover"].ToString())}\" alt=\"{dataRow["title"]}\" width=\"320\" height=\"180\">";
                    ss += "      </div>";
                    ss += $"      <h3 class=\"title\">{dataRow["title"]}</h3>";
                    ss += "   </a>";
                    ss += "</article>";
                }
            }
            if (type == "activity")
            {
                DataTable activityTable = ActivityBll.Instance.GetList(12, "", "ReleaseTime DESC");
                foreach (DataRow dataRow in activityTable.Rows)
                {
                    ss += "<article class=\"g-phone-1-2 card xs\">";
                    ss += $"   <a class=\"card-bg\" href=\"/Pages/ShowManage/View.aspx?nid={dataRow["id"]}&type=activity\" title=\"{dataRow["title"]}\" target=\"_blank\">";
                    ss += "      <div class=\"thumbnail-container\">";
                    ss += $"          <img class=\"thumbnail\" src=\"/Style/img/46201453_10.gif\" data-src=\"{GetCover(dataRow["cover"].ToString())}\" alt=\"{dataRow["title"]}\" width=\"320\" height=\"180\">";
                    ss += "      </div>";
                    ss += $"      <h3 class=\"title\">{dataRow["title"]}</h3>";
                    ss += "   </a>";
                    ss += "</article>";
                }
            }
            #endregion
            litArticle.Text = ss;

            //勋章区
            DataTable medalDataTable = PersonMedalBll.Instance.GetList("userId='" + MemberEntity.User_id + "'");
            repMedal.DataSource = medalDataTable;
            repMedal.DataBind();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 获得作者的文章数
        /// </summary>
        /// <returns></returns>
        protected string GetArticleNum()
        {
            //文章数=作品数+合作数+活动数
            //1.取作品数
            DataTable worksTable = WorksBll.Instance.GetList("User_id='" + MemberEntity.User_id + "' and status='1'");
            int worksNum = worksTable.Rows.Count;
            //2.取合作数
            DataTable cooTable = CooperationBll.Instance.GetList("User_id='" + MemberEntity.User_id + "'");
            int cooNum = cooTable.Rows.Count;
            //3.取活动数
            DataTable activityTable = ActivityBll.Instance.GetList("User_id='" + MemberEntity.User_id + "'");
            int activityNum = activityTable.Rows.Count;

            return worksNum + cooNum + activityNum + "";
        }
        /// <summary>
        /// 获得作者的评论数
        /// </summary>
        /// <returns></returns>
        protected string GetReplyNum()
        {
            DataTable replyTable = ReplyBll.Instance.GetList("User_id='" + MemberEntity.User_id + "'");
            return replyTable.Rows.Count.ToString();
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
                return smallImgEntity.ImgUrl;
            }
            return "";
        }
        #endregion
    }
}