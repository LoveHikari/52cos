using Com.Cos.Infrastructure.Config;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.TenPayLibV3;
using System;
using System.Collections;

namespace Com.Cos.Infrastructure.WeChat
{
    public class WxPaySdk
    {
        private static readonly string AppId = WxPayConfig.AppId;
        private static readonly string MchId = WxPayConfig.MchId;
        private static readonly string Key = WxPayConfig.Key;
        private static readonly string AppSecret = WxPayConfig.AppSecret;
        private static readonly string NotifyUrl = WxPayConfig.NotifyUrl;  //异步回调地址
        /// <summary>
        /// 统一下单
        /// </summary>
        /// <param name="body"></param>
        /// <param name="detail"></param>
        /// <param name="totalFee"></param>
        /// <param name="outTradeNo"></param>
        /// <param name="spbillCreateIp"></param>
        /// <param name="attach"></param>
        /// <returns></returns>
        public static Hashtable UnifiedOrder(string body, string detail, string totalFee, string outTradeNo, string spbillCreateIp, string attach)
        {
            TenPayV3UnifiedorderRequestData tenPayData = new TenPayV3UnifiedorderRequestData(AppId, MchId, body, outTradeNo, (totalFee.ToDecimal() * 100).ToString("0").ToInt32(), spbillCreateIp, NotifyUrl, TenPayV3Type.APP, "", Key,
                Guid.NewGuid().ToString().Replace("-", ""), "WEB", null, DateTime.Now.AddMinutes(30), detail, attach);
            UnifiedorderResult result = TenPayV3.Unifiedorder(tenPayData);

            RequestHandler requestHandler = new RequestHandler();

            requestHandler.SetParameter("appid", result.appid);
            requestHandler.SetParameter("partnerid", result.mch_id);
            requestHandler.SetParameter("prepayid", result.prepay_id);
            requestHandler.SetParameter("package", "Sign=WXPay");
            requestHandler.SetParameter("noncestr", result.nonce_str);
            requestHandler.SetParameter("timestamp", System.DateTimeHelper.ConvertDateTimeInt(DateTime.Now).ToString());
            requestHandler.SetParameter("sign", requestHandler.CreateMd5Sign("key", Key));

            Hashtable request = requestHandler.GetAllParameters();

            return request;
        }
        /// <summary>
        /// 是否财付通签名,规则是:按参数名称a-z排序,遇到空值的参数不参加签名
        /// </summary>
        /// <param name="responseHandler"></param>
        /// <returns></returns>
        public static bool IsTenpaySign(ResponseHandler responseHandler)
        {
            responseHandler.SetKey(Key);
            return responseHandler.IsTenpaySign();
        }
    }
}