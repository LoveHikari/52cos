using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Com.Cos.WebApi.Filter;

namespace Com.Cos.WebApi.Models.MemberViewModels
{
    /// <summary>
    /// 注册模型
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// 用户名，手机注册时为手机号
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "用户名必填")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "用户名长度应为{2}到{1}个字符")]
        [CustomRemote("CheckExist", "Remote", HttpMethod = "GET",AdditionalFields = "Type", ErrorMessage = "已存在的邮箱或手机号")]
        public string UserName { get; set; }
        /// <summary>
        /// 注册类型，phone
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "注册类型必填")]
        [RegularExpression("phone", ErrorMessage = "不支持的注册类型")]
        public string Type { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "密码必填")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "密码长度应为{2}到{1}个字符")]
        public string Password { get; set; }
        /// <summary>
        /// 短信验证码
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "短信验证码必填")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "短信验证码长度应为{2}个字符")]
        public string VerifyCode { get; set; }
    }
}