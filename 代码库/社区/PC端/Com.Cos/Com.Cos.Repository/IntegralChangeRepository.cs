using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 积分变更记录表仓储
    /// </summary>
    public class IntegralChangeRepository:BaseRepository<IntegralChange>, IIntegralChangeRepository
    {
        public IntegralChangeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}