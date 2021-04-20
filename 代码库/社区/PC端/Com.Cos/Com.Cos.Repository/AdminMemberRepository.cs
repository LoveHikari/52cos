using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 后台用户表仓储
    /// </summary>
    public class AdminMemberRepository:BaseRepository<AdminMember>,IAdminMemberRepository
    {
        public AdminMemberRepository(IDbContext nContext) : base(nContext)
        {
        }
    }
}