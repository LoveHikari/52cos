using Com.Cos.Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace Com.Cos.Infrastructure
{
    public class SysHelper
    {
        /// <summary>
        /// 随机产生文件名
        /// </summary>
        /// <returns></returns>
        public static string RandomFileName()
        {
            Random ran = new Random();

            return (DateTimeHelper.ConvertDateTimeInt(DateTime.Now) + ran.Str(4, true)).ToLower();
        }
        /// <summary>
        /// 生成订单号
        /// </summary>
        /// <returns></returns>
        public static string GenerateTradeNo()
        {
            Random ran = new Random();
            return DateTime.Now.ToString("yyyyMMddHHmmssfff") + ran.RandomNumber(4);
        }

        /// <summary>
        /// 获得时间间隔
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns></returns>
        public static string GetDateInterval(string time)
        {
            DateTime dateTime = DateTime.Parse(time);

            TimeSpan timeSpan = DateTime.Now - dateTime;
            if (timeSpan < TimeSpan.FromMinutes(1))
            {
                return Math.Floor(timeSpan.TotalSeconds) + "秒前";
            }
            if (timeSpan < TimeSpan.FromHours(1))
            {
                return Math.Floor(timeSpan.TotalMinutes) + "分钟前";
            }
            if (timeSpan < TimeSpan.FromDays(1))
            {
                return Math.Floor(timeSpan.TotalHours) + "小时前";
            }
            return dateTime.ToString("yyyy-MM-dd HH:mm");
        }

        /// <summary>
        /// 获得url参数
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static IDictionary<string, string> GetUrlParam(string url)
        {
            url = System.Web.HttpUtility.UrlDecode(url);
            if (url.Contains("?"))
            {
                url = url.SplitRight("?");
            }
            IDictionary<string, string> dic = new SortedDictionary<string, string>();
            var ss = url.Split('&', StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in ss)
            {
                dic.Add(s.SplitLeft("="), s.SplitRight("="));
            }
            return dic;
        }
        /// <summary>
        /// 获得ip信息
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static IpInfoModel GetIpInfo(string ip)
        {
            string url = "http://ip.taobao.com/service/getIpInfo.php?ip=" + ip;
            string html = System.HttpHelper.GetHttpWebRequest(url);
            JObject jo = JObject.Parse(html);
            IpInfoModel model = new IpInfoModel()
            {
                Country = jo["data"]["country"].ToString(),
                Area = jo["data"]["area"].ToString(),
                Region = jo["data"]["region"].ToString(),
                City = jo["data"]["city"].ToString(),
                County = jo["data"]["county"].ToString(),
                Isp = jo["data"]["isp"].ToString()
            };
            return model;
        }
    }
}