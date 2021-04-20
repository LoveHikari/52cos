using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Web.Service.ShowManage
{
    /// <summary>
    /// Address 的摘要说明
    /// 添加收货地址
    /// </summary>
    public class Address : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string addId = context.Request.Form["ctb[post-addId]"];  //地址id
            string status = context.Request.Form["ctb[post-status]"];  //修改状态（add、update）
            string userId = context.Request.Form["ctb[post-userId]"];  //会员id
            string province = context.Request.Form["ctb[post-province]"];  //省
            string city = context.Request.Form["ctb[post-city]"];  //市
            string county = context.Request.Form["ctb[post-county]"];  //区/县
            string address = context.Request.Form["ctb[post-address]"];  //详细地址
            string zipCode = context.Request.Form["ctb[post-zipCode]"];  //邮政编码
            string name = context.Request.Form["ctb[post-name]"];  //姓名
            string phone = context.Request.Form["ctb[post-phone]"];  //手机号码
            string s = "{\"status\":\"error\"}";
            bool b = false;

            if (status == "add")  //增加
            {
                MailingAddressEntity mailingAddressEntity = new MailingAddressEntity();
                mailingAddressEntity.UserId = userId;
                mailingAddressEntity.Province = province;
                mailingAddressEntity.City = city;
                mailingAddressEntity.County = county;
                mailingAddressEntity.Address = address;
                mailingAddressEntity.Name = name;
                mailingAddressEntity.ZipCode = zipCode;
                mailingAddressEntity.Phone = phone;
                mailingAddressEntity.AddTime = DateTime.Now;
                mailingAddressEntity.Status = 1;
                b = MailingAddressBll.Instance.Add(mailingAddressEntity) > 0;
            }
            else  //修改
            {
                MailingAddressEntity mailingAddressEntity = MailingAddressBll.Instance.GetModel(int.Parse(addId));
                mailingAddressEntity.UserId = userId;
                mailingAddressEntity.Province = province;
                mailingAddressEntity.City = city;
                mailingAddressEntity.County = county;
                mailingAddressEntity.Address = address;
                mailingAddressEntity.Name = name;
                mailingAddressEntity.ZipCode = zipCode;
                mailingAddressEntity.Phone = phone;
                mailingAddressEntity.AddTime = DateTime.Now;
                mailingAddressEntity.Status = 1;
                b = MailingAddressBll.Instance.Update(mailingAddressEntity);
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