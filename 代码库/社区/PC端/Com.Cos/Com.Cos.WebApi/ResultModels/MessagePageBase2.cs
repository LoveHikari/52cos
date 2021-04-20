namespace Com.Cos.WebApi.ResultModels
{
    public class MessagePageBase2
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 数据总数
        /// </summary>
        public int TotalRecord { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 上一页
        /// </summary>
        public int PrevPage { get; set; }
        /// <summary>
        /// 下一页
        /// </summary>
        public int NextPage { get; set; }

        public object Data { get; set; }
    }
}