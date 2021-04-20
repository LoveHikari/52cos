using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Admin.Service.ShareManage
{
    /// <summary>
    /// SaveOffical 的摘要说明
    /// 保存官方价
    /// </summary>
    public class SaveOffical : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string exId = context.Request.Form["ExId"];
            string official = context.Request.Form["Official"];
            string s = "{\"status\":\"error\"}";
            bool b = false;

            ExchangeEntity exchangeEntity = ExchangeBll.Instance.GetModel(int.Parse(exId));
            exchangeEntity.Official = official;
            b = ExchangeBll.Instance.Update(exchangeEntity);
            if (b)
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