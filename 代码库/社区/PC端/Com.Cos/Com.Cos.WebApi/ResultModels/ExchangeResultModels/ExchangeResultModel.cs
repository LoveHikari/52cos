namespace Com.Cos.WebApi.ResultModels.ExchangeResultModels
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
        /// 最终值
        /// </summary>
        public string Official { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        public string Cover { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Portrait { get; set; }
    }
}