using System;

namespace Com.Cos.Entity
{
    /// <summary>
    /// RentEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// 出租表
    /// </summary>
    [Serializable]
    public partial class RentEntity
    {
        public RentEntity()
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
        private string _official;
        private string _rentperson;
        private DateTime _addtime;
        private DateTime? _entertime;
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
        /// 其他描述
        /// </summary>
        public string Describe
        {
            set { _describe = value; }
            get { return _describe; }
        }
        /// <summary>
        /// 物品名称
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
        /// 物品来源
        /// </summary>
        public string Source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 物品组成
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
        /// 出租价格
        /// </summary>
        public string Official
        {
            set { _official = value; }
            get { return _official; }
        }
        /// <summary>
        /// 租用人id
        /// </summary>
        public string RentPerson
        {
            set { _rentperson = value; }
            get { return _rentperson; }
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

