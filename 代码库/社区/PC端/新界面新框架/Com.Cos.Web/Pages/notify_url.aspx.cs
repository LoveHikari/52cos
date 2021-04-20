using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Web.Pages
{
    /// <summary>
    /// 功能：服务器异步通知页面
    /// 版本：3.3
    /// 日期：2012-07-10
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
    /// </summary>
    public partial class notify_url : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //请在这里加上商户的业务逻辑程序代码
                //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表
                string user_id = Request.Form["extra_common_param"];
                string notify_time = DateTime.Now.ToString();//Request.Form["notify_time"]; //通知时间
                string notify_type = "";//Request.Form["notify_type"]; //通知类型
                string notify_id = Request.Form["notify_id"]; //通知校验ID
                string sign_type = Request.Form["sign_type"]; //签名方式
                string sign = Request.Form["sign"]; //签名
                string out_trade_no = Request.Form["out_trade_no"]; //商户订单号
                string subject = Request.Form["subject"]; //商品名称
                string payment_type = Request.Form["payment_type"]; //支付类型
                string trade_no = Request.Form["trade_no"]; //支付宝交易号
                string trade_status = Request.Form["trade_status"]; //交易状态
                string gmt_create = DateTime.Now.ToString(); //交易创建时间

                string gmt_payment = DateTime.Now.ToString(); //交易付款时间

                string gmt_close = DateTime.Now.ToString(); //交易关闭时间

                string seller_email = Request.Form["seller_email"]; //卖家支付宝账号
                string seller_id = Request.Form["seller_id"]; //卖家支付宝账户号
                string buyer_email = Request.Form["buyer_email"]; //买家支付宝账号
                string buyer_id = Request.Form["buyer_id"]; //买家支付宝账户号
                string total_fee = Request.Form["total_fee"]; //交易金额
                string body = Request.Form["body"]; //商品描述
                string discount = Request.Form["discount"]; //折扣
                string business_scene = Request.Form["business_scene"]; //是否扫码支付
                string extra_common_param = Request.Form["extra_common_param"]; //公用回传参数

                TransactionsEntity transactionsEntity = new TransactionsEntity();
                transactionsEntity.UserId = user_id;
                transactionsEntity.NotifyTime = Convert.ToDateTime(notify_time);
                transactionsEntity.NotifyType = notify_type;
                transactionsEntity.NotifyId = notify_id;
                transactionsEntity.SignType = sign_type;
                transactionsEntity.Sign = sign;
                transactionsEntity.OutTradeNo = out_trade_no;
                transactionsEntity.Subject = subject;
                transactionsEntity.PaymentType = payment_type;
                transactionsEntity.TradeNo = trade_no;
                transactionsEntity.TradeStatus = trade_status;
                transactionsEntity.GmtCreate = Convert.ToDateTime(gmt_create);
                transactionsEntity.GmtPayment = Convert.ToDateTime(gmt_payment);
                transactionsEntity.GmtClose = Convert.ToDateTime(gmt_close);
                transactionsEntity.SellerEmail = seller_email;
                transactionsEntity.SellerId = seller_id;
                transactionsEntity.BuyerEmail = buyer_email;
                transactionsEntity.BuyerId = buyer_id;
                transactionsEntity.TotalFee = total_fee;
                transactionsEntity.Body = body;
                transactionsEntity.Discount = discount;
                transactionsEntity.BusinessScene = business_scene;
                transactionsEntity.ExtraCommonParam = extra_common_param;
                transactionsEntity.Status = 1;
                TransactionsBll.Instance.Add(transactionsEntity);

                //保存到充值记录表
                RechargeRecordEntity rechargeRecordEntity = new RechargeRecordEntity();
                rechargeRecordEntity.UserId = user_id;

                rechargeRecordEntity.RMB = double.Parse(total_fee).ToString();
                if (subject.IndexOf("身家", StringComparison.Ordinal) > -1)
                {
                    rechargeRecordEntity.source = "ShenJiaRecharge";
                    rechargeRecordEntity.Cnbi = "0";
                }
                else if (subject.IndexOf("会员", StringComparison.Ordinal) > -1)
                {
                    rechargeRecordEntity.source = "PurchaseVip";
                    rechargeRecordEntity.Cnbi = "0";
                }
                else if (subject.IndexOf("押金", StringComparison.Ordinal) > -1)
                {
                    rechargeRecordEntity.source = "Deposit";
                    rechargeRecordEntity.Cnbi = "0";
                }
                else
                {
                    rechargeRecordEntity.source = "";
                    rechargeRecordEntity.Cnbi = (double.Parse(total_fee) * 100).ToString();
                }

                rechargeRecordEntity.addTime = DateTime.Now;
                rechargeRecordEntity.OrderNo = out_trade_no;
                rechargeRecordEntity.OrderName = subject;
                rechargeRecordEntity.wareDesc = body;
                rechargeRecordEntity.Status = 1;
                RechargeRecordBll.Instance.Add(rechargeRecordEntity);
                //保存到积分变更表
                IntegralChangeEntity integralChangeEntity = new IntegralChangeEntity();
                integralChangeEntity.UserId = user_id;
                integralChangeEntity.source = "ShenJiaRecharge";
                integralChangeEntity.ShenJia = decimal.Parse(total_fee);
                integralChangeEntity.Bean = "0";
                integralChangeEntity.Cnbi = rechargeRecordEntity.Cnbi;
                integralChangeEntity.integral = 0;
                integralChangeEntity.Growth = 0;
                integralChangeEntity.Status = 1;
                integralChangeEntity.ardent = 0;
                integralChangeEntity.AddTime = DateTime.Now;
                IntegralChangeBll.Instance.Add(integralChangeEntity);
                //更新会员表
                if (subject.IndexOf("身家", StringComparison.Ordinal) > -1)
                {
                    MemberBll.Instance.UpdateIntegral(user_id, "ShenJia", integralChangeEntity.ShenJia.ToString());
                }
                else if (subject.IndexOf("会员", StringComparison.Ordinal) > -1)
                {
                    //string month = (double.Parse(total_fee)/0.01).ToString();
                    MemberBll.Instance.UpdateVip(user_id, total_fee);
                }
                else if (subject.IndexOf("押金", StringComparison.Ordinal) > -1)
                {
                    MemberBll.Instance.UpdateIntegral(user_id, "Deposit", total_fee);
                }
                else
                {
                    MemberBll.Instance.UpdateIntegral(user_id, "Cnbi", integralChangeEntity.Cnbi);
                }


                //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——
                Response.Write("success");  //请不要修改或删除

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            catch (Exception ex)
            {
                Response.Write("错误：" + ex.Message);
            }
        }
    }
}
