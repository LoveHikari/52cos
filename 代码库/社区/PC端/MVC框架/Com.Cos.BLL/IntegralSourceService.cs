using Com.Cos.DAL;
using Com.Cos.IBLL;
using Com.Cos.IDAL;
using Com.Cos.Models;

namespace Com.Cos.BLL
{
    /// <summary>
    /// 积分来源业务层
    /// </summary>
    public class IntegralSourceService:BaseService<IntegralSource>,IIntegralSourceService
    {
        public IntegralSourceService() : base(RepositoryFactory.IntegralSourceRepository)
        {
        }
    }
}