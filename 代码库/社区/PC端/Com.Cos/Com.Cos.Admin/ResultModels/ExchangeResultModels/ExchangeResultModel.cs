using System;

namespace Com.Cos.Admin.ResultModels.ExchangeResultModels
{
    public class ExchangeResultModel
    {
        public int Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// 最终值
        /// </summary>
        public string Official { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 发布人昵称
        /// </summary>
        public string Nickname { get; set; }
        public DateTime AddTime { get; set; }
    }
}