using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Domain.Entity
{
    /// <summary>
    /// sns_exchangePerson:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable, Table("sns_exchangePerson")]
    public partial class ExchangePerson:IAggregateRoot
    {
        public ExchangePerson()
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
        /// 兑换会员id
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "兑换会员id")]
        public string UserId { get; set; }
        /// <summary>
        /// 分享Id
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "分享Id")]
        public string ExId { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "添加时间")]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [Column]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "地址")]
        public string Address { get; set; }
        /// <summary>
        /// 审核标志
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "审核标志")]
        public string Examine { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column]
        [DefaultValue(1)]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "Status")]
        public int Status { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "流水号")]
        public string SerialNum { get; set; }
        /// <summary>
        /// 寄往用户的物流号
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "寄往用户的物流号")]
        public string LogisticCode { get; set; }
        /// <summary>
        /// 寄往官方的物流号
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "寄往官方的物流号")]
        public string LogisticCode2 { get; set; }
        /// <summary>
        /// 付款方式：Ali，Wx
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "寄往官方的物流号")]
        public string PaymentWay { get; set; }
        /// <summary>
        /// 邮费
        /// </summary>
        [Column("Postage", TypeName = "money")]
        [Display(Name = "邮费")]
        public decimal Postage { get; set; }
        /// <summary>
        /// 身家
        /// </summary>
        [Column("ShenJia", TypeName = "money")]
        [Display(Name = "身家")]
        public decimal ShenJia { get; set; }
        #endregion Model

    }
}

