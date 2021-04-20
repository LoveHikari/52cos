using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Com.Cos.Infrastructure
{
    public class CosDbContext : DbContext, IDbContext
    {
        public CosDbContext(DbContextOptions<CosDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailingAddress>();
            modelBuilder.Entity<Member>();
            modelBuilder.Entity<LoginCode>();
            modelBuilder.Entity<QuickNavigation>();
            modelBuilder.Entity<AdminMember>();
            modelBuilder.Entity<Slide>();
            modelBuilder.Entity<Exchange>();
            modelBuilder.Entity<Img>();
            modelBuilder.Entity<HotSearch>();
            modelBuilder.Entity<ExchangeClass>();
            modelBuilder.Entity<ExchangeExamine>();
            modelBuilder.Entity<Cooperation>();
            modelBuilder.Entity<ExchangeReply>();
            modelBuilder.Entity<CooperationReply>();
            modelBuilder.Entity<ExchangePerson>();
            modelBuilder.Entity<RechargeRecord>();
            modelBuilder.Entity<SysPara>();
            modelBuilder.Entity<ExchangeEvent>();
            modelBuilder.Entity<DepositControl>();
            modelBuilder.Entity<Logistic>();
            modelBuilder.Entity<ShipperCompany>();
            modelBuilder.Entity<CooperationClass>();
            modelBuilder.Entity<Refund>();
            modelBuilder.Entity<Postage>();
            modelBuilder.Entity<CosFileStat>();
            modelBuilder.Entity<Voucher>(builder => builder.HasQueryFilter(v => v.Status > 0));
            modelBuilder.Entity<LoginIP>(builder => builder.HasQueryFilter(v => v.Status > 0));
            modelBuilder.Entity<IntegralChange>(builder => builder.HasQueryFilter(v => v.Status > 0));
            modelBuilder.Entity<Logging>(builder => builder.HasQueryFilter(v => v.Status > 0));
            modelBuilder.Entity<MemberRegister>();
            modelBuilder.Entity<VersionNotes>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<MailingAddress> MailingAddresses { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<LoginCode> LoginCodes { get; set; }
        public DbSet<QuickNavigation> QuickNavigations { get; set; }
        public DbSet<AdminMember> AdminMembers { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<Img> Imgs { get; set; }
        public DbSet<HotSearch> HotSearches { get; set; }
        public DbSet<ExchangeClass> ExchangeClasses { get; set; }
        public DbSet<ExchangeExamine> ExchangeExamines { get; set; }
        public DbSet<Cooperation> Cooperations { get; set; }
        public DbSet<ExchangeReply> ExchangeReplies { get; set; }
        public DbSet<CooperationReply> CooperationReplies { get; set; }
        /// <summary>
        /// 兑换人员表数据上下文
        /// </summary>
        public DbSet<ExchangePerson> ExchangePersons { get; set; }
        /// <summary>
        /// 充值记录表数据上下文
        /// </summary>
        public DbSet<RechargeRecord> RechargeRecords { get; set; }
        /// <summary>
        /// 系统配置对应表数据上下文
        /// </summary>
        public DbSet<SysPara> SysParas { get; set; }
        public DbSet<ExchangeEvent> ExchangeEvents { get; set; }
        public DbSet<DepositControl> DepositControls { get; set; }
        public DbSet<Logistic> Logistics { get; set; }
        public DbSet<ShipperCompany> ShipperCompanies { get; set; }
        public DbSet<CooperationClass> CooperationClasses { get; set; }
        public DbSet<Refund> Refunds { get; set; }
        public DbSet<Postage> Postages { get; set; }
        public DbSet<CosFileStat> CosFileStats { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<LoginIP> LoginIps { get; set; }
        public DbSet<IntegralChange> IntegralChanges { get; set; }
        public DbSet<Logging> Loggings { get; set; }
        public DbSet<MemberRegister> MemberRegisters { get; set; }
        public DbSet<VersionNotes> VersionNoteses { get; set; }

    }
}
