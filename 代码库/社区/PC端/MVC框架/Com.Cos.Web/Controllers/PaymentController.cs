using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Cos.BLL;
using Com.Cos.Common;
using Com.Cos.Common.Alipay;
using Com.Cos.Models;
using System.Transactions;
using Newtonsoft.Json.Linq;

namespace Com.Cos.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly Com.Cos.IBLL.ITransactionsService _transactionsService;
        private readonly Com.Cos.IBLL.IMemberService _memberService;
        private readonly Com.Cos.IBLL.IRechargeRecordService _rechargeRecordService;
        private readonly Com.Cos.IBLL.IIntegralChangeService _integralChangeService;
        private readonly Com.Cos.IBLL.IExchangePersonService _exchangePersonService;
        private readonly Com.Cos.IBLL.IExchangeService _exchangeService;
        public PaymentController()
        {
            _transactionsService = new TransactionsService();
            _memberService = new MemberService();
            _rechargeRecordService = new RechargeRecordService();
            _integralChangeService = new IntegralChangeService();
            _exchangePersonService = new ExchangePersonService();
            _exchangeService = new ExchangeService();
        }
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        // 同步调用，只发生一次
        // GET: Payment/AlipayReturn
        public ActionResult AlipayReturn()
        {
            SortedDictionary<string, string> sPara = GetRequestGet();

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                AlipayNotify aliNotify = new AlipayNotify();
                bool verifyResult = aliNotify.Verify(sPara, Request.QueryString["notify_id"], Request.QueryString["sign"]);

                if (true)//验证成功
                {


                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //请在这里加上商户的业务逻辑程序代码
                    
                    string notify_time = Request.QueryString["notify_time"]; //通知时间
                    string notify_type = "";//Request.Form["notify_type"]; //通知类型
                    string notify_id = Request.QueryString["notify_id"]; //通知校验ID
                    string sign_type = Request.QueryString["sign_type"]; //签名方式
                    string sign = Request.QueryString["sign"]; //签名
                    string out_trade_no = Request.QueryString["out_trade_no"]; //商户订单号
                    string subject = Request.QueryString["subject"]; //商品名称
                    string payment_type = Request.QueryString["payment_type"]; //支付类型
                    string trade_no = Request.QueryString["trade_no"]; //支付宝交易号
                    string trade_status = Request.QueryString["trade_status"]; //交易状态
                    string gmt_create = DateTime.Now.ToString(CultureInfo.InvariantCulture); //交易创建时间

                    string gmt_payment = DateTime.Now.ToString(CultureInfo.InvariantCulture); //交易付款时间

                    string gmt_close = DateTime.Now.ToString(CultureInfo.InvariantCulture); //交易关闭时间

                    string seller_email = Request.QueryString["seller_email"]; //卖家支付宝账号
                    string seller_id = Request.QueryString["seller_id"]; //卖家支付宝账户号
                    string buyer_email = Request.QueryString["buyer_email"]; //买家支付宝账号
                    string buyer_id = Request.QueryString["buyer_id"]; //买家支付宝账户号
                    string total_fee = Request.QueryString["total_fee"]; //交易金额
                    string body = Request.QueryString["body"]; //商品描述
                    string discount = Request.QueryString["discount"]; //折扣
                    string business_scene = Request.QueryString["business_scene"]; //是否扫码支付
                    string extra_common_param = Request.QueryString["extra_common_param"]; //公用回传参数
                    JObject jo = JObject.Parse(extra_common_param);
                    string user_id = jo["UserId"].ToString();
                    string exId = jo["ExId"].ToString();
                    string address = jo["Address"].ToString();
                    string deposit = jo["Deposit"].ToString();
                    string method = jo["Method"].ToString();

                    if (subject.IndexOf("兑换订单", StringComparison.Ordinal) > -1)  //兑换订单
                    {
                        //ExchangeConfirm(user_id, exId, address, deposit, method);
                    }
                    else
                    {
                        Recharge(user_id, subject, total_fee, out_trade_no, body);
                    }


                    if (Request.QueryString["trade_status"] == "TRADE_FINISHED" || Request.QueryString["trade_status"] == "TRADE_SUCCESS")
                    {
                        //判断该笔订单是否在商户网站中已经做过处理
                        //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                        //如果有做过处理，不执行商户的业务程序
                        string message = "支付成功";
                    }
                    else
                    {
                        string message = "支付失败";
                    }

                    //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                else//验证失败
                {
                    string message = ("验证失败");
                }
            }
            else
            {
                string message = ("无返回参数");
            }
            return View();
        }

        /// <summary>
        /// 异步调用，支付宝会在24小时内多次调用，直到成功为止
        /// </summary>
        /// <returns></returns>
        // POST: Payment/AlipayNotify
        [AllowAnonymous]
        public ActionResult AlipayNotify()
        {
            SortedDictionary<string, string> sPara = GetRequestPost();

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                AlipayNotify aliNotify = new AlipayNotify();
                bool verifyResult = aliNotify.Verify(sPara, Request.Form["notify_id"], Request.Form["sign"]);
                try
                {
                    if (verifyResult)//验证成功
                    {
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //请在这里加上商户的业务逻辑程序代码


                        //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                        //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表
                        string extra_common_param = Request.Form["extra_common_param"]; //公用回传参数
                        JObject jo = JObject.Parse(extra_common_param);
                        string user_id = jo["UserId"].ToString();
                        string exId = jo["ExId"].ToString();
                        string address = jo["Address"].ToString();
                        string deposit = jo["Deposit"].ToString();
                        string method = jo["Method"].ToString();
                        string notify_time = Request.Form["notify_time"]; //通知时间
                        string notify_type = "";//Request.Form["notify_type"]; //通知类型
                        string notify_id = Request.Form["notify_id"]; //通知校验ID
                        string sign_type = Request.Form["sign_type"]; //签名方式
                        string sign = Request.Form["sign"]; //签名
                        string out_trade_no = Request.Form["out_trade_no"]; //商户订单号
                        string subject = Request.Form["subject"]; //商品名称
                        string payment_type = Request.Form["payment_type"]; //支付类型
                        string trade_no = Request.Form["trade_no"]; //支付宝交易号
                        string trade_status = Request.Form["trade_status"]; //交易状态
                        string gmt_create = DateTime.Now.ToString(CultureInfo.InvariantCulture); //交易创建时间

                        string gmt_payment = DateTime.Now.ToString(CultureInfo.InvariantCulture); //交易付款时间

                        string gmt_close = DateTime.Now.ToString(CultureInfo.InvariantCulture); //交易关闭时间

                        string seller_email = Request.Form["seller_email"]; //卖家支付宝账号
                        string seller_id = Request.Form["seller_id"]; //卖家支付宝账户号
                        string buyer_email = Request.Form["buyer_email"]; //买家支付宝账号
                        string buyer_id = Request.Form["buyer_id"]; //买家支付宝账户号
                        string total_fee = Request.Form["total_fee"]; //交易金额
                        string body = Request.Form["body"]; //商品描述
                        string discount = Request.Form["discount"]; //折扣
                        string business_scene = Request.Form["business_scene"]; //是否扫码支付
                        

                        Transactions transactions = new Transactions
                        {
                            UserId = user_id,
                            NotifyTime = Convert.ToDateTime(notify_time),
                            NotifyType = notify_type,
                            NotifyId = notify_id,
                            SignType = sign_type,
                            Sign = sign,
                            OutTradeNo = out_trade_no,
                            Subject = subject,
                            PaymentType = payment_type,
                            TradeNo = trade_no,
                            TradeStatus = trade_status,
                            GmtCreate = Convert.ToDateTime(gmt_create),
                            GmtPayment = Convert.ToDateTime(gmt_payment),
                            GmtClose = Convert.ToDateTime(gmt_close),
                            SellerEmail = seller_email,
                            SellerId = seller_id,
                            BuyerEmail = buyer_email,
                            BuyerId = buyer_id,
                            TotalFee = total_fee,
                            Body = body,
                            Discount = discount,
                            BusinessScene = business_scene,
                            ExtraCommonParam = extra_common_param,
                            Status = 1
                        };
                        _transactionsService.Add(transactions);


                        if (Request.Form["trade_status"] == "TRADE_FINISHED" || Request.Form["trade_status"] == "TRADE_SUCCESS")  //在指定时间段内未支付时关闭的交易；在交易完成全额退款成功时关闭的交易。//交易成功，且可对该交易做操作，如：多级分润、退款等。
                        {
                            //判断该笔订单是否在商户网站中已经做过处理
                            //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                            //如果有做过处理，不执行商户的业务程序

                            //注意：
                            //该种交易状态只在一种情况下出现——开通了高级即时到账，买家付款成功后。
                            if (subject.IndexOf("兑换订单", StringComparison.Ordinal) > -1)  //兑换订单
                            {
                                ExchangeConfirm(user_id, exId, address, deposit, method, total_fee);
                            }
                            if (subject.IndexOf("租借订单", StringComparison.Ordinal) > -1)  //租借订单
                            {
                                RentedConfirm(user_id, exId, address, deposit, method);
                            }
                            else
                            {
                                Recharge(user_id, subject, total_fee, out_trade_no, body);
                            }

                        }
                        else
                        {
                            Com.Cos.Common.Alipay.AlipayCore.LogResult("错误：支付失败");
                        }

                        //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                        Response.Write("success");  //请不要修改或删除

                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    }
                    else//验证失败
                    {
                        Com.Cos.Common.Alipay.AlipayCore.LogResult("错误：验证失败");
                        Response.Write("fail");
                    }
                }
                catch (Exception ex)
                {
                    Com.Cos.Common.Alipay.AlipayCore.LogResult("错误：" + ex.Message);
                }

            }
            else
            {
                Com.Cos.Common.Alipay.AlipayCore.LogResult("错误：无通知参数");
                Response.Write("无通知参数");
            }

            return View("AlipayNotify");
        }

        /// <summary>
        /// 获取支付宝GET过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        private SortedDictionary<string, string> GetRequestGet()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.QueryString;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.QueryString[requestItem[i]]);
            }

            return sArray;
        }
        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        private SortedDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }

            return sArray;
        }

        #region 私有方法
        /// <summary>
        /// 租借订单提交
        /// </summary>
        /// <param name="userId">会员id</param>
        /// <param name="exId">兑换id</param>
        /// <param name="address">地址id</param>
        /// <param name="deposit">押金</param>
        /// <param name="method">兑换方式，0为会员租赁，1为单次租赁</param>
        private void RentedConfirm(string userId, string exId, string address, string deposit, string method)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                //添加兑换人员表
                var ep = new Com.Cos.Models.ExchangePerson()
                {
                    UserId = userId,
                    ExId = exId,
                    AddTime = DateTime.Now,
                    Examine = "0",
                    Address = address,
                    Status = 1
                };
                _exchangePersonService.Add(ep);
                //更新兑换表
                var ex = _exchangeService.Find(exId.ToInt32());
                ex.Examine = "4";  //修改为已兑换
                ex.ExchangePerson = userId;
                _exchangeService.Update(ex);
                //更新会员表
                var member = _memberService.Find(userId.ToInt32());
                member.Deposit = deposit.ToDecimal();
                if (method == "0")  //会员租赁
                {
                    member.RemainingConversions--;
                }
                if (method == "1")  //单次租赁
                {
                    member.Shenjia -= 50;
                }
                _memberService.Update(member);

                ts.Complete();
            }

        }

        /// <summary>
        /// 兑换订单提交
        /// </summary>
        /// <param name="userId">会员id</param>
        /// <param name="exId">兑换id</param>
        /// <param name="address">地址id</param>
        /// <param name="deposit">押金</param>
        /// <param name="method">兑换方式，0为会员兑换，1为身家兑换</param>
        /// <param name="total_fee">交易金额</param>
        private void ExchangeConfirm(string userId, string exId, string address, string deposit, string method,string total_fee)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                //添加兑换人员表
                var ep = new Com.Cos.Models.ExchangePerson()
                {
                    UserId = userId,
                    ExId = exId,
                    AddTime = DateTime.Now,
                    Examine = "0",
                    Address = address,
                    Status = 1
                };
                _exchangePersonService.Add(ep);
                //更新兑换表
                var ex = _exchangeService.Find(exId.ToInt32());
                ex.Examine = "0";  //修改为已结束
                ex.ExchangePerson = userId;
                _exchangeService.Update(ex);
                //更新会员表
                var member = _memberService.Find(userId.ToInt32());
                member.Deposit = deposit.ToDecimal();
                if (method == "1")  //身家兑换
                {
                    member.Shenjia -= total_fee.ToDecimal() - deposit.ToDecimal();
                }
                _memberService.Update(member);

                ts.Complete();
            }

        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="userId">会员id</param>
        /// <param name="subject">商品名称</param>
        /// <param name="total_fee">交易金额</param>
        /// <param name="out_trade_no">商户订单号</param>
        /// <param name="body">商品描述</param>
        private void Recharge(string userId, string subject, string total_fee, string out_trade_no, string body)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                string integralSource = "";  //积分来源
                //更新会员表
                var user = _memberService.Find(userId.ToInt32());
                if (subject.IndexOf("身家", StringComparison.Ordinal) > -1)  //如果是身家充值
                {
                    //获得原来的身家
                    decimal oldShenJia = user.Shenjia ?? 0;
                    //增加身家
                    decimal shenJia = oldShenJia + total_fee.ToDecimal();
                    //修改
                    user.Shenjia = shenJia;
                    _memberService.Update(user);

                    integralSource = "ShenJiaRecharge";
                }
                else if (subject.IndexOf("会员", StringComparison.Ordinal) > -1)  //如果是购买会员
                {
                    if (decimal.Parse(total_fee) == 99) //充值金额为99，则增加一年会员，兑换次数加10
                    {
                        int conversions = user.Conversions ?? 0;
                        int remainingConversions = user.RemainingConversions ?? 0;
                        DateTime stime = user.Stime ?? DateTime.MinValue; //会员开始时间
                        DateTime etime = user.Etime ?? DateTime.MinValue; //会员结束时间
                        DateTime nowTime = DateTime.Now;
                        if (etime > nowTime)  //如果结束时间大于当前时间
                        {
                            user.Etime = etime.AddYears(1);
                        }
                        else
                        {
                            user.Stime = nowTime;
                            user.Etime = nowTime.AddYears(1);
                        }
                        user.Conversions = conversions + 10;
                        user.RemainingConversions = remainingConversions + 10;
                        user.Lv = 1;
                        _memberService.Update(user);

                        integralSource = "PurchaseVip";
                    }
                }
                //else if (subject.IndexOf("押金", StringComparison.Ordinal) > -1)  //如果是支付押金
                //{
                //    //获得原来的押金
                //    decimal oldDeposit = user.Deposit ?? 0;
                //    //增加押金
                //    decimal deposit = oldDeposit + decimal.Parse(total_fee);
                //    //修改
                //    user.Deposit = deposit;
                //    _memberService.Update(user);

                //    integralSource = "Deposit";
                //}

                //保存到充值记录表
                RechargeRecord rechargeRecord = new RechargeRecord
                {
                    UserId = userId,
                    Source = integralSource,
                    OrderNo = out_trade_no,
                    OrderName = subject,
                    Cnbi = "0",
                    RMB = total_fee,
                    WareDesc = body,
                    AddTime = DateTime.Now,
                    Status = 1
                };
                _rechargeRecordService.Add(rechargeRecord);
                //保存到积分变更表
                if (subject.IndexOf("身家", StringComparison.Ordinal) > -1)
                {
                    IntegralChange integralChange = new IntegralChange
                    {
                        UserId = userId,
                        Source = integralSource,
                        ShenJia = decimal.Parse(total_fee),
                        Bean = "0",
                        Cnbi = "0",
                        Integral = 0,
                        Growth = 0,
                        Status = 1,
                        Ardent = 0,
                        AddTime = DateTime.Now
                    };
                    _integralChangeService.Add(integralChange);
                }
                ts.Complete();
            }


        }

        #endregion
    }
}