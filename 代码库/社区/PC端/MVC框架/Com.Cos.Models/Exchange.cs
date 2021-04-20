using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Models
{
    /// <summary>
    /// 分享/兑换表
    /// </summary>
    [Serializable,Table("sns_exchange")]
    public partial class Exchange
    {
        public Exchange()
        { }
        #region Model
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 发布会员id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 物品名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 物品角色
        /// </summary>
        public string ItemCharacter { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        public string Cover { get; set; }
        /// <summary>
        /// 凭证
        /// </summary>
        public string Certificate { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        public string ImgList { get; set; }
        /// <summary>
        /// 服装来源
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 服装组成
        /// </summary>
        public string Constitute { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// 自我估价1
        /// </summary>
        public string Valuation1 { get; set; }
        /// <summary>
        /// 自我估价2
        /// </summary>
        public string Valuation2 { get; set; }
        /// <summary>
        /// 自我估价3
        /// </summary>
        public string Valuation3 { get; set; }
        /// <summary>
        /// 估价1票数
        /// </summary>
        public int Vote1 { get; set; }
        /// <summary>
        /// 估价2票数
        /// </summary>
        public int Vote2 { get; set; }
        /// <summary>
        /// 估价3票数
        /// </summary>
        public int Vote3 { get; set; }
        /// <summary>
        /// 官方价格
        /// </summary>
        public string Official { get; set; }
        /// <summary>
        /// 兑换人id
        /// </summary>
        public string ExchangePerson { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 报名时间
        /// </summary>
        public DateTime? EnterTime { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string ClassId { get; set; }
        /// <summary>
        /// 过期标志
        /// </summary>
        public string Examine { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Status { get; set; }
        #endregion Model

    }
}