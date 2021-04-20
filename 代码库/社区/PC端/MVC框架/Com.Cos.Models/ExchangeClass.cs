using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Models
{
    /// <summary>
    /// sns_exchangeClass:实体类(属性说明自动提取数据库字段的描述信息)
    /// 兑换分类表
    /// </summary>
    [Serializable,Table("sns_exchangeClass")]
    public partial class ExchangeClass
    {
        public ExchangeClass()
        { }
        #region Model
        private int _id;
        private string _classname;
        private int _classid;
        private string _classUsName;
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
        /// 分类英文名称
        /// </summary>
        public string ClassUsName
        {
            set { _classUsName = value; }
            get { return _classUsName; }
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

