using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Interfaces;
using Com.Cos.Repository;
using Microsoft.EntityFrameworkCore;

namespace Com.Cos.Application
{
    /// <summary>
    /// 兑换分类表业务
    /// </summary>
    public class ExchangeClassService : BaseService<ExchangeClass>, IExchangeClassService
    {
        public ExchangeClassService(CosDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// 获得分类列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<ExchangeClassDto>> FindListAsync()
        {
            List<ExchangeClassDto> dtoList = new List<ExchangeClassDto>();
            var model = await this.ExchangeClassRepository.FindList(e => e.Status > 0).ToListAsync();
            foreach (ExchangeClass ec in model)
            {
                dtoList.Add(new ExchangeClassDto()
                {
                    Id = ec.ClassId,
                    ClassName = ec.ClassName,
                    ClassUsName = ec.ClassUsName
                });
            }
            return dtoList;
        }
    }
}