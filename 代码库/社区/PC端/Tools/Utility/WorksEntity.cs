using System;

namespace Entity
{
    /// <summary>
    /// WorksEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class WorksEntity
    {
        public WorksEntity()
        { }
        #region Model
        private int _worksid = 0;
        private string _user_id = "";
        private string _workstitle = "";
        private string _workstype = "";
        private string _type2 = "";
        private string _originaworks = "";
        private string _originarole = "";
        private string _coser = "";
        private string _photography = "";
        private string _makeup = "";
        private string _late = "";
        private string _third = "";
        private string _painter = "";
        private string _labeldesc = "";
        private string _workscontent = "";
        private string _root = "0";
        private string _keep = "1";
        private string _watermark = "1";
        private DateTime _releasetime = DateTime.Now;
        private DateTime _updatetime = DateTime.Now;
        private int _goodno = 0;
        private int _status = 1;
        private int _reward = 0;
        private string _cover = "";
        private string _worksexcerpt = "";
        private string _source = "";
        private string _sourceurl = "";
        /// <summary>
        /// 
        /// </summary>
        public int WorksId
        {
            set { _worksid = value; }
            get { return _worksid; }
        }
        /// <summary>
        /// 发帖人id
        /// </summary>
        public string User_id
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 作品标题
        /// </summary>
        public string WorksTitle
        {
            set { _workstitle = value; }
            get { return _workstitle; }
        }
        /// <summary>
        /// 作品类型
        /// </summary>
        public string WorksType
        {
            set { _workstype = value; }
            get { return _workstype; }
        }
        /// <summary>
        /// 作品二级类型
        /// </summary>
        public string Type2
        {
            set { _type2 = value; }
            get { return _type2; }
        }
        /// <summary>
        /// 原作品
        /// </summary>
        public string OriginaWorks
        {
            set { _originaworks = value; }
            get { return _originaworks; }
        }
        /// <summary>
        /// 原角色
        /// </summary>
        public string OriginaRole
        {
            set { _originarole = value; }
            get { return _originarole; }
        }
        /// <summary>
        /// coser
        /// </summary>
        public string coser
        {
            set { _coser = value; }
            get { return _coser; }
        }
        /// <summary>
        /// 摄影
        /// </summary>
        public string Photography
        {
            set { _photography = value; }
            get { return _photography; }
        }
        /// <summary>
        /// 化妆
        /// </summary>
        public string Makeup
        {
            set { _makeup = value; }
            get { return _makeup; }
        }
        /// <summary>
        /// 后期
        /// </summary>
        public string Late
        {
            set { _late = value; }
            get { return _late; }
        }
        /// <summary>
        /// 协力
        /// </summary>
        public string Third
        {
            set { _third = value; }
            get { return _third; }
        }
        /// <summary>
        /// 画师
        /// </summary>
        public string Painter
        {
            set { _painter = value; }
            get { return _painter; }
        }
        /// <summary>
        /// 标签描述
        /// </summary>
        public string LabelDesc
        {
            set { _labeldesc = value; }
            get { return _labeldesc; }
        }
        /// <summary>
        /// 作品内容
        /// </summary>
        public string WorksContent
        {
            set { _workscontent = value; }
            get { return _workscontent; }
        }
        /// <summary>
        /// 权限设置
        /// </summary>
        public string Root
        {
            set { _root = value; }
            get { return _root; }
        }
        /// <summary>
        /// 允许保存
        /// </summary>
        public string Keep
        {
            set { _keep = value; }
            get { return _keep; }
        }
        /// <summary>
        /// 添加水印
        /// </summary>
        public string Watermark
        {
            set { _watermark = value; }
            get { return _watermark; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime ReleaseTime
        {
            set { _releasetime = value; }
            get { return _releasetime; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 被赞数
        /// </summary>
        public int GoodNo
        {
            set { _goodno = value; }
            get { return _goodno; }
        }
        /// <summary>
        /// 启用状态
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 打赏
        /// </summary>
        public int reward
        {
            set { _reward = value; }
            get { return _reward; }
        }
        /// <summary>
        /// 封面
        /// </summary>
        public string cover
        {
            set { _cover = value; }
            get { return _cover; }
        }
        /// <summary>
        /// 作品摘要
        /// </summary>
        public string worksExcerpt
        {
            set { _worksexcerpt = value; }
            get { return _worksexcerpt; }
        }
        /// <summary>
        /// 来源
        /// </summary>
        public string source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 来源网址
        /// </summary>
        public string sourceUrl
        {
            set { _sourceurl = value; }
            get { return _sourceurl; }
        }
        #endregion Model

    }
}

