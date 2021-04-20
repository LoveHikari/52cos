using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Models
{
    /// <summary>
    /// sns_lottery:实体类(属性说明自动提取数据库字段的描述信息)
    /// 抽奖活动参与表
    /// </summary>
    [Serializable, Table("sns_lottery")]
    public partial class Lottery
    {
        public Lottery()
        { }
        #region Model
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Required(ErrorMessage = "必填")]
        [Display(Name = "Id")]
        public int Id { get; set; }
        /// <summary>
        /// 活动id
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填")]
        [Display(Name = "活动id")]
        public int AcId { get; set; }
        /// <summary>
        /// 会员id
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填")]
        [Display(Name = "会员id")]
        public int UserId { get; set; }
        /// <summary>
        /// 抽奖码
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "抽奖码")]
        public string LotteryCode { get; set; }
        /// <summary>
        /// 获得时间
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填")]
        [Display(Name = "获得时间")]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 抽奖时间
        /// </summary>
        [Column]
        [Display(Name = "抽奖时间")]
        public DateTime? GetTime { get; set; }
        /// <summary>
        /// 获得奖品id
        /// </summary>
        [Column]
        [Display(Name = "获得奖品id")]
        public int? PrizeId { get; set; }
        /// <summary>
        /// 获得奖品
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "获得奖品")]
        public string PrizeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column]
        [DefaultValue(1)]
        [Required(ErrorMessage = "必填")]
        [Display(Name = "Status")]
        public int Status { get; set; }
        #endregion Model

    }
}

