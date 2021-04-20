using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 充值记录表业务接口
    /// </summary>
    public interface IRechargeRecordService:IBaseService<RechargeRecord>
    {
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<int> AddAsync(RechargeRecordDto dto);

        /// <summary>
        /// 处理订单
        /// </summary>
        /// <param name="id"></param>
        Task DealWithAsync(int id);
    }
}