namespace Com.Cos.Admin.Models.ExchangeViewModels
{
    /// <summary>
    /// 兑换列表模型
    /// </summary>
    public class ExchageListViewModel
    {
        /// <summary>
        /// 兑换id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public string AddTime { get; set; }
        /// <summary>
        /// 最终值
        /// </summary>
        public string Official { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// 兑换类型名
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 发布人昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 审核状态名
        /// </summary>
        public string ExamineName { get; set; }
        /// <summary>
        /// 物流运单
        /// </summary>
        public string LogisticCode { get; set; }
        public int Status { get; set; }
    }
}