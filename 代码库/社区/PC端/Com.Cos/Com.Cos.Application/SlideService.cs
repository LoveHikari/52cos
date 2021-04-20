using System.Collection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Interfaces;
using Com.Cos.Repository;
using Microsoft.EntityFrameworkCore;

namespace Com.Cos.Application
{
    /// <summary>
    /// 首页幻灯片业务
    /// </summary>
    public class SlideService: BaseService<Slide>, ISlideService
    {
        private readonly ISlideRepository _slideRepository;
        public SlideService(CosDbContext dbContext) : base(dbContext)
        {
            _slideRepository = RepositoryFactory.CreateObj<SlideRepository>(dbContext);
        }
        /// <summary>
        /// 获得前3个轮播图
        /// </summary>
        /// <returns></returns>
        public async Task<List<SlideDto>> FindListAsync()
        {
            var slideList = await _slideRepository.FindList(p => p.Sign == 1 && p.Status == 1).OrderBy(p => p.Weight).ThenByDescending(p=>p.AddTime).Take(3).ToListAsync();
            return slideList.ToList<SlideDto>();
        }
    }
}