using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 兑换人员表仓储
    /// </summary>
    public class ExchangePersonRepository:BaseRepository<ExchangePerson>, IExchangePersonRepository
    {
        public ExchangePersonRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}