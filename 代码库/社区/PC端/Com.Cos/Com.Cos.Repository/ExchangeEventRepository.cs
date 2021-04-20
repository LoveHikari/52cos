using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 兑换事件表仓储
    /// </summary>
    public class ExchangeEventRepository:BaseRepository<ExchangeEvent>,IExchangeEventRepository
    {
        public ExchangeEventRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}