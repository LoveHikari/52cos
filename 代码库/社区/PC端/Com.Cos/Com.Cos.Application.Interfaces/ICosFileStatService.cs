using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;


namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 腾讯对象存储文件信息表业务接口
    /// </summary>
    public interface ICosFileStatService:IBaseService<CosFileStat>
    {
        Task AddAsync(CosFileStatDto dto);
    }
}