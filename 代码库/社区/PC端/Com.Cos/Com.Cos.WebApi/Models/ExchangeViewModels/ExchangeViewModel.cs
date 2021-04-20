using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.WebApi.Models.ExchangeViewModels
{
    /// <summary>
    /// 发布兑换视图模型
    /// </summary>
    public class ExchangeViewModel
    {
        /// <summary>
        /// 发布会员id
        /// </summary>
        [Required(ErrorMessage = "用户id必填", AllowEmptyStrings = false)]
        [Range(typeof(int), "1", "999999999", ErrorMessage = "用户id必须大于0")]
        public int UserId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "标题必填", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "标题必须是{2}到{1}个字符")]
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required(ErrorMessage = "内容必填", AllowEmptyStrings = false)]
        [StringLength(2147483647, MinimumLength = 0, ErrorMessage = "内容必须是{2}到{1}个字符")]
        public string Describe { get; set; }
        /// <summary>
        /// 物品名称
        /// </summary>
        [Required(ErrorMessage = "物品名称必填", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "物品名称必须是{2}到{1}个字符")]
        public string ItemName { get; set; }
        /// <summary>
        /// 物品角色
        /// </summary>
        [Required(ErrorMessage = "物品角色必填", AllowEmptyStrings = false)]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "物品角色必须是{2}到{1}个字符")]
        public string ItemCharacter { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        [Required(ErrorMessage = "封面必填", AllowEmptyStrings = false)]
        [Range(typeof(int), "1", "999999999", ErrorMessage = "封面必填")]
        public int Cover { get; set; }

        /// <summary>
        /// 图片列表
        /// </summary>
        [Required(ErrorMessage = "图片必填", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "图片必须是{2}到{1}个字符")]
        public string ImgList { get; set; }
        /// <summary>
        /// 服装组成
        /// </summary>
        [Required(ErrorMessage = "服装组成必填", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "服装组成必须是{2}到{1}个字符")]
        public string Constitute { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        [Required(ErrorMessage = "原价必填", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "原价必须是{2}到{1}个字符")]
        [Range(typeof(decimal), "0.00", "99999999.99", ErrorMessage = "原价格式不正确")]
        public string Price { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        [Required(ErrorMessage = "分类必填", AllowEmptyStrings = false)]
        [Range(typeof(int), "1", "999999999", ErrorMessage = "分类必填")]
        public int ClassId { get; set; }
        /// <summary>
        /// 物品来源
        /// </summary>
        [Required(ErrorMessage = "物品来源必填", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "物品来源必须是{2}到{1}个字符")]
        public string Source { get; set; }
        /// <summary>
        /// 尺码
        /// </summary>
        //[Required(ErrorMessage = "尺码必填", AllowEmptyStrings = false)]
        public string Size { get; set; }
    }
}