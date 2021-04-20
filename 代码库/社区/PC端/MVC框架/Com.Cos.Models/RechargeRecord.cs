using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Models
{
    /// <summary>
    /// RechargeRecordEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// 充值记录表
    /// </summary>
    [Serializable,Table("sns_rechargeRecord")]
    public partial class RechargeRecord
    {
        public RechargeRecord()
        { }
        #region Model
        private int _id;
        private string _userId;
        private string _source;
        private string _rmb;
        private string _cnbi;
        private DateTime? _addTime;
        private string _orderNo;
        private string _orderName;
        private string _wareDesc;
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
        /// 会员id
        /// </summary>
        public string UserId
        {
            set { _userId = value; }
            get { return _userId; }
        }
        /// <summary>
        /// 变更来源
        /// </summary>
        public string Source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 人民币
        /// </summary>
        public string RMB
        {
            set { _rmb = value; }
            get { return _rmb; }
        }
        /// <summary>
        /// 折算的CN币
        /// </summary>
        public string Cnbi
        {
            set { _cnbi = value; }
            get { return _cnbi; }
        }
        /// <summary>
        /// 交易时间
        /// </summary>
        public DateTime? AddTime
        {
            set { _addTime = value; }
            get { return _addTime; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo
        {
            set { _orderNo = value; }
            get { return _orderNo; }
        }
        /// <summary>
        /// 订单名称
        /// </summary>
        public string OrderName
        {
            set { _orderName = value; }
            get { return _orderName; }
        }
        /// <summary>
        /// 商品描述
        ///
        /// </summary>
        public string WareDesc
        {
            set { _wareDesc = value; }
            get { return _wareDesc; }
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

