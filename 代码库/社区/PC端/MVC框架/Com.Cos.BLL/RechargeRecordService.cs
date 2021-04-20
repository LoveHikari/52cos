using Com.Cos.DAL;
using Com.Cos.IBLL;
using Com.Cos.IDAL;
using Com.Cos.Models;

namespace Com.Cos.BLL
{
    /// <summary>
    /// 充值记录业务层
    /// </summary>
    public class RechargeRecordService : BaseService<RechargeRecord>,IRechargeRecordService
    {
        public RechargeRecordService() : base(RepositoryFactory.RechargeRecordRepository)
        {
        }
    }
}