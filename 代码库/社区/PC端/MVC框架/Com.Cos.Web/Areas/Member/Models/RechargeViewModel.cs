using System.ComponentModel.DataAnnotations;

namespace Com.Cos.Web.Areas.Member.Models
{
    public class RechargeViewModel
    {
        /// <summary>
        /// 充值方式
        /// </summary>
        [Display(Name = "充值方式")]
        public string RechargeMethod { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        [Display(Name = "支付方式")]
        public string PaymentMethod { get; set; }
        /// <summary>
        /// 订单名称
        /// </summary>
        [Display(Name = "订单名称")]
        public string Subject { get; set; }
    }
}