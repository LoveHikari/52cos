using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.WebApi.ResultModels;
using Com.Cos.WebApi.ResultModels.HotSearchResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Com.Cos.WebApi.Controllers
{
    /// <summary>
    /// 热门搜索表控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/HotSearches")]
    public class HotSearchController : Controller
    {
        private readonly IHotSearchService _hotSearchService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public HotSearchController(CosDbContext dbContext)
        {
            _hotSearchService = new HotSearchService(dbContext);
        }
        /// <summary>
        /// 获得热门搜索关键词
        /// </summary>
        /// <returns></returns>
        // GET /api/HotSearches
        [HttpGet, MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Get()
        {
            HotSearchResult result = new HotSearchResult();
            result.List = new List<string>();
            var v = await _hotSearchService.GetListAsync();
            v?.ForEach(p => { result.List.Add(p.RefValue); });

            return result;
        }
        /// <summary>
        /// 记录关键词
        /// </summary>
        /// <param name="value">关键词</param>
        /// <returns></returns>
        // POST /api/HotSearches/value
        [HttpPost("{value}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Post(string value)
        {
            MessageBase2 result = new MessageBase2();
            await _hotSearchService.AddAsync(value);
            return result;
        }
    }
}