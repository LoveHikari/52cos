using System;

namespace Com.Cos.Entity
{
    /// <summary>
    /// SlideEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// 首页幻灯片
    /// </summary>
    [Serializable]
    public partial class SlideEntity
    {
        public SlideEntity()
        { }
        #region Model
        private int _id;
        private string _imgtext;
        private string _imgurl;
        private string _imghref;
        private int _weight;
        private DateTime _addtime;
        private int? _sign;
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
        /// 文本
        /// </summary>
        public string ImgText
        {
            set { _imgtext = value; }
            get { return _imgtext; }
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
        /// 链接地址
        /// </summary>
        public string ImgHref
        {
            set { _imghref = value; }
            get { return _imghref; }
        }
        /// <summary>
        /// 权重
        /// </summary>
        public int weight
        {
            set { _weight = value; }
            get { return _weight; }
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
        /// 标志
        /// </summary>
        public int? Sign
        {
            set { _sign = value; }
            get { return _sign; }
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

