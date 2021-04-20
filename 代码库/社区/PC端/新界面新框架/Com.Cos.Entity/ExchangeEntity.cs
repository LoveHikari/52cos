using System;
namespace Com.Cos.Entity
{
    /// <summary>
    /// 分享表
    /// </summary>
    [Serializable]
    public partial class ExchangeEntity
    {
        public ExchangeEntity()
        { }
        #region Model
        private int _id;
        private string _userid;
        private string _title;
        private string _describe;
        private string _itemname;
        private string _cover;
        private string _certificate;
        private string _imgs;
        private string _source;
        private string _constitute;
        private string _price;
        private string _valuation1;
        private string _valuation2;
        private string _valuation3;
        private int _vote1;
        private int _vote2;
        private int _vote3;
        private string _official;
        private string _exchangeperson;
        private DateTime _addtime;
        private DateTime? _entertime;
        private string _classid;
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
        /// 发布会员id
        /// </summary>
        public string UserId
        {
            set { _userid = value; }
            get { return _userid; }
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
        /// 内容
        /// </summary>
        public string Describe
        {
            set { _describe = value; }
            get { return _describe; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ItemName
        {
            set { _itemname = value; }
            get { return _itemname; }
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
        /// 凭证
        /// </summary>
        public string Certificate
        {
            set { _certificate = value; }
            get { return _certificate; }
        }
        /// <summary>
        /// 图片列表
        /// </summary>
        public string Imgs
        {
            set { _imgs = value; }
            get { return _imgs; }
        }
        /// <summary>
        /// 服装来源
        /// </summary>
        public string Source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 服装组成
        /// </summary>
        public string Constitute
        {
            set { _constitute = value; }
            get { return _constitute; }
        }
        /// <summary>
        /// 原价
        /// </summary>
        public string Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 自我估价1
        /// </summary>
        public string Valuation1
        {
            set { _valuation1 = value; }
            get { return _valuation1; }
        }
        /// <summary>
        /// 自我估价2
        /// </summary>
        public string Valuation2
        {
            set { _valuation2 = value; }
            get { return _valuation2; }
        }
        /// <summary>
        /// 自我估价3
        /// </summary>
        public string Valuation3
        {
            set { _valuation3 = value; }
            get { return _valuation3; }
        }
        /// <summary>
        /// 估价1票数
        /// </summary>
        public int Vote1
        {
            set { _vote1 = value; }
            get { return _vote1; }
        }
        /// <summary>
        /// 估价2票数
        /// </summary>
        public int Vote2
        {
            set { _vote2 = value; }
            get { return _vote2; }
        }
        /// <summary>
        /// 估价3票数
        /// </summary>
        public int Vote3
        {
            set { _vote3 = value; }
            get { return _vote3; }
        }
        /// <summary>
        /// 官方价格
        /// </summary>
        public string Official
        {
            set { _official = value; }
            get { return _official; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExchangePerson
        {
            set { _exchangeperson = value; }
            get { return _exchangeperson; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 报名时间
        /// </summary>
        public DateTime? EnterTime
        {
            set { _entertime = value; }
            get { return _entertime; }
        }
        /// <summary>
        /// 分类
        /// </summary>
        public string ClassId
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 过期标志
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