using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Com.Cos.Admin.Models.ExchangeViewModels
{
    /// <summary>
    /// 兑换详情模型
    /// </summary>
    public class ExchangeDetailViewModel
    {
        public int Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Display(Name = "标题")]
        public string Title { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        [Display(Name = "封面")]
        public string Cover { get; set; }
        /// <summary>
        /// 服装组成
        /// </summary>
        [Display(Name = "服装组成")]
        public string Constitute { get; set; }
        /// <summary>
        /// 物品来源
        /// </summary>
        [Display(Name = "物品来源")]
        public string Source { get; set; }
        /// <summary>
        /// 分类id
        /// </summary>
        [Display(Name = "分类")]
        public string ClassId { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Display(Name = "内容")]
        public string Describe { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        [Display(Name = "原价")]
        public string Price { get; set; }
        /// <summary>
        /// 最终值
        /// </summary>
        [Display(Name = "最终值")]
        public string Official { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public string ExamineId { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        [Display(Name = "发布时间")]
        public string AddTime { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        [Display(Name = "图片")]
        public List<string> ImgList { get; set; }
    }
}