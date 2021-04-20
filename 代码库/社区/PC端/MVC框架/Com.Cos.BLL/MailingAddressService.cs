using System.Linq;
using Com.Cos.DAL;
using Com.Cos.IBLL;
using Com.Cos.IDAL;
using Com.Cos.Models;

namespace Com.Cos.BLL
{
    /// <summary>
    /// 通讯地址业务
    /// </summary>
    public class MailingAddressService:BaseService<MailingAddress>, IMailingAddressService
    {
        public MailingAddressService() : base(RepositoryFactory.MailingAddressRepository)
        {
        }

        /// <summary>
        /// 获得地址列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IQueryable<MailingAddress> FindList(int userId)
        {
            return CurrentRepository.FindList(m => m.UserId == userId.ToString());
        }
    }
}