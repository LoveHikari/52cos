using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Cos.Bll;

namespace Com.Cos.Admin.Service.WorksManage
{
    /// <summary>
    /// DeleteWorks 的摘要说明
    /// 删除作品
    /// </summary>
    public class DeleteWorks : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string worksId = context.Request.QueryString["worksId"];
            int i = 0;
            bool b = false;
            //1.删除打赏表
            RewardBll.Instance.UpdateStatus(worksId, "0");
            //2.删除点赞表
            //todo 删除点赞表
            //3.删除评论表
            ReplyBll.Instance.UpdateStatus(worksId, "0");
            //4.删除作品表
            b = WorksBll.Instance.UpdateStatus(worksId, "0");

            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            context.Response.Write(b);
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