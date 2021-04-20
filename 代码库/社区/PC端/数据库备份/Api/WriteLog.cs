using System;
using System.IO;
using System.Configuration;

/***
 * title:错误日志输出类
 * date:2016-08-19
 * author:YUXiaoWei
***/
namespace Api
{
    /// <summary>
    /// 输出log
    /// </summary>
    public class WriteLog
    {
        public static object locker = new object();
        /// <summary>
        /// 将异常打印到LOG文件
        /// </summary>
        /// <param name="ex">异常</param>
        public static void WriteError(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                /* <!--错误日志目录 -->
                 * <add key="LogFilePath" value="E:\111"/>
                 * </appSettings>
                 */
                string directPath = ConfigurationManager.AppSettings["LogFilePath"]?.Trim();    //获得文件夹路径
                if (string.IsNullOrEmpty(directPath))
                {
                    directPath = Environment.CurrentDirectory;  //如果日志文件为空，则默认在Debug目录下新建 YYYY-mm-dd_Log.log文件
                }
                if (!Directory.Exists(directPath))   //判断文件夹是否存在，如果不存在则创建
                {
                    Directory.CreateDirectory(directPath);
                }
                directPath += string.Format(@"\{0}_Log.log", DateTime.Now.ToString("yyyy-MM-dd"));

                sw = !File.Exists(directPath) ? File.CreateText(directPath) : File.AppendText(directPath);    //判断文件是否存在如果不存在则创建，如果存在则添加。

                //把异常信息输出到文件
                sw.WriteLine("当前时间：" + DateTime.Now);
                sw.WriteLine("异常信息：" + ex.Message);
                sw.WriteLine("异常对象：" + ex.Source);
                sw.WriteLine("调用堆栈：\n" + ex.StackTrace.Trim());
                sw.WriteLine("触发方法：" + ex.TargetSite);
                sw.WriteLine("***********************************************************************");
                sw.WriteLine();
            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Dispose();
                    sw = null;
                }
            }
        }
        /// <summary>
        /// 将异常打印到LOG文件
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="Tag">传入标签（这里用于标识函数由哪个线程调用）</param>
        public static void WriteError(Exception ex, string Tag = "")
        {
            lock (locker)
            {
                StreamWriter sw = null;
                try
                {
                    /* <!--错误日志目录 -->
                     * <add key="LogFilePath" value="E:\111"/>
                     * </appSettings>
                     */
                    string directPath = ConfigurationManager.AppSettings["LogFilePath"]?.Trim(); //获得文件夹路径
                    if (string.IsNullOrEmpty(directPath))
                    {
                        directPath = Environment.CurrentDirectory; //如果日志文件为空，则默认在Debug目录下新建 YYYY-mm-dd_Log.log文件
                    }
                    if (!Directory.Exists(directPath)) //判断文件夹是否存在，如果不存在则创建
                    {
                        Directory.CreateDirectory(directPath);
                    }
                    directPath += string.Format(@"\{0}_Log.log", DateTime.Now.ToString("yyyy-MM-dd"));

                    sw = !File.Exists(directPath) ? File.CreateText(directPath) : File.AppendText(directPath);
                    //判断文件是否存在如果不存在则创建，如果存在则添加。

                    //把异常信息输出到文件
                    sw.WriteLine(string.Concat('[', DateTime.Now.ToString(), "] Tag:" + Tag));
                    sw.WriteLine("异常信息：" + ex.Message);
                    sw.WriteLine("异常对象：" + ex.Source);
                    sw.WriteLine("调用堆栈：\n" + ex.StackTrace.Trim());
                    sw.WriteLine("触发方法：" + ex.TargetSite);
                    sw.WriteLine("***********************************************************************");
                    sw.WriteLine();
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Flush();
                        sw.Dispose();
                        sw = null;
                    }
                }
            }
        }

        public static void WriteSucceed(string txt)
        {
            StreamWriter sw = null;
            try
            {
                string directPath = ConfigurationManager.AppSettings["LogFilePath"]?.Trim();    //获得文件夹路径
                if (string.IsNullOrEmpty(directPath))
                {
                    directPath = Environment.CurrentDirectory;  //如果日志文件为空，则默认在Debug目录下新建 YYYY-mm-dd_Log.log文件
                }
                if (!Directory.Exists(directPath))   //判断文件夹是否存在，如果不存在则创建
                {
                    Directory.CreateDirectory(directPath);
                }
                directPath += string.Format(@"\{0}_Log.log", "备份成功");

                sw = !File.Exists(directPath) ? File.CreateText(directPath) : File.AppendText(directPath);    //判断文件是否存在如果不存在则创建，如果存在则添加。

                //把异常信息输出到文件
                sw.WriteLine(txt);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Dispose();
                    sw = null;
                }
            }
        }
    }
}