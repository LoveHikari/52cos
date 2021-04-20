using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 物流信息表业务接口
    /// </summary>
    public interface ILogisticService : IBaseService<Logistic>
    {
        /// <summary>
        /// 添加物流信息
        /// </summary>
        /// <param name="dto"></param>
        Task AddAsync(LogisticDto dto);
        /// <summary>
        /// 获得物流信息列表
        /// </summary>
        /// <param name="logisticCode">物流单号</param>
        /// <returns></returns>
        List<LogisticDto> FindList(string logisticCode);
    }
}