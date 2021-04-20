using System;

namespace Com.Cos.Entity
{
    /// <summary>
    /// TransactionsEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// 充值交易记录表
    /// </summary>
    [Serializable]
    public partial class TransactionsEntity
    {
        public TransactionsEntity()
        { }
        #region Model
        private int _id;
        private string _userid;
        private DateTime _notifytime;
        private string _notifytype;
        private string _notifyid;
        private string _signtype;
        private string _sign;
        private string _outtradeno;
        private string _subject;
        private string _paymenttype;
        private string _tradeno;
        private string _tradestatus;
        private DateTime? _gmtcreate;
        private DateTime? _gmtpayment;
        private DateTime? _gmtclose;
        private string _selleremail;
        private string _sellerid;
        private string _buyeremail;
        private string _buyerid;
        private string _totalfee;
        private string _body;
        private string _discount;
        private string _businessscene;
        private string _extracommonparam;
        private int _status = 1;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 会员id
        /// </summary>
        public string UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 通知时间
        /// </summary>
        public DateTime NotifyTime
        {
            set { _notifytime = value; }
            get { return _notifytime; }
        }
        /// <summary>
        /// 通知类型
        /// </summary>
        public string NotifyType
        {
            set { _notifytype = value; }
            get { return _notifytype; }
        }
        /// <summary>
        /// 通知校验ID
        /// </summary>
        public string NotifyId
        {
            set { _notifyid = value; }
            get { return _notifyid; }
        }
        /// <summary>
        /// 签名方式
        /// </summary>
        public string SignType
        {
            set { _signtype = value; }
            get { return _signtype; }
        }
        /// <summary>
        /// 签名
        /// </summary>
        public string Sign
        {
            set { _sign = value; }
            get { return _sign; }
        }
        /// <summary>
        /// 商户网站唯一订单号
        /// </summary>
        public string OutTradeNo
        {
            set { _outtradeno = value; }
            get { return _outtradeno; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string Subject
        {
            set { _subject = value; }
            get { return _subject; }
        }
        /// <summary>
        /// 支付类型
        /// </summary>
        public string PaymentType
        {
            set { _paymenttype = value; }
            get { return _paymenttype; }
        }
        /// <summary>
        /// 支付宝交易号
        /// </summary>
        public string TradeNo
        {
            set { _tradeno = value; }
            get { return _tradeno; }
        }
        /// <summary>
        /// 交易状态
        /// </summary>
        public string TradeStatus
        {
            set { _tradestatus = value; }
            get { return _tradestatus; }
        }
        /// <summary>
        /// 交易创建时间
        /// </summary>
        public DateTime? GmtCreate
        {
            set { _gmtcreate = value; }
            get { return _gmtcreate; }
        }
        /// <summary>
        /// 交易付款时间
        /// </summary>
        public DateTime? GmtPayment
        {
            set { _gmtpayment = value; }
            get { return _gmtpayment; }
        }
        /// <summary>
        /// 交易关闭时间
        /// </summary>
        public DateTime? GmtClose
        {
            set { _gmtclose = value; }
            get { return _gmtclose; }
        }
        /// <summary>
        /// 卖家支付宝账号
        /// </summary>
        public string SellerEmail
        {
            set { _selleremail = value; }
            get { return _selleremail; }
        }
        /// <summary>
        /// 卖家支付宝账户号
        /// </summary>
        public string SellerId
        {
            set { _sellerid = value; }
            get { return _sellerid; }
        }
        /// <summary>
        /// 买家支付宝账号
        /// </summary>
        public string BuyerEmail
        {
            set { _buyeremail = value; }
            get { return _buyeremail; }
        }
        /// <summary>
        /// 买家支付宝账户号
        /// </summary>
        public string BuyerId
        {
            set { _buyerid = value; }
            get { return _buyerid; }
        }
        /// <summary>
        /// 交易金额
        /// </summary>
        public string TotalFee
        {
            set { _totalfee = value; }
            get { return _totalfee; }
        }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string Body
        {
            set { _body = value; }
            get { return _body; }
        }
        /// <summary>
        /// 折扣
        /// </summary>
        public string Discount
        {
            set { _discount = value; }
            get { return _discount; }
        }
        /// <summary>
        /// 是否扫码支付
        /// </summary>
        public string BusinessScene
        {
            set { _businessscene = value; }
            get { return _businessscene; }
        }
        /// <summary>
        /// 公用回传参数
        /// </summary>
        public string ExtraCommonParam
        {
            set { _extracommonparam = value; }
            get { return _extracommonparam; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        #endregion Model

    }
}

