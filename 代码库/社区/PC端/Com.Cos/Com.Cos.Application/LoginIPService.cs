using System;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;

namespace Com.Cos.Application
{
    /// <summary>
    /// 访问记录表业务
    /// </summary>
    public class LoginIPService:BaseService<LoginIP>,ILoginIPService
    {
        public LoginIPService(CosDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ip">访问ip</param>
        /// <param name="url">访问的url</param>
        public void Add(string ip,string url)
        {
            var model = new LoginIP()
            {
                Ip = ip,
                Address = "",
                RawUrl = url,
                AddTime = DateTime.Now,
                Status = 1
            };
            this.LoginIpRepository.Add(model);
        }

        public int GetCount(DateTime? dateTime = null)
        {
            if (dateTime == null)
            {
                return this.LoginIpRepository.Count(m => m.Status > 0);
            }
            return this.LoginIpRepository.Count(m => m.Status > 0 && m.AddTime.Date == dateTime.GetValueOrDefault().Date);
        }
    }
}