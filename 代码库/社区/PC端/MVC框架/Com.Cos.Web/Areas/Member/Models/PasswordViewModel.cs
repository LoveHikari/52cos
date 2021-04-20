using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Com.Cos.Web.Areas.Member.Models
{
    public class PasswordViewModel
    {
        /// <summary>
        /// 当前密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "当前密码:")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{2}到{1}个字符")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "手机号码:")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{2}到{1}个字符")]
        [System.Web.Mvc.Remote(action:"CheckPhone",controller:"Member",areaReference:AreaReference.UseRoot, ErrorMessage = "未绑定的手机号")]
        public string PhoneMobile { get; set; }
        /// <summary>
        /// 短信验证码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "验证码长度不正确")]
        [Display(Name = "手机验证码:")]
        public string SMSCode { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "请输入新密码:")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{2}到{1}个字符")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// 确认密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "两次输入的密码不一致")]
        [Display(Name = "请确认新密码:")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}