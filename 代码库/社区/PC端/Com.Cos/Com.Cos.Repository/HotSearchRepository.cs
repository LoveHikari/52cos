using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 热门搜索表仓储
    /// </summary>
    public class HotSearchRepository:BaseRepository<HotSearch>,IHotSearchRepository
    {
        public HotSearchRepository(IDbContext nContext) : base(nContext)
        {
        }
    }
}