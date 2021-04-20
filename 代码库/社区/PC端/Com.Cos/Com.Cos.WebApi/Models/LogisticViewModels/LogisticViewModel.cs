using System.Collections.Generic;
using Com.Cos.Infrastructure.KdGold;

namespace Com.Cos.WebApi.Models.LogisticViewModels
{
    public class LogisticViewModel
    {
        public string EBusinessID { get; set; }
        public string PushTime { get; set; }
        public string Count { get; set; }
        public List<RequestData> Data { get; set; }

    }

    public class RequestData
    {
        public string EBusinessID { get; set; }
        public string OrderCode { get; set; }
        public string ShipperCode { get; set; }
        public string LogisticCode { get; set; }
        public string Success { get; set; }
        public string Reason { get; set; }
        public string State { get; set; }
        public string CallBack { get; set; }
        public List<Traces> Traces { get; set; }
        public string EstimatedDeliveryTime { get; set; }
        public string PickerInfo { get; set; }
        public string SenderInfo { get; set; }

    }

}