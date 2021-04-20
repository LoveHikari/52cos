using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 物流公司表仓储
    /// </summary>
    public class ShipperCompanyRepository:BaseRepository<ShipperCompany>, IShipperCompanyRepository
    {
        public ShipperCompanyRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}