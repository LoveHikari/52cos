using Com.Cos.DAL;
using Com.Cos.IBLL;
using Com.Cos.IDAL;
using Com.Cos.Models;

namespace Com.Cos.BLL
{
    /// <summary>
    /// 支付宝充值交易记录业务
    /// </summary>
    public class TransactionsService:BaseService<Transactions>,ITransactionsService
    {
        public TransactionsService() : base(RepositoryFactory.TransactionsRepository)
        {
        }
    }
}