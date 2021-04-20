using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Com.Cos.Api;
using Com.Cos.Bll;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Web.Service.App_Public
{
    /// <summary>
    /// RegisterLogin 的摘要说明
    /// 注册，并登录
    /// </summary>
    public class RegisterLogin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string nickname = context.Request.Form["user[nickname]"];
            string email = context.Request.Form["user[email]"];
            string pwd = context.Request.Form["user[pwd]"];
            string s = "{\"status\":\"error\"}";
            bool b = false;
            DataTable dt = MemberBll.Instance.GetList("Email='"+email+"'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                s = "{\"status\":\"exist\"}";
                return;
            }

            MemberEntity memberEntity = new MemberEntity();
            memberEntity.User_name = "";
            memberEntity.Email = email;
            memberEntity.Password = DEncryptUtils.Encrypt3DES(pwd);
            memberEntity.Real_name = "";
            memberEntity.nickname = nickname;
            memberEntity.Gender = memberEntity.Birthday = memberEntity.Phone_tel = memberEntity.Phone_mob = memberEntity.Im_qq = memberEntity.Im_msn 
            = memberEntity.In_skype = memberEntity.Im_yahoo = memberEntity.Im_aliww = memberEntity.Outer_id 
            = memberEntity.Feed_config = "";
            memberEntity.Portrait = "/Upload/Portrait/1.jpg";
            memberEntity.Reg_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            memberEntity.Last_login = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            memberEntity.Last_ip = new BasePage().ClientIP;
            memberEntity.Logins = 0;
            memberEntity.Ugrade = 1;
            memberEntity.Status = 1;
            memberEntity.reward = 0;
            memberEntity.CNbi = 0;
            memberEntity.integral = 0;
            memberEntity.ardent = 0;
            memberEntity.Growth = 0;
            memberEntity.code = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Guid.NewGuid().ToString(), "MD5");
            memberEntity.Activation = "0";
            memberEntity.Describe = "";
            memberEntity.Shenjia = 0;
            memberEntity.Bean = "0";

            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat(EmailConfig.Instance._EmailBody, memberEntity.nickname, HttpContext.Current.Request.Url.Host, memberEntity.code);

            //发送注册邮件
            b = MemberApi.SendRegisterMail(memberEntity.nickname, memberEntity.code, memberEntity.Email);
            if (b)
            {
                b = MemberBll.Instance.Add(memberEntity)>0;
                if (b)
                {
                    CookieHelper cookieHelper = new CookieHelper("52cos", DateTime.Now.AddMonths(1));
                    dt = MemberBll.Instance.GetList("Email='" + memberEntity.Email + "' and Password='"+memberEntity.Password+"'").Tables[0];
                    cookieHelper.SetCookie("user_id", DEncryptUtils.DESEncrypt(dt.Rows[0]["User_id"].ToString())); //将user_id添加到cookie
                    cookieHelper.SetCookie("pwd", memberEntity.Password); //将Password添加到cookie
                    s = "{\"status\":\"success\"}";
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