using System;
namespace Com.Cos.Entity
{
    /// <summary>
    /// sns_exchangeClass:实体类(属性说明自动提取数据库字段的描述信息)
    /// 兑换分类表
    /// </summary>
    [Serializable]
    public partial class ExchangeClassEntity
    {
        public ExchangeClassEntity()
        { }
        #region Model
        private int _id;
        private string _classname;
        private int _classid;
        private string _reserved;
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
        /// 分类名称
        /// </summary>
        public string ClassName
        {
            set { _classname = value; }
            get { return _classname; }
        }
        /// <summary>
        /// 分类id
        /// </summary>
        public int ClassId
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 预留字段
        /// </summary>
        public string Reserved
        {
            set { _reserved = value; }
            get { return _reserved; }
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

