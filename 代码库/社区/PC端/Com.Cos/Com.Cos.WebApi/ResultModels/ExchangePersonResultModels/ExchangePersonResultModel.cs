namespace Com.Cos.WebApi.ResultModels.ExchangePersonResultModels
{
    public class ExchangePersonResultModel
    {
        /// <summary>
        /// 兑换id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 我的兑换id
        /// </summary>
        public int EpId { get; set; }
        /// <summary>
        /// 兑换编号
        /// </summary>
        public string SerialNum { get; set; }
        /// <summary>
        /// 物流编号
        /// </summary>
        public string LogisticCode { get; set; }
        /// <summary>
        /// 物流状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        public string Cover { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string AddTime { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Portrait { get; set; }
        /// <summary>
        /// 兑换状态
        /// </summary>
        public int ExamineId { get; set; }
    }
}