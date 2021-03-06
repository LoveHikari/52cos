using System;

namespace Com.Cos.Entity
{
    /// <summary>
    /// RechargeRecordEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// 充值记录表
    /// </summary>
    [Serializable]
    public partial class RechargeRecordEntity
    {
        public RechargeRecordEntity()
        { }
        #region Model
        private int _id;
        private string _userid;
        private string _source;
        private string _rmb;
        private string _cnbi;
        private DateTime? _addtime;
        private string _orderno;
        private string _ordername;
        private string _waredesc;
        private int _status = 1;
        /// <summary>
        /// 
        /// </summary>
        public int id
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
        /// 变更来源
        /// </summary>
        public string source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 人民币
        /// </summary>
        public string RMB
        {
            set { _rmb = value; }
            get { return _rmb; }
        }
        /// <summary>
        /// 折算的CN币
        /// </summary>
        public string Cnbi
        {
            set { _cnbi = value; }
            get { return _cnbi; }
        }
        /// <summary>
        /// 交易时间
        /// </summary>
        public DateTime? addTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo
        {
            set { _orderno = value; }
            get { return _orderno; }
        }
        /// <summary>
        /// 订单名称
        /// </summary>
        public string OrderName
        {
            set { _ordername = value; }
            get { return _ordername; }
        }
        /// <summary>
        /// 商品描述
        ///
        /// </summary>
        public string wareDesc
        {
            set { _waredesc = value; }
            get { return _waredesc; }
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

