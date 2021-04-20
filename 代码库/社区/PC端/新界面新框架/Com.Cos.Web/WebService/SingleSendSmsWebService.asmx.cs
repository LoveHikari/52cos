using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Sms.Model.V20160927;
using Com.Cos.Utility;

namespace Com.Cos.Web.WebService
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SingleSendSmsWebService : System.Web.Services.WebService
    {
        /// <summary>
        /// 发送短信通用接口
        /// </summary>
        /// <param name="signName">管理控制台中配置的短信签名（状态必须是验证通过）</param>
        /// <param name="templateCode">管理控制台中配置的审核通过的短信模板的模板CODE（状态必须是验证通过）</param>
        /// <param name="recNum">接收号码，多个号码可以逗号分隔</param>
        /// <param name="paramString">短信模板中的变量；数字需要转换为字符串；个人用户每个变量长度必须小于15个字符。例：{"code":"123456","product":"登录"}</param>
        /// <returns></returns>
        [WebMethod]
        public string SingleSendSms(string signName, string templateCode, string recNum, string paramString)
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
                return "200";
            }
            catch (ServerException ex)
            {
                WriteLog.WriteError(ex);
                throw;
            }
            catch (ClientException ex)
            {
                WriteLog.WriteError(ex);
                throw;
            }
        }
    }
}
