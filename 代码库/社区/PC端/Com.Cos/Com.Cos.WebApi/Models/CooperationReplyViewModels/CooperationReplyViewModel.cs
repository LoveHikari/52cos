using System.ComponentModel.DataAnnotations;

namespace Com.Cos.WebApi.Models.CooperationReplyViewModels
{
    /// <summary>
    /// 合作评论视图模型
    /// </summary>
    public class CooperationReplyViewModel
    {
        /// <summary>
        /// 回复用户id
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Range(typeof(int), "1", "999999999", ErrorMessage = "用户id必须大于0")]
        public int UserId { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        [Required(ErrorMessage = "回复内容必填")]
        public string Text { get; set; }
        /// <summary>
        /// 评论id
        /// </summary>
        public int ParentId { get; set; }
    }
}