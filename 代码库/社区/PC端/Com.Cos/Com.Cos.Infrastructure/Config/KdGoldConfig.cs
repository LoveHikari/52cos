namespace Com.Cos.Infrastructure.Config
{
    public class KdGoldConfig
    {
        /// <summary>
        /// 电商ID
        /// </summary>
        public static string EBusinessId => ConfigurationManager.Get("KdGoldConfig:EBusinessId");
        /// <summary>
        /// 电商加密私钥，快递鸟提供，注意保管，不要泄漏
        /// </summary>
        public static string AppKey => ConfigurationManager.Get("KdGoldConfig:AppKey");
        /// <summary>
        /// 请求url
        /// </summary>
        public static string ReqUrl => ConfigurationManager.Get("KdGoldConfig:ReqUrl");
    }
}