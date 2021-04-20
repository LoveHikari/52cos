using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Domain.Entity
{
    /// <summary>
    /// sns_mailingAddress:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable, Table("sns_mailingAddress")]
    public partial class MailingAddress : IAggregateRoot
    {
        public MailingAddress()
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
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "会员id")]
        public string UserId { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "省")]
        public string Province { get; set; }
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
        public string County { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "详细地址")]
        public string Address { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "邮政编码")]
        public string ZipCode { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "姓名")]
        public string Name { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "手机号码")]
        public string Phone { get; set; }
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
        /// <summary>
        /// 是否默认
        /// </summary>
        [Column]
        [Display(Name = "是否默认")]
        public bool? IsDefault { get; set; }
        #endregion Model

    }
}