using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 腾讯对象存储文件信息表仓储
    /// </summary>
    public class CosFileStatRepository:BaseRepository<CosFileStat>,ICosFileStatRepository
    {
        public CosFileStatRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}