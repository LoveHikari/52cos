namespace Com.Cos.Infrastructure.Config
{
    public class OtherConfig
    {
        /// <summary>
        /// 头像目录
        /// </summary>
        public static string PortraitWebDir => ConfigurationManager.Get("OtherConfig:PortraitWebDir");
        /// <summary>
        /// 图片目录
        /// </summary>
        public static string ImgWebDir => ConfigurationManager.Get("OtherConfig:ImgWebDir");
        /// <summary>
        /// 临时文件目录
        /// </summary>
        public static string TempFileDir => ConfigurationManager.Get("OtherConfig:TempFileDir");
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string CosSSMSConnString => ConfigurationManager.Get("ConnectionStrings:CosSSMSConnString");
        public static string AppleDownloadUrl => ConfigurationManager.Get("OtherConfig:AppleDownloadUrl");
        public static string AndroidDownloadUrl => ConfigurationManager.Get("OtherConfig:AndroidDownloadUrl");
    }
}