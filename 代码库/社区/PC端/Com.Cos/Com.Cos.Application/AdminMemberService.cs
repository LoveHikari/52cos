using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Interfaces;
using Com.Cos.Repository;

namespace Com.Cos.Application
{
    public class AdminMemberService : BaseService<AdminMember>, IAdminMemberService
    {

        public AdminMemberService(CosDbContext dbContext) : base(dbContext)
        {

        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public AdminMemberDto Find(string userName, string password)
        {
            password = System.DEncryptHelper.Encrypt3DES(password);
            var member = this.AdminMemberRepository.Find(p => p.UserName == userName && p.Password == password && p.Status > 0);
            AdminMemberDto dto = new AdminMemberDto()
            {
                Id = member.Id,
                Authority = member.Authority.GetValueOrDefault(),
                UserName = member.UserName,
                Nickname = member.Nickname
            };
            return dto;
        }
    }
}