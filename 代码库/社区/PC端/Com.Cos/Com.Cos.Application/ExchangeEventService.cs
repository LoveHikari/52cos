using System;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Application
{
    /// <summary>
    /// 兑换事件表业务
    /// </summary>
    public class ExchangeEventService : BaseService<ExchangeEvent>, IExchangeEventService
    {
        public ExchangeEventService(CosDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> AddAsync(ExchangeEventDto dto)
        {
            var model = new ExchangeEvent()
            {
                AddTime = DateTime.Now,
                AddressId = dto.AddressId,
                Deposit = dto.Deposit,
                ExId = dto.ExId,
                Examine = dto.Examine,
                OrderNo = dto.OrderNo,
                Status = 0,
                UserId = dto.UserId,
                VouId = dto.VouId,
                ShenJia = dto.ShenJia,
                Postage = dto.Postage
            };
            model = await this.ExchangeEventRepository.AddAsync(model);
            return model.Id;
        }

        /// <summary>
        /// 处理订单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentWay">付款方式</param>
        /// <returns></returns>
        public async Task<bool> DealWithAsync(int id,string paymentWay)
        {
            var model = await this.ExchangeEventRepository.FindAsync(ee => ee.Id == id && ee.Status == 0);
            if (model==null)
            {
                return true;
            }
            bool b = false;
            using (var ts = await this.DbContext.Database.BeginTransactionAsync())
            {
                //添加兑换人员表
                var ep = new ExchangePerson()
                {
                    UserId = model.UserId.ToString(),
                    ExId = model.ExId.ToString(),
                    AddTime = DateTime.Now,
                    PaymentWay = paymentWay,
                    Address = model.AddressId.ToString(),
                    Status = 1,
                    SerialNum = model.OrderNo.SplitLeft("-"),
                    Postage = model.Postage.GetValueOrDefault(),
                    ShenJia = model.ShenJia.GetValueOrDefault()
                };
                if (model.Examine == "身家兑换")
                {

                    ep.Examine = "1";
                    ep = await this.ExchangePersonRepository.AddAsync(ep);
                    //更新兑换表
                    var ex = await  this.ExchangeRepository.FindAsync(e => e.Id == model.ExId);
                    ex.Examine = "10";  //修改为已结束
                    ex.ExchangePerson = model.UserId.ToString();
                    b = await this.ExchangeRepository.UpdateAsync(ex);
                    //更新会员表
                    var member = await this.MemberRepository.FindAsync(m => m.Id == model.UserId);

                    member.Shenjia -= ex.Price.ToDecimal();
                    b = await this.MemberRepository.UpdateAsync(member);



                }
                if (model.Examine == "会员租赁")
                {
                    ep.Examine = "2";
                    ep = await this.ExchangePersonRepository.AddAsync(ep);
                    //更新兑换表
                    var ex = await this.ExchangeRepository.FindAsync(e => e.Id == model.ExId);
                    ex.Examine = "4";  //修改为已兑换
                    ex.ExchangePerson = model.UserId.ToString();
                    b = await this.ExchangeRepository.UpdateAsync(ex);
                    //更新会员表
                    var member =await this.MemberRepository.FindAsync(m => m.Id == model.UserId);
                    member.Deposit += model.Deposit;
                    member.RemainingConversions--;
                    b = await this.MemberRepository.UpdateAsync(member);

                }
                if (model.Examine == "单次租赁")
                {
                    ep.Examine = "3";
                    ep = await this.ExchangePersonRepository.AddAsync(ep);
                    //更新兑换表
                    var ex = await this.ExchangeRepository.FindAsync(e => e.Id == model.ExId);
                    ex.Examine = "4";  //修改为已兑换
                    ex.ExchangePerson = model.UserId.ToString();
                    b = await this.ExchangeRepository.UpdateAsync(ex);
                    //更新会员表
                    var member = await this.MemberRepository.FindAsync(m => m.Id == model.UserId);
                    member.Deposit += model.Deposit;
                    b = await this.MemberRepository.UpdateAsync(member);
                }
                if (model.Examine == "兑换券")
                {
                    ep.Examine = "4";
                    ep = await this.ExchangePersonRepository.AddAsync(ep);
                    //更新兑换表
                    var ex = await this.ExchangeRepository.FindAsync(e => e.Id == model.ExId);
                    ex.Examine = "4";  //修改为已兑换
                    ex.ExchangePerson = model.UserId.ToString();
                    b = await this.ExchangeRepository.UpdateAsync(ex);
                    //更新会员表
                    var member = await this.MemberRepository.FindAsync(m => m.Id == model.UserId);
                    member.Deposit += model.Deposit;
                    b = await this.MemberRepository.UpdateAsync(member);
                    //更新兑换码表
                    var voucher = await this.VoucherRepository.FindAsync(m => m.Id == model.VouId);
                    voucher.State = 3;
                    b = await this.VoucherRepository.UpdateAsync(voucher);
                }
                model.Status = 1;
                b = await this.ExchangeEventRepository.UpdateAsync(model);

                ts.Commit();

                
            }
            RongCloudHelper.PublishSystemBySystem(model.UserId.ToString(), "兑换成功，请查看");
            return b;
        }
    }
}