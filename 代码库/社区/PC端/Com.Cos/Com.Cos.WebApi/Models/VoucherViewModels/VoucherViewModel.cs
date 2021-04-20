using System.ComponentModel.DataAnnotations;
using Com.Cos.WebApi.Filter;

namespace Com.Cos.WebApi.Models.VoucherViewModels
{
    /// <summary>
    /// 兑换码视图模型
    /// </summary>
    public class VoucherViewModel
    {
        /// <summary>
        /// 兑换码
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "兑换码必填")]
        [CustomRemote("CheckVoucher", "Remote", HttpMethod = "GET", ErrorMessage = "兑换码已使用或不存在")]
        public string Code { get; set; }
    }
}