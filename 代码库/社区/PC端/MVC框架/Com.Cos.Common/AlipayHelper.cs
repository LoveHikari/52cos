using System;
using System.Collections.Generic;
using Com.Cos.Common.Alipay;

namespace Com.Cos.Common
{
    public class AlipayHelper
    {

        /// <summary>
        /// 建立请求
        /// </summary>
        /// <param name="userId">用户名</param>
        /// <param name="money">支付金额</param>
        /// <param name="subject">订单名称</param>
        /// <param name="exId">兑换id</param>
        /// <param name="address">收货地址id</param>
        /// <param name="deposit">押金</param>
        /// <param name="method">兑换方式</param>
        /// <returns></returns>
        public static string BuildRequest(string userId, string money, string subject,string exId="",string address="",string deposit="",string method="")
        {
            //DONE: 支付宝充值
            //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓以下支付宝↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
            ////////////////////////////////////////////请求参数////////////////////////////////////////////
            //商户订单号，商户网站订单系统中唯一订单号，必填
            string out_trade_no = Guid.NewGuid().ToString();

            //付款金额，必填
            string total_fee = string.Format("{0:0.00}", money?.Split(',')[0]);
            //商品描述，可空
            string body = subject;

            ////////////////////////////////////////////////////////////////////////////////////////////////
            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("service", AlipayConfig.service);
            sParaTemp.Add("partner", AlipayConfig.partner);
            sParaTemp.Add("seller_id", AlipayConfig.seller_id);
            sParaTemp.Add("_input_charset", AlipayConfig.input_charset.ToLower());
            sParaTemp.Add("payment_type", AlipayConfig.payment_type);
            sParaTemp.Add("notify_url", AlipayConfig.notify_url);
            sParaTemp.Add("return_url", AlipayConfig.return_url);
            sParaTemp.Add("anti_phishing_key", AlipayConfig.anti_phishing_key);
            //sParaTemp.Add("exter_invoke_ip", AlipayConfig.exter_invoke_ip);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("body", body);
            string extra_common_param ="{"+ $"\"UserId\":\"{userId}\",\"ExId\":\"{exId}\",\"Address\":\"{address}\",\"Deposit\":\"{deposit}\",\"Method\":\"{method}\"" +"}";
            sParaTemp.Add("extra_common_param", extra_common_param);
            //其他业务参数根据在线开发文档，添加参数.文档地址:https://doc.open.alipay.com/doc2/detail.htm?spm=a219a.7629140.0.0.O9yorI&treeId=62&articleId=103740&docType=1
            //如sParaTemp.Add("参数名","参数值");

            //建立请求
            return AlipaySubmit.BuildRequest(sParaTemp, "post", "确认");
        }
    }
}