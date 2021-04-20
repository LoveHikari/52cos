using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.WebApi.Models.ExchangeReplyViewModels;
using Com.Cos.WebApi.ResultModels;
using Com.Cos.WebApi.ResultModels.ExchangeReplyResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Com.Cos.WebApi.Controllers
{
    /// <summary>
    /// 兑换评论控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/ExchangeReplies")]
    public class ExchangeReplyController : Controller
    {
        private readonly IExchangeReplyService _exchangeReplyService;

        public ExchangeReplyController(IExchangeReplyService exchangeReplyService)
        {
            _exchangeReplyService = exchangeReplyService;
        }
        /// <summary>
        /// 获得兑换评论列表
        /// </summary>
        /// <param name="exId">兑换Id</param>
        /// <param name="userId">登录用户id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数据数</param>
        /// <returns></returns>
        // GET /api/ExchangeReplies?exid=1&pageIndex=1&pageSize=4
        [AcceptVerbs("GET"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Get(int exId, int userId, int pageIndex, int pageSize)
        {
            MessageBase2 result = new MessageBase2();


            var v = await _exchangeReplyService.FindListAsync(exId, userId, pageIndex, pageSize);
            var page = ConvertHelper.ChangeType<MessagePageBase>(v.pageDto);

            List<ExchangeReplyResultModel> erList = new List<ExchangeReplyResultModel>();
            v.dtoList.ForEach(p => { erList.Add(ConvertHelper.ChangeType<ExchangeReplyResultModel>(p)); });
            page.Data = erList;

            result.Data = page;
            return result;
        }
        /// <summary>
        /// 评论
        /// </summary>
        /// <param name="exId">兑换id</param>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST /api/ExchangeReplies/1
        [HttpPost("{exId:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Post(int exId, [FromBody]ExchangeReplyViewModel model)
        {
            MessageBase2 result = new MessageBase2();

            ExchangeReplyDto dto = new ExchangeReplyDto()
            {
                ExId = exId,
                UserId = model.UserId,
                Text = model.Text,
                ParentId = model.ParentId
            };
            await _exchangeReplyService.AddAsync(dto);


            return result;
        }
        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="id">评论id</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        // PUT /api/ExchangeReplies/1?userid=30
        [HttpPut("{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Put(int id, int userId)
        {
            MessageBase2 result = new MessageBase2();
            await _exchangeReplyService.LikeAsync(id, userId);
            return result;
        }
    }
}