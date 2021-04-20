using System;

namespace Entity
{
    /// <summary>
    /// ImgEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ImgEntity
    {
        public ImgEntity()
        { }
        #region Model
        private int _imgid = 0;
        private string _imgurl = "";
        private DateTime? _addtime = null;
        private int _status = 1;
        /// <summary>
        /// 
        /// </summary>
        public int ImgId
        {
            set { _imgid = value; }
            get { return _imgid; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgUrl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }
        /// <summary>
        /// 添加时间
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

