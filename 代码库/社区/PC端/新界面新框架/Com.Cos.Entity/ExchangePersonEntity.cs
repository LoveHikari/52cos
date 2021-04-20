using System;

namespace Com.Cos.Entity
{
    /// <summary>
    /// ExchangePersonEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// 兑换人员表
    /// </summary>
    [Serializable]
    public partial class ExchangePersonEntity
    {
        public ExchangePersonEntity()
        { }
        #region Model
        private int _id;
        private string _userid;
        private string _exid;
        private DateTime _addtime;
        private string _address;
        private string _examine;
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
        /// 兑换会员id
        /// </summary>
        public string UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 分享Id
        /// </summary>
        public string ExId
        {
            set { _exid = value; }
            get { return _exid; }
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
        /// 地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 审核标志
        /// </summary>
        public string Examine
        {
            set { _examine = value; }
            get { return _examine; }
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

