namespace Com.Cos.WebApi.ResultModels.ExchangeResultModels
{
    /// <summary>
    /// 确认兑换返回结果
    /// </summary>
    public class ExchangeConfimResultModel
    {
        /// <summary>
        /// 地址id
        /// </summary>
        public int AddressId { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        public string Consignee { get; set; }
        /// <summary>
        /// 移动电话
        /// </summary>
        public string PhoneMob { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 兑换方式
        /// </summary>
        public string Examine { get; set; }
        /// <summary>
        /// 运费
        /// </summary>
        public decimal Fare { get; set; }
        /// <summary>
        /// 押金
        /// </summary>
        public decimal Deposit { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal PriceSum { get; set; }
    }
}