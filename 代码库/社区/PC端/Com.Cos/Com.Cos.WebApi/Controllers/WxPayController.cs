using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Com.Cos.Infrastructure.WeChat;

namespace Com.Cos.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/WxPays")]
    public class WxPayController : Controller
    {
        private readonly IExchangeEventService _exchangeEventService;
        private readonly IRechargeRecordService _rechargeRecordService;
        public WxPayController(IExchangeEventService exchangeEventService, IRechargeRecordService rechargeRecordService)
        {
            _exchangeEventService = exchangeEventService;
            _rechargeRecordService = rechargeRecordService;
        }

        /// <summary>
        /// 兑换付款完成后处理兑换事件
        /// 异步调用，支付宝会在24小时内多次调用，直到成功为止
        /// </summary>
        /// <returns></returns>
        // POST: api/WxPays/WxpayNotify
        [AcceptVerbs("POST"), Route("WxpayNotify"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> WxpayNotify()
        {

            var response = new Senparc.Weixin.MP.TenPayLibV3.ResponseHandler(HttpContext);
            if (WxPaySdk.IsTenpaySign(response))
            {
                string passbackParams = response.GetParameter("attach");
                IDictionary<string, string> ps = SysHelper.GetUrlParam(passbackParams);
                int id = ps["id"].ToInt32(); //兑换事件Id
                switch (ps["merchantType"])
                {
                    case "身家充值":
                        await _rechargeRecordService.DealWithAsync(id);
                        break;
                    case "兑换租赁":
                        await _exchangeEventService.DealWithAsync(id, "Wx");
                        break;
                }
            }

            var request = new Senparc.Weixin.MP.TenPayLibV3.RequestHandler();
            request.SetParameter("return_code", "SUCCESS");
            request.SetParameter("return_msg", "OK");
            return request.ParseXML();
        }
    }
}