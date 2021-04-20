using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Domain.Entity
{
    /// <summary>
    /// 兑换码表
    /// </summary>
    [Serializable, Table("sns_voucher")]
    public partial class Voucher:IAggregateRoot
    {
        public Voucher()
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
        /// 兑换码
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "兑换码")]
        public string Code { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "标题")]
        public string Title { get; set; }
        /// <summary>
        /// 兑换码说明
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "兑换码说明")]
        public string Description { get; set; }
        /// <summary>
        /// 使用场景说明
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "使用场景说明")]
        public string Scenes { get; set; }
        /// <summary>
        /// 兑换码兑换开始时间
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "兑换码兑换开始时间")]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 兑换码兑换结束时间
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "兑换码兑换结束时间")]
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 绑定用户id
        /// </summary>
        [Column]
        [Display(Name = "绑定用户id")]
        public int? UserId { get; set; }
        /// <summary>
        /// 兑换码使用开始时间
        /// </summary>
        [Column]
        [Display(Name = "兑换码使用开始时间")]
        public DateTime? StartTime2 { get; set; }
        /// <summary>
        /// 兑换码使用结束时间
        /// </summary>
        [Column]
        [Display(Name = "兑换码使用结束时间")]
        public DateTime? EndTime2 { get; set; }
        /// <summary>
        /// 使用状态
        /// </summary>
        [Column]
        [Display(Name = "使用状态")]
        public int? State { get; set; }
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

