using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Domain.Entity
{
    /// <summary>
    /// 合作表
    /// </summary>
    [Serializable, Table("sns_cooperation")]
    public partial class Cooperation:IAggregateRoot
    {
        public Cooperation()
        { }
        #region Model
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "id")]
        public int Id { get; set; }
        /// <summary>
        /// 发布会员id
        /// </summary>
        [Column]
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
        /// 是否寄拍
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "是否寄拍")]
        public string Send { get; set; }
        /// <summary>
        /// 报名截止
        /// </summary>
        [Column]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "报名截止")]
        public string EnrollEnd { get; set; }
        /// <summary>
        /// 时间预算
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "时间预算")]
        public string TimeBudget { get; set; }
        /// <summary>
        /// 意向类型
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "意向类型")]
        public string Intention { get; set; }
        /// <summary>
        /// 接单数量
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "接单数量")]
        public string AcceptSum { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        [Column]
        [StringLength(2147483647, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "介绍")]
        public string Cont { get; set; }
        /// <summary>
        /// 预算
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "预算")]
        public string RMBBudget { get; set; }
        /// <summary>
        /// 性别要求
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "性别要求")]
        public string GenderAsk { get; set; }
        /// <summary>
        /// 报名人员
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "报名人员")]
        public string SignPerson { get; set; }
        /// <summary>
        /// 查看人次
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "查看人次")]
        public string PersonSum { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        [Column]
        [Display(Name = "发布时间")]
        public DateTime? ReleaseTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column]
        [DefaultValue(1)]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "Status")]
        public int Status { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "联系人")]
        public string Contacts { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "电话")]
        public string Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "qq")]
        public string Qq { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        [Column]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "封面")]
        public string Cover { get; set; }
        /// <summary>
        /// 限制报名人数
        /// </summary>
        [Column]
        [DefaultValue(0)]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "限制报名人数")]
        public int LimitPerson { get; set; }
        /// <summary>
        /// 意向
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "意向")]
        public string Will { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "省")]
        public string Prov { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "市")]
        public string City { get; set; }
        /// <summary>
        /// 区/县
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "区/县")]
        public string Dist { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        [Column]
        [StringLength(2147483647, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "摘要")]
        public string Excerpt { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        [Column]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "图片列表")]
        public string ImgList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        /// <summary>
        /// 分类id
        /// </summary>
        [Column]
        [Display(Name = "分类id")]
        public int? ClassId { get; set; }
        /// <summary>
        /// 点击量
        /// </summary>
        [Column]
        [Display(Name = "点击量")]
        public int? Clicks { get; set; }
        #endregion Model

    }
}

