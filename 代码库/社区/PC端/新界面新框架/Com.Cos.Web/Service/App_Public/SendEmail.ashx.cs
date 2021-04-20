using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Com.Cos.Bll;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Web.Service.App_Public
{
    /// <summary>
    /// SendEmail 的摘要说明
    /// 邮箱激活
    /// </summary>
    public class SendEmail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string oldCode = context.Request.QueryString["code"];
            bool i = false;
            DataTable dt = MemberBll.Instance.GetList("code='" + oldCode + "'").Tables[0];
            MemberEntity memberEntity = MemberBll.Instance.GetModel(Convert.ToInt32(dt.Rows[0]["User_id"]));
            memberEntity.code = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Guid.NewGuid().ToString(), "MD5");
            memberEntity.Activation = "0";
            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat("亲爱的 {0}", memberEntity.nickname);
            mailBody.Append(@"<br />这封信是由 52cos平台 社区 发送的。<br />
                            您收到这封邮件，是由于在 52cos平台 社区 进行了新用户注册，或用户修改 Email 使用 了这个邮箱地址。如果您并没有访问过 52cos平台 社区，或没有进行上述操作，请忽略这封邮件。您不需要退订或进行其他进一步的操作。
                            <br />
                            <br />
                            ----------------------------------------------------------------------<br />
                            帐号激活说明<br />
                            ----------------------------------------------------------------------<br />
                            <br />
                            如果您是 52cos平台 社区 的新用户，或在修改您的注册 Email 时使用了本地址，我们需要对您的地址有效性进行验证以避免垃圾邮件或地址被滥用。
                            <br  />
                            您只需点击下面的链接即可激活您的帐号：<br />");
            mailBody.AppendFormat(@"<a style='color: #009A61; text-decoration: none;' href='http://{1}/Pages/App_Public/confirm.aspx?type=register&amp;code={0}'>
                            http://{1}/Pages/App_Public/confirm.aspx?type=register&amp;code={0}
                        </a>", memberEntity.code, HttpContext.Current.Request.Url.Host);
            mailBody.Append(@"<br />(如果上面不是链接形式，请将该地址手工粘贴到浏览器地址栏再访问)
                                <br />
                                感谢您的访问，祝您使用愉快！
                                <br />
                                此致<br />
                                52cos平台 社区 管理团队.<br />
                                http://sq.52cos.com/");


            //发送注册邮件
            bool b = MailHelper.sendMail("52cos社区 邮箱激活", mailBody.ToString(), EmailConfig.Instance._EmailName, new List<string>() { dt.Rows[0]["Email"].ToString() }, EmailConfig.Instance._EmailAgreement, EmailConfig.Instance._EmailUserName, EmailConfig.Instance._EmailPassword);
            if (b)
            {
                i = MemberBll.Instance.Update(memberEntity);
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