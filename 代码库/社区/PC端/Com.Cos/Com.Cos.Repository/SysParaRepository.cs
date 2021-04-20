using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 系统配置对应表仓储
    /// </summary>
    public class SysParaRepository:BaseRepository<SysPara>,ISysParaRepository
    {
        public SysParaRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}