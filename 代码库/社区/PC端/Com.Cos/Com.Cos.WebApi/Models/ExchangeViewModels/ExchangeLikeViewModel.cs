using System.ComponentModel.DataAnnotations;

namespace Com.Cos.WebApi.Models.ExchangeViewModels
{
    /// <summary>
    /// 用户关注兑换视图模型
    /// </summary>
    public class ExchangeLikeViewModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        [Required(AllowEmptyStrings = false,ErrorMessage = "用户id必填")]
        [Range(typeof(int), "1", "999999999", ErrorMessage = "用户id必须大于0")]
        public int UserId { get; set; }

    }
}