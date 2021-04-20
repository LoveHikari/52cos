namespace Com.Cos.Application.DTO
{
    public class ExchangeEventDto
    {
        /// <summary>
        /// 地址id
        /// </summary>
        public int AddressId { get; set; }
        /// <summary>
        /// 押金
        /// </summary>
        public int Deposit { get; set; }
        /// <summary>
        /// 邮费
        /// </summary>
        public decimal Postage { get; set; }
        /// <summary>
        /// 身家
        /// </summary>
        public decimal ShenJia { get; set; }

        /// <summary>
        /// 兑换id
        /// </summary>
        public int ExId { get; set; }
        /// <summary>
        /// 兑换方式
        /// </summary>
        public string Examine { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 兑换码id
        /// </summary>
        public int VouId { get; set; }
    }
}