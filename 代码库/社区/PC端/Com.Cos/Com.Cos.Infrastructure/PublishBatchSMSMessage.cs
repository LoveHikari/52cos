using System;
using System.Collections.Generic;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Sms.Model.V20160927;
using Aliyun.MNS;
using Aliyun.MNS.Model;

namespace Com.Cos.Infrastructure
{
    /// <summary>
    /// 发生短信
    /// </summary>
    public class PublishBatchSMSMessage
    {
        /// <summary>
        /// 用户注册验证码
        /// </summary>
        /// <param name="recNum">接收号码</param>
        /// <returns>6位验证码</returns>
        public static string UserRegistrationVerifyCode(string recNum)
        {
            Random ran = new Random();
            string code = ran.RandomNumber(6, true);

            /**
            * Step 1. 初始化Client
            */
            IMNS client = new Aliyun.MNS.MNSClient(Permanent.ACCESS_KEY_ID, Permanent.ACCESS_KEY_SECRET, Permanent.ENDPOINT);
            /**
             * Step 2. 获取主题引用
             */
            Topic topic = client.GetNativeTopic(Permanent.TOPIC_NAME);
            /**
             * Step 3. 生成SMS消息属性
             */
            MessageAttributes messageAttributes = new MessageAttributes();
            BatchSmsAttributes batchSmsAttributes = new BatchSmsAttributes();
            // 3.1 设置发送短信的签名：SMSSignName
            batchSmsAttributes.FreeSignName = "幻幻平台";
            // 3.2 设置发送短信的模板SMSTemplateCode
            batchSmsAttributes.TemplateCode = "SMS_25255316";
            Dictionary<string, string> param = new Dictionary<string, string>();
            // 3.3 （如果短信模板中定义了参数）设置短信模板中的参数，发送短信时，会进行替换
            param.Add("code", code);
            param.Add("product", "幻幻社区");
            // 3.4 设置短信接收者手机号码
            batchSmsAttributes.AddReceiver(recNum, param);

            messageAttributes.BatchSmsAttributes = batchSmsAttributes;
            PublishMessageRequest request = new PublishMessageRequest();
            request.MessageAttributes = messageAttributes;
            /**
             * Step 4. 设置SMS消息体（必须）
             *
             * 注：目前暂时不支持消息内容为空，需要指定消息内容，不为空即可。
             */
            request.MessageBody = "smsmessage";

            /**
             * Step 5. 发布SMS消息
             */
            PublishMessageResponse resp = topic.PublishMessage(request);
            //return resp.MessageId;
            return code;
        }

        /// <summary>
        /// 身份验证验证码
        /// </summary>
        /// <param name="recNum">接收号码</param>
        /// <returns>6位验证码</returns>
        public static string AuthenticationVerifyCode(string recNum)
        {
            Random ran = new Random();
            string code = ran.RandomNumber(6, true);

            /**
            * Step 1. 初始化Client
            */
            IMNS client = new Aliyun.MNS.MNSClient(Permanent.ACCESS_KEY_ID, Permanent.ACCESS_KEY_SECRET, Permanent.ENDPOINT);
            /**
             * Step 2. 获取主题引用
             */
            Topic topic = client.GetNativeTopic(Permanent.TOPIC_NAME);
            /**
             * Step 3. 生成SMS消息属性
             */
            MessageAttributes messageAttributes = new MessageAttributes();
            BatchSmsAttributes batchSmsAttributes = new BatchSmsAttributes();
            // 3.1 设置发送短信的签名：SMSSignName
            batchSmsAttributes.FreeSignName = "幻幻平台";
            // 3.2 设置发送短信的模板SMSTemplateCode
            batchSmsAttributes.TemplateCode = "SMS_25255320";
            Dictionary<string, string> param = new Dictionary<string, string>();
            // 3.3 （如果短信模板中定义了参数）设置短信模板中的参数，发送短信时，会进行替换
            param.Add("code", code);
            param.Add("product", "幻幻社区");
            // 3.4 设置短信接收者手机号码
            batchSmsAttributes.AddReceiver(recNum, param);

            messageAttributes.BatchSmsAttributes = batchSmsAttributes;
            PublishMessageRequest request = new PublishMessageRequest();
            request.MessageAttributes = messageAttributes;
            /**
             * Step 4. 设置SMS消息体（必须）
             *
             * 注：目前暂时不支持消息内容为空，需要指定消息内容，不为空即可。
             */
            request.MessageBody = "smsmessage";

            /**
             * Step 5. 发布SMS消息
             */
            PublishMessageResponse resp = topic.PublishMessage(request);
            //return resp.MessageId;
            return code;
        }
    }
}