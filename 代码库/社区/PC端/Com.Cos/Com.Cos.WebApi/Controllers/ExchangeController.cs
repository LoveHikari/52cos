using Com.Cos.Application;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.WebApi.Models.ExchangeViewModels;
using Com.Cos.WebApi.Result.ImgResult;
using Com.Cos.WebApi.ResultModels;
using Com.Cos.WebApi.ResultModels.ExchangeResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Com.Cos.Infrastructure.KdGold;

namespace Com.Cos.WebApi.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// 分享表控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/Exchanges")]
    public class ExchangeController : Controller
    {
        private readonly IExchangeService _exchangeService;
        private readonly IMemberService _memberService;
        private readonly IMailingAddressService _mailingAddressService;
        private readonly IPostageService _postageService;
        /// <summary>
        /// 构造函数
        /// </summary>
        public ExchangeController(IExchangeService exchangeService, IMemberService memberService, IMailingAddressService mailingAddressService, IPostageService postageService)
        {
            _exchangeService = exchangeService;
            _memberService = memberService;
            _mailingAddressService = mailingAddressService;
            _postageService = postageService;
        }

        /// <summary>
        /// 分页取出数据
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数量</param>
        /// <param name="sea">搜索关键词</param>
        /// <param name="cid">分类id</param>
        /// <param name="eid">状态id</param>
        /// <param name="rec">是否推荐</param>
        /// <returns></returns>
        // GET: api/Exchanges?pageIndex=1&pageSize=4&sea=萝莉&cid=1&eid=1
        [HttpGet, MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Get(int pageIndex, int pageSize, string sea, int cid, int eid, bool rec)
        {
            MessageBase2 result = new MessageBase2();

            var v = await _exchangeService.FindListAsync(pageIndex, pageSize, sea, cid, eid, 0, rec);

            var page = ConvertHelper.ChangeType<MessagePageBase2>(v.pageDto);
            var erList = new List<ExchangeResultModel>();
            v.dto.ForEach(p => { erList.Add(ConvertHelper.ChangeType<ExchangeResultModel>(p)); });
            page.Data = erList;

            result.Data = page;
            return result;
        }
        /// <summary>
        /// 发布兑换
        /// </summary>
        /// <param name="model"></param>
        // POST: api/Exchanges
        [HttpPost, MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Post([FromBody]ExchangeViewModel model)
        {
            MessageBase2 result = new MessageBase2();

            ExchangeDto dto = ConvertHelper.ChangeType<ExchangeDto>(model);
            await _exchangeService.AddAsync(dto);

            return result;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="userId">查看该兑换的会员id</param>
        // Get: api/Exchanges/2?userId=30
        [HttpGet("{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Get(int id, int userId)
        {
            await _exchangeService.ClickAsync(id);
            MessageBase2 result = new MessageBase2();

            var dto = await _exchangeService.FindAsync(id, userId);

            var edModel = ConvertHelper.ChangeType<ExchangeDetailResultModel>(dto);
            edModel.ShareURL = "http://www.52cos.cn/Exc/Detail/" + edModel.Id;
            edModel.ImgList = new List<ExchangeImgResultModel>();
            dto.ImgDtoList.ForEach(i =>
            {
                edModel.ImgList.Add(ConvertHelper.ChangeType<ExchangeImgResultModel>(i));
            });
            result.Data = edModel;
            return result;
        }
        /// <summary>
        /// 关注兑换
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="model"></param>
        // PUT: api/Exchanges/1
        [HttpPut("{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Put(int id, [FromBody]ExchangeLikeViewModel model)
        {
            MessageBase2 result = new MessageBase2();

            await _exchangeService.LikeAsync(id, model.UserId);

            return result;
        }
        /// <summary>
        /// 获得确认兑换信息
        /// </summary>
        /// <param name="exId">兑换id</param>
        /// <param name="model"></param>
        /// <returns></returns>
        // GET: api/Exchanges/Confirm/1?userId=30&examine=身家兑换
        [HttpGet, Route("Confirm/{exId:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> GetConfirm(int exId, [FromQuery]ExchangeConfimViewModel model)
        {
            MessageBase2 result = new MessageBase2();
            if ((model.Examine == "会员租赁" || model.Examine == "单次租赁" || model.Examine == "兑换券") && await this._exchangeService.ExistAsync(model.UserId))  //判断是否已经有租赁
            {
                result.Success = Permanent.FAILED;
                result.Error = (int)StatusCodeEnum.UNAUTHORIZED;
                result.ErrorMsg = "已经存在租赁，不能再租赁";
                return result;
            }
            var resultModel = new ExchangeConfimResultModel();

            var maDto = await _mailingAddressService.GetDefaultAsync(model.UserId);
            var exDto = await _exchangeService.FindAsync(exId);

            resultModel.AddressId = maDto?.Id ?? 0;
            resultModel.Consignee = maDto?.Name;
            resultModel.PhoneMob = maDto?.Phone;
            resultModel.Address = maDto?.Province + maDto?.City + maDto?.County + maDto?.Address;
            resultModel.Examine = model.Examine;
            resultModel.Fare = exDto.Postage == 0 ? await _postageService.GetPostageAsync() : exDto.Postage;  //邮费

            resultModel.Deposit = await _memberService.GetDepositAsync(model.UserId, exDto.Official.ToInt32());
            switch (model.Examine)
            {
                case "身家兑换":
                    resultModel.Price = exDto.Official.ToDecimal();
                    resultModel.PriceSum = resultModel.Fare;
                    break;
                case "会员租赁":
                    resultModel.Price = 0;
                    resultModel.PriceSum = resultModel.Fare + resultModel.Deposit;
                    break;
                case "单次租赁":
                    resultModel.Price = exDto.Rent == 0 ? 30 : exDto.Rent;
                    resultModel.PriceSum = resultModel.Fare + resultModel.Deposit + resultModel.Price;
                    break;
                case "兑换券":
                    resultModel.Price = 0;
                    resultModel.Fare = 0;
                    resultModel.PriceSum = resultModel.Deposit;
                    break;
                default:
                    resultModel.Price = 0;
                    break;
            }


            result.Data = resultModel;
            return result;
        }

        /// <summary>
        /// 获得最终值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // Get: api/Exchanges/Order/2
        [HttpGet, Route("Order/{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> GetOrder(int id)
        {
            MessageBase2 result = new MessageBase2();
            var dto = await _exchangeService.FindAsync(id);

            result.Data = dto.Official;

            return result;
        }
        /// <summary>
        /// 获得应交押金
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        // Get: api/Exchanges/Deposit/2?userId=30
        [HttpGet, Route("Deposit/{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> GetDeposit(int id, int userId)
        {
            MessageBase2 result = new MessageBase2();
            var dto = await _exchangeService.FindAsync(id);
            int dep = await _memberService.GetDepositAsync(userId, dto.Official.ToInt32());
            result.Data = dep;
            return result;
        }
        /// <summary>
        /// 删除兑换
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <returns></returns>
        // DELETE: api/Exchanges/2
        [HttpDelete("{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Delete(int id)
        {
            MessageBase2 result = new MessageBase2();
            await _exchangeService.DeleteAsync(id);
            return result;
        }
        /// <summary>
        /// 修改兑换
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="model"></param>
        /// <returns></returns>
        // PUT: api/Exchanges/Update/2
        [HttpPut, Route("Update/{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> PutUpdate(int id, [FromBody]ExchangeViewModel model)
        {
            MessageBase2 result = new MessageBase2();

            ExchangeDto dto = ConvertHelper.ChangeType<ExchangeDto>(model);
            await _exchangeService.UpdateAsync(id, dto);

            return result;
        }
        /// <summary>
        /// 同意审核兑换
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="type"></param>
        /// <returns></returns>
        // PUT api/Exchanges/Censor/2?type=同意
        [HttpPut, Route("Censor/{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> PutCensor(int id, [RegularExpression("同意|拒绝", ErrorMessage = "不支持的类型")]string type)
        {
            MessageBase2 result = new MessageBase2();
            await _exchangeService.UpdateExamineAsync(id, type);

            return result;
        }
        /// <summary>
        /// 修改物流单号
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="code">物流单号</param>
        /// <returns></returns>
        // PUT api/Exchanges/LogisticCode/2?code=111111111111
        [HttpPut, Route("LogisticCode/{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> PutLogisticCode(int id, string code)
        {
            MessageBase2 result = new MessageBase2();

            //if (KdGoldCore.OrderTracesSubByJson(code)==null)
            //{
            //    result.Success = Permanent.FAILED;
            //    result.Error = (int) StatusCodeEnum.UNPROCESABLE_ENTITY;
            //    result.ErrorMsg = "物流单号不正确";
            //}
            //else
            //{
            await _exchangeService.UpdateLogisticCodeAsync(id, code);
            //}

            return result;
        }
    }
}
