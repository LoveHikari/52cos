namespace Com.Cos.Web.Models
{
    public class MessageBase
    {
        public string Status { get; set; }
        public string Error { get; set; }
        public string ErrorMsg { get; set; }
    }

    public class Constant
    {
        public static string APPID = "wlkx1s5foth387gg6ad780";

        public static string pubKey = @"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDxgHGBF3FtMsjd/Yt3atCABN9FCELhrTwpmnc4mLRY2+GQJTHvSYuK2Sk8oGDZsQfKYQpy1dEw/vJWjTL30XrnrrYMgLm27xDU5iVbTPz9P00FVmznQwMDBhbiVgsn1VTyyr/HbKUr51BCgvA+cavN1mMg98IWMMP5nJNxkO+SFQIDAQAB";

        public const string SUCCESS = "true";
        public const string FAILED = "false";

        public const string ERROR_VALIDCODEFAILDED = "1";
        public const string ERRORMSG_VALIDCODEFAILED = "验证码错误";

        public const string ERROR_RELOGIN = "2";
        public const string ERRORMSG_RELOGIN = "需要重新登录";

        public const string ERROR_SERVER = "3";
        public const string ERRORMSG_SERVER = "服务器错误";

        public const string ERROR_INVALID = "4";
        public const string ERRORMSG_INVALID = "无效请求";

        public const string ERROR_NOMONEY = "5";
        public const string ERRORMSG_NOMONEY = "余额不足";

        public const string ERROR_INVALIDPWD = "6";
        public const string ERRORMSG_INVALIDPWD = "密码错误";

        public const string ERROR_SIGN = "7";
        public const string ERRORMSG_SIGN = "验证签名失败";

        public const int summaryDays = 5;

        public const string and = "&";
    }
}