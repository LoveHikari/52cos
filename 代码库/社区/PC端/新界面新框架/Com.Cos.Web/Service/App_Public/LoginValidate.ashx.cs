using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using Com.Cos.Bll;
using Com.Cos.Utility;

namespace Com.Cos.Web.Service.App_Public
{
    /// <summary>
    /// LoginValidate 的摘要说明
    /// 登录验证
    /// </summary>
    public class LoginValidate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string email = context.Request.Form["user[email]"];
            string pwd = context.Request.Form["user[pwd]"];
            string remember = context.Request.Form["user[remember]"];

            int i = -1;
            DataTable dt;
            if (email.IndexOf("@", StringComparison.Ordinal) > -1)
            {
                dt = MemberBll.Instance.GetList("Email='" + email + "' AND Password='" + DEncryptUtils.Encrypt3DES(pwd) + "'").Tables[0];
            }
            else
            {
                dt = MemberBll.Instance.GetList("User_name='" + email + "' AND Password='" + DEncryptUtils.Encrypt3DES(pwd) + "'").Tables[0];

            }

            if (dt.Rows.Count > 0)
            {
                CookieHelper cookieHelper = null;
                if (remember == "1") //下次自动登录,设置cookie为一个月
                {
                    cookieHelper = new CookieHelper("52cos", DateTime.Now.AddMonths(1));
                }
                else
                {
                    cookieHelper = new CookieHelper("52cos");  //默认关闭浏览器，失效
                }
                cookieHelper.SetCookie("user_id", DEncryptUtils.DESEncrypt(dt.Rows[0]["User_id"].ToString())); //将user_id添加到cookie
                cookieHelper.SetCookie("pwd", dt.Rows[0]["Password"].ToString()); //将Password添加到cookie
                i = 1;
            }
            else
            {
                i = 0;
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