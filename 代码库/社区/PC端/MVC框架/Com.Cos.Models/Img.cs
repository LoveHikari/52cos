using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Models
{
    /// <summary>
    /// 图片表
    /// </summary>
    [Serializable,Table("sns_Img")]
    public partial class Img
    {
        public Img()
        { }
        #region Model
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Required(ErrorMessage = "Id必填")]
        [Display(Name = "Id")]
        public int Id { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        [Column]
        [Required(ErrorMessage = "ImgBigUrl必填")]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "图片地址")]
        public string ImgBigUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column]
        [Required(ErrorMessage = "ImgSmallUrl必填")]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "ImgSmallUrl")]
        public string ImgSmallUrl { get; set; }
        /// <summary>
        /// 图片的Md5
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填")]
        [StringLength(int.MaxValue, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "图片的Md5")]
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
        [Required(ErrorMessage = "Status必填")]
        [Display(Name = "Status")]
        public int Status { get; set; }
        #endregion Model

    }
}

