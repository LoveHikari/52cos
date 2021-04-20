using System;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Com.Cos.Api
{
    /// <summary>
    /// 获得一些文章相关内容的类
    /// </summary>
    public class WorksApi
    {
        /// <summary>
        /// 获取封面地址
        /// </summary>
        /// <param name="cover">封面id</param>
        /// <returns></returns>
        public static string GetCover(string cover)
        {
            if (!string.IsNullOrEmpty(cover))
            {
                SmallImgEntity smallImgEntity = SmallImgBll.Instance.GetModel(Convert.ToInt32(cover));
                return smallImgEntity?.ImgUrl;
            }
            return "";
        }
        /// <summary>
        /// 获得类型的文本
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetTypeText(string type)
        {
            return SysParaBll.Instance.GetModel(Convert.ToInt32(type==""?"0": type))?.RefText;
        }
        /// <summary>
        /// 获取发布时间
        /// </summary>
        /// <param name="releaseTime">发布时间</param>
        /// <returns></returns>
        public static string GetTime(string releaseTime)
        {
            DateTime dt = Convert.ToDateTime(releaseTime);
            DateTime nowDt = DateTime.Now;
            TimeSpan ts = nowDt - dt;

            if (ts.Days >= 365)
            {
                return ts.Days / 365 + "年前";
            }
            if (ts.Days >= 30)
            {
                return ts.Days / 30 + "月前";
            }
            if (ts.Days >= 1)
            {
                return ts.Days + "天前";
            }
            if (ts.Hours >= 1)
            {
                return ts.Hours + "小时前";
            }
            if (ts.Minutes >= 1)
            {
                return ts.Minutes + "分钟前";
            }
            return (int)(ts.TotalSeconds * 1000) + "秒前";
        }
    }
}