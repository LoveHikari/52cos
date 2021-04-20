using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    public class RefundRepository : BaseRepository<Refund>, IRefundRepository
    {
        public RefundRepository(IDbContext nContext) : base(nContext)
        {
        }
    }
}