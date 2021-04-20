using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 押金对照表仓储
    /// </summary>
    public class DepositControlRepository:BaseRepository<DepositControl>,IDepositControlRepository
    {
        public DepositControlRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}