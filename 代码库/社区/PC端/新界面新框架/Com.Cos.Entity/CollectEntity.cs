using System;
namespace Com.Cos.Entity
{
    /// <summary>
    /// 收藏表
    /// </summary>
    [Serializable]
    public partial class CollectEntity
    {
        public CollectEntity()
        { }
        #region Model
        private int _id;
        private string _userid;
        private string _articleid;
        private string _classid;
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
        /// 会员id
        /// </summary>
        public string UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 文章id
        /// </summary>
        public string ArticleId
        {
            set { _articleid = value; }
            get { return _articleid; }
        }
        /// <summary>
        /// 分类
        /// </summary>
        public string ClassId
        {
            set { _classid = value; }
            get { return _classid; }
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

