using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 日志记录表业务接口
    /// </summary>
    public interface ILoggingService:IBaseService<Logging>
    {
        Task AddAsync(LoggingDto dto);
    }
}