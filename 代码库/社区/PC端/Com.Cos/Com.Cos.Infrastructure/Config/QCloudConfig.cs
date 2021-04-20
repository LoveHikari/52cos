namespace Com.Cos.Infrastructure.Config
{
    /// <summary>
    /// 腾讯云配置
    /// </summary>
    public class QCloudConfig
    {
        /// <summary>
        /// 授权appid
        /// </summary>
        public static string AppId => ConfigurationManager.Get("QCloudConfig:AppId");
        /// <summary>
        /// 授权secret id
        /// </summary>
        public static string SecretId => ConfigurationManager.Get("QCloudConfig:SecretId");
        /// <summary>
        /// 授权secret key
        /// </summary>
        public static string SecretKey => ConfigurationManager.Get("QCloudConfig:SecretKey");
        public static string BucketName => ConfigurationManager.Get("QCloudConfig:BucketName");
    }
}