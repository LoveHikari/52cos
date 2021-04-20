using System.ComponentModel.DataAnnotations;

namespace Com.Cos.WebApi.Models.MemberViewModels
{
    /// <summary>
    /// 登录模型
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// 用户名，手机注册时为手机号，QQ注册时为openid
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "用户名必填")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "用户名长度应为{2}到{1}个字符")]
        public string UserName { get; set; }
        /// <summary>
        /// 注册类型，phone、QQ、wechat
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "注册类型必填")]
        [RegularExpression("phone|Email", ErrorMessage = "不支持的注册类型")]
        public string Type { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "密码必填")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "密码长度应为{2}到{1}个字符")]
        public string Password { get; set; }
    }
}