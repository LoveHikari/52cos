using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 兑换码表仓储
    /// </summary>
    public class VoucherRepository:BaseRepository<Voucher>, IVoucherRepository
    {
        public VoucherRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}