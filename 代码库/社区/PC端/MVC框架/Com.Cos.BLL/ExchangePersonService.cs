using System.Transactions;
using Com.Cos.DAL;
using Com.Cos.IBLL;
using Com.Cos.IDAL;
using Com.Cos.Models;

namespace Com.Cos.BLL
{
    /// <summary>
    /// 兑换人员业务
    /// </summary>
    public class ExchangePersonService:BaseService<ExchangePerson>,IExchangePersonService
    {
        public ExchangePersonService() : base(RepositoryFactory.ExchangePersonRepository)
        {
        }

        
    }
}