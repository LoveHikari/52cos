using System;
using System.Configuration;
using System.IO;

namespace Com.Cos.Common
{
    public class UploadFile
    {
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="img">base64</param>
        /// <param name="dir">图片存放目录</param>
        /// <returns>图片存放路径</returns>
        public static string UploadImg(string img, string dir)
        {
            string ext = "";
            string[] str = img.Split(',');
            if (str[0].IndexOf("image/jpeg", StringComparison.Ordinal) > 0)
            {
                ext = ".jpg";
            }
            else if (str[0].IndexOf("image/gif", StringComparison.Ordinal) > 0)
            {
                ext = ".gif";
            }
            else if (str[0].IndexOf("image/png", StringComparison.Ordinal) > 0)
            {
                ext = ".png";
            }
            //获取时间戳
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            Random ro = new Random();
            string tt = Convert.ToInt64(ts.TotalSeconds).ToString() + ro.Next();
            // 生成的文件名  
            string photo = System.IO.Path.Combine(Com.Cos.Models.Config.UploadConfig.Instance.ImgRootPath, dir, tt + ext);
            // 生成文件  
            FileStream fs = new FileStream(photo, FileMode.Create);
            byte[] array = Convert.FromBase64String(str[1]);
            fs.Write(array, 0, array.Length);
            fs.Close();
            return "/" + System.IO.Path.Combine(dir, tt + ext).Replace("\\","/");
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="img">base64</param>
        /// <param name="dir1">要保存的目录,不在返回中的目录部分</param>
        /// <param name="dir2">要保存的目录,返回的路径将从这里开始</param>
        /// <param name="fileName">文件名,不包含后缀名</param>
        /// <returns>图片存放路径</returns>
        public static string UploadImg(string img, string dir1, string dir2, string fileName)
        {

            string ext = "";  //图片后缀名
            string[] str = img.Split(',');
            if (str[0].IndexOf("image/jpeg", StringComparison.CurrentCultureIgnoreCase) > 0)
            {
                ext = ".jpg";
            }
            else if (str[0].IndexOf("image/gif", StringComparison.CurrentCultureIgnoreCase) > 0)
            {
                ext = ".gif";
            }
            else if (str[0].IndexOf("image/png", StringComparison.CurrentCultureIgnoreCase) > 0)
            {
                ext = ".png";
            }

            // 生成最终文件路径 
            string photo = System.IO.Path.Combine(dir1, dir2, fileName + ext);
            if (!System.IO.Directory.Exists(System.IO.Path.Combine(dir1, dir2)))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(dir1, dir2));
            }

            // 生成文件  
            using (FileStream fs = new FileStream(photo, FileMode.Create))
            {
                byte[] array = Convert.FromBase64String(str[1]);
                fs.Write(array, 0, array.Length);
            }
            return ("\\" + System.IO.Path.Combine(dir2, fileName + ext)).Replace("\\", "/");
        }
    }
}