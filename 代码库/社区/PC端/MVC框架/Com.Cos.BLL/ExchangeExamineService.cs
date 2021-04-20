using System.Linq;
using Com.Cos.DAL;
using Com.Cos.IBLL;
using Com.Cos.IDAL;
using Com.Cos.Models;

namespace Com.Cos.BLL
{
    /// <summary>
    /// 兑换状态业务类
    /// </summary>
    public class ExchangeExamineService:BaseService<ExchangeExamine>, IExchangeExamineService
    {
        public ExchangeExamineService() : base(RepositoryFactory.ExchangeExamineRepository)
        {
        }

        /// <summary>
        /// 根据examineUsName获得实体
        /// </summary>
        /// <param name="examineUsName"></param>
        /// <returns></returns>
        public ExchangeExamine Find(string examineUsName)
        {
            return CurrentRepository.Find(e => e.ExamineUsName == examineUsName);
        }
        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <returns></returns>
        public override IQueryable<ExchangeExamine> FindList()
        {
            return CurrentRepository.FindList(ex => ex.Status > 0, "id", false);
        }
        /// <summary>
        /// 根据examineId获得实体
        /// </summary>
        /// <param name="examineId"></param>
        /// <returns></returns>
        public ExchangeExamine Find(int examineId)
        {
            return CurrentRepository.Find(e => e.ExamineId == examineId.ToString());
        }
    }
}