using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Models
{
    /// <summary>
    /// 积分来源表
    /// </summary>
    [Serializable,Table("sns_integralSource")]
    public partial class IntegralSource
    {
        public IntegralSource()
        { }
        #region Model
        private int _id;
        private string _refValue;
        private string _refText;
        private string _refDesc;
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
        /// 对应值
        /// </summary>
        public string RefValue
        {
            set { _refValue = value; }
            get { return _refValue; }
        }
        /// <summary>
        /// 值文本
        /// </summary>
        public string RefText
        {
            set { _refText = value; }
            get { return _refText; }
        }
        /// <summary>
        /// 值描述
        /// </summary>
        public string RefDesc
        {
            set { _refDesc = value; }
            get { return _refDesc; }
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

