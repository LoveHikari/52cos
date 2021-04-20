using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Domain.Entity
{
    /// <summary>
    /// 合作回复评论表
    /// </summary>
    [Serializable, Table("sns_cooperationReply")]
    public partial class CooperationReply:IAggregateRoot
    {
        public CooperationReply()
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
        /// 合作id
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "合作id")]
        public int CoId { get; set; }
        /// <summary>
        /// 会员id
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "会员id")]
        public int UserId { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "回复内容")]
        public string Text { get; set; }
        /// <summary>
        /// 父回复id
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "父回复id")]
        public int ParentId { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "点赞数")]
        public int LikeNum { get; set; }
        /// <summary>
        /// 点赞人员
        /// </summary>
        [Column]
        [StringLength(-1, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "点赞人员")]
        public string LikeUser { get; set; }
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

