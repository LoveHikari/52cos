using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 会员表仓储
    /// </summary>
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(IDbContext nContext) : base(nContext)
        {
        }
    }
}