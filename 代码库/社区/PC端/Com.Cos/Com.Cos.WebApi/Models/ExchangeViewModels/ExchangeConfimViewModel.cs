using System.ComponentModel.DataAnnotations;

namespace Com.Cos.WebApi.Models.ExchangeViewModels
{
    /// <summary>
    /// 确认兑换信息视图模型
    /// </summary>
    public class ExchangeConfimViewModel
    {
        /// <summary>
        /// 兑换方式
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "必须选择兑换方式")]
        [RegularExpression("身家兑换|会员租赁|单次租赁|兑换券", ErrorMessage = "不支持的兑换类型")]
        public string Examine { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "必须先登录")]
        [Range(typeof(int), "1", "999999999", ErrorMessage = "必须先登录")]
        public int UserId { get; set; }
    }
}