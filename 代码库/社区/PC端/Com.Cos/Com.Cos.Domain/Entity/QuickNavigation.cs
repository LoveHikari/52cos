using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Domain.Entity
{
    /// <summary>
    /// sns_quickNavigation:实体类(属性说明自动提取数据库字段的描述信息)
    /// 快捷导航表
    /// </summary>
    [Serializable, Table("sns_quickNavigation")]
    public partial class QuickNavigation : IAggregateRoot
    {
        public QuickNavigation()
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
        /// 小标题
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "小标题")]
        public string SmallTitle { get; set; }
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
        public string Cont { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "链接")]
        public string Link { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "添加时间")]
        public DateTime AddTime { get; set; }
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

