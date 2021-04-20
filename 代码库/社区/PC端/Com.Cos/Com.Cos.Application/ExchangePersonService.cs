using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Interfaces;
using Com.Cos.Infrastructure.KdGold;
using Microsoft.EntityFrameworkCore;

namespace Com.Cos.Application
{
    /// <summary>
    /// 兑换人员表业务
    /// </summary>
    public class ExchangePersonService : BaseService<ExchangePerson>, IExchangePersonService
    {
        public ExchangePersonService(CosDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// 获得兑换列表
        /// </summary>
        /// <param name="userId">兑换人员id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数据数</param>
        /// <returns></returns>
        public async Task<(PageDto pageDto, List<ExchangePersonDto> dto)> FindListAsync(int userId, int pageIndex, int pageSize)
        {
            /*SELECT ep.SerialNum,ep.LogisticCode,ex.Title,m.nickname,ep.AddTime,i.ImgSmallUrl Cover FROM dbo.sns_exchangePerson ep
            LEFT JOIN dbo.sns_exchange ex ON ex.Id=ep.ExId
            LEFT JOIN dbo.cos_member m ON m.User_id=ep.UserId
            LEFT JOIN dbo.sns_Img i ON i.Id=ex.Cover
            WHERE ep.UserId=30*/
            var v = from ep in this.DbContext.ExchangePersons
                    join ex in this.DbContext.Exchanges on ep.ExId equals ex.Id.ToString() into exi
                    from ex in exi.DefaultIfEmpty()
                    join m in this.DbContext.Members on ep.UserId equals m.Id.ToString() into mi
                    from m in mi.DefaultIfEmpty()
                    join i in this.DbContext.Imgs on ex.Cover equals i.Id.ToString() into ii
                    from i in ii.DefaultIfEmpty()
                    where ep.UserId == userId.ToString()
                    orderby ep.AddTime descending
                    select new ExchangePersonDto
                    {
                        Id = ep.ExId,
                        EpId = ep.Id,
                        SerialNum = ep.SerialNum,
                        LogisticCode = ep.LogisticCode,
                        Title = ex.Title,
                        Nickname = m.Nickname,
                        AddTime = ep.AddTime.ToString("yyyy-MM-dd HH:mm"),
                        Cover = i.ImgSmallUrl,
                        Portrait = m.Portrait,
                        ExamineId = ex.Examine.ToInt32(0)
                    };

            var v2 = from l in this.DbContext.Logistics
                     join sp in this.DbContext.SysParas on new { state = l.State.ToString(), type = "logisticState" } equals new { state = sp.RefValue, type = sp.RefType } into spi
                     from sp in spi.DefaultIfEmpty()
                     select new
                     {
                         AcceptTime = l.AcceptTime,
                         LogisticCode = l.LogisticCode,
                         State = sp.RefText
                     };

            int totalRecord = await v.CountAsync();
            int pageCount = Convert.ToInt32(Math.Ceiling(totalRecord / Convert.ToDouble(pageSize)));
            int prevPage = pageIndex > 0 ? pageIndex - 1 : 0;
            int nextPage = pageIndex < pageCount ? pageIndex + 1 : 0;

            var exList = await v.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            exList.ForEach(ex =>
            {
                ex.State =  v2.Where(l => l.LogisticCode == ex.LogisticCode).OrderByDescending(l => l.AcceptTime).FirstOrDefault()?.State ?? "订单处理中";
            });

            var pageDto = new PageDto()
            {
                TotalRecord = totalRecord,
                PageCount = pageCount,
                NextPage = nextPage,
                PrevPage = prevPage,
                PageSize = pageSize,
                PageIndex = pageIndex
            };


            return (pageDto, exList);
        }
        /// <summary>
        /// 获得全部兑换列表
        /// </summary>
        /// <returns></returns>
        public List<ExchangePersonDto> FindList()
        {
            var v = from ep in this.DbContext.ExchangePersons
                    join ex in this.DbContext.Exchanges on ep.ExId equals ex.Id.ToString() into exi
                    from ex in exi.DefaultIfEmpty()
                    join m in this.DbContext.Members on ep.UserId equals m.Id.ToString() into mi
                    from m in mi.DefaultIfEmpty()
                    join i in this.DbContext.Imgs on ex.Cover equals i.Id.ToString() into ii
                    from i in ii.DefaultIfEmpty()
                    join ma in this.DbContext.MailingAddresses on ep.Address equals ma.Id.ToString() into mai
                    from ma in mai.DefaultIfEmpty()
                    join sp in this.DbContext.SysParas on new { RefType = "ExchangeType", RefValue = ep.Examine } equals new { RefType = sp.RefType, RefValue = sp.RefValue } into spi
                    from sp in spi.DefaultIfEmpty()
                    orderby ep.AddTime descending
                    select new ExchangePersonDto
                    {
                        Id = ep.ExId,
                        EpId = ep.Id,
                        LogisticCode = ep.LogisticCode,
                        Title = ex.Title,
                        UserId = ep.UserId.ToInt32(0),
                        AddTime = ep.AddTime.ToString("yyyy-MM-dd HH:mm"),
                        SerialNum = ep.SerialNum,
                        Address = ma.Province + ma.City + ma.County + ma.Address,
                        ZipCode = ma.ZipCode,
                        Consignee = ma.Name,
                        ConsigneePhone = ma.Phone,
                        Examine = sp.RefText
                    };
            return v.ToList();
        }
        /// <summary>
        /// 修改快递单号
        /// </summary>
        /// <param name="epId"></param>
        /// <param name="logistic">快递单号</param>
        /// <returns></returns>
        public bool UpdateLogistic(int epId, string logistic)
        {
            var model = this.ExchangePersonRepository.Find(ep => ep.Id == epId);
            model.LogisticCode = logistic;
            //提交到快递鸟
            KdGoldCore.OrderTracesSubByJson(logistic);

            return this.ExchangePersonRepository.Update(model);
        }
        /// <summary>
        /// 修改快递单号
        /// </summary>
        /// <param name="id">我的兑换id</param>
        /// <param name="code">快递单号</param>
        public async Task UpdateLogisticCodeAsync(int id, string code)
        {
            ExchangePerson model = await this.ExchangePersonRepository.FindAsync(ex => ex.Id == id);
            Exchange exchange = await this.ExchangeRepository.FindAsync(ex => ex.Id == model.ExId.ToInt32(0));
            exchange.Examine = "6";
            model.LogisticCode2 = code;
            using (var tr = await this.DbContext.Database.BeginTransactionAsync())
            {
                await this.ExchangePersonRepository.UpdateAsync(model);
                await this.ExchangeRepository.UpdateAsync(exchange);
                tr.Commit();
            }
        }
    }
}