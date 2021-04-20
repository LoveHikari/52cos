using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.Cos.Web.Service.HomeManage
{
    /// <summary>
    /// BuyVip 的摘要说明
    /// 会员购买
    /// </summary>
    public class BuyVip : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string userId = context.Request.Form["user[id]"];
            string money = context.Request.Form["ctb[money]"];
            //DONE: 支付宝充值
            //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓以下支付宝↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
            ////////////////////////////////////////////请求参数////////////////////////////////////////////
            //商户订单号，商户网站订单系统中唯一订单号，必填
            string out_trade_no = Guid.NewGuid().ToString();
            //订单名称，必填
            string subject = "会员购买";
            //付款金额，必填
            string total_fee = string.Format("{0:0.00}", money?.Split(',')[0]);
            //商品描述，可空
            string body = "会员购买";

            ////////////////////////////////////////////////////////////////////////////////////////////////

            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("service", Config.service);
            sParaTemp.Add("partner", Config.partner);
            sParaTemp.Add("seller_id", Config.seller_id);
            sParaTemp.Add("_input_charset", Config.input_charset.ToLower());
            sParaTemp.Add("payment_type", Config.payment_type);
            sParaTemp.Add("notify_url", Config.notify_url);
            sParaTemp.Add("return_url", Config.return_url);
            sParaTemp.Add("anti_phishing_key", Config.anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", Config.exter_invoke_ip);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("body", body);
            sParaTemp.Add("extra_common_param", userId);
            //其他业务参数根据在线开发文档，添加参数.文档地址:https://doc.open.alipay.com/doc2/detail.htm?spm=a219a.7629140.0.0.O9yorI&treeId=62&articleId=103740&docType=1
            //如sParaTemp.Add("参数名","参数值");

            //建立请求
            string sHtmlText = Submit.BuildRequest(sParaTemp, "post", "确认");
            context.Response.ContentType = "text/html";
            context.Response.Charset = "utf-8";
            context.Response.Write(sHtmlText);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}