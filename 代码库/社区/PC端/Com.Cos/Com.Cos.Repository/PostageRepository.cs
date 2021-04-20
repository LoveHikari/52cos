using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 邮费表仓储
    /// </summary>
    public class PostageRepository:BaseRepository<Postage>, IPostageRepository
    {
        public PostageRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}