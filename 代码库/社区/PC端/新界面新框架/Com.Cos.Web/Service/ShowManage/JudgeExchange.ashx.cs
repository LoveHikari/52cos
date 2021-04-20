using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Com.Cos.Bll;

namespace Com.Cos.Web.Service.ShowManage
{
    /// <summary>
    /// JudgeExchange 的摘要说明
    /// 判断是否已有兑换
    /// </summary>
    public class JudgeExchange : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string userId = context.Request.Form["UserId"];
            string s = "{\"status\":\"error\"}";

            DataTable dt = ExchangeBll.Instance.GetList("ExchangePerson='"+userId+"' AND Examine>3 AND Status>0").Tables[0];
            if (dt.Rows.Count > 0)
            {
                s = "{\"status\":\"exist\"}";
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