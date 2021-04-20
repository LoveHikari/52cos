namespace Com.Cos.WebApi.ResultModels.StartResultModels
{
    /// <summary>
    /// 用户登录返回结果数据
    /// </summary>
    public class MemberLoginResultModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Portrait { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 融云token
        /// </summary>
        public string RongToken { get; set; }
    }
}