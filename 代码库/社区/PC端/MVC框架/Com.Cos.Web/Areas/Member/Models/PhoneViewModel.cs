using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Com.Cos.Web.Areas.Member.Models
{
    public class PhoneViewModel
    {
        /// <summary>
        /// 手机号码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "手机号码：")]
        [RegularExpression("^(13[0-9]|14[5|7]|15[0-9]|18[0-9]|17[0-9])\\d{8}$", ErrorMessage = "手机号格式不正确")]
        [System.Web.Mvc.Remote(action: "CheckPhone", controller: "Member", areaReference: AreaReference.UseRoot, ErrorMessage = "未绑定的手机号")]
        public string OldPhoneMob { get; set; }
        /// <summary>
        /// 手机验证码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "验证码长度不正确")]
        [Display(Name = "手机验证码：")]
        public string SMSCode { get; set; }
        /// <summary>
        /// 确认新手机号
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "确认新手机号：")]
        [RegularExpression("^(13[0-9]|14[5|7]|15[0-9]|18[0-9]|17[0-9])\\d{8}$", ErrorMessage = "手机号格式不正确")]
        [System.Web.Mvc.Remote(action: "CheckPhone2", controller: "Member", areaReference: AreaReference.UseRoot, ErrorMessage = "手机号已存在")]
        public string PhoneMob { get; set; }
    }
}