using System;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;

namespace Com.Cos.Application
{
    /// <summary>
    /// 积分变更记录表业务
    /// </summary>
    public class IntegralChangeService:BaseService<IntegralChange>, IIntegralChangeService
    {
        public IntegralChangeService(CosDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// 兑换回收成功时
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="value">身家值</param>
        public void AddExchange(int userId,string value)
        {
            IntegralChange model = new IntegralChange()
            {
                Source = "shareRedemption",
                UserId = userId.ToString(),
                Description = "发布兑换",
                RefValue = value,
                AddTime = DateTime.Now,
                Status = 1
            };
            this.IntegralChangeRepository.Add(model);
            Member member = this.MemberRepository.Find(m => m.Id == userId);
            member.Shenjia = member.Shenjia.GetValueOrDefault() + value.ToDecimal();
            this.MemberRepository.Update(member);
        }
    }
}