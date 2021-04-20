using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Models
{
    /// <summary>
    /// ExchangePersonEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// 兑换人员表
    /// </summary>
    [Serializable,Table("sns_exchangePerson")]
    public partial class ExchangePerson
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 兑换会员id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 分享Id
        /// </summary>
        public string ExId { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 审核标志
        /// </summary>
        public string Examine { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Status { get; set; }
    }
}