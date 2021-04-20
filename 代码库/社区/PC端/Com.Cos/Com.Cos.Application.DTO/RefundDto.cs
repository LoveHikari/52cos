using System;

namespace Com.Cos.Application.DTO
{
    public class RefundDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 退款类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 退款账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 退款账号类型
        /// </summary>
        public string AccountType { get; set; }
        /// <summary>
        /// 退款金额
        /// </summary>
        public double Money { get; set; }
        /// <summary>
        /// 用户持有金额
        /// </summary>
        public double Deposit { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 处理状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OutBizNo { get; set; }
    }
}