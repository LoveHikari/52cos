using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Domain.Entity
{
    /// <summary>
    /// 兑换状态表
    /// </summary>
    [Serializable, Table("sns_exchangeExamine")]
    public partial class ExchangeExamine:IAggregateRoot
    {
        public ExchangeExamine()
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
        /// 状态名称
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "状态名称")]
        public string ExamineName { get; set; }
        /// <summary>
        /// 状态id
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "状态id")]
        public string ExamineId { get; set; }
        /// <summary>
        /// 状态英文名称
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "状态英文名称")]
        public string ExamineUsName { get; set; }
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

