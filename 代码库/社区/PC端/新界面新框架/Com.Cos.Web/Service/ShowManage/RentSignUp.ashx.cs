using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Web.Service.ShowManage
{
    /// <summary>
    /// RentSignUp 的摘要说明
    /// 出租报名
    /// </summary>
    public class RentSignUp : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string userId = context.Request.Form["UserId"];  //报名人id
            string rId = context.Request.Form["RId"];  //出租的帖子id
            string address = context.Request.Form["AddressId"];  //收货地址id
            string s = "{\"status\":\"error\"}";
            bool b = false;
            //获得帖子信息
            RentEntity rentEntity = RentBll.Instance.GetModel(int.Parse(rId));
            string official = rentEntity.Official;
            if (rentEntity.Examine == "1")  //兑换中状态
            {
                //取身家值
                MemberEntity memberEntity = MemberBll.Instance.GetModel(int.Parse(userId));
                if (memberEntity.Shenjia < decimal.Parse(official))
                {
                    s = "{\"status\":\"lacking\"}";
                }
                else
                {
                    //添加积分变更表
                    IntegralChangeEntity integralChangeEntity = new IntegralChangeEntity();
                    integralChangeEntity.UserId = userId;
                    integralChangeEntity.source = "rent";  //出租
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
                    MemberBll.Instance.UpdateIntegral(userId, "ShenJia", integralChangeEntity.ShenJia.ToString());
                    //添加兑换表
                    RentPersonEntity rentPersonEntity = new RentPersonEntity();
                    rentPersonEntity.UserId = userId;
                    rentPersonEntity.RId = rId;
                    rentPersonEntity.AddTime = DateTime.Now;
                    rentPersonEntity.Address = address;
                    rentPersonEntity.Examine = "1";
                    rentPersonEntity.Status = 1;
                    b = RentPersonBll.Instance.Add(rentPersonEntity) > 0;
                    if (b)
                    {
                        //更新出租表
                        rentEntity.RentPerson = userId;
                        rentEntity.EnterTime = DateTime.Now;
                        rentEntity.Examine = "0";
                        b = RentBll.Instance.Update(rentEntity);
                        if (b)
                        {
                            s = "{\"status\":\"success\"}";
                        }
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}