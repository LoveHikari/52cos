namespace Com.Cos.WebApi.ResultModels.CooperationResultModels
{
    /// <summary>
    /// 合作列表返回结果
    /// </summary>
    public class CooperationResultModel
    {
        /// <summary>
        /// 合作id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        public string Cover { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Portrait { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 报名人数
        /// </summary>
        public int PersonNum { get; set; }
    }
}