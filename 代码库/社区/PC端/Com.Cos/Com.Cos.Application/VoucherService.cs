using System;
using System.Collections.Generic;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Microsoft.EntityFrameworkCore;

namespace Com.Cos.Application
{
    /// <summary>
    /// 兑换码表业务
    /// </summary>
    public class VoucherService:BaseService<Voucher>, IVoucherService
    {
        public VoucherService(CosDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// 兑换
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="code">兑换码</param>
        public async Task ExchangeAsync(int userId,string code)
        {
            var model = await this.VoucherRepository.FindAsync(v=> String.Equals(v.Code, code, StringComparison.CurrentCultureIgnoreCase));
            model.UserId = userId;
            model.State = 1;
            model.StartTime2 = DateTime.Now;
            model.EndTime2 = ("23:59:59").ToDateTime();
            await this.VoucherRepository.UpdateAsync(model);
        }
        /// <summary>
        /// 是否存在可用的
        /// </summary>
        /// <param name="code">兑换码</param>
        /// <returns></returns>
        public async Task<bool> ExistAsync(string code)
        {
            return await this.VoucherRepository.ExistAsync(v=>String.Equals(v.Code, code, StringComparison.CurrentCultureIgnoreCase) && v.UserId == null && v.State == 0);
        }

        /// <summary>
        /// 是否存在可用的
        /// </summary>
        /// <param name="voucherId">兑换码</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public async Task<bool> ExistAsync(int voucherId, int userId)
        {
            return await this.VoucherRepository.ExistAsync(v => v.Id==voucherId && v.UserId == userId && v.State == 1 && DateTime.Now>=v.StartTime2 && DateTime.Now<=v.EndTime2);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数据数</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public async Task<(PageDto pageDto, List<VoucherDto> dto)> FindListAsync(int pageIndex, int pageSize, int userId)
        {
            var v = from vo in this.DbContext.Vouchers
                where vo.UserId == userId
                orderby vo.EndTime2 ascending 
                select new VoucherDto()
                {
                    Id = vo.Id,
                    Title = vo.Title,
                    Description = vo.Description,
                    EndTime = vo.EndTime2.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss"),
                    IsValid = DateTime.Now>=vo.StartTime2 && DateTime.Now<=vo.EndTime2
                };

            int totalRecord = await v.CountAsync();
            int pageCount = Convert.ToInt32(Math.Ceiling(totalRecord / Convert.ToDouble(pageSize)));
            int prevPage = pageIndex > 0 ? pageIndex - 1 : 0;
            int nextPage = pageIndex < pageCount ? pageIndex + 1 : 0;

            var exList = await v.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

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



        //public void Add()
        //{

        //    Random random = new Random();
        //    for (int i = 0; i < 100; i++)
        //    {
        //        int ms = DateTime.Now.Millisecond;

        //        long i1 = DateTime.Now.ToString("20171001HHmmss").ToLong() * (ms << 1) + (ms << 1) * (ms >> 1);

        //        string i2 = random.RandomNumber(4);

        //        string s = "nb" + i1 + i2;


        //        Voucher model = new Voucher()
        //        {
        //            Code = "nb" + s.SubRight(16),
        //            Title = "兑换优惠券",
        //            Description = "免费租赁一次",
        //            Scenes = "10月1日宁波活动券",
        //            StartTime = "2017.10.01 08:00:00".ToDateTime(),
        //            EndTime = "2017.10.01 23:59:59".ToDateTime(),
        //            State = 0,
        //            AddTime = DateTime.Now,
        //            Status = 1

        //        };
        //        this.VoucherRepository.Add(model);
        //    }

        //}


    }
}