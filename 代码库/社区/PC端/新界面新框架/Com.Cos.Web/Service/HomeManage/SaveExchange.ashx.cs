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
    /// SaveExchange 的摘要说明
    /// 保存交换
    /// </summary>
    public class SaveExchange : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string userId = context.Request.Form["ctb[uid]"];   //作者id
            string title = context.Request.Form["ctb[post-title]"];  //标题
            string describe = context.Request.Form["ctb[post-describe]"];  //其他描述
            string itemName = context.Request.Form["ctb[post-itemName]"]; //物品名称
            string cover = context.Request.Form["ctb[thumbnail-id]"];  //封面id
            string certificate = context.Request.Form["ctb[certificate-ids][]"];  //凭证
            string imgs = context.Request.Form["ctb[attach-ids][]"];   //图片id
            string source = context.Request.Form["ctb[post-source]"];  //物品来源
            string constitute = context.Request.Form["ctb[post-constitute]"];   //物品组成
            string classId = context.Request.Form["ctb[post-cid]"];   //分类id
            string price = context.Request.Form["ctb[post-price]"];  //原价
            string valuation = context.Request.Form["ctb[tags][]"];  //估价
            string[] vs = valuation.Split(',');
            string s = "{\"status\":\"error\"}";
            bool b = false;

            try
            {
                ExchangeEntity exchangeEntity = new ExchangeEntity();
                exchangeEntity.UserId = userId;
                exchangeEntity.Title = title;
                exchangeEntity.Describe = describe;
                exchangeEntity.ItemName = itemName;
                exchangeEntity.Cover = cover;
                exchangeEntity.ClassId = classId;
                if (certificate == null)
                {
                    certificate = "";
                }
                exchangeEntity.Certificate = certificate;
                exchangeEntity.Imgs = imgs;
                exchangeEntity.Source = source;
                exchangeEntity.Constitute = constitute;
                exchangeEntity.Price = price;
                exchangeEntity.Valuation1 = vs[0];
                exchangeEntity.Valuation2 = vs[1];
                exchangeEntity.Valuation3 = vs[2];
                exchangeEntity.Vote1 = 0;
                exchangeEntity.Vote2 = 0;
                exchangeEntity.Vote3 = 0;
                exchangeEntity.Official = "";
                exchangeEntity.ExchangePerson = "";
                exchangeEntity.AddTime = DateTime.Now;
                exchangeEntity.EnterTime = null;
                exchangeEntity.Examine = "1";
                exchangeEntity.Status = 1;
                b = ExchangeBll.Instance.Add(exchangeEntity) > 0;
                if (b)
                {
                    s = "{\"status\":\"success\"}";
                }
            }
            catch (System.Exception ex)
            {
                s = "{\"status\":\"" + ex.Message + "\"}";
                WriteLog.WriteError(ex);
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