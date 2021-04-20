using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Application
{
    /// <summary>
    /// 物流公司表业务
    /// </summary>
    public class ShipperCompanyService:BaseService<ShipperCompany>,IShipperCompanyService
    {
        public ShipperCompanyService(CosDbContext dbContext) : base(dbContext)
        {
        }
    }
}