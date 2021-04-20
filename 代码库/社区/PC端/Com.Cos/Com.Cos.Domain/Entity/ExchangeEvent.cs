using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Domain.Entity
{
    /// <summary>
    /// 兑换事件表
    /// </summary>
    [Serializable, Table("sns_exchangeEvent")]
    public partial class ExchangeEvent:IAggregateRoot
    {
        public ExchangeEvent()
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
        /// 会员id
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "会员id")]
        public int UserId { get; set; }
        /// <summary>
        /// 兑换id
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "兑换id")]
        public int ExId { get; set; }
        /// <summary>
        /// 地址id
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "地址id")]
        public int AddressId { get; set; }
        /// <summary>
        /// 兑换码id
        /// </summary>
        [Column]
        [Display(Name = "兑换码id")]
        public int? VouId { get; set; }
        /// <summary>
        /// 兑换标志
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "兑换标志")]
        public string Examine { get; set; }
        /// <summary>
        /// 押金
        /// </summary>
        [Column]
        [Display(Name = "押金")]
        public int Deposit { get; set; }
        /// <summary>
        /// 邮费
        /// </summary>
        [Column("Postage", TypeName = "money")]
        [Display(Name = "邮费")]
        public decimal? Postage { get; set; }
        /// <summary>
        /// 身家
        /// </summary>
        [Column("ShenJia", TypeName = "money")]
        [Display(Name = "身家")]
        public decimal? ShenJia { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "订单号")]
        public string OrderNo { get; set; }
        /// <summary>
        /// 交易时间
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "交易时间")]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 交易状态
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "交易状态")]
        public int Status { get; set; }
        #endregion Model

    }
}

