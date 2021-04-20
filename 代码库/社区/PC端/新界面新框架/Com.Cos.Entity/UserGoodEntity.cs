using System;

namespace Com.Cos.Entity
{
    /// <summary>
    /// UserGoodEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// 点赞关联表
    /// </summary>
    [Serializable]
    public partial class UserGoodEntity
    {
        public UserGoodEntity()
        { }
        #region Model
        private int _goodid;
        private string _user_id;
        private string _workid;
        private int _status = 1;
        /// <summary>
        /// 
        /// </summary>
        public int GoodId
        {
            set { _goodid = value; }
            get { return _goodid; }
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
        /// 作品id
        /// </summary>
        public string WorkId
        {
            set { _workid = value; }
            get { return _workid; }
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

