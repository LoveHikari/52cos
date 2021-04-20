using System;

namespace Com.Cos.Entity
{
    /// <summary>
    /// MenuModuleEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// 菜单模块表
    /// </summary>
    [Serializable]
    public partial class MenuModuleEntity
    {
        public MenuModuleEntity()
        { }
        #region Model
        private int _id;
        private string _reftype;
        private string _reftypedesc;
        private string _refhref;
        private string _refclass;
        private string _reftxt;
        private string _parenttype;
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
        /// 类型
        /// </summary>
        public string RefType
        {
            set { _reftype = value; }
            get { return _reftype; }
        }
        /// <summary>
        /// 类型描述
        /// </summary>
        public string RefTypeDesc
        {
            set { _reftypedesc = value; }
            get { return _reftypedesc; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string RefHref
        {
            set { _refhref = value; }
            get { return _refhref; }
        }
        /// <summary>
        /// 样式
        /// </summary>
        public string RefClass
        {
            set { _refclass = value; }
            get { return _refclass; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string RefTxt
        {
            set { _reftxt = value; }
            get { return _reftxt; }
        }
        /// <summary>
        /// 父类型
        /// </summary>
        public string ParentType
        {
            set { _parenttype = value; }
            get { return _parenttype; }
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

