namespace Com.Cos.Application.DTO
{
    public class RechargeRecordDto
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 订单名
        /// </summary>
        public string OrderName { get; set; }
        /// <summary>
        /// 订单说明
        /// </summary>
        public string WareDesc { get; set; }
        /// <summary>
        /// 充值类型
        /// </summary>
        public string Type { get; set; }
    }
}