namespace Com.Cos.Common
{
    /// <summary>
    /// 注册客户端js脚本
    /// </summary>
    public class RegisterClientScript
    {
        /// <summary>
        /// 弹出消息框，并重定向
        /// </summary>
        /// <param name="msg">要提示的消息</param>
        /// <param name="url">重定向地址</param>
        /// <returns>js脚本</returns>
        public static string AlertRedirect(string msg,string url)
        {
            string js = $"<script>alert('{msg}');window.location.replace('{url}');</script>";
            return js;
        }
        /// <summary>
        /// 弹出消息框
        /// </summary>
        /// <param name="msg">要提示的消息</param>
        /// <returns>js脚本</returns>
        public static string Alert(string msg)
        {
            string js = $"<script>alert('{msg}');</script>";
            return js;
        }
    }
}