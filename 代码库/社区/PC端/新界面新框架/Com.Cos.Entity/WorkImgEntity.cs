using System;

namespace Com.Cos.Entity
{
    /// <summary>
    /// WorkImgEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class WorkImgEntity
    {
        public WorkImgEntity()
        { }
        #region Model
        private int _id;
        private string _workid;
        private string _imgid;
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
        /// 
        /// </summary>
        public string workId
        {
            set { _workid = value; }
            get { return _workid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImgId
        {
            set { _imgid = value; }
            get { return _imgid; }
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

