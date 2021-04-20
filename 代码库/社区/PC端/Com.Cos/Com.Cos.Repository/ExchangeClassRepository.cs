using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 兑换分类表仓储
    /// </summary>
    public class ExchangeClassRepository:BaseRepository<ExchangeClass>,IExchangeClassRepository
    {
        public ExchangeClassRepository(IDbContext nContext) : base(nContext)
        {
        }
    }
}