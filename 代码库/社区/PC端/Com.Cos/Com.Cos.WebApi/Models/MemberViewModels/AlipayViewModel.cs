using System.ComponentModel.DataAnnotations;
using Com.Cos.WebApi.Filter;

namespace Com.Cos.WebApi.Models.MemberViewModels
{
    public class AlipayViewModel
    {
        /// <summary>
        /// 真实姓名
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "真实姓名必填")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "真实姓名长度应为{2}到{1}个字符")]
        public string RealName { get; set; }
        /// <summary>
        /// 支付宝账号
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "支付宝账号必填")]
        [CustomRemote("CheckAlipay", "Remote", HttpMethod = "GET", ErrorMessage = "支付宝账号已存在")]
        public string ImAlipay { get; set; }
    }
}