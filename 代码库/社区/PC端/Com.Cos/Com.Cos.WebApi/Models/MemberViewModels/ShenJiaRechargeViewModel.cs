using System.ComponentModel.DataAnnotations;

namespace Com.Cos.WebApi.Models.MemberViewModels
{
    public class ShenJiaRechargeViewModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "用户id必填")]
        [Range(typeof(int), "1", "999999999", ErrorMessage = "用户id必须大于0")]
        public int UserId { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "充值金额必填")]
        [Range(typeof(decimal), "0.01", "999999999.99", ErrorMessage = "必须大于0")]
        public decimal Money { get; set; }
        /// <summary>
        /// 充值类型
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "充值类型必填")]
        [RegularExpression("身家充值|会员充值", ErrorMessage = "不支持的充值类型")]
        public string Type { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "支付类型必填")]
        [RegularExpression("Ali|Wx", ErrorMessage = "不支持的支付类型")]
        public string PayType { get; set; }
    }
}