using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Cos.Bll;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Web.Service.HomeManage
{
    /// <summary>
    /// SaveContributions 的摘要说明
    /// 保存投稿
    /// </summary>
    public class SaveContributions : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string userId = DEncryptUtils.DESDecrypt(CookieHelper.GetCookieValue("52cos", "user_id")).Replace("\0", "");
            string classification = context.Request.Form["theme_custom_post_source[type]"]; //作品、合作、活动
            string worksTitle = context.Request.Form["ctb[post-title]"];  //作品标题
            string worksExcerpt = context.Request.Form["ctb[post-excerpt]"];  //作品摘要
            string worksContent = context.Request.Form["ctb[post-content]"];  //作品内容
            string worksType = context.Request.Form["ctb[cats][]"];  //作品分类
            string labelDesc = context.Request.Form["ctb[tags][]"]; //作品标签
            string source = context.Request.Form["theme_custom_post_source[source]"];  //来源
            string sourceUrl = context.Request.Form["theme_custom_post_source[reprint][url]"]; //来源地址
            string author = context.Request.Form["theme_custom_post_source[reprint][author]"]; //作者
            string cover = context.Request.Form["ctb[thumbnail-id]"];  //封面id
            string imgs = context.Request.Form["ctb[attach-ids][]"];  //原图id组

            int i = 0;
            string[] types = worksType.Split(',');
            string[] imgss = imgs.Split(',');
            if (classification == "works") //作品
            {
                i = SaveWorks(userId, worksTitle, worksExcerpt, worksContent, labelDesc, source, sourceUrl, author, cover, types);
            }
            if (classification == "reprint") //合作
            {
                i = SaveReprint(userId, worksTitle, worksExcerpt, worksContent, cover);
            }
            if (classification == "activity") //活动
            {
                i = SaveActivity(userId, worksTitle, worksExcerpt, worksContent, cover);
            }
            
            
            

            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            context.Response.Write(i);
        }
        /// <summary>
        /// 保存活动
        /// </summary>
        /// <returns></returns>
        private int SaveActivity(string userId, string worksTitle, string worksExcerpt, string worksContent, string cover)
        {
            ActivityEntity activityEntity = new ActivityEntity();
            activityEntity.User_id = userId;
            activityEntity.title = worksTitle;
            activityEntity.starttime = null;
            activityEntity.endtime = null;
            activityEntity.enrollEnd = null;
            activityEntity.contacts = "";
            activityEntity.phone = "";
            activityEntity.qq = "";
            activityEntity.cover = cover;
            activityEntity.cont = worksContent;
            activityEntity.RMBBudget = "";
            activityEntity.limitPerson = "";
            activityEntity.prov = "";
            activityEntity.city = "";
            activityEntity.dist = "";
            activityEntity.ReleaseTime = DateTime.Now;
            activityEntity.Status = 1;
            activityEntity.excerpt = worksExcerpt;
            if (ActivityBll.Instance.Add(activityEntity) > 0)
            {
                return 1;
            }
            return -1;
        }
        /// <summary>
        /// 保存合作
        /// </summary>
        /// <returns></returns>
        private int SaveReprint(string userId, string worksTitle, string worksExcerpt, string worksContent, string cover)
        {

            CooperationEntity cooperationEntity = new CooperationEntity();
            cooperationEntity.User_id = userId;
            cooperationEntity.title = worksTitle;
            cooperationEntity.type = "";
            cooperationEntity.send = "";
            cooperationEntity.enrollEnd = null;
            cooperationEntity.timeBudget = "";
            cooperationEntity.intention = "";
            cooperationEntity.acceptSum = "";
            cooperationEntity.cooContent = worksContent;
            cooperationEntity.RMBBudget = "";
            cooperationEntity.GenderAsk = "";
            cooperationEntity.signPerson = "";
            cooperationEntity.personSum = "";
            cooperationEntity.ReleaseTime = DateTime.Now;
            cooperationEntity.Status = 1;
            cooperationEntity.contacts = "";
            cooperationEntity.phone = "";
            cooperationEntity.qq = "";
            cooperationEntity.cover = cover;
            cooperationEntity.limitPerson = 0;
            cooperationEntity.will = "";
            cooperationEntity.prov = "";
            cooperationEntity.city = "";
            cooperationEntity.dist = "";
            cooperationEntity.excerpt = worksExcerpt;
            if (CooperationBll.Instance.Add(cooperationEntity) > 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// 保存作品
        /// </summary>
        /// <returns></returns>
        private int SaveWorks(string userId, string worksTitle, string worksExcerpt, string worksContent, string labelDesc, string source, string sourceUrl, string author, string cover, string[] types)
        {
            WorksEntity worksEntity = new WorksEntity();
            worksEntity.User_id = userId;
            worksEntity.WorksTitle = worksTitle;
            worksEntity.WorksType = types[0];
            if (types.Length > 1)
            {
                worksEntity.Type2 = types[1];
            }
            else
            {
                worksEntity.Type2 = "0";
            }
            worksEntity.OriginaWorks = "";
            worksEntity.OriginaRole = "";
            worksEntity.coser = "";
            worksEntity.Photography = "";
            worksEntity.Makeup = "";
            worksEntity.Late = "";
            worksEntity.Third = "";
            worksEntity.Painter = "";
            worksEntity.LabelDesc = labelDesc;
            worksEntity.WorksContent = worksContent;
            worksEntity.Root = "0";
            worksEntity.Keep = "1";
            worksEntity.Watermark = "1";
            worksEntity.ReleaseTime = DateTime.Now;
            worksEntity.UpdateTime = DateTime.Now;
            worksEntity.GoodNo = 0;
            worksEntity.Status = 1;
            worksEntity.reward = 0;
            worksEntity.cover = cover;
            worksEntity.worksExcerpt = worksExcerpt;
            worksEntity.source = source;
            worksEntity.sourceUrl = sourceUrl;
            worksEntity.Sticky = "0";
            worksEntity.Recommend = "0";

            if ((worksEntity.WorksId = WorksBll.Instance.Add(worksEntity)) > 0)
            {
                //保存作品图片
                //foreach (string s in imgss)
                //{
                //    WorkImgEntity workImgEntity = new WorkImgEntity();
                //    workImgEntity.workId = worksEntity.WorksId.ToString();
                //    workImgEntity.ImgId = s;
                //    workImgEntity.Status = 1;
                //    WorkImgBll.Instance.Add(workImgEntity);
                //}
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

       
    }
}