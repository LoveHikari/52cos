using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 兑换状态表仓储
    /// </summary>
    public class ExchangeExamineRepository:BaseRepository<ExchangeExamine>, IExchangeExamineRepository
    {
        public ExchangeExamineRepository(IDbContext nContext) : base(nContext)
        {
        }
    }
}