using Com.Cos.IDAL;

namespace Com.Cos.DAL
{
    /// <summary>
    /// 简单工厂？
    /// <remarks>创建：2014.02.03</remarks>
    /// </summary>
    public static class RepositoryFactory
    {
        public static ISlideRepository SlideRepository => new SlideRepository();
        /// <summary>
        /// 用户仓储
        /// </summary>
        public static IMemberRepository MemberRepository => new MemberRepository();

        /// <summary>
        /// 分享/兑换仓储
        /// </summary>
        public static IExchangeRepository ExchangeRepository => new ExchangeRepository();
        /// <summary>
        /// 合作仓储
        /// </summary>
        public static ICooperationRepository CooperationRepository => new CooperationRepository();
        /// <summary>
        /// 图片仓储
        /// </summary>
        public static  IImgRepository ImgRepository => new ImgRepository();
        /// <summary>
        /// 兑换分类仓储
        /// </summary>
        public static IExchangeClassRepository ExchangeClassRepository => new ExchangeClassRepository();
        /// <summary>
        /// 兑换状态仓储
        /// </summary>
        public static IExchangeExamineRepository ExchangeExamineRepository => new ExchangeExamineRepository();
        /// <summary>
        /// 充值记录仓储
        /// </summary>
        public static IRechargeRecordRepository RechargeRecordRepository => new RechargeRecordRepository();
        /// <summary>
        /// 菜单模块仓储
        /// </summary>
        public static IMenuModuleRepository MenuModuleRepository => new MenuModuleRepository();
        /// <summary>
        /// 积分来源仓储
        /// </summary>
        public static IIntegralSourceRepository IntegralSourceRepository=> new IntegralSourceRepository();
        /// <summary>
        /// 支付宝充值交易记录仓储
        /// </summary>
        public static ITransactionsRepository TransactionsRepository => new TransactionsRepository();
        /// <summary>
        /// 积分变更记录仓储
        /// </summary>
        public static IIntegralChangeRepository IntegralChangeRepository => new IntegralChangeRepository();
        /// <summary>
        /// 通讯地址仓储
        /// </summary>
        public static IMailingAddressRepository MailingAddressRepository => new MailingAddressRepository();
        /// <summary>
        /// 兑换人员仓储
        /// </summary>
        public static IExchangePersonRepository ExchangePersonRepository => new ExchangePersonRepository();
        /// <summary>
        /// 抽奖活动参与仓储
        /// </summary>
        public static ILotteryRepository LotteryRepository => new LotteryRepository();
    }
}