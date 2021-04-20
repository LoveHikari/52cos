using System.ComponentModel.DataAnnotations;

namespace Com.Cos.WebApi.Models.LoggingViewModels
{
    public class LoggingViewModel
    {
        /// <summary>
        /// 终端
        /// </summary>
        [Required(ErrorMessage = "终端必填", AllowEmptyStrings = false)]
        [RegularExpression("android|ios", ErrorMessage = "不支持的终端类型")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "终端{2}到{1}个字符")]
        public string Terminal { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        [Required(ErrorMessage = "型号必填", AllowEmptyStrings = false)]
        [StringLength(5000, MinimumLength = 0, ErrorMessage = "型号{2}到{1}个字符")]
        public string Model { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        [Required(ErrorMessage = "版本必填", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "版本{2}到{1}个字符")]
        public string Version { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        [Required(ErrorMessage = "级别必填", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "级别{2}到{1}个字符")]
        public string Rank { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        [Required(ErrorMessage = "信息必填", AllowEmptyStrings = false)]
        [StringLength(5000, MinimumLength = 0, ErrorMessage = "信息{2}到{1}个字符")]
        public string Info { get; set; }
    }
}