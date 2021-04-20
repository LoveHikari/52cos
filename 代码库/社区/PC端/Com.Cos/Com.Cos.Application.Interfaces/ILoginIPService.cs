using System;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 访问记录表业务接口
    /// </summary>
    public interface ILoginIPService:IBaseService<LoginIP>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ip">访问ip</param>
        /// <param name="url">访问的url</param>
        void Add(string ip, string url);

        int GetCount(DateTime? dateTime = null);
    }
}