using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 快捷导航表业务接口
    /// </summary>
    public interface IQuickNavigationService : IBaseService<QuickNavigation>
    {
        Task<QuickNavigationDto> FindAsync(int id);

        /// <summary>
        /// 获得列表
        /// </summary>
        /// <returns></returns>
        List<QuickNavigationDto> FindList();

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool Update(QuickNavigationDto dto);
    }
}