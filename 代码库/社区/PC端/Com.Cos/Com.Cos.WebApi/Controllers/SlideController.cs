using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.WebApi.ResultModels.SlideResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Com.Cos.WebApi.Controllers
{
    /// <summary>
    /// 首页幻灯片控制器
    /// </summary>
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/Slides")]
    public class SlideController : Controller
    {
        private readonly ISlideService _slideService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public SlideController(CosDbContext dbContext)
        {
            _slideService = new SlideService(dbContext);
        }
        /// <summary>
        /// 获得首页轮播图
        /// </summary>
        /// <returns></returns>
        // GET: api/Slides
        [HttpGet, MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Get()
        {
            SlideResult result = new SlideResult();
            result.List = new List<SlideResultModel>();
            (await _slideService.FindListAsync()).ForEach(p=> { result.List.Add(ConvertHelper.ChangeType<SlideResultModel>(p)); });

            return result;
        }
    }
}
