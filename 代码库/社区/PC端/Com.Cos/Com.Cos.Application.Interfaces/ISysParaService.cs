using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 系统配置对应表业务接口
    /// </summary>
    public interface ISysParaService:IBaseService<SysPara>
    {
        Task<string> GetTextAsync(string type, string value);
        Task<List<SysParaDto>> FindListAsync(string type);
    }
}