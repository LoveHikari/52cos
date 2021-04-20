using System;
namespace Com.Cos.Entity
{
    /// <summary>
    /// SysParaEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SysParaEntity
    {
        public SysParaEntity()
        { }
        #region Model
        private int _id;
        private string _reftype;
        private string _reftypedesc;
        private string _refvalue;
        private string _reftext;
        private string _refdesc;
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
        /// 
        /// </summary>
        public string RefType
        {
            set { _reftype = value; }
            get { return _reftype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RefTypeDesc
        {
            set { _reftypedesc = value; }
            get { return _reftypedesc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RefValue
        {
            set { _refvalue = value; }
            get { return _refvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RefText
        {
            set { _reftext = value; }
            get { return _reftext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RefDesc
        {
            set { _refdesc = value; }
            get { return _refdesc; }
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

