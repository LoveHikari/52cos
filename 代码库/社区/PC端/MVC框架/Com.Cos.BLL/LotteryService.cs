using Com.Cos.DAL;
using Com.Cos.IBLL;
using Com.Cos.IDAL;
using Com.Cos.Models;

namespace Com.Cos.BLL
{
    /// <summary>
    /// 抽奖活动参与业务
    /// </summary>
    public class LotteryService : BaseService<Lottery>, ILotteryService
    {
        public LotteryService() : base(RepositoryFactory.LotteryRepository)
        {
        }
    }
}