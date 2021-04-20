using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;

namespace Com.Cos.Application
{
    /// <summary>
    /// 用户注册信息表业务
    /// </summary>
    public class MemberRegisterService:BaseService<MemberRegister>, IMemberRegisterService
    {
        public MemberRegisterService(CosDbContext dbContext) : base(dbContext)
        {
        }
    }
}