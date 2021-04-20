using System;
using System.ComponentModel.DataAnnotations;

namespace Com.Cos.Web.Areas.Cooperation.Models
{
    public class CooperationViewModel
    {
        /// <summary>
        /// id
        /// </summary>
        [Display(Name = "id")]
        public int Id { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [Display(Name = "头像")]
        public string Portrait { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [Display(Name = "昵称")]
        public string Nickname { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "合作主题")]
        public string Title { get; set; }
        /// <summary>
        /// 活动时间
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "合作时间")]
        //[DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public string EnrollEnd { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "合作地址")]
        public string Address { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "合作需求")]
        public string Cont { get; set; }
        /// <summary>
        /// 预算
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "合作费用")]
        [DataType(DataType.Currency,ErrorMessage = "费用格式不正确")]
        public string Budget { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "图片列表")]
        public string ImgList { get; set; }

        /// <summary>
        /// 封面
        /// </summary>
        [Display(Name = "封面")]
        public string Cover { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        [Display(Name = "发布时间")]
        public DateTime ReleaseTime { get; set; }
        /// <summary>
        /// 意向类型，需或求
        /// </summary>
        [Display(Name = "意向类型")]
        public string Will { get; set; }
    }
}