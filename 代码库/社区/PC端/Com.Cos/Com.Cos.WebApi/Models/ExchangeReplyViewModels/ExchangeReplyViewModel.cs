using System.ComponentModel.DataAnnotations;

namespace Com.Cos.WebApi.Models.ExchangeReplyViewModels
{
    /// <summary>
    /// 兑换评论视图模型
    /// </summary>
    public class ExchangeReplyViewModel
    {
        /// <summary>
        /// 回复用户id
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "用户id必填")]
        [Range(typeof(int), "1", "999999999", ErrorMessage = "用户id必须大于0")]
        public int UserId { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "回复内容必填")]
        public string Text { get; set; }
        /// <summary>
        /// 评论id
        /// </summary>
        public int ParentId { get; set; }

    }
}