using System;
using Com.Cos.Infrastructure.Config;
using RongCloud.Server.NetCore.messages;
using RongCloud.Server.NetCore.models;

namespace Com.Cos.Infrastructure
{
    /// <summary>
    /// 融云帮助类
    /// </summary>
    public class RongCloudHelper
    {
        private static readonly string RongAppkey = RongCloudConfig.RongAppkey;  //融云appkey
        private static readonly string RongAppsecret = RongCloudConfig.RongAppsecret;  //融云appSecret
        private static readonly string RongFromuseridSystem = RongCloudConfig.RongFromuseridSystem;  //融云系统信息发送id，姓名：系统消息
        private static readonly string RongFromuseridInteractive = RongCloudConfig.RongFromuseridInteractive;  //融云系统信息发送id，姓名：互动消息

        private static readonly RongCloud.Server.NetCore.RongCloud Rongcloud = RongCloud.Server.NetCore.RongCloud.getInstance(RongAppkey, RongAppsecret);

        /// <summary>
        /// 获得用户token
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="nickname"></param>
        /// <param name="portraitUri"></param>
        /// <returns></returns>
        public static string GetToken(string userId, string nickname = "", string portraitUri = "http://www.rongcloud.cn/images/logo.png")
        {
            TokenReslut usergetTokenResult = Rongcloud.user.getToken(userId, nickname, portraitUri);
            return usergetTokenResult.getToken();
        }

        /// <summary>
        /// 发送系统消息
        /// </summary>
        /// <param name="toUserId">接收用户Id，提供多个本参数可以实现向多用户发送系统消息，上限为 100 人。以逗号隔开</param>
        /// <param name="content">表示文本内容</param>
        /// <param name="extra">附加信息(如果开发者自己需要，可以自己在 App 端进行解析)</param>
        /// <returns></returns>
        public static string PublishSystemBySystem(string toUserId, string content, string extra= "helloExtra")
        {
            return PublishSystem(RongFromuseridSystem, toUserId, content, extra);
        }

        /// <summary>
        /// 发送互动消息
        /// </summary>
        /// <param name="toUserId">接收用户Id，提供多个本参数可以实现向多用户发送系统消息，上限为 100 人。以逗号隔开</param>
        /// <param name="content">表示文本内容</param>
        /// <param name="extra">附加信息(如果开发者自己需要，可以自己在 App 端进行解析)</param>
        /// <returns></returns>
        public static string PublishSystemByInteractive(string toUserId, string content, string extra = "helloExtra")
        {
            return PublishSystem(RongFromuseridInteractive, toUserId, content, extra);
        }




        /// <summary>
        /// 发送系统消息方法（一个用户向一个或多个用户发送系统消息，单条消息最大 128k，会话类型为 SYSTEM。每秒钟最多发送 100 条消息，每次最多同时向 100 人发送，如：一次发送 100 人时，示为 100 条消息。） 
        /// </summary>
        /// <param name="fromUserId">发送人用户 Id</param>
        /// <param name="toUserId">接收用户Id，提供多个本参数可以实现向多用户发送系统消息，上限为 100 人。以逗号隔开</param>
        /// <param name="content">表示文本内容</param>
        /// <param name="extra">附加信息(如果开发者自己需要，可以自己在 App 端进行解析)</param>
        /// <returns></returns>
        private static string PublishSystem(string fromUserId,string toUserId, string content, string extra)
        {
            String[] messagepublishSystemToUserId = toUserId.Split(',', StringSplitOptions.RemoveEmptyEntries); ;  //接收用户Id

            TxtMessage messagepublishSystemTxtMessage = new TxtMessage(content, extra);
            CodeSuccessReslut messagepublishSystemResult = Rongcloud.message.PublishSystem(fromUserId, messagepublishSystemToUserId, messagepublishSystemTxtMessage, "thisisapush", "{\"pushData\":\"hello\"}", 1, 1);
            //Console.WriteLine("message.PublishSystem:  " + messagepublishSystemResult.toString());
            return "200";
        }
    }
}