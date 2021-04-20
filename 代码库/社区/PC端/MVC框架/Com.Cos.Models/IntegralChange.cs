using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Models
{
    /// <summary>
    /// IntegralChangeEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// 积分变更记录表
    /// </summary>
    [Serializable,Table("sns_IntegralChange")]
    public partial class IntegralChange
    {
        public IntegralChange()
        { }
        #region Model
        private int _id;
        private string _userid;
        private string _source;
        private decimal _shenjia;
        private string _cnbi;
        private int? _integral;
        private int? _growth;
        private string _bean;
        private int _status = 1;
        private int? _ardent;
        private DateTime? _addtime;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserId
        {
            set { _userid = value; }
            get { return _userid; }
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
        /// 身价
        /// </summary>
        public decimal ShenJia
        {
            set { _shenjia = value; }
            get { return _shenjia; }
        }
        /// <summary>
        /// cn币
        /// </summary>
        public string Cnbi
        {
            set { _cnbi = value; }
            get { return _cnbi; }
        }
        /// <summary>
        /// 节操
        /// </summary>
        public int? Integral
        {
            set { _integral = value; }
            get { return _integral; }
        }
        /// <summary>
        /// 成长值
        /// </summary>
        public int? Growth
        {
            set { _growth = value; }
            get { return _growth; }
        }
        /// <summary>
        /// 豆子
        /// </summary>
        public string Bean
        {
            set { _bean = value; }
            get { return _bean; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 热心
        /// </summary>
        public int? Ardent
        {
            set { _ardent = value; }
            get { return _ardent; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        #endregion Model

    }
}

