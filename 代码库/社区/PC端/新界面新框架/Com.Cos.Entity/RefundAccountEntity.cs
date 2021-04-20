using System;
namespace Com.Cos.Entity
{
    /// <summary>
    /// 退款账号表
    /// </summary>
    [Serializable]
    public partial class RefundAccountEntity
    {
        public RefundAccountEntity()
        { }
        #region Model
        private int _id;
        private string _userid;
        private string _realname;
        private string _batchno;
        private Single _batchfee;
        private string _accountname;
        private string _remark;
        private DateTime _addtime;
        private int _status;
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
        /// 真实姓名
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 流水号
        /// </summary>
        public string BatchNo
        {
            set { _batchno = value; }
            get { return _batchno; }
        }
        /// <summary>
        /// 付款金额
        /// </summary>
        public Single BatchFee
        {
            set { _batchfee = value; }
            get { return _batchfee; }
        }
        /// <summary>
        /// 收款方帐号
        /// </summary>
        public string AccountName
        {
            set { _accountname = value; }
            get { return _accountname; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
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

