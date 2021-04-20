using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 兑换分类表业务接口
    /// </summary>
    public interface IExchangeClassService:IBaseService<ExchangeClass>
    {
        /// <summary>
        /// 获得分类列表
        /// </summary>
        /// <returns></returns>
        Task<List<ExchangeClassDto>> FindListAsync();
    }
}