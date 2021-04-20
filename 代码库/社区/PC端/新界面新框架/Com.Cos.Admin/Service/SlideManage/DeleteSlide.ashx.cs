using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Cos.Bll;

namespace Com.Cos.Admin.Service.SlideManage
{
    /// <summary>
    /// DeleteSlide 的摘要说明
    /// 删除幻灯片
    /// </summary>
    public class DeleteSlide : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request.QueryString["Id"];

            bool b = SlideBll.Instance.UpdateStatus(id, "0");

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