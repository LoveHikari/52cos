using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;
using System;
using System.Threading.Tasks;

namespace Com.Cos.Application
{
    /// <summary>
    /// 腾讯对象存储文件信息表业务
    /// </summary>
    public class CosFileStatService:BaseService<CosFileStat>,ICosFileStatService
    {
        public CosFileStatService(CosDbContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task AddAsync(CosFileStatDto dto)
        {
            var model = new CosFileStat()
            {
                AccessUrl = dto.AccessUrl,
                ResourcePath = dto.ResourcePath,
                SourceUrl = dto.SourceUrl,
                Url = dto.Url,
                AddTime = DateTime.Now,
                Status = 1
            };
             await this.CosFileStatRepository.AddAsync(model);
        }
    }
}