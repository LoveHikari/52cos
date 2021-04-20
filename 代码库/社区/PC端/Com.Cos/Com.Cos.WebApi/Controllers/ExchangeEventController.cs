using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Ali;
using Com.Cos.Infrastructure.WeChat;
using Com.Cos.WebApi.Models.ExchangeEventViewModels;
using Com.Cos.WebApi.ResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Com.Cos.WebApi.Controllers
{
    /// <summary>
    /// 兑换事件控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/ExchangeEvents")]
    public class ExchangeEventController : Controller
    {
        private readonly IExchangeService _exchangeService;
        private readonly IMemberService _memberService;
        private readonly IExchangeEventService _exchangeEventService;
        private readonly IPostageService _postageService;
        /// <summary>
        /// 构造函数
        /// </summary>
        public ExchangeEventController(IExchangeService exchangeService, IMemberService memberService, IExchangeEventService exchangeEventService, IPostageService postageService)
        {
            _exchangeService = exchangeService;
            _memberService = memberService;
            _exchangeEventService = exchangeEventService;
            _postageService = postageService;
        }
        /// <summary>
        /// 添加兑换事件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST /api/ExchangeEvents
        [AcceptVerbs("POST"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Post([FromBody]ExchangeEventViewModel model)
        {
            MessageBase2 result = new MessageBase2();

            var dto = await _exchangeService.FindAsync(model.ExId);

            decimal postage = dto.Postage == 0 ? await _postageService.GetPostageAsync() : dto.Postage;  //邮费
            string totalAmount = "";//金额
            string outTradeNo = SysHelper.GenerateTradeNo();
            int dep = 0;  //押金
            decimal shenJia = 0;
            switch (model.Examine)
            {
                case "身家兑换":
                    shenJia = dto.Official.ToDecimal(); ;
                    if (shenJia -(await _memberService.FindAsync(model.UserId)).ShenJia > 0)
                    {
                        result.Success = Permanent.FAILED;
                        result.Error = (int)StatusCodeEnum.FORBIDDEN;
                        result.ErrorMsg = "身家不足";
                        return result;
                    }
                    totalAmount = postage.ToString(CultureInfo.InvariantCulture);  //邮费
                    break;
                case "会员租赁":
                    dep = await _memberService.GetDepositAsync(model.UserId, dto.Official.ToInt32()); //总押金
                    totalAmount = (postage + dep).ToString("0.00");  //邮费+押金
                    break;
                case "单次租赁":
                    decimal price = dto.Rent == 0 ? 30 : dto.Rent;
                    dep = await _memberService.GetDepositAsync(model.UserId, dto.Official.ToInt32()); //总押金
                    totalAmount = (postage + dep + price).ToString("0.00");  //邮费+押金+30
                    break;
                case "兑换券":
                    postage = 0;
                    dep = await _memberService.GetDepositAsync(model.UserId, dto.Official.ToInt32()); //总押金
                    totalAmount = (postage + dep).ToString("0.00");  //邮费+押金
                    break;
            }

            ExchangeEventDto eedto = new ExchangeEventDto()
            {
                Deposit = dep,
                UserId = model.UserId,
                OrderNo = outTradeNo,
                Examine = model.Examine,
                AddressId = model.AddressId,
                ExId = model.ExId,
                VouId = model.VoucherId,
                Postage = postage.ToDecimal(),
                ShenJia = shenJia
            };
            int eeId = await _exchangeEventService.AddAsync(eedto);

            string passbackParams = "merchantType=兑换租赁&id=" + eeId;
            if (model.PayType == "Ali")
            {
                result.Data = AliPaySdk.Signature(dto.Title, model.Examine, totalAmount, outTradeNo, passbackParams);
            }
            if (model.PayType == "Wx")
            {
                result.Data = WxPaySdk.UnifiedOrder(dto.Title, model.Examine, totalAmount, outTradeNo, HttpContext.GetUserIp(), passbackParams);
            }



            return result;
            //页面输出的response.Body就是orderString 可以直接给客户端请求，无需再做处理。

        }

    }
}