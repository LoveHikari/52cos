namespace Com.Cos.Infrastructure.Config
{
    public class RongCloudConfig
    {
        /// <summary>
        /// 融云appkey
        /// </summary>
        public static string RongAppkey => ConfigurationManager.Get("RongCloudConfig:RongAppkey");
        /// <summary>
        /// 融云appSecret
        /// </summary>
        public static string RongAppsecret => ConfigurationManager.Get("RongCloudConfig:RongAppsecret");
        /// <summary>
        /// 融云系统信息发送id，姓名：系统消息
        /// </summary>
        public static string RongFromuseridSystem => ConfigurationManager.Get("RongCloudConfig:RongFromuseridSystem");
        /// <summary>
        /// 融云系统信息发送id，姓名：互动消息
        /// </summary>
        public static string RongFromuseridInteractive => ConfigurationManager.Get("RongCloudConfig:RongFromuseridInteractive");
    }
}