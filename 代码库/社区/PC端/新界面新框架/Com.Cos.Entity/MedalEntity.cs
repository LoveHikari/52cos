using System;

namespace Com.Cos.Entity
{
    /// <summary>
    /// MedalEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class MedalEntity
    {
        public MedalEntity()
        { }
        #region Model
        private int _id;
        private string _reftext;
        private string _refdesc;
        private string _imgurl;
        private string _access;
        private DateTime? _addtime;
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
        /// 值文本
        /// </summary>
        public string RefText
        {
            set { _reftext = value; }
            get { return _reftext; }
        }
        /// <summary>
        /// 值描述
        /// </summary>
        public string RefDesc
        {
            set { _refdesc = value; }
            get { return _refdesc; }
        }
        /// <summary>
        /// 图片位置
        /// </summary>
        public string imgUrl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }
        /// <summary>
        /// 获取条件
        /// </summary>
        public string access
        {
            set { _access = value; }
            get { return _access; }
        }
        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? addtime
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

