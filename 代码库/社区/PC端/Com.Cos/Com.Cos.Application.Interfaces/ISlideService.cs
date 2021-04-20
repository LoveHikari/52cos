using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 首页幻灯片业务接口
    /// </summary>
    public interface ISlideService : IBaseService<Slide>
    {
        /// <summary>
        /// 获得前3个轮播图
        /// </summary>
        /// <returns></returns>
        Task<List<SlideDto>> FindListAsync();
    }
}