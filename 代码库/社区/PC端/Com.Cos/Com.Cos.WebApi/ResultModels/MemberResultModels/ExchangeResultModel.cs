namespace Com.Cos.WebApi.ResultModels.MemberResultModels
{
    /// <summary>
    /// 兑换列表返回结果数据
    /// </summary>
    public class ExchangeResultModel
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
        /// 状态
        /// </summary>
        public string Examine { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        public string Cover { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public string AddTime { get; set; }
        /// <summary>
        /// 物流运单号
        /// </summary>
        public string LogisticCode { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Portrait { get; set; }
    }
}