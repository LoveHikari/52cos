using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Models
{
    /// <summary>
    /// 菜单模块
    /// </summary>
    [Serializable, Table("sns_menuModule")]
    public class MenuModule
    {
        public MenuModule()
        { }
        #region Model
        private int _id;
        private string _refType;
        private string _refTypeDesc;
        private string _refHref;
        private string _refClass;
        private string _refTxt;
        private string _parentType;
        private DateTime _addTime;
        private int _status = 1;
        /// <summary>
        /// 
        /// </summary>
        [Key]
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
            set { _refType = value; }
            get { return _refType; }
        }
        /// <summary>
        /// 类型描述
        /// </summary>
        public string RefTypeDesc
        {
            set { _refTypeDesc = value; }
            get { return _refTypeDesc; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string RefHref
        {
            set { _refHref = value; }
            get { return _refHref; }
        }
        /// <summary>
        /// 样式
        /// </summary>
        public string RefClass
        {
            set { _refClass = value; }
            get { return _refClass; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string RefTxt
        {
            set { _refTxt = value; }
            get { return _refTxt; }
        }
        /// <summary>
        /// 父类型
        /// </summary>
        public string ParentType
        {
            set { _parentType = value; }
            get { return _parentType; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addTime = value; }
            get { return _addTime; }
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