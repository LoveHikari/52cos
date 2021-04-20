using System.Collections.Generic;

namespace Com.Cos.WebApi.ResultModels.ExchangeClassResultModels
{
    public class ExchangeClassResult : MessageBase
    {
        public List<ExchangeClassResultModel> List { get; set; }
    }
}