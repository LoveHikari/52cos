namespace Com.Cos.WebApi.Result.ImgResult
{
    /// <summary>
    /// 兑换详情图片列表模型
    /// </summary>
    public class ExchangeImgResultModel
    {
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgPath { get; set; }
        /// <summary>
        /// 图片宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 图片高度
        /// </summary>
        public int Height { get; set; }
    }
}