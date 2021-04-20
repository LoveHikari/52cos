using System;
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
    /// 热门搜索表业务
    /// </summary>
    public class HotSearchService : BaseService<HotSearch>, IHotSearchService
    {
        private readonly IHotSearchRepository _hotSearchRepository;
        public HotSearchService(CosDbContext dbContext) : base(dbContext)
        {
            _hotSearchRepository = RepositoryFactory.CreateObj<HotSearchRepository>(dbContext);
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<HotSearchDto>> GetListAsync()
        {
            var v = await _hotSearchRepository.FindList(h => h.Status > 0 && h.RefType == 0, "Num", false).Take(12).ToListAsync();

            List<HotSearchDto> dtos = new List<HotSearchDto>();
            foreach (HotSearch search in v)
            {
                dtos.Add(new HotSearchDto()
                {
                    RefValue = search.RefValue
                });
            }
            return dtos;
        }
        /// <summary>
        /// 添加关键词
        /// </summary>
        /// <param name="value"></param>
        /// <returns>是否添加成功</returns>
        public async Task<bool> AddAsync(string value)
        {
            //如果不存在则添加，如果存在则数量加1
            var model = await _hotSearchRepository.FindAsync(h => h.RefValue == value && h.RefType == 0);
            bool b;
            if (model == null)
            {
                model = new HotSearch()
                {
                    AddTime = DateTime.Now,
                    Num = 1,
                    RefType = 0,
                    RefValue = value,
                    Status = 1
                };
                b = _hotSearchRepository.AddAsync(model).Id>0;
            }
            else
            {
                model.Num++;
                b = await _hotSearchRepository.UpdateAsync(model);
            }
            return b;
        }
    }
}