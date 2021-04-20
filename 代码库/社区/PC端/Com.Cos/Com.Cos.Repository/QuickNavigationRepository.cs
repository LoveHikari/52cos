using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 快捷导航表仓储
    /// </summary>
    public class QuickNavigationRepository:BaseRepository<QuickNavigation>, IQuickNavigationRepository
    {

        public QuickNavigationRepository(IDbContext nContext) : base(nContext)
        {
        }
    }
}