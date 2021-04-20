using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 热门搜索表业务接口
    /// </summary>
    public interface IHotSearchService : IBaseService<HotSearch>
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        Task<List<HotSearchDto>> GetListAsync();
        /// <summary>
        /// 添加关键词
        /// </summary>
        /// <param name="value"></param>
        /// <returns>是否添加成功</returns>
        Task<bool> AddAsync(string value);
    }
}