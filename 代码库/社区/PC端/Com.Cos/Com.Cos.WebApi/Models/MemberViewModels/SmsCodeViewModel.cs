using System.ComponentModel.DataAnnotations;

namespace Com.Cos.WebApi.Models.MemberViewModels
{
    /// <summary>
    /// 验证短信验证码模型
    /// </summary>
    public class SmsCodeViewModel
    {
        /// <summary>
        /// 短信验证码
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "短信验证码必填")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "短信验证码长度应为{2}个字符")]
        public string VerifyCode { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "手机号必填")]
        public string Phone { get; set; }
    }
}