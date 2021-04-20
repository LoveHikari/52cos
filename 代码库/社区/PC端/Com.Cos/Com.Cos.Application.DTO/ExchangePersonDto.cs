namespace Com.Cos.Application.DTO
{
    public class ExchangePersonDto
    {
        /// <summary>
        /// 兑换id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 我的兑换id
        /// </summary>
        public int EpId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
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
        /// <summary>
        /// 收货地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        public string Consignee { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string ConsigneePhone { get; set; }
        /// <summary>
        /// 兑换状态
        /// </summary>
        public string Examine { get; set; }
    }
}