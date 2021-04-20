using System.Collections.Generic;

namespace Com.Cos.Infrastructure.KdGold
{
    /// <summary>
    /// 单号识别
    /// </summary>
    public class OrderDistinguishModel
    {
        public string EBusinessID { get; set; }
        public string LogisticCode { get; set; }
        public string Success { get; set; }
        public string Code { get; set; }
        public List<Shipper> Shipper { get; set; }
    }

    public class Shipper
    {
        public string ShipperCode { get; set; }
        public string ShipperName { get; set; }

    }
}