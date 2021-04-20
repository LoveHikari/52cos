namespace Com.Cos.Infrastructure.Config
{
    public class AliPayConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static string AppId => ConfigurationManager.Get("AliPayConfig:AppId");
        /// <summary>
        /// 支付宝网关
        /// </summary>
        public static string ServerUrl => ConfigurationManager.Get("AliPayConfig:ServerUrl");
        public static string Charset => ConfigurationManager.Get("AliPayConfig:Charset");
        /// <summary>
        /// 签名方式
        /// </summary>
        public static string SignType => ConfigurationManager.Get("AliPayConfig:SignType");
        /// <summary>
        /// 异步回调地址
        /// </summary>
        public static string NotifyUrl => ConfigurationManager.Get("AliPayConfig:NotifyUrl");
        /// <summary>
        /// RSA2(SHA256)密钥
        /// </summary>
        public static string AppPrivateKey => ConfigurationManager.Get("AliPayConfig:AppPrivateKey");
        /// <summary>
        /// 支付宝公钥
        /// </summary>
        public static string AlipayPublicKey => ConfigurationManager.Get("AliPayConfig:AlipayPublicKey");
    }
}