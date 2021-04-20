using System.Collections.Generic;

namespace Com.Cos.Infrastructure.KdGold
{
    public class KdApiSearchModel
    {
        public string EBusinessID { get; set; }
        public string OrderCode { get; set; }
        public string ShipperCode { get; set; }
        public string LogisticCode { get; set; }
        public string CallBack { get; set; }
        public string Success { get; set; }
        public string Reason { get; set; }
        public string State { get; set; }
        public List<Traces> Traces { get; set; }

    }

    public class Traces
    {
        public string AcceptTime { get; set; }
        public string AcceptStation { get; set; }
        public string Remark { get; set; }

    }
}