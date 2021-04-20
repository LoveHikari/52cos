using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 用户注册信息表仓储
    /// </summary>
    public class MemberRegisterRepository:BaseRepository<MemberRegister>, IMemberRegisterRepository
    {
        public MemberRegisterRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}