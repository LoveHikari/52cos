using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 兑换事件表业务接口
    /// </summary>
    public interface IExchangeEventService:IBaseService<ExchangeEvent>
    {
        Task<int> AddAsync(ExchangeEventDto dto);

        /// <summary>
        /// 处理订单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentWay">付款方式</param>
        /// <returns></returns>
        Task<bool> DealWithAsync(int id, string paymentWay);
    }
}