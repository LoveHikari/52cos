namespace Com.Cos.WebApi.ResultModels.StartResultModels
{
    public class VersionResultModel
    {
        /// <summary>
        /// 是否有更新
        /// </summary>
        public bool IsUpdate { get; set; }
        /// <summary>
        /// 更新地址
        /// </summary>
        public string Url { get; set; }
    }
}