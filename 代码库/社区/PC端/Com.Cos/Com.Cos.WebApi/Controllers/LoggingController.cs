using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.WebApi.Models.LoggingViewModels;
using Com.Cos.WebApi.ResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Com.Cos.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/Loggings")]
    public class LoggingController : Controller
    {
        private readonly ILoggingService _loggingService;
        public LoggingController(ILoggingService loggingService)
        {
            this._loggingService = loggingService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST /api/Loggings
        [AcceptVerbs("POST"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Post([FromBody]LoggingViewModel model)
        {
            MessageBase2 result = new MessageBase2();
            LoggingDto dto = ConvertHelper.ChangeType<LoggingDto>(model);
            await _loggingService.AddAsync(dto);

            return result;
        }
    }
}