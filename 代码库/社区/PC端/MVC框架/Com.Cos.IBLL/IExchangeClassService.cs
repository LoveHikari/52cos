using System;
using System.Linq;
using System.Linq.Expressions;
using Com.Cos.Models;

namespace Com.Cos.IBLL
{
    public interface IExchangeClassService:IBaseService<ExchangeClass>
    {
        /// <summary>
        /// 根据classUsName获得实体
        /// </summary>
        /// <param name="classUsName"></param>
        /// <returns></returns>
        ExchangeClass Find(string classUsName);
        /// <summary>
        /// 根据classId获得实体
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        ExchangeClass Find(int classId);
    }
}