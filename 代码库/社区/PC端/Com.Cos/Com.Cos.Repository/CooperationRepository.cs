using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 合作表仓储
    /// </summary>
    public class CooperationRepository:BaseRepository<Cooperation>,ICooperationRepository
    {
        public CooperationRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}