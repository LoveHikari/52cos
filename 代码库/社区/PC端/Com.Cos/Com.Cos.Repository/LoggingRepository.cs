using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 日志记录表仓储
    /// </summary>
    public class LoggingRepository:BaseRepository<Logging>, ILoggingRepository
    {
        public LoggingRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}