using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 合作分类表仓储
    /// </summary>
    public class CooperationClassRepository:BaseRepository<CooperationClass>,ICooperationClassRepository
    {
        public CooperationClassRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}