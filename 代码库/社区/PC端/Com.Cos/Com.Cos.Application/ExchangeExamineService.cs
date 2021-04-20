using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Com.Cos.Application
{
    public class ExchangeExamineService:BaseService<ExchangeExamine>,IExchangeExamineService
    {
        public ExchangeExamineService(CosDbContext nContext) : base(nContext)
        {
        }

        /// <summary>
        /// 获得分类列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<ExchangeExamineDto>> FindListAsync()
        {
            List<ExchangeExamineDto> dtoList = new List<ExchangeExamineDto>();
            var model = await this.ExchangeExamineRepository.FindList(e => e.Status > 0).ToListAsync();
            foreach (ExchangeExamine ec in model)
            {
                dtoList.Add(new ExchangeExamineDto()
                {
                    Id = ec.ExamineId.ToInt32(),
                    ExamineName = ec.ExamineName,
                    ExamineUsName = ec.ExamineUsName
                });
            }
            return dtoList;
        }
    }
}