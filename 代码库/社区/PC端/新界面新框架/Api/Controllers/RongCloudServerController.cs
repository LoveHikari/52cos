using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using io.rong.rong.models;
using io.rong.rong;
using System.Runtime.Serialization;

namespace Api.Controllers
{
    /// <summary>
    /// 荣云服务器SDK
    /// </summary>
    [AllowAnonymous]
    [Authorize]
    public class RongCloudServerController : ApiController
    {
        /// <summary>
        /// 获取 Token 方法
        /// api/RongCloudServer/GetToken?uid={4}&amp;uname={用户名}
        /// </summary>
        /// <param name="uid">会员id</param>
        /// <param name="uname">会员用户名</param>
        /// <returns></returns>
        // GET api/RongCloudServer/GetToken?uid=4&uname=用户名
        [AcceptVerbs("GET")]
        public object GetToken(string uid,string uname)
        {
            //开发环境
            //String appKey = "kj7swf8o7wbw2";
            //String appSecret = "qeWNKGh2hPbp4";
            //生产环境
            String appKey = "qf3d5gbj35u5h";
            String appSecret = "blxSwWiIKq2vS";
            RongCloud rongcloud = RongCloud.getInstance(appKey, appSecret);
            TokenReslut usergetTokenResult = rongcloud.user.getToken(uid, uname, "http://www.rongcloud.cn/images/logo.png");
            return new Dictionary<string,string>() { {"status","200"}, {"token", usergetTokenResult.getToken() } };
            
        }
    }
}
