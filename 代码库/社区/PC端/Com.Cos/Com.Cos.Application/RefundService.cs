using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;

namespace Com.Cos.Application
{
    /// <summary>
    /// 退款记录表业务
    /// </summary>
    public class RefundService : BaseService<Refund>, IRefundService
    {
        public RefundService(CosDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// 添加退款订单
        /// </summary>
        /// <param name="userId">用户id</param>
        public async Task AddAsync(int userId)
        {
            var member = await this.MemberRepository.FindAsync(m => m.Id == userId);
            decimal deposit = member.Deposit.GetValueOrDefault();
            Refund refund = new Refund()
            {
                UserId = userId,
                Money = deposit.ToDouble(),
                Type = "退还押金",
                Description = "退还押金",
                Account = member.ImAlipay,
                AccountType = "alipay",
                RealName = member.Real_name,
                OutBizNo = SysHelper.GenerateTradeNo(),
                AddTime = DateTime.Now,
                Status = 0
            };
            await this.RefundRepository.AddAsync(refund);
        }
        /// <summary>
        /// 添加取消订单
        /// </summary>
        /// <param name="epId">兑换人员id</param>
        public void AddCancelOrder(int epId)
        {
            var epModel = this.ExchangePersonRepository.Find(m => m.Id == epId);
            decimal money = epModel.Postage;
            if (epModel.Examine == "3")
            {
                money += 30;
            }

            Refund refund = new Refund()
            {
                UserId = epModel.UserId.ToInt32(),
                Money = money.ToDouble(),
                Type = "正常退款",
                Description = "退还押金",
                Account = "",
                AccountType = epModel.PaymentWay,
                RealName = "",
                OutBizNo = epModel.SerialNum,
                AddTime = DateTime.Now,
                Status = 0
            };
            this.RefundRepository.Add(refund);
        }
        /// <summary>
        /// 获得退款列表
        /// </summary>
        /// <returns></returns>
        public List<RefundDto> FindList()
        {
            /*SELECT r.id,r.UserId,r.Type,r.Account,r.AddTime,r.AccountType,r.Money,m.nickname,m.Deposit,r.Status FROM sns_refund r
            LEFT JOIN dbo.cos_member m ON r.UserId=m.User_id
            ORDER BY r.AddTime DESC*/
            var v = from r in this.DbContext.Refunds
                    join m in this.DbContext.Members on r.UserId equals m.Id into mi
                    from m in mi.DefaultIfEmpty()
                    orderby r.AddTime descending
                    select new RefundDto
                    {
                        Id = r.Id,
                        UserId = r.UserId,
                        Type = r.Type,
                        Account = r.Account,
                        AddTime = r.AddTime,
                        AccountType = r.AccountType,
                        Money = r.Money,
                        Nickname = m.Nickname,
                        Deposit = m.Deposit.ToDouble(0),
                        Status = r.Status
                    };
            return v.ToList();
        }
        /// <summary>
        /// 获得退款信息
        /// </summary>
        /// <param name="id">退款id</param>
        /// <returns></returns>
        public RefundDto Find(int id)
        {
            var v = from r in this.DbContext.Refunds
                    join m in this.DbContext.Members on r.UserId equals m.Id into mi
                    from m in mi.DefaultIfEmpty()
                    where r.Id == id
                    select new RefundDto()
                    {
                        Account = m.ImAlipay,
                        RealName = m.Real_name,
                        Money = r.Money,
                        OutBizNo = r.OutBizNo
                    };
            RefundDto dto = v.FirstOrDefault();

            return dto;
        }

        /// <summary>
        /// 修改押金
        /// </summary>
        /// <param name="id">退款id</param>
        /// <returns>修改成功返回true</returns>
        public bool UpdateDeposit(int id)
        {
            var model = this.RefundRepository.Find(m => m.Id == id);
            var userId = model.UserId;
            model.Status = 1;

            var member = this.MemberRepository.Find(m => m.Id == userId);
            member.Deposit = member.Deposit.GetValueOrDefault(0) - model.Money.ToDecimal();
            using (var tr = this.DbContext.Database.BeginTransaction())
            {
                this.MemberRepository.Update(member);
                this.RefundRepository.Update(model);
                tr.Commit();
            }
            return true;
        }
    }
}