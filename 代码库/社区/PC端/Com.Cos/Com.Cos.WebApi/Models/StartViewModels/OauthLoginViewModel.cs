using System.ComponentModel.DataAnnotations;

namespace Com.Cos.WebApi.Models.StartViewModels
{
    /// <summary>
    /// 第三方登录模型
    /// </summary>
    public class OauthLoginViewModel
    {
        /// <summary>
        /// QQ注册时为openid
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "必填")]
        public string UserName { get; set; }
        /// <summary>
        /// 注册类型，QQ、wechat
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "必填")]
        [RegularExpression("QQ|wechat|sina", ErrorMessage = "不支持的注册类型")]
        public string Type { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "必填")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{2}到{1}个字符")]
        public string Nickname { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "必填")]
        [RegularExpression("1|0|男|女", ErrorMessage = "不支持的性别类型")]
        public string Gender { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "必填")]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        public string Figureurl { get; set; }
    }
}