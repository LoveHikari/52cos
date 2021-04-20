using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Com.Cos.WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IModuleService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
        /// <summary>
        /// 发送短信通用接口
        /// </summary>
        /// <param name="signName">管理控制台中配置的短信签名（状态必须是验证通过）</param>
        /// <param name="templateCode">管理控制台中配置的审核通过的短信模板的模板CODE（状态必须是验证通过）</param>
        /// <param name="recNum">接收号码，多个号码可以逗号分隔</param>
        /// <param name="paramString">短信模板中的变量；数字需要转换为字符串；个人用户每个变量长度必须小于15个字符。例：{"code":"123456","product":"登录"}</param>
        /// <returns>成功返回200</returns>
        [OperationContract]
        string SingleSendSms(string signName, string templateCode, string recNum, string paramString);
    }


    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
