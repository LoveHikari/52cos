using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 首页幻灯片仓储
    /// </summary>
    public class SlideRepository:BaseRepository<Slide>, ISlideRepository
    {
        public SlideRepository(IDbContext nContext) : base(nContext)
        {
        }
    }
}