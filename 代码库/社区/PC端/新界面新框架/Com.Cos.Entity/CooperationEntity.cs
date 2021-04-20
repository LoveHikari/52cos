using System;

namespace Com.Cos.Entity
{
    /// <summary>
    /// CooperationEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class CooperationEntity
    {
        public CooperationEntity()
        { }
        #region Model
        private int _id;
        private string _user_id;
        private string _title;
        private string _type;
        private string _send;
        private DateTime? _enrollend;
        private string _timebudget;
        private string _intention;
        private string _acceptsum;
        private string _coocontent;
        private string _rmbbudget;
        private string _genderask;
        private string _signperson;
        private string _personsum;
        private DateTime _releasetime;
        private int _status = 1;
        private string _contacts;
        private string _phone;
        private string _qq;
        private string _cover;
        private int _limitperson = 0;
        private string _will;
        private string _prov;
        private string _city;
        private string _dist;
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
        /// 接单种类
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 是否寄拍
        /// </summary>
        public string send
        {
            set { _send = value; }
            get { return _send; }
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
        /// 时间预算
        /// </summary>
        public string timeBudget
        {
            set { _timebudget = value; }
            get { return _timebudget; }
        }
        /// <summary>
        /// 意向类型
        /// </summary>
        public string intention
        {
            set { _intention = value; }
            get { return _intention; }
        }
        /// <summary>
        /// 接单数量
        /// </summary>
        public string acceptSum
        {
            set { _acceptsum = value; }
            get { return _acceptsum; }
        }
        /// <summary>
        /// 介绍
        /// </summary>
        public string cooContent
        {
            set { _coocontent = value; }
            get { return _coocontent; }
        }
        /// <summary>
        /// 预算
        /// </summary>
        public string RMBBudget
        {
            set { _rmbbudget = value; }
            get { return _rmbbudget; }
        }
        /// <summary>
        /// 性别要求
        /// </summary>
        public string GenderAsk
        {
            set { _genderask = value; }
            get { return _genderask; }
        }
        /// <summary>
        /// 报名人员
        /// </summary>
        public string signPerson
        {
            set { _signperson = value; }
            get { return _signperson; }
        }
        /// <summary>
        /// 查看人次
        /// </summary>
        public string personSum
        {
            set { _personsum = value; }
            get { return _personsum; }
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
        /// 
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
        /// 限制报名人数
        /// </summary>
        public int limitPerson
        {
            set { _limitperson = value; }
            get { return _limitperson; }
        }
        /// <summary>
        /// 意向
        /// </summary>
        public string will
        {
            set { _will = value; }
            get { return _will; }
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

