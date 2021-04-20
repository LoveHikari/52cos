using System.Threading.Tasks;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 邮费表业务接口
    /// </summary>
    public interface IPostageService:IBaseService<Postage>
    {
        /// <summary>
        /// 获得邮费
        /// </summary>
        /// <returns></returns>
        Task<int> GetPostageAsync();
    }
}