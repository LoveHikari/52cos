using System;

namespace Com.Cos.Entity
{
    /// <summary>
    /// LoginIPEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class LoginIPEntity
    {
        public LoginIPEntity()
        { }
        #region Model
        private int _id;
        private string _user_id;
        private string _last_ip;
        private string _lastddress;
        private int _status = 1;
        private DateTime? _lasttime;
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
        public string User_id
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 登录IP
        /// </summary>
        public string Last_ip
        {
            set { _last_ip = value; }
            get { return _last_ip; }
        }
        /// <summary>
        /// 登录地址
        /// </summary>
        public string Lastddress
        {
            set { _lastddress = value; }
            get { return _lastddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime? LastTime
        {
            set { _lasttime = value; }
            get { return _lasttime; }
        }
        #endregion Model

    }
}

