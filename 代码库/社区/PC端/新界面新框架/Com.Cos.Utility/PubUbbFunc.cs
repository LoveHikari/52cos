using System.Text.RegularExpressions;
using System.Web;

namespace Com.Cos.Utility
{
    /// <summary>
    /// PubUbbFunc 的摘要说明
    /// </summary>
    public class PubUbbFunc
    {
        public PubUbbFunc()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 多行文本框前台页面HMTL显示

        public static string TextBoxToHTML(string sDetail)
        {
            sDetail = sDetail.Replace(" ", "&nbsp;").Replace("　", "&nbsp;");
            sDetail = sDetail.Replace("'", "&#39;");
            sDetail = sDetail.Replace("\"", "&quot;");
            sDetail = sDetail.Replace("<", "&lt;");
            sDetail = sDetail.Replace(">", "&gt;");
            sDetail = sDetail.Replace("\r\n", "<BR>");
            return sDetail;
        }

        #endregion

        #region 编辑器中内容前台页面显示全部内容(要求有HTML标签）
        /// <summary>
        /// 编辑器中内容前台页面显示全部内容(要求有HTML标签)
        /// </summary>
        /// <param name="sDetail"></param>
        /// <returns></returns>
        public static string EditorContentToHTML(string sDetail)
        {
            sDetail = HttpContext.Current.Server.HtmlDecode(sDetail);
            sDetail = Regex.Replace(sDetail, @"\<script[^>]*>|<\/script>", "", RegexOptions.IgnoreCase);
            sDetail = Regex.Replace(sDetail, @"\<form[^>]*>|<\/form>", "", RegexOptions.IgnoreCase);
            return sDetail;
        }

        #endregion

        #region 编辑器中内容前台页面显示部分内容（去掉全部的HTML标签）
        /// <summary>
        /// 编辑器中内容前台页面显示部分内容（去掉全部的HTML标签）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EditorContentDelHTML(string str)
        {
            str = HttpContext.Current.Server.HtmlDecode(str);
            str = Regex.Replace(str, @"\<(img)[^>]*>|<\/(img)>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<(table|tbody|tr|td|th|)[^>]*>|<\/(table|tbody|tr|td|th|)>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<(div|blockquote|fieldset|legend)[^>]*>|<\/(div|blockquote|fieldset|legend)>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<(font|i|u|h[1-9]|s)[^>]*>|<\/(font|i|u|h[1-9]|s)>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<(style|strong)[^>]*>|<\/(style|strong)>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<a[^>]*>|<\/a>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<(meta|iframe|frame|span|tbody|layer)[^>]*>|<\/(iframe|frame|meta|span|tbody|layer)>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<a[^>]*", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"[\s]*", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<form[^>]*>|<\/form>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\&nbsp;", "", RegexOptions.IgnoreCase);
            str = str.Replace("'", "&#39;");
            str = str.Replace("\"", "&quot;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = Regex.Replace(str, @"\<p[^>]*>|<\/p>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<span[^>]*>|<\/span>", "", RegexOptions.IgnoreCase);
            return str;
        }
        #endregion

        #region 编辑器中内容前台页面显示部分内容（去掉全部的Img标签）
        /// <summary>
        /// 编辑器中内容前台页面显示部分内容（去掉全部的Img标签）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EditorContentDelImg(string str)
        {
            str = HttpContext.Current.Server.HtmlDecode(str);
            str = Regex.Replace(str, @"\<(img)[^>]*>|<\/(img)>", "", RegexOptions.IgnoreCase);
            return str;
        }
        #endregion


        #region 多行文本框前台页面HMTL显示

        public static string ReplaceCharBack(string sDetail)
        {
            sDetail = sDetail.Replace("&nbsp;", " ").Replace("&nbsp;", "　");
            sDetail = sDetail.Replace("&#39;","'");
            sDetail = sDetail.Replace("&quot;","\"");
            sDetail = sDetail.Replace("&lt;","<");
            sDetail = sDetail.Replace("&gt;",">");
            sDetail = sDetail.Replace("<BR>","\r\n");
            return sDetail;
        }

        #endregion
    }
}
