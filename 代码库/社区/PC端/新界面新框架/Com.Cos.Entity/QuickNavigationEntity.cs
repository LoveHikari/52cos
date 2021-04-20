using System;

namespace Com.Cos.Entity
{
    /// <summary>
    /// QuickNavigationEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// 快捷导航表
    /// </summary>
    [Serializable]
    public partial class QuickNavigationEntity
    {
        public QuickNavigationEntity()
        { }
        #region Model
        private int _id;
        private string _smalltitle;
        private string _title;
        private string _cont;
        private string _link;
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
        /// 小标题
        /// </summary>
        public string SmallTitle
        {
            set { _smalltitle = value; }
            get { return _smalltitle; }
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
        /// 内容
        /// </summary>
        public string Cont
        {
            set { _cont = value; }
            get { return _cont; }
        }
        /// <summary>
        /// 链接
        /// </summary>
        public string Link
        {
            set { _link = value; }
            get { return _link; }
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

