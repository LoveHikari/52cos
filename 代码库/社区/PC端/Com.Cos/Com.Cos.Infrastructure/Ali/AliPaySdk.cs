using Alipay.AopSdk.Core;
using Alipay.AopSdk.Core.Domain;
using Alipay.AopSdk.Core.Request;
using Alipay.AopSdk.Core.Response;
using Alipay.AopSdk.Core.Util;
using Com.Cos.Infrastructure.Config;
using System;
using System.Collections.Generic;

namespace Com.Cos.Infrastructure.Ali
{
    public class AliPaySdk
    {
        private static readonly string AppId = AliPayConfig.AppId;
        private static readonly string ServerUrl = AliPayConfig.ServerUrl;  //支付宝网关
        private static readonly string Charset = AliPayConfig.Charset;
        private static readonly string SignType = AliPayConfig.SignType;  //签名方式 
        private static readonly string NotifyUrl = AliPayConfig.NotifyUrl;  //异步回调地址
        private static readonly string AppPrivateKey = AliPayConfig.AppPrivateKey; //RSA2(SHA256)密钥
        private static readonly string AlipayPublicKey = AliPayConfig.AlipayPublicKey; //支付宝公钥

        /// <summary>
        /// 签名订单
        /// </summary>
        /// <param name="body">订单描述</param>
        /// <param name="subject">商品标题</param>
        /// <param name="totalAmount">订单总金额</param>
        /// <param name="outTradeNo">订单号</param>
        /// <param name="passbackParams">公共回传参数</param>
        /// <returns>签名</returns>
        public static string Signature(string body, string subject, string totalAmount, string outTradeNo, string passbackParams)
        {
            IAopClient client = new DefaultAopClient(ServerUrl, AppId, AppPrivateKey, "json", "1.0", SignType, AlipayPublicKey, Charset, false);
            //实例化具体API对应的request类,类名称和接口名称对应,当前调用接口名称如：alipay.trade.app.pay
            AlipayTradeAppPayRequest request = new AlipayTradeAppPayRequest();
            //SDK已经封装掉了公共参数，这里只需要传入业务参数。以下方法为sdk的model入参方式(model和biz_content同时存在的情况下取biz_content)。
            AlipayTradeAppPayModel almodel = new AlipayTradeAppPayModel();
            almodel.Body = body;
            almodel.Subject = subject;
            almodel.TotalAmount = String.Format("{0:0.00}", totalAmount);
            almodel.ProductCode = "QUICK_MSECURITY_PAY";
            almodel.OutTradeNo = outTradeNo;
            almodel.TimeoutExpress = "30m";
            almodel.PassbackParams = System.Web.HttpUtility.UrlEncode(passbackParams);
            request.SetBizModel(almodel);
            request.SetNotifyUrl(NotifyUrl);
            //这里和普通的接口调用不同，使用的是sdkExecute
            AlipayTradeAppPayResponse response = client.SdkExecute(request);
            //HttpUtility.HtmlEncode是为了输出到页面时防止被浏览器将关键参数html转义，实际打印到日志以及http传输不会有这个问题
            return response.Body;
            //页面输出的response.Body就是orderString 可以直接给客户端请求，无需再做处理。
        }
        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static bool VerifySignature(IDictionary<string, string> parameters)
        {
            return AlipaySignature.RSACheckV1(parameters, AlipayPublicKey, Charset, SignType, false);
        }

        /// <summary>
        /// 单笔转账到支付宝账户接口
        /// </summary>
        /// <param name="payeeAccount">收款方账户</param>
        /// <param name="realName">真实姓名</param>
        /// <param name="amount">转账金额</param>
        /// <param name="outBizNo">订单号</param>
        /// <returns></returns>
        public static string FundTrans(string payeeAccount,string realName, string amount,string outBizNo)
        {
            //https://docs.open.alipay.com/api_28/alipay.fund.trans.toaccount.transfer
            IAopClient client = new DefaultAopClient(ServerUrl, AppId, AppPrivateKey, "json", "1.0", SignType, AlipayPublicKey, Charset, false);
            AlipayFundTransToaccountTransferRequest request = new AlipayFundTransToaccountTransferRequest();
            request.BizContent = "{" +
                                 "\"out_biz_no\":\"" + outBizNo + "\"," +
                                 "\"payee_type\":\"ALIPAY_LOGONID\"," +  //收款方账户类型。
                                 "\"payee_account\":\""+ payeeAccount + "\"," +  //收款方账户。与payee_type配合使用。付款方和收款方不能是同一个账户。
                                 "\"amount\":\""+ amount + "\"," +  //转账金额,金额必须大于等于0.1元
                                 "\"payer_show_name\":\"上海晶歌文化传播有限公司\"," +  //付款方姓名
                                 "\"payee_real_name\":\"" + realName + "\"," +  //收款方真实姓名（最长支持100个英文/50个汉字）。 如果本参数不为空，则会校验该账户在支付宝登记的实名是否与收款方真实姓名一致。
                                 "\"remark\":\"退还押金\"" +  //转账备注
                                 "  }";

            AlipayFundTransToaccountTransferResponse response = client.Execute(request);
            if (response.Code == "10000")
            {
                return "10000";
            }
            else
            {
                return response.Body;
            }

        }

        public static string TradeRefund(string outTradeNo,string refundAmount)
        {
            //https://docs.open.alipay.com/api_1/alipay.trade.refund
            IAopClient client = new DefaultAopClient(ServerUrl, AppId, AppPrivateKey, "json", "1.0", SignType, AlipayPublicKey, Charset, false);
            AlipayTradeRefundRequest request = new AlipayTradeRefundRequest();
            request.BizContent = "{" +
                                 "\"out_trade_no\":\""+ outTradeNo + "\"," +
                                 "\"trade_no\":\"\"," +
                                 "\"refund_amount\":"+ refundAmount + "," +
                                 "\"refund_reason\":\"正常退款\"," +
                                 "\"out_request_no\":\"HZ01RF001\"," +
                                 "\"operator_id\":\"OP001\"," +
                                 "\"store_id\":\"NJ_S_001\"," +
                                 "\"terminal_id\":\"NJ_T_001\"" +
                                 "  }";
            AlipayTradeRefundResponse response = client.Execute(request);
            if (response.Code == "10000")
            {
                return "10000";
            }
            else
            {
                return response.Body;
            }
        }
    }
}