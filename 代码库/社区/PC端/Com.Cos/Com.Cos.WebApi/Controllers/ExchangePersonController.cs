using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.KdGold;
using Com.Cos.WebApi.ResultModels;
using Com.Cos.WebApi.ResultModels.ExchangePersonResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Com.Cos.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/ExchangePersons")]
    public class ExchangePersonController : Controller
    {
        private readonly IExchangePersonService _exchangePersonService;
        public ExchangePersonController(IExchangePersonService exchangePersonService)
        {
            _exchangePersonService = exchangePersonService;
        }
        /// <summary>
        /// 获得我的兑换列表
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数据数</param>
        /// <returns></returns>
        // GET /api/ExchangePersons?userId=30&pageIndex=1&pageSize=4
        [AcceptVerbs("Get"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Get(int userId, int pageIndex, int pageSize)
        {
            MessageBase2 result = new MessageBase2();
            
            var v = await _exchangePersonService.FindListAsync(userId,pageIndex, pageSize);

            var page = ConvertHelper.ChangeType<MessagePageBase2>(v.pageDto);
            List<ExchangePersonResultModel> resultModel = new List<ExchangePersonResultModel>();
            v.dto.ForEach(d=>{resultModel.Add(new ExchangePersonResultModel()
            {
                Id = d.Id.ToInt32(),
                AddTime = d.AddTime,
                Cover = d.Cover,
                LogisticCode = d.LogisticCode,
                Nickname = d.Nickname,
                State = d.State,
                Title = d.Title,
                SerialNum = d.SerialNum.SubLeft(16),
                Portrait = d.Portrait,
                ExamineId = d.ExamineId,
                EpId = d.EpId
            });});

            page.Data = resultModel;
            result.Data = page;

            return result;
        }

        /// <summary>
        /// 修改物流单号
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="code">物流单号</param>
        /// <returns></returns>
        [HttpPut, Route("LogisticCode/{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> PutLogisticCode(int id, string code)
        {
            MessageBase2 result = new MessageBase2();
            //if (KdGoldCore.OrderTracesSubByJson(code) == null)
            //{
            //    result.Success = Permanent.FAILED;
            //    result.Error = (int)StatusCodeEnum.UNPROCESABLE_ENTITY;
            //    result.ErrorMsg = "物流单号不正确";
            //}
            //else
            //{
                await this._exchangePersonService.UpdateLogisticCodeAsync(id, code);
            //}
            return result;
        }
    }
}