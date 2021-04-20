using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Com.Cos.Application
{
    /// <summary>
    /// 短信验证码表业务逻辑
    /// </summary>
    public class LoginCodeService: BaseService<LoginCode>, ILoginCodeService
    {
        private readonly ILoginCodeRepository _loginCodeRepository;
        public LoginCodeService(CosDbContext dbContext) : base(dbContext)
        {
            _loginCodeRepository = RepositoryFactory.CreateObj<LoginCodeRepository>(dbContext);
        }
        /// <summary>
        /// 添加验证码
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="code">验证码</param>
        /// <returns>添加成功返回true</returns>
        public async Task<bool> AddAsync(string phone, string code)
        {
            LoginCode loginCode = new LoginCode()
            {
                Phone = phone,
                Code = code,
                AddTime = DateTime.Now,
                Status = 1
            };
            return (await _loginCodeRepository.AddAsync(loginCode)).Id > 0;
        }
        /// <summary>
        /// 查询验证码，满足条件返回true
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="code">验证码</param>
        /// <returns>满足条件返回true</returns>
        public async Task<bool> FindAsync(string phone, string code)
        {
            var model = await _loginCodeRepository.FindList(p => p.Phone == phone && p.Status == 1, "AddTime", false).FirstOrDefaultAsync();
            if (model == null || DateTime.Now - model.AddTime > new TimeSpan(0, 30, 0) || model.Code != code)
            {
                return false;
            }
            model.Status = 0;
            bool b =  await _loginCodeRepository.UpdateAsync(model);
            return true;
        }
    }
}