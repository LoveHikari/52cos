using Com.Cos.Application.Interfaces;
using Com.Cos.Domain;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Interfaces;
using Com.Cos.Repository;

namespace Com.Cos.Application
{
    public class BaseService<TAggregateRoot> : IBaseService<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        protected readonly CosDbContext DbContext;

        protected readonly IMailingAddressRepository MailingAddressRepository;
        protected readonly IExchangeRepository ExchangeRepository;
        protected readonly IExchangeExamineRepository ExchangeExamineRepository;
        protected readonly ICooperationRepository CooperationRepository;
        protected readonly IImgRepository ImgRepository;
        protected readonly IExchangeReplyRepository ExchangeReplyRepository;
        protected readonly ICooperationReplyRepository CooperationReplyRepository;
        protected readonly IExchangePersonRepository ExchangePersonRepository;  //兑换人员表数据访问
        protected readonly IMemberRepository MemberRepository;  //用户表数据访问
        protected readonly IRechargeRecordRepository RechargeRecordRepository;  //充值记录表数据访问
        protected readonly ISysParaRepository SysParaRepository;  //系统配置对应表数据访问
        protected readonly IExchangeEventRepository ExchangeEventRepository;  //兑换事件表数据访问
        protected readonly IDepositControlRepository DepositControlRepository;
        protected readonly ILogisticRepository LogisticRepository;
        protected readonly ILoginCodeRepository LoginCodeRepository;
        protected readonly IShipperCompanyRepository ShipperCompanyRepository;
        protected readonly IAdminMemberRepository AdminMemberRepository;
        protected readonly ICooperationClassRepository CooperationClassRepository;
        protected readonly IRefundRepository RefundRepository;
        protected readonly IQuickNavigationRepository QuickNavigationRepository;
        protected readonly IPostageRepository PostageRepository;
        protected readonly ICosFileStatRepository CosFileStatRepository;
        protected readonly IExchangeClassRepository ExchangeClassRepository;
        protected readonly IVoucherRepository VoucherRepository;
        protected readonly ILoginIPRepository LoginIpRepository;
        protected readonly IIntegralChangeRepository IntegralChangeRepository;
        protected readonly ILoggingRepository LoggingRepository;
        protected readonly IMemberRegisterRepository MemberRegisterRepository;
        protected readonly IVersionNotesRepository VersionNotesRepository;
        public BaseService(CosDbContext dbContext)
        {
            this.DbContext = dbContext;

            this.MailingAddressRepository = RepositoryFactory.CreateObj<MailingAddressRepository>(dbContext);
            this.ExchangeRepository = RepositoryFactory.CreateObj<ExchangeRepository>(dbContext);
            this.ExchangeExamineRepository = RepositoryFactory.CreateObj<ExchangeExamineRepository>(dbContext);
            this.CooperationRepository = RepositoryFactory.CreateObj<CooperationRepository>(dbContext);
            this.ImgRepository = RepositoryFactory.CreateObj<ImgRepository>(dbContext);
            this.ExchangeReplyRepository = RepositoryFactory.CreateObj<ExchangeReplyRepository>(dbContext);
            this.CooperationReplyRepository = RepositoryFactory.CreateObj<CooperationReplyRepository>(dbContext);
            this.ExchangePersonRepository = RepositoryFactory.CreateObj<ExchangePersonRepository>(dbContext);
            this.MemberRepository = RepositoryFactory.CreateObj<MemberRepository>(dbContext);
            this.RechargeRecordRepository = RepositoryFactory.CreateObj<RechargeRecordRepository>(dbContext);
            this.SysParaRepository = RepositoryFactory.CreateObj<SysParaRepository>(dbContext);
            this.ExchangeEventRepository = RepositoryFactory.CreateObj<ExchangeEventRepository>(dbContext);
            this.DepositControlRepository = RepositoryFactory.CreateObj<DepositControlRepository>(dbContext);
            this.LogisticRepository = RepositoryFactory.CreateObj<LogisticRepository>(dbContext);
            this.LoginCodeRepository = RepositoryFactory.CreateObj<LoginCodeRepository>(dbContext);
            this.ShipperCompanyRepository = RepositoryFactory.CreateObj<ShipperCompanyRepository>(dbContext);
            this.AdminMemberRepository = RepositoryFactory.CreateObj<AdminMemberRepository>(dbContext);
            this.CooperationClassRepository = RepositoryFactory.CreateObj<CooperationClassRepository>(dbContext);
            this.RefundRepository = RepositoryFactory.CreateObj<RefundRepository>(dbContext);
            this.QuickNavigationRepository = RepositoryFactory.CreateObj<QuickNavigationRepository>(dbContext);
            this.PostageRepository = RepositoryFactory.CreateObj<PostageRepository>(dbContext);
            this.CosFileStatRepository = RepositoryFactory.CreateObj<CosFileStatRepository>(dbContext);
            this.ExchangeClassRepository = RepositoryFactory.CreateObj<ExchangeClassRepository>(dbContext);
            this.VoucherRepository = RepositoryFactory.CreateObj<VoucherRepository>(dbContext);
            this.LoginIpRepository = RepositoryFactory.CreateObj<LoginIPRepository>(dbContext);
            this.IntegralChangeRepository = RepositoryFactory.CreateObj<IntegralChangeRepository>(dbContext);
            this.LoggingRepository = RepositoryFactory.CreateObj<LoggingRepository>(dbContext);
            this.MemberRegisterRepository = RepositoryFactory.CreateObj<MemberRegisterRepository>(dbContext);
            this.VersionNotesRepository = RepositoryFactory.CreateObj<VersionNotesRepository>(dbContext);
        }
    }
}