using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Web.Service.ShowManage
{
    /// <summary>
    /// GoodClick 的摘要说明
    /// 点赞
    /// </summary>
    public class GoodClick : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string workId = context.Request.Form["WorksId"];
            string userId = context.Request.Form["UserId"];
            int i;
            bool b = UserGoodBll.Instance.ExistsByUserId(userId, workId);
            if (b)
            {
                i = 0;  //已赞
            }
            else
            {
                //记录点赞表
                UserGoodEntity userGoodEntity = new UserGoodEntity();
                userGoodEntity.User_id = userId;
                userGoodEntity.WorkId = workId;
                userGoodEntity.Status = 1;
                i = UserGoodBll.Instance.Add(userGoodEntity);
                if (i > 0)
                {
                    //记录积分变更表
                    IntegralChangeEntity integralChangeEntity = new IntegralChangeEntity();
                    integralChangeEntity.UserId = userId;
                    integralChangeEntity.source = "clickLike";
                    integralChangeEntity.Cnbi = "0";
                    integralChangeEntity.integral = 1;
                    integralChangeEntity.ardent = 1;
                    integralChangeEntity.Growth = 1;
                    integralChangeEntity.AddTime = DateTime.Now;
                    integralChangeEntity.Status = 1;
                    IntegralChangeBll.Instance.Add(integralChangeEntity);
                    //更新帖子
                    WorksBll.Instance.UpdateIntegral(workId, "GoodNo", "1");
                    //更新会员表
                    MemberBll.Instance.UpdateIntegral(userId, "integral", "1");
                    MemberBll.Instance.UpdateIntegral(userId, "ardent", "1");
                    MemberBll.Instance.UpdateIntegral(userId, "Growth", "1");
                }
            }
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            context.Response.Write(i);
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