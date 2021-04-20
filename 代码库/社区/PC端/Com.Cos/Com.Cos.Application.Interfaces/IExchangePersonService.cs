using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 兑换人员表业务接口
    /// </summary>
    public interface IExchangePersonService:IBaseService<ExchangePerson>
    {
        /// <summary>
        /// 获得兑换列表
        /// </summary>
        /// <param name="userId">兑换人员id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数据数</param>
        /// <returns></returns>
        Task<(PageDto pageDto, List<ExchangePersonDto> dto)> FindListAsync(int userId,int pageIndex, int pageSize);
        /// <summary>
        /// 获得全部兑换列表
        /// </summary>
        /// <returns></returns>
        List<ExchangePersonDto> FindList();

        /// <summary>
        /// 修改快递单号
        /// </summary>
        /// <param name="epId"></param>
        /// <param name="logistic">快递单号</param>
        /// <returns></returns>
        bool UpdateLogistic(int epId, string logistic);
        /// <summary>
        /// 修改快递单号
        /// </summary>
        /// <param name="id">我的兑换id</param>
        /// <param name="code">快递单号</param>
        Task UpdateLogisticCodeAsync(int id, string code);
    }
}