using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 退款记录表业务接口
    /// </summary>
    public interface IRefundService:IBaseService<Refund>
    {
        /// <summary>
        /// 添加退款订单
        /// </summary>
        /// <param name="userId">用户id</param>
        Task AddAsync(int userId);

        /// <summary>
        /// 获得退款列表
        /// </summary>
        /// <returns></returns>
        List<RefundDto> FindList();

        /// <summary>
        /// 获得退款信息
        /// </summary>
        /// <param name="id">退款id</param>
        /// <returns></returns>
        RefundDto Find(int id);

        /// <summary>
        /// 修改押金
        /// </summary>
        /// <param name="id">退款id</param>
        /// <returns>修改成功返回true</returns>
        bool UpdateDeposit(int id);
    }
}