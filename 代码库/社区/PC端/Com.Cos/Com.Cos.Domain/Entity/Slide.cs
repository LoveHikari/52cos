using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Domain.Entity
{
    /// <summary>
    /// sns_slide:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable, Table("sns_slide")]
    public partial class Slide:IAggregateRoot
    {
        public Slide()
        { }
        #region Model
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "Id")]
        public int Id { get; set; }
        /// <summary>
        /// 文本
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "文本")]
        public string ImgText { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "图片地址")]
        public string ImgUrl { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        [Column]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "链接地址")]
        public string ImgHref { get; set; }
        /// <summary>
        /// 权重
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "权重")]
        public int Weight { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "添加时间")]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 标志
        /// </summary>
        [Column]
        [Display(Name = "标志")]
        public int? Sign { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column]
        [DefaultValue(1)]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "Status")]
        public int Status { get; set; }
        #endregion Model

    }
}

