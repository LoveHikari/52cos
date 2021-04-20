using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Sms.Model.V20160927;
using System;
using System.Web.Services;
using Com.Cos.Common;

namespace Com.Cos.WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class ModuleService : IModuleService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>
        /// 发送短信通用接口
        /// </summary>
        /// <param name="signName">管理控制台中配置的短信签名（状态必须是验证通过）</param>
        /// <param name="templateCode">管理控制台中配置的审核通过的短信模板的模板CODE（状态必须是验证通过）</param>
        /// <param name="recNum">接收号码，多个号码可以逗号分隔</param>
        /// <param name="paramString">短信模板中的变量；数字需要转换为字符串；个人用户每个变量长度必须小于15个字符。例：{"code":"123456","product":"登录"}</param>
        /// <returns>成功返回200</returns>
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
                WriteLogHelper.WriteError(ex);
                throw;
            }
            catch (ClientException ex)
            {
                WriteLogHelper.WriteError(ex);
                throw;
            }
        }
    }
}
