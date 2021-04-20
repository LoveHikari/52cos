using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Com.Cos.Common
{
    public class QQApi
    {
        private const string AUTHORIZE_URL = "https://graph.qq.com/oauth2.0/authorize";
        //public const string ACCESS_TOKEN_URL = "https://graph.qq.com/oauth2.0/token";
        private const string ACCESS_TOKEN_URL = "https://graph.qq.com/oauth2.0/authorize";
        private const string APP_ID = "101255587";
        private const string APP_KEY = "b800e1905ae103f98a7948b1dff06d88";
        private const string REDIRECT_URI = "http://passport.efu.com.cn/QQToken.aspx";  //回调地址
        private const string SCOPE = "get_user_info";
        //public static string AppSecret = "713b249a0cee15466fdc8431bc1cf437";

        /// <summary>
        /// 获取Access Token URL
        /// </summary>
        /// <returns></returns>
        public static string GetAccessToken()
        {
            Dictionary<string, string> config = new Dictionary<string, string>()
            {
                {"client_id",APP_ID},
                {"redirect_uri",REDIRECT_URI},
                {"response_type","token"},
                {"scope",SCOPE}

            };
            UriBuilder builder = new UriBuilder(AUTHORIZE_URL) {Query = BuildQueryString(config)};
            return builder.ToString();
        }

        ///// <summary>
        ///// 获取用户的OpenID
        ///// </summary>
        ///// <param name="accessToken">Access Token</param>
        ///// <returns></returns>
        //public static string GetOpenId(string accessToken)
        //{
        //    if (string.IsNullOrEmpty(accessToken))
        //    {
        //        return null;
        //    }

        //    Dictionary<string, string> config = new Dictionary<string, string>()
        //    {
        //        {"access_token",accessToken}
        //    };

        //    string str1 = GetPageHtml("https://graph.qq.com/oauth2.0/me", "Get", config);
        //    if (string.IsNullOrEmpty(str1))
        //    {
        //        return null;
        //    }
        //    str1 = str1.Replace("callback(", "[").Replace(");", "]").Replace(" ", "");
        //    List<OpenId> obj1 = JosnToObj<List<OpenId>>(str1);
        //    if (obj1.Count > 0)
        //    {
        //        return obj1[0].openid;
        //    }
        //    return null;
        //}


        //private static string GetPageHtml(string url, string method, Dictionary<string, string> parameters)
        //{
        //    string rawUrl = string.Empty;
        //    UriBuilder uri = new UriBuilder(url);
        //    string result = string.Empty;
        //    uri.Query = BuildQueryString(parameters);
        //    HttpWebRequest http = WebRequest.Create(uri.Uri) as HttpWebRequest;
        //    http.ServicePoint.Expect100Continue = false;
        //    http.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0)";
        //    switch (method)
        //    {
        //        case "Get":
        //            http.Method = "GET";
        //            break;
        //        case "Post":
        //            {
        //                http.Method = "POST";
        //                http.ContentType = "application/x-www-form-urlencoded";
        //                using (StreamWriter request = new StreamWriter(http.GetRequestStream()))
        //                {
        //                    try
        //                    {
        //                        request.Write(BuildQueryString(parameters));
        //                    }
        //                    finally
        //                    {
        //                        request.Close();
        //                    }
        //                }
        //            }
        //            break;
        //    }

        //    try
        //    {
        //        using (WebResponse response = http.GetResponse())
        //        {

        //            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        //            {
        //                try
        //                {
        //                    result = reader.ReadToEnd();
        //                }
        //                catch (WeiboException)
        //                {
        //                    throw;
        //                }
        //                finally
        //                {
        //                    reader.Close();
        //                }
        //            }


        //            response.Close();
        //        }
        //    }
        //    catch (Exception webEx)
        //    {
        //        Log.Write("QQApi.GetPageHtml()", "url:" + url, webEx);
        //    }
        //    return result;
        //}


        /// <summary>
        /// 拼接url参数
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns>a=1&amp;b=1</returns>
        private static string BuildQueryString(Dictionary<string, string> param)
        {
            List<string> pairs = new List<string>();
            foreach (KeyValuePair<string, string> item in param)
            {
                if (string.IsNullOrEmpty(item.Value))
                    continue;
                pairs.Add($"{Uri.EscapeDataString(item.Key)}={Uri.EscapeDataString(item.Value)}");
            }
            return string.Join("&", pairs.ToArray());
        }


        public static string GetTokenVal(string str1)
        {
            if (string.IsNullOrEmpty(str1))
            {
                return null;
            }
            string e1 = @"access_token=(?<x>[^\]]*?)\&";
            Regex rxg = new Regex(e1, RegexOptions.IgnoreCase);
            if (rxg.IsMatch(str1))
            {
                var m1 = rxg.Matches(str1);
                string val1 = m1[0].Value;
                if (string.IsNullOrEmpty(val1) == false)
                {
                    val1 = val1.Replace("access_token=", "").Replace("&", "");
                    return val1;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

    }

    [Serializable]
    public class OpenId
    {
        //callback( {"client_id":"101006681","openid":"0204AF668CD1983ED2FBD55049D5911B"} )
        public string client_id { get; set; }
        public string openid { get; set; }
    }
    /// <summary>
    /// 用户信息
    /// </summary>
    [Serializable]
    public class UserInfo
    {
        public string ret { get; set; }
        public string msg { get; set; }
        public string nickname { get; set; }
        public string figureurl { get; set; }
        public string figureurl_1 { get; set; }
        public string figureurl_2 { get; set; }
        public string figureurl_qq_1 { get; set; }
        public string figureurl_qq_2 { get; set; }
        public string gender { get; set; }
        public string is_yellow_vip { get; set; }
        public string vip { get; set; }
        public string yellow_vip_level { get; set; }
        public string level { get; set; }
        public string is_yellow_year_vip { get; set; }


    }
    /// <summary>
    /// 返回信息
    /// </summary>
    [Serializable]
    public class RetMsg
    {
        public string ret { get; set; }
        public string errcode { get; set; }
        public string msg { get; set; }
        public string id { get; set; }
        public string time { get; set; }
    }

    [Serializable]
    public class SUrl
    {
        public string object_type { get; set; }
        public string result { get; set; }
        public string url_short { get; set; }
        public string object_id { get; set; }
        public string url_long { get; set; }
        public string type { get; set; }
    }

}