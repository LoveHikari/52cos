using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application.Interfaces;
using Com.Cos.WebApi.ResultModels;
using Com.Cos.WebApi.ResultModels.SysParaResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Com.Cos.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/SysParas")]
    public class SysParaController : Controller
    {
        private readonly ISysParaService _sysParaService;
        public SysParaController(ISysParaService sysParaService)
        {
            _sysParaService = sysParaService;
        }
        /// <summary>
        /// 获得尺码列表
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("Size"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> GetSize()
        {
            MessageBase2 result = new MessageBase2();
            var dtos =await _sysParaService.FindListAsync("size");
            List<SysParaResultModel> models = new List<SysParaResultModel>();
            dtos.ForEach(dto => models.Add(ConvertHelper.ChangeType<SysParaResultModel>(dto)));
            result.Data = models;

            return result;
        }
    }
}