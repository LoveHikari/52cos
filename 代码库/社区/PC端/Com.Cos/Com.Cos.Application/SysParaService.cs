using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Com.Cos.Application
{
    /// <summary>
    /// 系统配置对应表业务
    /// </summary>
    public class SysParaService : BaseService<SysPara>, ISysParaService
    {
        public SysParaService(CosDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<string> GetTextAsync(string type, string value)
        {
            return (await this.SysParaRepository.FindAsync(para => para.RefType == type && para.RefValue == value)).RefText;
        }

        public async Task<List<SysParaDto>> FindListAsync(string type)
        {
            var modelList = await this.SysParaRepository.FindList(para => para.RefType == type).ToListAsync();
            List<SysParaDto> dtos = new List<SysParaDto>();
            foreach (SysPara para in modelList)
            {
                dtos.Add(new SysParaDto()
                {
                    Text = para.RefText,
                    Value = para.RefValue
                });
            }
            return dtos;
        }
    }
}