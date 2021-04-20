using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Domain.Entity
{
    /// <summary>
    /// 分享表
    /// </summary>
    [Serializable, Table("sns_exchange")]
    public partial class Exchange:IAggregateRoot
    {
        public Exchange()
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
        /// 发布会员id
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "发布会员id")]
        public string UserId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "标题")]
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Column]
        [StringLength(2147483647, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "内容")]
        public string Describe { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "ItemName")]
        public string ItemName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "ItemCharacter")]
        public string ItemCharacter { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "封面")]
        public string Cover { get; set; }
        /// <summary>
        /// 凭证
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "凭证")]
        public string Certificate { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "图片列表")]
        public string ImgList { get; set; }
        /// <summary>
        /// 服装来源
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "服装来源")]
        public string Source { get; set; }
        /// <summary>
        /// 服装组成
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "服装组成")]
        public string Constitute { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "原价")]
        public string Price { get; set; }
        /// <summary>
        /// 自我估价1
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "自我估价1")]
        public string Valuation1 { get; set; }
        /// <summary>
        /// 自我估价2
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "自我估价2")]
        public string Valuation2 { get; set; }
        /// <summary>
        /// 自我估价3
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "自我估价3")]
        public string Valuation3 { get; set; }
        /// <summary>
        /// 估价1票数
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "估价1票数")]
        public int Vote1 { get; set; }
        /// <summary>
        /// 估价2票数
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "估价2票数")]
        public int Vote2 { get; set; }
        /// <summary>
        /// 估价3票数
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "估价3票数")]
        public int Vote3 { get; set; }
        /// <summary>
        /// 官方价格
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "官方价格")]
        public string Official { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "ExchangePerson")]
        public string ExchangePerson { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "发布时间")]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 报名时间
        /// </summary>
        [Column]
        [Display(Name = "报名时间")]
        public DateTime? EnterTime { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "分类")]
        public string ClassId { get; set; }
        /// <summary>
        /// 过期标志
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "过期标志")]
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
        /// 关注人员
        /// </summary>
        [Column]
        [StringLength(-1, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "关注人员")]
        public string LikeUser { get; set; }
        /// <summary>
        /// 物流运单号
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "物流运单号")]
        public string LogisticCode { get; set; }
        /// <summary>
        /// 点击量
        /// </summary>
        [Column]
        [Display(Name = "点击量")]
        public int? Clicks { get; set; }
        /// <summary>
        /// 尺码
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "尺码")]
        public string Size { get; set; }
        /// <summary>
        /// 运费
        /// </summary>
        [Column]
        [StringLength(16, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "运费")]
        public decimal? Postage { get; set; }
        /// <summary>
        /// 租金
        /// </summary>
        [Column]
        [StringLength(16, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "租金")]
        public decimal? Rent { get; set; }
        #endregion Model

    }
}

