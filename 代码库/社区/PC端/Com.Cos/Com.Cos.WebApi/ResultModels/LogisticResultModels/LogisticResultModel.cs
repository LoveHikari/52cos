using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Com.Cos.WebApi.ResultModels.LogisticResultModels
{
    public class LogisticResultModel
    {
        /// <summary>
        /// 快递公司编码
        /// </summary>
        public string ShipperCode { get; set; }
        /// <summary>
        /// 物流运单号
        /// </summary>
        public string LogisticCode { get; set; }
        /// <summary>
        /// 物流状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 物流信息
        /// </summary>
        public List<KeyValuePair<string,string>> Accept { get; set; }
        /// <summary>
        /// 物流客服电话
        /// </summary>
        public string LogisticPhone { get; set; }


    }
}