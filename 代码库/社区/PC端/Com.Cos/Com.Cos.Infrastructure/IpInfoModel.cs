namespace Com.Cos.Infrastructure
{
    public class IpInfoModel
    {
        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 省（自治区或直辖市）
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 县
        /// </summary>
        public string County { get; set; }
        /// <summary>
        /// 运营商
        /// </summary>
        public string Isp { get; set; }
    }
}