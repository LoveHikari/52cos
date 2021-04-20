using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    public interface IExchangeExamineService:IBaseService<ExchangeExamine>
    {
        /// <summary>
        /// 获得分类列表
        /// </summary>
        /// <returns></returns>
        Task<List<ExchangeExamineDto>> FindListAsync();
    }
}