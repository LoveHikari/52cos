using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 合作分类表业务接口
    /// </summary>
    public interface ICooperationClassService:IBaseService<CooperationClass>
    {
        /// <summary>
        /// 获得分类列表
        /// </summary>
        /// <returns></returns>
        Task<List<ExchangeClassDto>> FindListAsync();
    }
}