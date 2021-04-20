using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Com.Cos.Bll;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Web.Service.App_Public
{
    /// <summary>
    /// RebuildPassword 的摘要说明
    /// 重设密码
    /// </summary>
    public class RebuildPassword : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string code = context.Request.Form["user[token]"];
            string pwd = context.Request.Form["user[pwd]"];
            bool b = false;
            DataTable dt = MemberBll.Instance.GetList("code='" + code + "'").Tables[0];
            MemberEntity memberEntity = MemberBll.Instance.GetModel(Convert.ToInt32(dt.Rows[0]["User_id"]));
            memberEntity.Password = DEncryptUtils.Encrypt3DES(pwd);
            memberEntity.Activation = "1";
            b = MemberBll.Instance.Update(memberEntity);
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            context.Response.Write(b);
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