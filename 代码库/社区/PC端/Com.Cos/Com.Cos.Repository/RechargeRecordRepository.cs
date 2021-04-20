using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 充值记录表仓储
    /// </summary>
    public class RechargeRecordRepository:BaseRepository<RechargeRecord>, IRechargeRecordRepository
    {
        public RechargeRecordRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}