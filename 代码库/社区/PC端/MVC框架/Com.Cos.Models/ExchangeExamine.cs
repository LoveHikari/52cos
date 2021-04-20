using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Models
{
    /// <summary>
    /// 兑换状态表
    /// </summary>
    [Serializable,Table("sns_exchangeExamine")]
    public partial class ExchangeExamine
    {
        public ExchangeExamine()
        { }
        #region Model
        private int _id;
        private string _examineName;
        private string _examineId;
        private string _examineUsName;
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
        /// 状态名称
        /// </summary>
        public string ExamineName
        {
            set { _examineName = value; }
            get { return _examineName; }
        }
        /// <summary>
        /// 状态id
        /// </summary>
        public string ExamineId
        {
            set { _examineId = value; }
            get { return _examineId; }
        }
        /// <summary>
        /// 状态英文名称
        /// </summary>
        public string ExamineUsName
        {
            set { _examineUsName = value; }
            get { return _examineUsName; }
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

