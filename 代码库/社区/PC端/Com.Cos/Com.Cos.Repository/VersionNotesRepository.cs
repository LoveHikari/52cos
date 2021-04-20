using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 版本记录表仓储
    /// </summary>
    public class VersionNotesRepository:BaseRepository<VersionNotes>, IVersionNotesRepository
    {
        public VersionNotesRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}