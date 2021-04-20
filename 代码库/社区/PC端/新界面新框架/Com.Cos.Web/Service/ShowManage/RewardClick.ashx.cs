using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Web.Service.ShowManage
{
    /// <summary>
    /// RewardClick 的摘要说明
    /// 打赏
    /// </summary>
    public class RewardClick : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string workId = context.Request.Form["WorksId"];
            string userId = context.Request.Form["UserId"];
            string money = context.Request.Form["Money"];
            string uid = context.Request.Form["Uid"];
            int i;
            //查看cn币余额
            MemberEntity memberEntity = MemberBll.Instance.GetModel(int.Parse(userId));
            if (memberEntity.CNbi < int.Parse(money))
            {
                i = 0;
            }
            else
            {


                //记录打赏表
                RewardEntity rewardEntity = new RewardEntity();
                rewardEntity.User_id = userId;
                rewardEntity.worksId = workId;
                rewardEntity.rewardMoney = int.Parse(money);
                rewardEntity.Status = 1;
                i = RewardBll.Instance.Add(rewardEntity);
                if (i > 0)
                {
                    //记录积分变更表
                    IntegralChangeEntity integralChangeEntity = new IntegralChangeEntity();
                    integralChangeEntity.UserId = userId;
                    integralChangeEntity.source = "reward";
                    integralChangeEntity.Cnbi = "-" + money;
                    integralChangeEntity.integral = 1;
                    integralChangeEntity.ardent = 1;
                    integralChangeEntity.Growth = int.Parse(money) * 10;
                    integralChangeEntity.AddTime = DateTime.Now;
                    integralChangeEntity.Status = 1;
                    IntegralChangeBll.Instance.Add(integralChangeEntity);
                    //更新帖子
                    WorksBll.Instance.UpdateIntegral(workId, "reward", money);
                    //更新会员表
                    MemberBll.Instance.UpdateIntegral(userId, "Cnbi", "-" + money);
                    MemberBll.Instance.UpdateIntegral(userId, "integral", "1");
                    MemberBll.Instance.UpdateIntegral(userId, "ardent", "1");
                    MemberBll.Instance.UpdateIntegral(userId, "Growth", (int.Parse(money) * 10).ToString());
                    //记录发帖人积分变更
                    integralChangeEntity = new IntegralChangeEntity();
                    integralChangeEntity.UserId = uid;
                    integralChangeEntity.source = "reward";
                    integralChangeEntity.Cnbi = money;
                    integralChangeEntity.integral = 0;
                    integralChangeEntity.ardent = 0;
                    integralChangeEntity.Growth = 0;
                    integralChangeEntity.AddTime = DateTime.Now;
                    integralChangeEntity.Status = 1;
                    IntegralChangeBll.Instance.Add(integralChangeEntity);
                    //更新发帖人cn币
                    MemberBll.Instance.UpdateIntegral(uid, "Cnbi", money);
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