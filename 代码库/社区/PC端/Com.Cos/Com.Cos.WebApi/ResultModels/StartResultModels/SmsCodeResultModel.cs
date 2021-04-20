namespace Com.Cos.WebApi.ResultModels.StartResultModels
{
    /// <summary>
    /// 短信验证码返回模型
    /// </summary>
    public class SmsCodeResultModel
    {
        /// <summary>
        /// 验证码
        /// </summary>
        public string VerifyCode { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
    }
}