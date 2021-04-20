using System;

namespace Com.Cos.Entity
{
    /// <summary>
    /// ReplyEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ReplyEntity
    {
        public ReplyEntity()
        { }
        #region Model
        private int _replyid;
        private string _type;
        private string _workid;
        private string _user_id;
        private string _replycontent;
        private DateTime? _releasetime;
        private int _status = 1;
        /// <summary>
        /// 
        /// </summary>
        public int ReplyId
        {
            set { _replyid = value; }
            get { return _replyid; }
        }
        /// <summary>
        /// 类别
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 关联id
        /// </summary>
        public string workId
        {
            set { _workid = value; }
            get { return _workid; }
        }
        /// <summary>
        /// 会员id
        /// </summary>
        public string User_id
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string ReplyContent
        {
            set { _replycontent = value; }
            get { return _replycontent; }
        }
        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime? ReleaseTime
        {
            set { _releasetime = value; }
            get { return _releasetime; }
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

