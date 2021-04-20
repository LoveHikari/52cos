using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Models
{
    /// <summary>
    /// 合作表
    /// </summary>
    [Serializable,Table("sns_cooperation")]
    public partial class Cooperation
    {
        public Cooperation()
        { }
        #region Model
        private int _id;
        private string _userId;
        private string _title;
        private string _send;
        private string _enrollEnd;
        private string _timeBudget;
        private string _intention;
        private string _acceptSum;
        private string _cont;
        private string _rMBBudget;
        private string _genderAsk;
        private string _signPerson;
        private string _personSum;
        private DateTime? _releaseTime;
        private int _status = 1;
        private string _contacts;
        private string _phone;
        private string _qq;
        private string _cover;
        private int _limitPerson = 0;
        private string _will;
        private string _prov;
        private string _city;
        private string _dist;
        private string _excerpt;
        private string _imgList;
        private string _address;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 发布会员id
        /// </summary>
        public string UserId
        {
            set { _userId = value; }
            get { return _userId; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 是否寄拍
        /// </summary>
        public string Send
        {
            set { _send = value; }
            get { return _send; }
        }
        /// <summary>
        /// 报名截止
        /// </summary>
        public string EnrollEnd
        {
            set { _enrollEnd = value; }
            get { return _enrollEnd; }
        }
        /// <summary>
        /// 时间预算
        /// </summary>
        public string TimeBudget
        {
            set { _timeBudget = value; }
            get { return _timeBudget; }
        }
        /// <summary>
        /// 意向类型
        /// </summary>
        public string Intention
        {
            set { _intention = value; }
            get { return _intention; }
        }
        /// <summary>
        /// 接单数量
        /// </summary>
        public string AcceptSum
        {
            set { _acceptSum = value; }
            get { return _acceptSum; }
        }
        /// <summary>
        /// 介绍
        /// </summary>
        public string Cont
        {
            set { _cont = value; }
            get { return _cont; }
        }
        /// <summary>
        /// 预算
        /// </summary>
        public string RMBBudget
        {
            set { _rMBBudget = value; }
            get { return _rMBBudget; }
        }
        /// <summary>
        /// 性别要求
        /// </summary>
        public string GenderAsk
        {
            set { _genderAsk = value; }
            get { return _genderAsk; }
        }
        /// <summary>
        /// 报名人员
        /// </summary>
        public string SignPerson
        {
            set { _signPerson = value; }
            get { return _signPerson; }
        }
        /// <summary>
        /// 查看人次
        /// </summary>
        public string PersonSum
        {
            set { _personSum = value; }
            get { return _personSum; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? ReleaseTime
        {
            set { _releaseTime = value; }
            get { return _releaseTime; }
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
        public string Contacts
        {
            set { _contacts = value; }
            get { return _contacts; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Qq
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 封面
        /// </summary>
        public string Cover
        {
            set { _cover = value; }
            get { return _cover; }
        }
        /// <summary>
        /// 限制报名人数
        /// </summary>
        public int LimitPerson
        {
            set { _limitPerson = value; }
            get { return _limitPerson; }
        }
        /// <summary>
        /// 意向
        /// </summary>
        public string Will
        {
            set { _will = value; }
            get { return _will; }
        }
        /// <summary>
        /// 省
        /// </summary>
        public string Prov
        {
            set { _prov = value; }
            get { return _prov; }
        }
        /// <summary>
        /// 市
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 区/县
        /// </summary>
        public string Dist
        {
            set { _dist = value; }
            get { return _dist; }
        }
        /// <summary>
        /// 摘要
        /// </summary>
        public string Excerpt
        {
            set { _excerpt = value; }
            get { return _excerpt; }
        }
        /// <summary>
        /// 图片列表
        /// </summary>
        public string ImgList
        {
            set { _imgList = value; }
            get { return _imgList; }
        }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        #endregion Model

    }
}

