using System.ComponentModel.DataAnnotations;
using Com.Cos.WebApi.Filter;

namespace Com.Cos.WebApi.Models.ExchangeEventViewModels
{
    public class ExchangeEventViewModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "用户id必填")]
        [Range(typeof(int), "1", "999999999", ErrorMessage = "用户id必须大于0")]
        [CustomRemote("IsVip", "Remote", HttpMethod = "GET", AdditionalFields = "Examine", ErrorMessage = "会员次数不足或不是会员")]
        public int UserId { get; set; }
        /// <summary>
        /// 收货地址id
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "收货地址必填")]
        [Range(typeof(int), "1", "999999999", ErrorMessage = "收货地址必填")]
        public int AddressId { get; set; }
        /// <summary>
        /// 兑换id
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "兑换必填")]
        [Range(typeof(int), "1", "999999999", ErrorMessage = "兑换必填")]
        public int ExId { get; set; }
        /// <summary>
        /// 兑换方式
        /// </summary>
        [Required(AllowEmptyStrings = false,ErrorMessage = "兑换方式必填")]
        [RegularExpression("身家兑换|会员租赁|单次租赁|兑换券", ErrorMessage = "兑换方式是不支持的兑换类型")]
        public string Examine { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "支付类型必填")]
        [RegularExpression("Ali|Wx", ErrorMessage = "支付类型是不支持的支付类型")]
        public string PayType { get; set; }
        /// <summary>
        /// 兑换码id
        /// </summary>
        [CustomRemote("CheckVoucher", "Remote", HttpMethod = "GET", AdditionalFields = "UserId,Examine", ErrorMessage = "兑换码无效")]
        public int VoucherId { get; set; }
    }
}