using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.WebApi.Models.CooperationReplyViewModels;
using Com.Cos.WebApi.Models.ExchangeReplyViewModels;
using Com.Cos.WebApi.ResultModels;
using Com.Cos.WebApi.ResultModels.CooperationReplyResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Com.Cos.WebApi.Controllers
{
    /// <summary>
    /// 合作评论控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/CooperationReplies")]
    public class CooperationReplyController : Controller
    {
        private readonly ICooperationReplyService _cooperationReplyService;

        public CooperationReplyController(ICooperationReplyService cooperationReplyService)
        {
            _cooperationReplyService = cooperationReplyService;
        }
        /// <summary>
        /// 获得合作评论列表
        /// </summary>
        /// <param name="coId">合作Id</param>
        /// <param name="userId">登录用户id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数据数</param>
        /// <returns></returns>
        // GET /api/CooperationReplies?coid=1&pageIndex=1&pageSize=4
        [AcceptVerbs("GET"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Get(int coId, int userId, int pageIndex, int pageSize)
        {
            MessageBase2 result = new MessageBase2();

            var v = await _cooperationReplyService.FindListAsync(coId, userId, pageIndex, pageSize);

            var page = ConvertHelper.ChangeType<MessagePageBase2>(v.pageDto);
            List<CooperationReplyResultModel> erList = new List<CooperationReplyResultModel>();
            v.dtoList.ForEach(p => { erList.Add(ConvertHelper.ChangeType<CooperationReplyResultModel>(p)); });
            page.Data = erList;

            result.Data = page;
            return result;
        }
        /// <summary>
        /// 评论
        /// </summary>
        /// <param name="coId">评论id</param>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST /api/CooperationReplies/1
        [HttpPost("{coId:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Post(int coId, [FromBody]CooperationReplyViewModel model)
        {
            MessageBase2 result = new MessageBase2();

            CooperationReplyDto dto = new CooperationReplyDto()
            {
                CoId = coId,
                UserId = model.UserId,
                Text = model.Text,
                ParentId = model.ParentId
            };
            await _cooperationReplyService.AddAsync(dto);


            return result;
        }
        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="id">评论id</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        // PUT /api/CooperationReplies/1?userid=30
        [HttpPut("{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Put(int id, int userId)
        {
            MessageBase2 result = new MessageBase2();
            await _cooperationReplyService.LikeAsync(id, userId);
            return result;
        }
    }
}