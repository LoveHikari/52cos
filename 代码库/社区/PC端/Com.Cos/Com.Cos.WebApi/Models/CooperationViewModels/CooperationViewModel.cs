using System;
using System.ComponentModel.DataAnnotations;

namespace Com.Cos.WebApi.Models.CooperationViewModels
{
    /// <summary>
    /// 发布合作视图模型
    /// </summary>
    public class CooperationViewModel
    {
        /// <summary>
        /// 发布会员id
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "用户id必填")]
        [Range(typeof(int), "1", "999999999", ErrorMessage = "用户id必须大于0")]
        public int UserId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "标题必填")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "标题必须是{2}到{1}个字符")]
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "内容必填")]
        [StringLength(2147483647, MinimumLength = 0, ErrorMessage = "内容必须是{2}到{1}个字符")]
        public string Describe { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "封面必填")]
        [Range(typeof(int), "1", "999999999", ErrorMessage = "封面必填")]
        public int Cover { get; set; }

        /// <summary>
        /// 图片列表
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "图片必填")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "图片必须是{2}到{1}个字符")]
        public string ImgList { get; set; }
        /// <summary>
        /// 活动时间
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "活动时间必填")]
        [DataType(DataType.DateTime, ErrorMessage = "活动时间不是有效的时间格式")]
        public DateTime EnrollEnd { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "省必填")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "省必须是{2}到{1}个字符")]
        public string Prov { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "市必填")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "市必须是{2}到{1}个字符")]
        public string City { get; set; }
        /// <summary>
        /// 区/县
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "区/县必填")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = " 区/县必须是{2}到{1}个字符")]
        public string Dist { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "详细地址必填")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "详细地址必须是{2}到{1}个字符")]
        public string Address { get; set; }
        /// <summary>
        /// 限制人数
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "限制人数必填")]
        public int LimitPerson { get; set; }
        /// <summary>
        /// 需求
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "需求必填")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "需求必须是{2}到{1}个字符")]
        public string Will { get; set; }
        /// <summary>
        /// 分类id
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "分类必填")]
        [Range(typeof(int), "1", "999999999", ErrorMessage = "分类必填")]
        public int ClassId { get; set; }

    }
}