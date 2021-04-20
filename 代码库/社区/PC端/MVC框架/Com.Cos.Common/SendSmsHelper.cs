using System;
using System.Collections.Generic;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Sms.Model.V20160927;
using ServerException = System.Runtime.Remoting.ServerException;

namespace Com.Cos.Common
{
    /// <summary>
    /// 发送短信帮助类
    /// </summary>
    public class SendSmsHelper
    {
        /// <summary>
        /// 发送短信通用接口
        /// </summary>
        /// <param name="signName">管理控制台中配置的短信签名（状态必须是验证通过）</param>
        /// <param name="templateCode">管理控制台中配置的审核通过的短信模板的模板CODE（状态必须是验证通过）</param>
        /// <param name="recNum">接收号码，多个号码可以逗号分隔</param>
        /// <param name="paramString">短信模板中的变量；数字需要转换为字符串；个人用户每个变量长度必须小于15个字符。例：{"code":"123456","product":"登录"}</param>
        /// <returns>是否发送成功</returns>
        private static bool SingleSendSms(string signName, string templateCode, string recNum, string paramString)
        {
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", "PrDPRjqAl2epRSnX", "H7vLdyxHi23Xz7hDsAevGruVAWxsFP");
            IAcsClient client = new DefaultAcsClient(profile);
            SingleSendSmsRequest request = new SingleSendSmsRequest();
            try
            {
                request.SignName = signName;// "管理控制台中配置的短信签名（状态必须是验证通过）";
                request.TemplateCode = templateCode;//"管理控制台中配置的审核通过的短信模板的模板CODE（状态必须是验证通过）";
                request.RecNum = recNum;//"接收号码，多个号码可以逗号分隔";
                request.ParamString = paramString;//"短信模板中的变量；数字需要转换为字符串；个人用户每个变量长度必须小于15个字符。";
                SingleSendSmsResponse httpResponse = client.GetAcsResponse(request);
                return true;
            }
            catch (ServerException ex)
            {
                WriteLogHelper.WriteError(ex);
                throw;
            }
            catch (ClientException ex)
            {
                WriteLogHelper.WriteError(ex);
                throw;
            }
        }

        /// <summary>
        /// 用户注册验证码，例：
        /// api/SendSms/UserRegister?recNum={18758855664}
        /// </summary>
        /// <param name="recNum">接收的手机号码</param>
        /// <returns>验证码，发送失败返回0</returns>
        // POST api/SendSms/UserRegister?recNum=18758855664
        public static string UserRegister(string recNum)
        {
            Random ran = new Random();
            string code = ran.RandomNumber(6, true);
            string paramString = "{\"code\":\"" + code + "\",\"product\":\"幻幻社区\"}";
            bool b = SingleSendSms("幻幻平台", "SMS_25255316", recNum, paramString);
            if (b)  //发送成功
            {
                return code;
            }
            return "0";
        }
    }
}