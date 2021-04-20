using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Com.Cos.Web.Models
{
    /// <summary>
    /// 首页登录模型
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "账户")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "密码")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "{2}到{1}个字符")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// 自动登录
        /// </summary>
        [Display(Name = "自动登录"), DefaultValue(true)]
        public bool RememberMe { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "验证码不正确")]
        [Display(Name = "验证码")]
        public string VerificationCode { get; set; }

    }
}