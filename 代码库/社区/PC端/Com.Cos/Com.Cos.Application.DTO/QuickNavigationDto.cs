using System;

namespace Com.Cos.Application.DTO
{
    public class QuickNavigationDto
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 小标题
        /// </summary>
        public string SmallTitle { get; set; }
        /// <summary>
        /// 正文
        /// </summary>
        public string Cont { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}