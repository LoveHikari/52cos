namespace Com.Cos.Infrastructure.Config
{
    public class WxPayConfig
    {
        /// <summary>
        /// 绑定支付的APPID（必须配置）
        /// </summary>
        public static string AppId => ConfigurationManager.Get("WxPayConfig:AppId");
        /// <summary>
        /// 商户号（必须配置）
        /// </summary>
        public static string MchId => ConfigurationManager.Get("WxPayConfig:MchId");
        /// <summary>
        /// 商户支付密钥，参考开户邮件设置（必须配置）
        /// </summary>
        public static string Key => ConfigurationManager.Get("WxPayConfig:Key");
        /// <summary>
        /// 公众帐号secert（仅JSAPI支付的时候需要配置）
        /// </summary>
        public static string AppSecret => ConfigurationManager.Get("WxPayConfig:AppSecret");
        /// <summary>
        /// 异步回调地址
        /// </summary>
        public static string NotifyUrl => ConfigurationManager.Get("WxPayConfig:NotifyUrl");
    }
}