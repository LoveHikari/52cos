using System;
using System.IO;

namespace Com.Cos.Utility
{
    public class UploadFile
    {
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="img">base64</param>
        /// <returns>图片存放路径</returns>
        public static string UploadImg(string img, string path)
        {
            
            string ext = "";
            string[] str = img.Split(',');
            if (str[0].IndexOf("image/jpeg") > 0)
            {
                ext = ".jpg";
            }
            else if (str[0].IndexOf("image/gif") > 0)
            {
                ext = ".gif";
            }
            else if (str[0].IndexOf("image/png") > 0)
            {
                ext = ".png";
            }
            //获取时间戳
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            Random ro = new Random();
            string tt = Convert.ToInt64(ts.TotalSeconds).ToString() + ro.Next();
            // 生成的文件名  
            string photo = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + path + tt + ext;
            // 生成文件  
            FileStream fs = new FileStream(photo, FileMode.Create);
            byte[] array = Convert.FromBase64String(str[1]);
            fs.Write(array, 0, array.Length);
            fs.Close();
            return "\\" + path + tt + ext;
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="img">base64</param>
        /// <param name="path">路径</param>
        /// <param name="fileName">文件名</param>
        /// <returns>图片存放路径</returns>
        public static string UploadImg(string img, string path, string fileName)
        {

            string ext = "";
            string[] str = img.Split(',');
            if (str[0].IndexOf("image/jpeg") > 0)
            {
                ext = ".jpg";
            }
            else if (str[0].IndexOf("image/gif") > 0)
            {
                ext = ".gif";
            }
            else if (str[0].IndexOf("image/png") > 0)
            {
                ext = ".png";
            }
            //获取时间戳
            //TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            //Random ro = new Random();
            //string tt = Convert.ToInt64(ts.TotalSeconds).ToString() + ro.Next();
            // 生成的文件名  
            string photo = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + path + fileName + ext;
            // 生成文件  
            FileStream fs = new FileStream(photo, FileMode.Create);
            byte[] array = Convert.FromBase64String(str[1]);
            fs.Write(array, 0, array.Length);
            fs.Close();
            return "\\" + path + fileName + ext;
        }
    }
}