using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Com.Cos.Web.Areas.Member.Models
{
    public class AccountViewModel
    {
        /// <summary>
        /// 昵称
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "昵称：")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        public string Nickname { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "邮箱：")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "邮箱格式不正确")]
        [System.Web.Mvc.Remote(action:"CheckEmail2", controller:"Member",areaReference:AreaReference.UseRoot, ErrorMessage = "邮箱已存在")]
        public string Email { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [Display(Name = "真实姓名：")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        public string RealName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "性别：")]
        public string Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "生日：")]
        public string Birthday { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "手机号码：")]
        public string PhoneMob { get; set; }
        /// <summary>
        /// 个性签名
        /// </summary>
        [Display(Name = "个性签名：")]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        public string Describe { get; set; }
    }
}