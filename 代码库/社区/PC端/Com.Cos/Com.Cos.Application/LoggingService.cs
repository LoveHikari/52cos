using System;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;

namespace Com.Cos.Application
{
    /// <summary>
    /// 日志记录表业务
    /// </summary>
    public class LoggingService:BaseService<Logging>, ILoggingService
    {
        public LoggingService(CosDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddAsync(LoggingDto dto)
        {
            var model = ConvertHelper.ChangeType<Logging>(dto);
            model.AddTime = DateTime.Now;
            model.Status = 1;
            await this.LoggingRepository.AddAsync(model);
        }
    }
}