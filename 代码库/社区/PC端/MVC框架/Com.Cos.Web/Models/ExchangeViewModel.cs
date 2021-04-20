using System;
using System.ComponentModel.DataAnnotations;

namespace Com.Cos.Web.Models
{
    public class ExchangeViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
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
        [Display(Name = "标题")]
        public string Title { get; set; }
        /// <summary>
        /// 最终值
        /// </summary>
        [Display(Name = "最终值")]
        public string Official { get; set; }
        /// <summary>
        /// 兑换状态
        /// </summary>
        [Display(Name = "兑换状态")]
        public string Examine { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        [Display(Name = "封面")]
        public string Cover { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        public string ImgList { get; set; }
    }
}