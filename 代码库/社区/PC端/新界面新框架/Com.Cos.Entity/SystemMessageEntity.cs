using System;
namespace Com.Cos.Entity
{
    /// <summary>
    /// sns_systemMessage:实体类(属性说明自动提取数据库字段的描述信息)
    /// 系统信息表
    /// </summary>
    [Serializable]
    public partial class SystemMessageEntity
    {
        public SystemMessageEntity()
        { }
        #region Model
        private int _id;
        private string _reftype;
        private string _reftypedesc;
        private string _title;
        private string _stitle;
        private string _body;
        private string _smallbody;
        private DateTime _addtime;
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
        /// 类别
        /// </summary>
        public string RefType
        {
            set { _reftype = value; }
            get { return _reftype; }
        }
        /// <summary>
        /// 类别描述
        /// </summary>
        public string RefTypeDesc
        {
            set { _reftypedesc = value; }
            get { return _reftypedesc; }
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
        /// 小标题
        /// </summary>
        public string Stitle
        {
            set { _stitle = value; }
            get { return _stitle; }
        }
        /// <summary>
        /// 正文
        /// </summary>
        public string Body
        {
            set { _body = value; }
            get { return _body; }
        }
        /// <summary>
        /// 纯文本
        /// </summary>
        public string SmallBody
        {
            set { _smallbody = value; }
            get { return _smallbody; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
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

