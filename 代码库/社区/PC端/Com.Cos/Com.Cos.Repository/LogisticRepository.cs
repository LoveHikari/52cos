using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 物流信息表仓储
    /// </summary>
    public class LogisticRepository:BaseRepository<Logistic>, ILogisticRepository
    {
        public LogisticRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}