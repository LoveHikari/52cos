using System;
using System.Collections.Generic;
using System.Data;
using Com.Cos.Bll;
using System.Text;
using System.Web;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Api
{
    /// <summary>
    /// 获得一些会员相关内容的类
    /// </summary>
    public class MemberApi
    {
        /// <summary>
        /// 获得作者发布的作品数
        /// </summary>
        /// <returns></returns>
        public static string GetWorksNum(string userId)
        {
            //1.取作品数
            DataTable worksTable = WorksBll.Instance.GetList("User_id='" + userId + "' and status='1'");
            return worksTable.Rows.Count.ToString();
        }
        /// <summary>
        /// 获得作者发布的合作数
        /// </summary>
        /// <returns></returns>
        public static string GetCooNum(string userId)
        {
            //2.取合作数
            DataTable cooTable = CooperationBll.Instance.GetList("User_id='" + userId + "'");
            return cooTable.Rows.Count.ToString();
        }
        /// <summary>
        /// 获得作者发布的活动数
        /// </summary>
        /// <returns></returns>
        public static string GetActivityNum(string userId)
        {
            //3.取活动数
            DataTable activityTable = ActivityBll.Instance.GetList("User_id='" + userId + "'");
            return activityTable.Rows.Count.ToString();
        }
        /// <summary>
        /// 获得作者发布的文章数
        /// </summary>
        /// <returns></returns>
        public static string GetArticleNum(string userId)
        {
            //文章数=作品数+合作数+活动数
            //1.取作品数
            DataTable worksTable = WorksBll.Instance.GetList("User_id='" + userId + "' and status='1'");
            int worksNum = worksTable.Rows.Count;
            //2.取合作数
            DataTable cooTable = CooperationBll.Instance.GetList("User_id='" + userId + "'");
            int cooNum = cooTable.Rows.Count;
            //3.取活动数
            DataTable activityTable = ActivityBll.Instance.GetList("User_id='" + userId + "'");
            int activityNum = activityTable.Rows.Count;

            return worksNum + cooNum + activityNum + "";
        }
        /// <summary>
        /// 获得作者的评论数
        /// </summary>
        /// <returns></returns>
        public static string GetReplyNum(string userId)
        {
            DataTable replyTable = ReplyBll.Instance.GetList("User_id='" + userId + "'");
            return replyTable.Rows.Count.ToString();
        }
        /// <summary>
        /// 账号注册
        /// </summary>
        /// <param name="nickname">昵称</param>
        /// <param name="acc">邮箱</param>
        /// <param name="pwd">密码（未加密）</param>
        /// <returns></returns>
        public static string Register(string nickname, string acc, string pwd)
        {
            string email, phone;
            if (RegexUtil.IsEmail(acc))
            {
                email = acc;
                phone = "";
            }
            else
            {
                phone = acc;
                email = "";
            }

            MemberEntity memberEntity = new MemberEntity();
            memberEntity.User_name = "";
            memberEntity.Email = email;
            memberEntity.Password = DEncryptUtils.Encrypt3DES(pwd);
            memberEntity.Real_name = "";
            memberEntity.nickname = nickname;
            memberEntity.Phone_mob = phone;
            memberEntity.Gender = memberEntity.Birthday = memberEntity.Phone_tel = memberEntity.Im_qq = memberEntity.Im_msn
            = memberEntity.In_skype = memberEntity.Im_yahoo = memberEntity.Im_aliww = memberEntity.Outer_id
            = memberEntity.Feed_config = "";
            memberEntity.Portrait = "/Upload/Portrait/1.jpg";
            memberEntity.Reg_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            memberEntity.Last_login = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            memberEntity.Last_ip = IpHelper.GetUserIp();
            memberEntity.Logins = 0;
            memberEntity.Ugrade = 1;
            memberEntity.Status = 1;
            memberEntity.reward = 0;
            memberEntity.CNbi = 0;
            memberEntity.integral = 0;
            memberEntity.ardent = 0;
            memberEntity.Growth = 0;
            memberEntity.Describe = "";
            memberEntity.Shenjia = 0;
            memberEntity.Bean = "";
            memberEntity.code = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Guid.NewGuid().ToString(), "MD5");
            memberEntity.Activation = "0";
            if (RegexUtil.IsEmail(acc))
            {
                if (SendRegisterMail(nickname, memberEntity.code, email))
                {
                    if (MemberBll.Instance.Add(memberEntity) > 0)
                    {
                        return "注册成功";
                    }
                    else
                    {
                        return "账号信息保存失败";
                    }
                }
                else
                {
                    return "邮件发生失败";
                }
            }
            else
            {
                if (MemberBll.Instance.Add(memberEntity) > 0)
                {
                    return "注册成功";
                }
                else
                {
                    return "账号信息保存失败";
                }
            }
            
        }
        /// <summary>
        /// 发生注册邮件
        /// </summary>
        /// <param name="nickname">昵称</param>
        /// <param name="code">邮件码</param>
        /// <param name="email">邮箱地址</param>
        /// <returns>成功返回true，失败返回flase</returns>
        public static bool SendRegisterMail(string nickname,string code, string email)
        {
            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat(EmailConfig.Instance._EmailBody, nickname, HttpContext.Current.Request.Url.Host, code);
            //发送注册邮件
            return MailHelper.sendMail(EmailConfig.Instance._EmailRegisterTitle, mailBody.ToString(), EmailConfig.Instance._EmailName, new List<string>() { email }, EmailConfig.Instance._EmailAgreement, EmailConfig.Instance._EmailUserName, EmailConfig.Instance._EmailPassword);
        }

        /// <summary>
        /// 发生注册邮件
        /// </summary>
        /// <param name="nickname">昵称</param>
        /// <param name="body">内容</param>
        /// <param name="email">邮箱地址</param>
        /// <returns>成功返回true，失败返回flase</returns>
        public static bool SendMail(string nickname, string body, string email)
        {
            return MailHelper.sendMail(EmailConfig.Instance._EmailRegisterTitle, body, EmailConfig.Instance._EmailName, new List<string>() { email }, EmailConfig.Instance._EmailAgreement, EmailConfig.Instance._EmailUserName, EmailConfig.Instance._EmailPassword);
        }
        /// <summary>
        /// 获得会员头像
        /// </summary>
        /// <param name="userId">会员id</param>
        /// <returns></returns>
        public static string GetPortraitUrl(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return "";
            }
            MemberEntity memberEntity = MemberBll.Instance.GetModel(int.Parse(userId));
            if (memberEntity != null)
            {
                return memberEntity.Portrait.Replace("\\", "/");
            }
            return "";
        }
        /// <summary>
        /// 获得会员昵称
        /// </summary>
        /// <param name="userId">会员Id</param>
        /// <returns></returns>
        public static string GetNickname(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return "";
            }
            MemberEntity memberEntity = MemberBll.Instance.GetModel(int.Parse(userId));
            if (memberEntity != null)
            {
                return memberEntity.nickname;
            }
            return "";
        }
    }
}