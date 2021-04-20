using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 通讯地址仓储
    /// </summary>
    public class MailingAddressRepository : BaseRepository<MailingAddress>,IMailingAddressRepository
    {
        public MailingAddressRepository(IDbContext nContext) : base(nContext)
        {
        }
    }
}