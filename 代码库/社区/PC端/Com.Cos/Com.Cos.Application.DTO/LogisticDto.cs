using System;

namespace Com.Cos.Application.DTO
{
    public class LogisticDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 快递公司
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 快递公司编码
        /// </summary>
        public string ShipperCode { get; set; }
        /// <summary>
        /// 物流运单号
        /// </summary>
        public string LogisticCode { get; set; }
        /// <summary>
        /// 物流状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 物流状态文本
        /// </summary>
        public string StateText { get; set; }
        /// <summary>
        /// 预计到达时间
        /// </summary>
        public string EstimatedDeliveryTime { get; set; }
        /// <summary>
        /// 收件员信息
        /// </summary>
        public string PickerInfo { get; set; }
        /// <summary>
        /// 派件员信息
        /// </summary>
        public string SenderInfo { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime AcceptTime { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string AcceptStation { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}