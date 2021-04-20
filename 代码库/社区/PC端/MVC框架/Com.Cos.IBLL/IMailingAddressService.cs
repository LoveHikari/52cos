using System.Linq;
using Com.Cos.Models;

namespace Com.Cos.IBLL
{
    /// <summary>
    /// 通讯地址业务接口
    /// </summary>
    public interface IMailingAddressService:IBaseService<MailingAddress>
    {
        /// <summary>
        /// 获得地址列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IQueryable<MailingAddress> FindList(int userId);
    }
}