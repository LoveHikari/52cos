using System.Collections.Generic;

namespace Com.Cos.WebApi.ResultModels.SlideResultModels
{
    /// <summary>
    /// 轮播图返回结果
    /// </summary>
    public class SlideResult:MessageBase
    {
        public List<SlideResultModel> List { get; set; }
    }
}