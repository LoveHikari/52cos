using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Cos.Bll;

namespace Com.Cos.Admin.Service.WorksManage
{
    /// <summary>
    /// UpdateStatus 的摘要说明
    /// </summary>
    public class UpdateStatus : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string workId = context.Request.Form["WorksId"];
            string statusNmae = context.Request.Form["StatusNmae"];
            string status = context.Request.Form["Status"];
            status = status == "0" ? "1" : "0";
            string s = "{\"status\":\"error\"}";
            if (WorksBll.Instance.UpdateStatus(workId, statusNmae, status))
            {
                s = "{\"status\":\"success\"}";
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