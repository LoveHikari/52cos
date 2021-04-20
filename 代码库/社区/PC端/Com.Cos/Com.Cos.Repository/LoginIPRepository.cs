using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 访问记录表仓储
    /// </summary>
    public class LoginIPRepository:BaseRepository<LoginIP>, ILoginIPRepository
    {
        public LoginIPRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}