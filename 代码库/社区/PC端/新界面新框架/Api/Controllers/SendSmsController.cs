using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Sms.Model.V20160927;
using Api.Cn52cosSq;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Api.Controllers
{
    /// <summary>
    /// 发送短信
    /// </summary>
    [AllowAnonymous]
    [Authorize]
    public class SendSmsController : ApiController
    {
        /// <summary>
        /// 用户注册验证码，例：
        /// api/SendSms/UserRegister?recNum={18758855664}
        /// </summary>
        /// <param name="recNum">接收号码，多个号码可以逗号分隔</param>
        /// <returns>{"status":200,"code":123456}</returns>
        // POST api/SendSms/UserRegister?recNum=18758855664
        [AcceptVerbs("POST")]
        public object UserRegister(string recNum)
        {
            Random ran = new Random();
            string code = ran.RandomNumber(6,true);
            string paramString = "{\"code\":\"" + code + "\",\"product\":\"幻幻社区\"}";
            SingleSendSmsWebService sms = new SingleSendSmsWebService();
            string status = sms.SingleSendSms("幻幻平台", "SMS_25255316", recNum, paramString);
            return new Dictionary<string, string>() { { "status", status }, { "code", code } };
        }
    }
}
