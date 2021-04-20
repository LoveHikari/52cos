using System.Linq;
using Com.Cos.Models;

namespace Com.Cos.IBLL
{
    /// <summary>
    /// 兑换状态业务接口
    /// </summary>
    public interface IExchangeExamineService:IBaseService<ExchangeExamine>
    {
        /// <summary>
        /// 根据examineUsName获得实体
        /// </summary>
        /// <param name="examineUsName"></param>
        /// <returns></returns>
        ExchangeExamine Find(string examineUsName);
        /// <summary>
        /// 根据examineId获得实体
        /// </summary>
        /// <param name="examineId"></param>
        /// <returns></returns>
        ExchangeExamine Find(int examineId);
    }
}