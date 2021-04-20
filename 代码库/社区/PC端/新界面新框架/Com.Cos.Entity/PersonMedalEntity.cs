using System;

namespace Com.Cos.Entity
{
    /// <summary>
    /// PersonMedalEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PersonMedalEntity
    {
        public PersonMedalEntity()
        { }
        #region Model
        private int _id;
        private string _medalid;
        private string _userid;
        private DateTime? _gettime;
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
        /// 对应的勋章id
        /// </summary>
        public string medalId
        {
            set { _medalid = value; }
            get { return _medalid; }
        }
        /// <summary>
        /// 会员id
        /// </summary>
        public string userId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 获得时间
        /// </summary>
        public DateTime? getTime
        {
            set { _gettime = value; }
            get { return _gettime; }
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

