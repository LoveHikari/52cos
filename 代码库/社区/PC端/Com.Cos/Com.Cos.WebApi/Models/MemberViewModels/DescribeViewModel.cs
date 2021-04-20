using System.ComponentModel.DataAnnotations;

namespace Com.Cos.WebApi.Models.MemberViewModels
{
    /// <summary>
    /// 修改个性签名模型
    /// </summary>
    public class DescribeViewModel
    {
        /// <summary>
        /// 个性签名
        /// </summary>
        [StringLength(500, MinimumLength = 0, ErrorMessage = "个性签名长度应为{2}到{1}个字符")]
        public string Describe { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [StringLength(50, MinimumLength = 0, ErrorMessage = "昵称长度应为{2}到{1}个字符")]
        public string Nickname { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [RegularExpression("1|0", ErrorMessage = "不是正确的性别类型")]
        public string Gender { get; set; }
    }
}