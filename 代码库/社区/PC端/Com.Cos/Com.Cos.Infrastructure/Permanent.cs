namespace Com.Cos.Infrastructure
{
    /// <summary>
    /// 常量数据
    /// </summary>
    public class Permanent
    {
        //*********************************阿里云发生短信配置***********************************************************//
        public const string ENDPOINT = "http://1453121311298991.mns.cn-hangzhou.aliyuncs.com/";  //访问MNS的接入地址
        public const string ACCESS_KEY_ID = "PrDPRjqAl2epRSnX";
        public const string ACCESS_KEY_SECRET = "H7vLdyxHi23Xz7hDsAevGruVAWxsFP";
        public const string TOPIC_NAME = "sms.topic-cn-hangzhou";  //主题名称




        public const string SUCCESS = "true";  //成功
        public const string FAILED = "false";  //失败

        //public const string PORTRAIT_DIR = "D:\\ftp\\web\\img.52cos.cn\\upload\\portrait";  //头像目录
        //public const string PORTRAIT_WEB_DIR = "/upload/portrait";  //头像目录

        //public const string IMG_DIR = "D:\\ftp\\web\\img.52cos.cn\\upload\\photo";  //图片目录
        //public const string IMG_WEB_DIR = "/upload/photo";

        public const string error_validCodeFailded = "1";
        public const string errorMsg_validCodeFailed = "验证码错误";

        public const string error_relogin = "2";
        public const string errorMsg_relogin = "需要重新登录";

        public const string error_server = "3";
        public const string errorMsg_server = "服务器错误";

        public const string error_invalid = "4";
        public const string errorMsg_invalid = "无效请求";

        public const string error_noMoney = "5";
        public const string errorMsg_noMoney = "余额不足";

        public const string error_invalidPwd = "6";
        public const string errorMsg_invalidPwd = "密码错误";

        public const string error_sign = "7";
        public const string errorMsg_sign = "验证签名失败";

        public const int summaryDays = 5;

        public const string and = "&";
    }
}