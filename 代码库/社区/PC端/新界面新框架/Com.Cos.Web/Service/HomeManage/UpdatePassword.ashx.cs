using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Com.Cos.Bll;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Web.Service.HomeManage
{
    /// <summary>
    /// UpdatePassword 的摘要说明
    /// 修改密码
    /// </summary>
    public class UpdatePassword : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string userId = context.Request.Form["user[userId]"];
            string oldPwd = context.Request.Form["user[old-pwd]"];
            string newPwd1 = context.Request.Form["user[new-pwd-1]"];
            string s = "{\"status\":\"error\"}";
            bool b = false;

            MemberEntity memberEntity = MemberBll.Instance.GetModel(Convert.ToInt32(userId));
            if (memberEntity != null)
            {
                if (memberEntity.Password == DEncryptUtils.Encrypt3DES(oldPwd))
                {
                    memberEntity.Password = DEncryptUtils.Encrypt3DES(newPwd1);
                    b = MemberBll.Instance.Update(memberEntity);
                    if (b)
                    {
                        s = "{\"status\":\"success\"}";
                    }
                }
            }

            context.Response.ContentType = "text/plain";
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