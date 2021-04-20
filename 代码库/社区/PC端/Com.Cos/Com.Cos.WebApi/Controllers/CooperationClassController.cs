using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application.Interfaces;
using Com.Cos.WebApi.ResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Com.Cos.WebApi.ResultModels.ExchangeClassResultModels;

namespace Com.Cos.WebApi.Controllers
{
    /// <summary>
    /// 合作分类控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/CooperationClasses")]
    public class CooperationClassController : Controller
    {
        private readonly ICooperationClassService _cooperationClassService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cooperationClassService"></param>
        public CooperationClassController(ICooperationClassService cooperationClassService)
        {
            _cooperationClassService = cooperationClassService;
        }
        /// <summary>
        /// 获得合作分类列表
        /// </summary>
        /// <returns></returns>
        // GET /api/CooperationClasses
        [AcceptVerbs("GET"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Get()
        {
            MessageBase2 result = new MessageBase2();

            var dtoList = await _cooperationClassService.FindListAsync();
            var v = new List<ExchangeClassResultModel>();
            dtoList.ForEach(d => { v.Add(ConvertHelper.ChangeType<ExchangeClassResultModel>(d)); });
            result.Data = v;
            return result;
        }
    }
}