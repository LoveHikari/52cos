using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Ali;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Cos.WebApi.Controllers
{
    /// <summary>
    /// 支付宝控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/AliPays")]
    public class AliPayController : Controller
    {

        private readonly IExchangeEventService _exchangeEventService;
        private readonly IRechargeRecordService _rechargeRecordService;
        public AliPayController(IExchangeEventService exchangeEventService, IRechargeRecordService rechargeRecordService)
        {
            _exchangeEventService = exchangeEventService;
            _rechargeRecordService = rechargeRecordService;
        }

        /// <summary>
        /// 兑换付款完成后处理兑换事件
        /// 异步调用，支付宝会在24小时内多次调用，直到成功为止
        /// </summary>
        /// <returns></returns>
        // POST: api/AliPays/AlipayNotify
        [AcceptVerbs("POST"), Route("AlipayNotify"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> AlipayNotify()
        {
            IDictionary<string, string> sPara = GetRequestPost();

            if (sPara.Count > 0)//判断是否有带返回参数
            {

                bool verifyResult = AliPaySdk.VerifySignature(sPara);

                if (verifyResult)//验证成功
                {

                    if (Request.Form["trade_status"] == "TRADE_FINISHED" || Request.Form["trade_status"] == "TRADE_SUCCESS")  //在指定时间段内未支付时关闭的交易；在交易完成全额退款成功时关闭的交易。//交易成功，且可对该交易做操作，如：多级分润、退款等。
                    {
                        string passbackParams = Request.Form["passback_params"];
                        IDictionary<string, string> ps = SysHelper.GetUrlParam(passbackParams);
                        int id = ps["id"].ToInt32(); //兑换事件Id
                        switch (ps["merchantType"])
                        {
                            case "身家充值":
                                await _rechargeRecordService.DealWithAsync(id);
                                break;
                            case "兑换租赁":
                                await _exchangeEventService.DealWithAsync(id, "Ali");
                                break;
                        }
                    }
                    else
                    {
                        LogHelper.WriteLog("错误：支付失败");
                    }

                    //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                    return "success";  //请不要修改或删除

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                else//验证失败
                {
                    LogHelper.WriteLog("错误：验证失败");
                    return "fail";
                }


            }
            else
            {
                LogHelper.WriteLog("错误：无通知参数");
                return "无通知参数";
            }
        }

        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        private IDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            IDictionary<string, string> sArray = new Dictionary<string, string>();
            //Load Form variables into NameValueCollection variable.
            var coll = Request.Form;

            // Get names of all forms into a string array.
            List<string> requestItem = coll.Keys.ToList();

            for (i = 0; i < requestItem.Count; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }

            return sArray;
        }

        
    }
}
