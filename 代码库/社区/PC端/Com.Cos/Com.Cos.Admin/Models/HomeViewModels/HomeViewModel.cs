namespace Com.Cos.Admin.Models.HomeViewModels
{
    public class HomeViewModel
    {
        /// <summary>
        /// 用户总数
        /// </summary>
        public int MemberCount { get; set; }
        /// <summary>
        /// 今天用户数
        /// </summary>
        public int TodayMemberCount { get; set; }
        /// <summary>
        /// 昨天用户数
        /// </summary>
        public int YesterdayMemberCount { get; set; }
        /// <summary>
        /// 会员总数
        /// </summary>
        public int VipCount { get; set; }
        /// <summary>
        /// 今天会员数
        /// </summary>
        public int TodayVipCount { get; set; }
        /// <summary>
        /// 昨天会员数
        /// </summary>
        public int YesterdayVipCount { get; set; }
        /// <summary>
        /// 访问量
        /// </summary>
        public int LoginCount { get; set; }
        /// <summary>
        /// 今天访问量
        /// </summary>
        public int TodayLoginCount { get; set; }
        /// <summary>
        /// 昨天访问量
        /// </summary>
        public int YesterdayLoginCount { get; set; }
    }
}