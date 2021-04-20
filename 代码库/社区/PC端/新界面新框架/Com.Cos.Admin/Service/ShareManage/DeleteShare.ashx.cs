using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Admin.Service.ShareManage
{
    /// <summary>
    /// DeleteShare 的摘要说明
    /// 删除分享
    /// </summary>
    public class DeleteShare : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string exId = context.Request.Form["ExId"];
            string s = "{\"status\":\"error\"}";
            bool b = false;
            //删除分享投票
            b = ExchangeVoteBll.Instance.UpdateStatus(exId, 0);
            //删除分享物流
            if (b)
            {
                b = ExchangeLogisticalBll.Instance.UpdateStatus(exId, 0);
            }
            //删除兑换人员
            if (b)
            {
                b = ExchangePersonBll.Instance.UpdateStatus(exId, 0);
            }
            //删除分享表
            if (b)
            {
                ExchangeEntity exchangeEntity = ExchangeBll.Instance.GetModel(int.Parse(exId));
                exchangeEntity.Status = 0;
                b = ExchangeBll.Instance.Update(exchangeEntity);
            }
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