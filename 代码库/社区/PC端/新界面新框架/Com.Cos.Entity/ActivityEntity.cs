using System;

namespace Com.Cos.Entity
{
    /// <summary>
    /// ActivityEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ActivityEntity
    {
        public ActivityEntity()
        { }
        #region Model
        private int _id;
        private string _user_id;
        private string _title;
        private DateTime? _starttime;
        private DateTime? _endtime;
        private DateTime? _enrollend;
        private string _contacts;
        private string _phone;
        private string _qq;
        private string _cover;
        private string _cont;
        private string _rmbbudget;
        private string _limitperson;
        private string _prov;
        private string _city;
        private string _dist;
        private DateTime _releasetime;
        private int _status = 1;
        private string _excerpt;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 发布会员id
        /// </summary>
        public string User_id
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 活动开始时间
        /// </summary>
        public DateTime? starttime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 活动结束时间
        /// </summary>
        public DateTime? endtime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 报名截止
        /// </summary>
        public DateTime? enrollEnd
        {
            set { _enrollend = value; }
            get { return _enrollend; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string contacts
        {
            set { _contacts = value; }
            get { return _contacts; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// QQ
        /// </summary>
        public string qq
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 封面
        /// </summary>
        public string cover
        {
            set { _cover = value; }
            get { return _cover; }
        }
        /// <summary>
        /// 介绍
        /// </summary>
        public string cont
        {
            set { _cont = value; }
            get { return _cont; }
        }
        /// <summary>
        /// 活动费用
        /// </summary>
        public string RMBBudget
        {
            set { _rmbbudget = value; }
            get { return _rmbbudget; }
        }
        /// <summary>
        /// 限制报名人数
        /// </summary>
        public string limitPerson
        {
            set { _limitperson = value; }
            get { return _limitperson; }
        }
        /// <summary>
        /// 省
        /// </summary>
        public string prov
        {
            set { _prov = value; }
            get { return _prov; }
        }
        /// <summary>
        /// 市
        /// </summary>
        public string city
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 区/县
        /// </summary>
        public string dist
        {
            set { _dist = value; }
            get { return _dist; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime ReleaseTime
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
        /// <summary>
        /// 摘要
        /// </summary>
        public string excerpt
        {
            set { _excerpt = value; }
            get { return _excerpt; }
        }
        #endregion Model

    }
}

