using Com.Cos.DAL;
using Com.Cos.IBLL;
using Com.Cos.IDAL;
using Com.Cos.Models;

namespace Com.Cos.BLL
{
    /// <summary>
    /// 积分变更记录业务
    /// </summary>
    public class IntegralChangeService:BaseService<IntegralChange>,IIntegralChangeService
    {
        public IntegralChangeService() : base(RepositoryFactory.IntegralChangeRepository)
        {
        }
    }
}