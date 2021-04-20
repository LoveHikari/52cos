using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 短信验证码仓储
    /// </summary>
    public class LoginCodeRepository : BaseRepository<LoginCode>, ILoginCodeRepository
    {
        public LoginCodeRepository(IDbContext nContext) : base(nContext)
        {
        }
    }
}