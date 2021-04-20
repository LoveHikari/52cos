using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Cos.Bll;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Web.Service.ShowManage
{
    /// <summary>
    /// Reply 的摘要说明
    /// 评论
    /// </summary>
    public class Reply : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string userId = DEncryptUtils.DESDecrypt(CookieHelper.GetCookieValue("52cos", "user_id")).Replace("\0", "");
            string type = context.Request.Form["comment_parent"];
            string workId = context.Request.Form["comment_post_ID"];
            string replyContent = context.Request.Form["comment"];
            string s = "{\"status\":\"error\"}";
            if (userId.Trim() != "")
            {
                ReplyEntity replyEntity = new ReplyEntity();
                replyEntity.User_id = userId;
                replyEntity.type = type;
                replyEntity.workId = workId;
                replyEntity.ReplyContent = replyContent;
                replyEntity.ReleaseTime = DateTime.Now;
                //插入回复表
                if (ReplyBll.Instance.Add(replyEntity) > 0)
                {
                    // todo 更新作品时间
                    s = "{\"status\":\"success\"}";
                }
            }

            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            context.Response.Write(s);
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