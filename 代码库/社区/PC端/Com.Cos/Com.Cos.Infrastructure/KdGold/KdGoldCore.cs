using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Com.Cos.Infrastructure.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Com.Cos.Infrastructure.KdGold
{
    /// <summary>
    /// 快递鸟核心函数
    /// </summary>
    public class KdGoldCore
    {
        //电商ID
        private static readonly string EBusinessID = KdGoldConfig.EBusinessId;
        //电商加密私钥，快递鸟提供，注意保管，不要泄漏
        private static readonly string AppKey = KdGoldConfig.AppKey;
        //请求url
        private static readonly string ReqURL = KdGoldConfig.ReqUrl;

        /// <summary>
        /// Json方式  单号识别
        /// </summary>
        /// <param name="logisticCode">物流单号</param>
        /// <returns></returns>
        private static OrderDistinguishModel OrderTracesByJson(string logisticCode)
        {
            string requestData = "{'LogisticCode': '" + logisticCode + "'}";

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("RequestData", HttpUtility.UrlEncode(requestData, Encoding.UTF8));
            param.Add("EBusinessID", EBusinessID);
            param.Add("RequestType", "2002");
            string dataSign = KdGoldCommon.Encrypt(requestData, AppKey, "UTF-8");
            param.Add("DataSign", HttpUtility.UrlEncode(dataSign, Encoding.UTF8));
            param.Add("DataType", "2");

            string result = KdGoldCommon.SendPost(ReqURL, param);

            //根据公司业务处理返回的信息......
            return (OrderDistinguishModel)JsonConvert.DeserializeObject(result, typeof(OrderDistinguishModel));
        }

        /// <summary>
        /// Json方式 查询订单物流轨迹（即时查询）
        /// </summary>
        /// <param name="logisticCode">物流单号</param>
        /// <returns></returns>
        public static KdApiSearchModel GetOrderTracesByJson(string logisticCode)
        {
            OrderDistinguishModel od = OrderTracesByJson(logisticCode);
            if (od.Success != "true" || od.Shipper.Count == 0)
            {
                return null;
            }

            string shipperCode = od.Shipper[0].ShipperCode;  //快递公司编码
            string requestData = "{'OrderCode':'','ShipperCode':'" + shipperCode + "','LogisticCode':'" + logisticCode + "'}";

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("RequestData", HttpUtility.UrlEncode(requestData, Encoding.UTF8));
            param.Add("EBusinessID", EBusinessID);
            param.Add("RequestType", "1002");
            string dataSign = KdGoldCommon.Encrypt(requestData, AppKey, "UTF-8");
            param.Add("DataSign", HttpUtility.UrlEncode(dataSign, Encoding.UTF8));
            param.Add("DataType", "2");

            string result = KdGoldCommon.SendPost(ReqURL, param);

            //根据公司业务处理返回的信息......

            return (KdApiSearchModel)JsonConvert.DeserializeObject(result, typeof(KdApiSearchModel));
        }

        /// <summary>
        /// Json方式  物流信息订阅
        /// </summary>
        /// <param name="logisticCode">物流单号</param>
        /// <returns></returns>
        public static string OrderTracesSubByJson(string logisticCode)
        {
            OrderDistinguishModel od = OrderTracesByJson(logisticCode);
            if (od == null || od.Success != "true" || od.Shipper==null || od.Shipper.Count == 0)
            {
                return null;
            }
            string shipperCode = od.Shipper[0].ShipperCode;  //快递公司编码
            string requestData = "{'ShipperCode':'"+ shipperCode + "', 'LogisticCode':'"+ logisticCode + "'}";

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("RequestData", HttpUtility.UrlEncode(requestData, Encoding.UTF8));
            param.Add("EBusinessID", EBusinessID);
            param.Add("RequestType", "1008");
            string dataSign = KdGoldCommon.Encrypt(requestData, AppKey, "UTF-8");
            param.Add("DataSign", HttpUtility.UrlEncode(dataSign, Encoding.UTF8));
            param.Add("DataType", "2");

            string result = KdGoldCommon.SendPost("http://api.kdniao.cc/api/dist", param);

            //根据公司业务处理返回的信息......

            return result;
        }

        public static string GetOrderTraces(string logisticCode)
        {
            string url = $"https://sp0.baidu.com/9_Q4sjW91Qh3otqbppnN2DJv/pae/channel/data/asyncqury?cb=jQuery110204759692032715892_1499865778178&appid=4001&com=&nu={logisticCode}";
            string cookie = "BAIDUID=68FFE5EAF7C6D7C29283C145A02D8B5D:FG=1; BIDUPSID=68FFE5EAF7C6D7C29283C145A02D8B5D; PSTM=1504770278; __cfduid=d72956bf85465c97edb605571643541fb1504772072; __guid=195541998.3188686396701214000.1506044202114.6543; cflag=15%3A3; PSINO=5; H_PS_PSSID=1449_21081_18559_24395; BDORZ=B490B5EBF6F3CD402E515D22BCDA1598; monitor_count=3";
            string html = HttpHelper.GetHttpWebRequest(url,cookie:cookie);
            Regex regex = new Regex("/\\*\\*/jQuery.+?\\((.+?)\\)");
            string json = regex.Match(html).Groups[1].Value;
            return json;
        }

    }
}