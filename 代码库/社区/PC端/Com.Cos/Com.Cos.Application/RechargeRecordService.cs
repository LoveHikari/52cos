using System;
using System.Globalization;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Application
{
    /// <summary>
    /// 充值记录表业务
    /// </summary>
    public class RechargeRecordService : BaseService<RechargeRecord>, IRechargeRecordService
    {
        public RechargeRecordService(CosDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(RechargeRecordDto dto)
        {
            var model = new RechargeRecord()
            {
                UserId = dto.UserId.ToString(),
                Source = dto.Type,
                RMB = dto.Money.ToString(CultureInfo.InvariantCulture),
                Cnbi = "",
                AddTime = DateTime.Now,
                OrderNo = dto.OrderNo,
                OrderName = dto.OrderName,
                WareDesc = dto.WareDesc,
                Status = 0
            };
            model = await this.RechargeRecordRepository.AddAsync(model);
            return model.Id;
        }
        /// <summary>
        /// 处理订单
        /// </summary>
        /// <param name="id"></param>
        public async Task DealWithAsync(int id)
        {
            var model = await this.RechargeRecordRepository.FindAsync(r => r.Id == id && r.Status == 0);
            if (model != null)
            {
                switch (model.Source)
                {
                    case "身家充值":
                        using (var ts = await this.DbContext.Database.BeginTransactionAsync())
                        {
                            model.Status = 1;
                            var member = await this.MemberRepository.FindAsync(m => m.Id == model.UserId.ToInt32(0));
                            member.Shenjia = (member.Shenjia ?? 0) + model.RMB.ToDecimal();
                            await this.MemberRepository.UpdateAsync(member);
                            await this.RechargeRecordRepository.UpdateAsync(model);

                            ts.Commit();
                        }
                        break;
                    case "会员充值":
                        using (var ts = await this.DbContext.Database.BeginTransactionAsync())
                        {
                            model.Status = 1;
                            var member = await this.MemberRepository.FindAsync(m => m.Id == model.UserId.ToInt32(0));

                            if (model.RMB == "99")  //1年会员，10次兑换
                            {
                                DateTime startTime = member.Stime.GetValueOrDefault();  //会员开始时间
                                DateTime endTime = member.Etime.GetValueOrDefault();  //结束时间
                                DateTime nowTime = DateTime.Now;
                                if (endTime - nowTime <= TimeSpan.Zero)
                                {
                                    startTime = nowTime;
                                    endTime = nowTime.AddYears(1);
                                }
                                else
                                {
                                    endTime = endTime.AddYears(1);
                                }
                                member.Stime = startTime;
                                member.Etime = endTime;
                                member.Conversions = member.Conversions.GetValueOrDefault(0) + 10;
                                member.RemainingConversions = member.Conversions.GetValueOrDefault(0) + 10;
                            }

                            await this.MemberRepository.UpdateAsync(member);
                            await this.RechargeRecordRepository.UpdateAsync(model);

                            ts.Commit();
                        }
                        break;
                }
                RongCloudHelper.PublishSystemBySystem(model.UserId, "充值成功，请查看");
            }

        }
    }
}