using Com.Cos.Application;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.WebApi.Models.CooperationViewModels;
using Com.Cos.WebApi.Result.ImgResult;
using Com.Cos.WebApi.ResultModels;
using Com.Cos.WebApi.ResultModels.CooperationResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.WebApi.Models.ExchangeViewModels;
using Com.Cos.WebApi.Filter;

namespace Com.Cos.WebApi.Controllers
{
    /// <summary>
    /// 合作控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/Cooperations")]
    public class CooperationController : Controller
    {
        private readonly ICooperationService _cooperationService;

        public CooperationController(ICooperationService cooperationService)
        {
            _cooperationService = cooperationService;
        }
        /// <summary>
        /// 发布合作
        /// </summary>
        /// <param name="model"></param>
        // POST: api/Cooperations
        [HttpPost, MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Post([FromBody]CooperationViewModel model)
        {
            MessageBase2 result = new MessageBase2();

            CooperationDto dto = ConvertHelper.ChangeType<CooperationDto>(model);
            await _cooperationService.AddAsync(dto);

            return result;
        }

        /// <summary>
        /// 分页取出数据
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数量</param>
        /// <param name="sea">搜索关键词</param>
        /// <param name="cid">分类id</param>
        /// <param name="city">市</param>
        /// <returns></returns>
        // GET: api/Cooperations?pageIndex=1&pageSize=4
        [HttpGet, MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Get(int pageIndex, int pageSize, string sea, int cid, string city)
        {
            MessageBase2 result = new MessageBase2();

            var v = await _cooperationService.FindListAsync(pageIndex, pageSize, 0, cid, city);
            var cr = new List<CooperationResultModel>();
            v.dtoList.ForEach(p => { cr.Add(ConvertHelper.ChangeType<CooperationResultModel>(p)); });

            var page = ConvertHelper.ChangeType<MessagePageBase2>(v.pageDto);
            page.Data = cr;

            result.Data = page;

            return result;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="userId">查看该兑换的会员id</param>
        // Get: api/Cooperations/2?userId=30
        [HttpGet("{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Get(int id, int userId)
        {
            await _cooperationService.ClickAsync(id);
            MessageBase2 result = new MessageBase2();

            var dto = await _cooperationService.FindAsync(id, userId);
            var cd = ConvertHelper.ChangeType<CooperationDetailResultModel>(dto);
            cd.ShareURL = "http://www.52cos.cn/Coo/Detail/" + cd.Id;
            cd.ImgList = new List<ExchangeImgResultModel>();
            dto.ImgDtoList.ForEach(i =>
            {
                cd.ImgList.Add(ConvertHelper.ChangeType<ExchangeImgResultModel>(i));
            });

            result.Data = cd;

            return result;
        }
        /// <summary>
        /// 关注合作
        /// </summary>
        /// <param name="id">合作id</param>
        /// <param name="model"></param>
        // PUT: api/Cooperations/1
        [HttpPut("{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Put(int id, [FromBody]ExchangeLikeViewModel model)
        {
            MessageBase2 result = new MessageBase2();

            if (! await this._cooperationService.LikeAsync(id, model.UserId))
            {
                result.Success = Permanent.FAILED;
                result.Error = (int)StatusCodeEnum.FORBIDDEN;
                result.ErrorMsg = "已到达参与上线";
            }

            return result;
        }

        /// <summary>
        /// 删除合作
        /// </summary>
        /// <param name="id">合作id</param>
        /// <returns></returns>
        // DELETE: api/Cooperations/2
        [HttpDelete("{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Delete(int id)
        {
            MessageBase2 result = new MessageBase2();
            await _cooperationService.DeleteAsync(id);
            return result;
        }
        /// <summary>
        /// 修改合作
        /// </summary>
        /// <param name="id">合作id</param>
        /// <param name="model"></param>
        /// <returns></returns>
        // PUT: api/Cooperations/Update/2
        [HttpPut, Route("Update/{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> PutUpdate(int id, [FromBody]CooperationViewModel model)
        {
            MessageBase2 result = new MessageBase2();

            CooperationDto dto = ConvertHelper.ChangeType<CooperationDto>(model);
            await _cooperationService.UpdateAsync(id, dto);

            return result;
        }
    }
}