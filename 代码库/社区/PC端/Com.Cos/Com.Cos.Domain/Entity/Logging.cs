using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Domain.Entity
{
    /// <summary>
    /// 日志记录表
    /// </summary>
    [Serializable, Table("sns_logging")]
    public partial class Logging : IAggregateRoot
    {
        public Logging()
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
        /// 终端
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "终端")]
        public string Terminal { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(5000, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "型号")]
        public string Model { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "版本")]
        public string Version { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "级别")]
        public string Rank { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(5000, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "信息")]
        public string Info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "AddTime")]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "Status")]
        public int Status { get; set; }
        #endregion Model

    }
}