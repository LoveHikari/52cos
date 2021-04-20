namespace Com.Cos.Admin.Models.MemberViewModels
{
    public class MemberListViewModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneMob { get; set; }
        /// <summary>
        /// 是否是会员
        /// </summary>
        public bool IsVip { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public string AddTime { get; set; }
        /// <summary>
        /// 注册地址
        /// </summary>
        public string Address { get; set; }
    }
}