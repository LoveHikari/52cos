using System.Linq;
using Com.Cos.DAL;
using Com.Cos.IBLL;
using Com.Cos.IDAL;
using Com.Cos.Models;

namespace Com.Cos.BLL
{
    public class ExchangeClassService:BaseService<ExchangeClass>, IExchangeClassService
    {
        public ExchangeClassService() : base(RepositoryFactory.ExchangeClassRepository)
        {
        }

        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <returns></returns>
        public override IQueryable<ExchangeClass> FindList()
        {
            return CurrentRepository.FindList( ex => ex.Status > 0,  "id", false);
        }
        /// <summary>
        /// 根据classUsName获得实体
        /// </summary>
        /// <param name="classUsName"></param>
        /// <returns></returns>
        public ExchangeClass Find(string classUsName)
        {
            return CurrentRepository.Find(e => e.ClassUsName == classUsName);
        }
        /// <summary>
        /// 根据classId获得实体
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public ExchangeClass Find(int classId)
        {
            return CurrentRepository.Find(e => e.ClassId == classId);
        }
    }
}