using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Application
{
    /// <summary>
    /// 押金对照表业务
    /// </summary>
    public class DepositControlService:BaseService<DepositControl>,IDepositControlService
    {
        public DepositControlService(CosDbContext dbContext) : base(dbContext)
        {
        }

    }
}