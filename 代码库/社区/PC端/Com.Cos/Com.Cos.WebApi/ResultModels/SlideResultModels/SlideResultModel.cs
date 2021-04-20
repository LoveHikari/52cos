namespace Com.Cos.WebApi.ResultModels.SlideResultModels
{
    /// <summary>
    /// 轮播图返回结果模型
    /// </summary>
    public class SlideResultModel
    {
        /// <summary>
        /// 文本描述
        /// </summary>
        public string ImgText { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string ImgHref { get; set; }
    }
}