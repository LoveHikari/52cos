using System;
using System.ComponentModel.DataAnnotations;

namespace Com.Cos.Web.Areas.Exchange.Models
{
    public class ExchangeViewModel
    {
        /// <summary>
        /// id
        /// </summary>
        [Display(Name = "id")]
        public int Id { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [Display(Name = "头像")]
        public string Portrait { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [Display(Name = "昵称")]
        public string Nickname { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "兑换标题")]
        public string Title { get; set; }
        /// <summary>
        /// 物品名称
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "物品原作")]
        public string ItemName { get; set; }
        /// <summary>
        /// 物品角色
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "物品角色")]
        public string ItemCharacter { get; set; }
        /// <summary>
        /// 物品组成
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "物品包含")]
        public string Constitute { get; set; }
        /// <summary>
        /// 物品来源
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "物品来源")]
        public string Source { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "物品价格")]
        [DataType(DataType.Currency, ErrorMessage = "费用格式不正确")]
        public string Price { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        [Display(Name = "物品分类")]
        public string ClassId { get; set; }
        /// <summary>
        /// 其他描述
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "其他描述")]
        public string Describe { get; set; }
        ///// <summary>
        ///// 自我估价1
        ///// </summary>
        //[Required(ErrorMessage = "必填")]
        //[StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        //[Display(Name = "公投值1")]
        //[DataType(DataType.Currency, ErrorMessage = "费用格式不正确")]
        //public string Valuation1 { get; set; }
        ///// <summary>
        ///// 自我估价2
        ///// </summary>
        //[Required(ErrorMessage = "必填")]
        //[StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        //[Display(Name = "公投值2")]
        //[DataType(DataType.Currency, ErrorMessage = "费用格式不正确")]
        //public string Valuation2 { get; set; }
        ///// <summary>
        ///// 自我估价3
        ///// </summary>
        //[Required(ErrorMessage = "必填")]
        //[StringLength(20, MinimumLength = 2, ErrorMessage = "{2}到{1}个字符")]
        //[Display(Name = "公投值3")]
        //[DataType(DataType.Currency, ErrorMessage = "费用格式不正确")]
        //public string Valuation3 { get; set; }
        ///// <summary>
        ///// 凭证
        ///// </summary>
        //[Required(ErrorMessage = "必填")]
        //[Display(Name = "凭证")]
        //public string Certificate { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "图片列表")]
        public string ImgList { get; set; }

        /// <summary>
        /// 封面
        /// </summary>
        [Display(Name = "封面")]
        public string Cover { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        [Display(Name = "发布时间")]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 官方价格
        /// </summary>
        [Display(Name = "最终值")]
        public string Official { get; set; }
        /// <summary>
        /// 审核标志
        /// </summary>
        [Display(Name = "兑换状态")]
        public string Examine { get; set; }
    }
}