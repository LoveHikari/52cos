using System.ComponentModel.DataAnnotations;
using Com.Cos.WebApi.Filter;

namespace Com.Cos.WebApi.Models.MemberViewModels
{
    /// <summary>
    /// 修改/绑定手机号模型
    /// </summary>
    public class PhoneViewModel
    {
        /// <summary>
        /// 短信验证码
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "短信验证码必填")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "短信验证码长度应为{2}个字符")]
        [CustomRemote("VerifyCode", "Remote", HttpMethod = "GET", AdditionalFields = "Phone", ErrorMessage = "短信验证码已过期或验证码不正确")]
        public string VerifyCode { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "手机号必填")]
        public string Phone { get; set; }
    }
}