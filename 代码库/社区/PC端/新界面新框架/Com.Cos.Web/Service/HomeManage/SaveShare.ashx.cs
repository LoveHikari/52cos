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
    /// SaveShare 的摘要说明
    /// 保存交换、出租
    /// </summary>
    public class SaveShare : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string type = context.Request.Form["type"];
            string userId = context.Request.Form["ctb[uid]"];   //作者id
            string title = context.Request.Form["ctb[post-title]"];  //标题
            string describe = context.Request.Form["ctb[post-describe]"];  //其他描述
            string itemName = context.Request.Form["ctb[post-itemName]"]; //物品名称
            string cover = context.Request.Form["ctb[thumbnail-id]"];  //封面id
            string certificate = context.Request.Form["ctb[certificate-ids][]"];  //凭证
            string imgs = context.Request.Form["ctb[attach-ids][]"];   //图片id
            string source = context.Request.Form["ctb[post-source]"];  //物品来源
            string constitute = context.Request.Form["ctb[post-constitute]"];   //物品组成
            string price = context.Request.Form["ctb[post-price]"];  //原价
            string valuation = context.Request.Form["ctb[tags][]"];  //估价
            string official = context.Request.Form["ctb[post-official]"];  //估价

            string s = "{\"status\":\"error\"}";
            

            try
            {
                if (type == "rent")
                {
                    s = SaveRent(userId, title, describe, itemName, cover, certificate, imgs, source, constitute, price, official);
                }
                else if(type == "enchange")
                {
                    s = SaveExchange(userId, title, describe, itemName, cover, certificate, imgs, source, constitute, price, valuation);
                }
            }
            catch (System.Exception ex)
            {
                s = "{\"status\":\"" + ex.Message + "\"}";
                WriteLog.WriteError(ex);
                throw ex;
            }
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            context.Response.Write(s);

        }

        private static string SaveExchange(string userId, string title, string describe, string itemName, string cover,
            string certificate, string imgs, string source, string constitute, string price, string valuation)
        {
            string[] vs = valuation.Split(',');
            bool b = false;
            ExchangeEntity exchangeEntity = new ExchangeEntity();
            exchangeEntity.UserId = userId;
            exchangeEntity.Title = title;
            exchangeEntity.Describe = describe;
            exchangeEntity.ItemName = itemName;
            exchangeEntity.Cover = cover;
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
            exchangeEntity.EnterTime = Convert.ToDateTime("1900-01-01");
            exchangeEntity.Examine = "1";
            exchangeEntity.Status = 1;
            b = ExchangeBll.Instance.Add(exchangeEntity) > 0;
            if (b)
            {
                return "{\"status\":\"success\"}";
            }
            return "{\"status\":\"error\"}";
        }
        /// <summary>
        /// 保存出租
        /// </summary>
        private static string SaveRent(string userId, string title, string describe, string itemName, string cover,
            string certificate, string imgs, string source, string constitute, string price, string official)
        {
            bool b = false;
            RentEntity rentEntity = new RentEntity();
            rentEntity.UserId = userId;
            rentEntity.Title = title;
            rentEntity.Describe = describe;
            rentEntity.ItemName = itemName;
            rentEntity.Cover = cover;
            if (certificate == null)
            {
                certificate = "";
            }
            rentEntity.Certificate = certificate;
            rentEntity.Imgs = imgs;
            rentEntity.Source = source;
            rentEntity.Constitute = constitute;
            rentEntity.Price = price;
            rentEntity.Official = official;
            rentEntity.RentPerson = "";
            rentEntity.AddTime = DateTime.Now;
            rentEntity.EnterTime = Convert.ToDateTime("1900-01-01");
            rentEntity.Examine = "1";
            rentEntity.Status = 1;
            b = RentBll.Instance.Add(rentEntity) > 0;
            if (b)
            {
                return "{\"status\":\"success\"}";
            }
            return "{\"status\":\"error\"}";
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