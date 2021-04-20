using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Cos.Api;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Admin.Service.ShareManage
{
    /// <summary>
    /// SetShareExamine 的摘要说明
    /// 设置分享过期标志
    /// </summary>
    public class SetShareExamine : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string examine = context.Request.Form["Examine"];
            string exId = context.Request.Form["Exid"];
            string s = "{\"status\":\"error\"}";
            bool b = false;
            ExchangeEntity exchangeEntity = ExchangeBll.Instance.GetModel(int.Parse(exId));

            if (examine == "3")   //加身家
            {
                string userId = exchangeEntity.UserId;
                MemberEntity memberEntity = MemberBll.Instance.GetModel(int.Parse(userId));
                MemberApi.SendMail(memberEntity.nickname, "您发布的兑换已被确认！", memberEntity.Email);
                string official = exchangeEntity.Official;
                MemberBll.Instance.UpdateIntegral(userId, "Shenjia", official);
            }

            exchangeEntity.Examine = examine;
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