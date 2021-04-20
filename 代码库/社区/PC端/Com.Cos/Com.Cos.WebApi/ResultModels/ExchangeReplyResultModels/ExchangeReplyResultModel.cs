namespace Com.Cos.WebApi.ResultModels.ExchangeReplyResultModels
{
    public class ExchangeReplyResultModel
    {
        /// <summary>
        /// 回复id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 兑换id
        /// </summary>
        public int ExId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Portrait { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 回复文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public string AddTime { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int LikeNum { get; set; }
        /// <summary>
        /// 是否已经点赞
        /// </summary>
        public bool IsLike { get; set; }
        /// <summary>
        /// 回复用户id
        /// </summary>
        public int ReplyUserId { get; set; }
        /// <summary>
        /// 回复用户昵称
        /// </summary>
        public string ReplyNickname { get; set; }
    }
}