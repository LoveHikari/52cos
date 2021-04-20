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

namespace Com.Cos.Application
{
    /// <summary>
    /// 快捷导航表业务
    /// </summary>
    public class QuickNavigationService : BaseService<QuickNavigation>, IQuickNavigationService
    {
        public QuickNavigationService(CosDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<QuickNavigationDto> FindAsync(int id)
        {
            var model = await this.QuickNavigationRepository.FindAsync(p => p.Id == id);
            QuickNavigationDto dto = new QuickNavigationDto()
            {
                Id = model.Id,
                Title = model.Title,
                SmallTitle = model.SmallTitle,
                Cont = model.Cont,
                Link = model.Link,
                AddTime = model.AddTime
            };
            return dto;
        }
        /// <summary>
        /// 获得列表
        /// </summary>
        /// <returns></returns>
        public List<QuickNavigationDto> FindList()
        {
            var modelList = this.QuickNavigationRepository.FindList().ToList();
            List<QuickNavigationDto> dtoList = new List<QuickNavigationDto>();
            modelList.ForEach(q => dtoList.Add(new QuickNavigationDto()
            {
                Id = q.Id,
                Title = q.Title,
                AddTime = q.AddTime
            }));

            return dtoList;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool Update(QuickNavigationDto dto)
        {
            var model = this.QuickNavigationRepository.Find(q => q.Id == dto.Id);
            model.Cont = dto.Cont;
            model.Link = dto.Link;
            model.SmallTitle = dto.SmallTitle;
            model.Title = dto.Title;

            return this.QuickNavigationRepository.Update(model);
        }
    }
}