namespace Com.Cos.WebApi.ResultModels.MemberResultModels
{
    /// <summary>
    /// 用户信息返回结果数据
    /// </summary>
    public class MemberResultModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string Portrait { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 身家
        /// </summary>
        public decimal ShenJia { get; set; }
        /// <summary>
        /// 剩余兑换次数
        /// </summary>
        public int Surplus { get; set; }
        /// <summary>
        /// 是否是会员
        /// </summary>
        public bool IsVip { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 个性签名
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 会员过期时间
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneMob { get; set; }
        /// <summary>
        /// 支付宝账号
        /// </summary>
        public string ImAlipay { get; set; }
        /// <summary>
        /// 押金
        /// </summary>
        public int Deposit { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 押金状态，true为正在申请退回
        /// </summary>
        public bool DepositState { get; set; }
    }
}