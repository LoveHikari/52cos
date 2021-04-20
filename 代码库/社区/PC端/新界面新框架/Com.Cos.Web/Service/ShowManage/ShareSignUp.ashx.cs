using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Com.Cos.Api;
using Com.Cos.Bll;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Web.Service.ShowManage
{
    /// <summary>
    /// ShareSignUp 的摘要说明
    /// 分享报名
    /// </summary>
    public class ShareSignUp : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string userId = context.Request.Form["UserId"];  //报名人id
            string exId = context.Request.Form["ExId"];  //分享的帖子id
            string address = context.Request.Form["AddressId"];  //收货地址id
            string classid = context.Request.Form["classId"];    //1表示直接兑换，2表示会员兑换
            string s = "{\"status\":\"error\"}";
            bool b = false;

            DataTable epdt  = ExchangePersonBll.Instance.GetList($"UserId={userId} and status=1").Tables[0];
            if (epdt.Rows.Count > 0)
            {
                s = "{\"status\":\"exist\"}";  //已有兑换，不能继续兑换
                context.Response.Write(s);
                return;
            }

            //获得帖子信息
            ExchangeEntity exchangeEntity = ExchangeBll.Instance.GetModel(int.Parse(exId));
            string official = exchangeEntity.Official;
            if (exchangeEntity.Examine == "4")  //兑换中状态
            {
                if (classid == "2")    //会员兑换
                {
                    if (!VipExchange(int.Parse(userId)))
                    {
                        s = "{\"status\":\"lacking\"}";  //会员不足
                        context.Response.Write(s);
                        return;
                    }
                }
                else  //普通兑换
                {
                    if (!OrdinaryExchange(int.Parse(userId), official))
                    {
                        s = "{\"status\":\"lacking\"}";  //身家不足
                        context.Response.Write(s);
                        return;
                    }
                }

                //添加兑换表
                ExchangePersonEntity exchangePersonEntity = new ExchangePersonEntity();
                exchangePersonEntity.UserId = userId;
                exchangePersonEntity.ExId = exId;
                exchangePersonEntity.AddTime = DateTime.Now;
                exchangePersonEntity.Address = address;
                exchangePersonEntity.Examine = "1";
                exchangePersonEntity.Status = 1;
                b = ExchangePersonBll.Instance.Add(exchangePersonEntity) > 0;
                if (b)
                {
                    //更新分享表
                    exchangeEntity.ExchangePerson = userId;
                    exchangeEntity.EnterTime = DateTime.Now;
                    exchangeEntity.Examine = "5";
                    b = ExchangeBll.Instance.Update(exchangeEntity);
                    if (b)
                    {
                        MailingAddressEntity mailingAddressEntity = MailingAddressBll.Instance.GetModel(int.Parse(exchangePersonEntity.Address));
                        string body = $@"id为：{exchangeEntity.Id}，标题为：{exchangeEntity.Title}，收货地址为：{mailingAddressEntity.Province}省{mailingAddressEntity.City}市{mailingAddressEntity.County}区/县{mailingAddressEntity.Address}，
                                            邮政编码为：{mailingAddressEntity.ZipCode}，兑换人：{mailingAddressEntity.Name}，兑换人手机号为：{mailingAddressEntity.Phone}";

                        MailHelper.sendMail("分享被兑换", body, EmailConfig.Instance._EmailName, new List<string>() { EmailConfig.Instance._EmailUserName }, EmailConfig.Instance._EmailAgreement, EmailConfig.Instance._EmailUserName, EmailConfig.Instance._EmailPassword);
                        s = "{\"status\":\"success\"}";
                    }
                }


            }
            else
            {
                s = "{\"status\":\"other\"}";
            }


            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            context.Response.Write(s);
        }
        /// <summary>
        /// 会员兑换
        /// </summary>
        /// <param name="userId"></param>
        private bool VipExchange(int userId)
        {
            MemberEntity memberEntity = MemberBll.Instance.GetModel(userId);
            if (memberEntity.Etime < DateTime.Now || memberEntity.RemainingConversions < 1)
            {
                return false;
            }
            else
            {
                //添加积分变更表
                IntegralChangeEntity integralChangeEntity = new IntegralChangeEntity();
                integralChangeEntity.UserId = userId.ToString();
                integralChangeEntity.source = "vipshareRedemption";
                integralChangeEntity.ShenJia = 0;
                integralChangeEntity.Cnbi = "0";
                integralChangeEntity.integral = 0;
                integralChangeEntity.ardent = 0;
                integralChangeEntity.Growth = 0;
                integralChangeEntity.Bean = "0";
                integralChangeEntity.Status = 1;
                integralChangeEntity.AddTime = DateTime.Now;
                IntegralChangeBll.Instance.Add(integralChangeEntity);
                //更新会员表积分
                MemberBll.Instance.UpdateIntegral(userId.ToString(), "RemainingConversions", "-1");
                return true;
            }
        }
        /// <summary>
        /// 普通兑换
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="official"></param>
        private bool OrdinaryExchange(int userId, string official)
        {
            //取身家值
            MemberEntity memberEntity = MemberBll.Instance.GetModel(userId);
            if (decimal.Parse(memberEntity.Shenjia.ToString()) < decimal.Parse(official))
            {
                //s = "{\"status\":\"lacking\"}";  //身家不足
                return false;
            }
            else
            {
                //添加积分变更表
                IntegralChangeEntity integralChangeEntity = new IntegralChangeEntity();
                integralChangeEntity.UserId = userId.ToString();
                integralChangeEntity.source = "shareRedemption";
                integralChangeEntity.ShenJia = -decimal.Parse(official);
                integralChangeEntity.Cnbi = "0";
                integralChangeEntity.integral = 0;
                integralChangeEntity.ardent = 0;
                integralChangeEntity.Growth = 0;
                integralChangeEntity.Bean = "0";
                integralChangeEntity.Status = 1;
                integralChangeEntity.AddTime = DateTime.Now;
                IntegralChangeBll.Instance.Add(integralChangeEntity);
                //更新会员表积分
                MemberBll.Instance.UpdateIntegral(userId.ToString(), "ShenJia", integralChangeEntity.ShenJia.ToString());
                return true;
            }
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