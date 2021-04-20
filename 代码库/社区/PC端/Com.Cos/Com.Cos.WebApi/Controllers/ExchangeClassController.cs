using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.WebApi.ResultModels.ExchangeClassResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Com.Cos.WebApi.Controllers
{
    /// <summary>
    /// 兑换分类控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/ExchangeClasses")]
    public class ExchangeClassController : Controller
    {
        private readonly IExchangeClassService _exchangeClassService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public ExchangeClassController(CosDbContext dbContext)
        {
            _exchangeClassService = new ExchangeClassService(dbContext);
        }
        /// <summary>
        /// 获得兑换分类列表
        /// </summary>
        /// <returns></returns>
        // GET /api/ExchangeClasses
        [AcceptVerbs("GET"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Get()
        {
            ExchangeClassResult result = new ExchangeClassResult();
            var dtoList = await _exchangeClassService.FindListAsync();
            result.List = new List<ExchangeClassResultModel>();
            dtoList.ForEach(d => { result.List.Add(ConvertHelper.ChangeType<ExchangeClassResultModel>(d)); });
            return result;
        }
    }
}