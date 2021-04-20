using System;

namespace Com.Cos.Entity
{
    /// <summary>
    /// ExchangeVoteEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// 分享投票记录表
    /// </summary>
    [Serializable]
    public partial class ExchangeVoteEntity
    {
        public ExchangeVoteEntity()
        { }
        #region Model
        private int _id;
        private string _userid;
        private string _exid;
        private DateTime _addtime;
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
        /// 投票会员id
        /// </summary>
        public string UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 分享帖子id
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

