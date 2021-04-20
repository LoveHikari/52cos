using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.WebApi.Result.ExchangeExamineResult;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Com.Cos.WebApi.Controllers
{
    /// <summary>
    /// 兑换状态控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/ExchangeExamines")]
    public class ExchangeExamineController : Controller
    {
        private readonly IExchangeExamineService _exchangeExamineService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public ExchangeExamineController(CosDbContext dbContext)
        {
            _exchangeExamineService = new ExchangeExamineService(dbContext);
        }
        /// <summary>
        /// 获得兑换状态列表
        /// </summary>
        /// <returns></returns>
        // GET /api/ExchangeExamines
        [AcceptVerbs("GET"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Get()
        {
            ExchangeExamineResult result = new ExchangeExamineResult();
            var dtoList = await _exchangeExamineService.FindListAsync();
            result.List = new List<ExchangeExamineResultModel>();
            dtoList.ForEach(d => { result.List.Add(ConvertHelper.ChangeType<ExchangeExamineResultModel>(d)); });
            return result;
        }
    }
}