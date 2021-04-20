using System.Data.Entity;
using Com.Cos.Models;

namespace Com.Cos.DAL
{
    /// <summary>
    /// 数据上下文
    /// <remarks>创建：2014.02.03</remarks>
    /// </summary>
    public class CosDbContext : DbContext
    {
        public CosDbContext() : base("CosDBContext")
        {
        }

        #region 上下文

        public DbSet<Slide> Slides { get; set; }
        /// <summary>
        /// 分享/兑换表数据上下文
        /// </summary>
        public DbSet<Exchange> Exchanges { get; set; }
        /// <summary>
        /// 会员表数据上下文
        /// </summary>
        public DbSet<Member> Members { get; set; }
        /// <summary>
        /// 合作表数据上下文
        /// </summary>
        public DbSet<Cooperation> Cooperations { get; set; }
        /// <summary>
        /// 图片数据上下文
        /// </summary>
        public DbSet<Img> Imgs { get; set; }
        /// <summary>
        /// 兑换分类数据上下文
        /// </summary>
        public DbSet<ExchangeClass> ExchangeClasses { get; set; }
        /// <summary>
        /// 兑换状态数据上下文
        /// </summary>
        public DbSet<ExchangeExamine> ExchangeExamines { get; set; }
        /// <summary>
        /// 充值记录数据上下文
        /// </summary>
        public DbSet<RechargeRecord> RechargeRecords { get; set; }
        /// <summary>
        /// 菜单模块数据上下文
        /// </summary>
        public IDbSet<MenuModule> MenuModules { get; set; }
        /// <summary>
        /// 积分来源上下文
        /// </summary>
        public IDbSet<IntegralSource> IntegralSources { get; set; }
        /// <summary>
        /// 支付宝充值交易记录上下文
        /// </summary>
        public IDbSet<Transactions> Transactionses { get; set; }
        /// <summary>
        /// 积分变更记录上下文
        /// </summary>
        public IDbSet<IntegralChange> IntegralChanges { get; set; }

        /// <summary>
        /// 通讯地址上下文
        /// </summary>
        public IDbSet<MailingAddress> MailingAddresses { get; set; }

        /// <summary>
        /// 兑换人员上下文
        /// </summary>
        public IDbSet<ExchangePerson> ExchangePersons { get; set; }
        /// <summary>
        /// 抽奖活动参与上下文
        /// </summary>
        public IDbSet<Lottery> Lotteries { get; set; }
        #endregion

    }
}