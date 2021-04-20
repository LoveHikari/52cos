using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 积分变更记录表业务接口
    /// </summary>
    public interface IIntegralChangeService:IBaseService<IntegralChange>
    {
        /// <summary>
        /// 兑换回收成功时
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="value">身家值</param>
        void AddExchange(int userId, string value);
    }
}