using System.ComponentModel.DataAnnotations;

namespace Com.Cos.Web.Areas.Exchange.Models
{
    public class ConfirmOrderViewModel
    {
        /// <summary>
        /// 兑换id
        /// </summary>
        [Display(Name = "id")]
        public int Id { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        [Display(Name = "收货地址")]
        public string Address { get; set; }
        /// <summary>
        /// 兑换方式，会员兑换为0，身家兑换为1
        /// </summary>
        [Display(Name = "兑换方式")]
        public string Method { get; set; }
        /// <summary>
        /// 付款金额
        /// </summary>
        public string Money { get; set; }
        /// <summary>
        /// 押金
        /// </summary>
        public string Deposit { get; set; }
        /// <summary>
        /// 订单类型,0为兑换，1为租借
        /// </summary>
        public int Type { get; set; }

    }
}