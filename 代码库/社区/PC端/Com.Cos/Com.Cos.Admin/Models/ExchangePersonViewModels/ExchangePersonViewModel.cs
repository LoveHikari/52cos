namespace Com.Cos.Admin.Models.ExchangePersonViewModels
{
    public class ExchangePersonViewModel
    {
        /// <summary>
        /// 兑换id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 兑换记录id
        /// </summary>
        public int EpId { get; set; }
        /// <summary>
        /// 兑换标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 物流单号
        /// </summary>
        public string LogisticCode { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 兑换时间
        /// </summary>
        public string AddTime { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        public string SerialNum { get; set; }
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