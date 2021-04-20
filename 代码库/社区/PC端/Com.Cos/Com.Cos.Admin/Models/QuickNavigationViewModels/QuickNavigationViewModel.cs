using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Admin.Models.QuickNavigationViewModels
{
    public class QuickNavigationViewModel
    {
        [Required(ErrorMessage = "必填", AllowEmptyStrings = false)]
        public int Id { get; set; }
        /// <summary>
        /// 小标题
        /// </summary>
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "小标题")]
        public string SmallTitle { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "必填", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "标题")]
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required(ErrorMessage = "必填", AllowEmptyStrings = false)]
        [StringLength(2147483647, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "内容")]
        public string Cont { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "链接")]
        public string Link { get; set; }
    }
}