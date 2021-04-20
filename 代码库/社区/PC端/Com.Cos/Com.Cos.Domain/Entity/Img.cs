using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Domain.Entity
{
    /// <summary>
    /// sns_Img:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable, Table("sns_Img")]
    public partial class Img:IAggregateRoot
    {
        public Img()
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
        /// 图片地址
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "图片地址")]
        public string ImgBigUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "ImgSmallUrl")]
        public string ImgSmallUrl { get; set; }
        /// <summary>
        /// 大图尺寸
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "大图尺寸")]
        public string BigSize { get; set; }
        /// <summary>
        /// 小图尺寸
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "小图尺寸")]
        public string SmallSize { get; set; }
        /// <summary>
        /// 图片的base64
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "图片的base64")]
        public string Md5 { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [Column]
        [Display(Name = "添加时间")]
        public DateTime? AddTime { get; set; }
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

