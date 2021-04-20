using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Config;
using Com.Cos.Infrastructure.KdGold;
using Com.Cos.WebApi.Models.LogisticViewModels;
using Com.Cos.WebApi.ResultModels;
using Com.Cos.WebApi.ResultModels.LogisticResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Com.Cos.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/Logistics")]
    public class LogisticController : Controller
    {
        private readonly ILogisticService _logisticService;
        private readonly ISysParaService _sysParaService;
        public LogisticController(ILogisticService logisticService,ISysParaService sysParaService)
        {
            _logisticService = logisticService;
            _sysParaService = sysParaService;
        }
        /// <summary>
        /// 快递鸟物流跟踪回调函数
        /// </summary>
        /// <param name="dataSign"></param>
        /// <param name="requestType"></param>
        /// <param name="requestData"></param>
        /// <returns></returns>
        // POST /api/Logistics
        [AcceptVerbs("POST"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Post(string dataSign, string requestType, string requestData)
        {
            LogisticViewModel model = JsonConvert.DeserializeObject<LogisticViewModel>(requestData);
            foreach (RequestData data in model.Data)
            {
                LogisticDto dto = new LogisticDto()
                {
                    ShipperCode = data.ShipperCode,
                    EstimatedDeliveryTime = data.EstimatedDeliveryTime,
                    LogisticCode = data.LogisticCode,
                    PickerInfo = data.PickerInfo,
                    SenderInfo = data.SenderInfo,
                    State = data.State.ToInt32()
                };
                foreach (Traces traces in data.Traces)
                {
                    dto.AcceptStation = traces.AcceptStation;
                    dto.AcceptTime = traces.AcceptTime.ToDateTime();
                    dto.Remark = traces.Remark;
                    await _logisticService.AddAsync(dto);
                }
            }
            IDictionary<string,object> dic = new Dictionary<string, object>();
            dic.Add("EBusinessID", KdGoldConfig.EBusinessId);
            dic.Add("UpdateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            dic.Add("Success", true);
            dic.Add("Reason", "");
            return dic;
        }
        /// <summary>
        /// 获得物流信息
        /// </summary>
        /// <param name="code">物流单号</param>
        /// <returns></returns>
        // GET /api/Logistics/00000000201708131
        [HttpGet("{code}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Get(string code)
        {
            MessageBase2 result = new MessageBase2();
            string json = KdGoldCore.GetOrderTraces(code);
            var jo = JObject.Parse(json);
            LogisticResultModel resultModel = new LogisticResultModel()
            {
                LogisticCode = code,
                ShipperCode = jo["data"]["company"]["fullname"].ToString(),
                State = await _sysParaService.GetTextAsync("logisticState", jo["data"]["info"]["state"].ToString())
            };
            resultModel.Accept = new List<KeyValuePair<string, string>>();
            foreach (JToken jt in jo["data"]["info"]["context"])
            {
                resultModel.Accept.Add(new KeyValuePair<string, string>(DateTimeHelper.ConvertDateTime(jt["time"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"), jt["desc"].ToString()));
            }

            resultModel.LogisticPhone = "1234567891";
            result.Data = resultModel;

            //var dtoList = _logisticService.FindList(code);
            //if (dtoList.Count>0)
            //{
            //    LogisticResultModel resultModel = new LogisticResultModel()
            //    {
            //        LogisticCode = dtoList[0].LogisticCode,
            //        ShipperCode = dtoList[0].ShipperCode,
            //        State = dtoList[0].StateText
            //    };
            //    resultModel.Accept = new List<KeyValuePair<string, string>>();
            //    foreach (LogisticDto dto in dtoList)
            //    {
            //        resultModel.Accept.Add(new KeyValuePair<string, string>(dto.AcceptTime.ToString("yyyy-MM-dd HH:mm:ss"), dto.AcceptStation));
            //    }
            //    resultModel.LogisticPhone = "1234567891";
            //    result.Data = resultModel;
            //}



            return result;
        }
    }
}