using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

/******************************************************************************************************************
 * 
 * 
 * 标  题： 图片处理类(版本：Version1.0.0)
 * 作  者： YuXiaoWei
 * 日  期： 2016/12/05
 * 修  改：
 * 参  考： 
 * 说  明： 暂无...
 * 备  注： 暂无...
 * 调用示列：
 *
 * 
 * ***************************************************************************************************************/

namespace Com.Cos.Common
{
    /// <summary>
    /// 图片处理类
    /// </summary>
    public class ImageHelper
    {
        #region 图片相关类型转换 http://keleyi.com/a/bjac/7531015d41ae2490.htm http://blog.csdn.net/smartsmile2012/article/details/46799417

        /// <summary>  
        /// 图片转二进制  
        /// </summary>  
        /// <param name="imagePath">图片地址</param>  
        /// <returns>二进制</returns>  
        public static byte[] GetPictureData(string imagePath)
        {
            //根据图片文件的路径使用文件流打开，并保存为byte[]
            using (FileStream fs = new FileStream(imagePath, FileMode.Open))  //可以是其他重载方法
            {
                byte[] byData = new byte[fs.Length];
                fs.Read(byData, 0, byData.Length);
                return byData;
            }
        }
        /// <summary>
        /// 获取Image对象
        /// </summary>
        /// <param name="imagePath">图片地址</param>
        /// <returns></returns>
        public static Image GetImage(string imagePath)
        {
            using (FileStream fs = new FileStream(imagePath, FileMode.Open))  //可以是其他重载方法
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    Image image = Image.FromStream(ms);
                    ms.Flush();
                    return image;
                }
            }
        }
        /// <summary>
        /// 二进制数组转图片对象
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static Image BytesToImage(byte[] bytes)
        {
            if (bytes == null)
                return null;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Image image = Image.FromStream(ms);
                ms.Flush();
                return image;
            }
        }
        /// <summary>
        /// 图片转二进制
        /// </summary>
        /// <param name="image">图片对象</param>  
        /// <returns>二进制</returns>  
        public static byte[] ImageToBytes(System.Drawing.Image image)
        {
            //将Image转换成流数据，并保存为byte[]   
            using (MemoryStream mstream = new MemoryStream())
            {
                image.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] byData = new Byte[mstream.Length];
                mstream.Position = 0;
                mstream.Read(byData, 0, byData.Length);
                mstream.Flush();
                return byData;
            }

        }
        /// <summary>
        /// 图片转二进制
        /// </summary>
        /// <param name="image">图片对象</param>
        /// <param name="imageFormat">后缀名</param>
        /// <returns></returns>
        public static byte[] ImageToBytes(Image image, System.Drawing.Imaging.ImageFormat imageFormat)
        {
            if (image == null) { return null; }
            byte[] data;
            using (MemoryStream ms = new MemoryStream())
            {
                using (Bitmap bitmap = new Bitmap(image))
                {
                    bitmap.Save(ms, imageFormat);
                    ms.Position = 0;
                    data = new byte[ms.Length];
                    ms.Read(data, 0, Convert.ToInt32(ms.Length));
                    ms.Flush();
                }
            }
            return data;
        }
        /// <summary>
        /// Bitmap转Image
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static System.Drawing.Image BitmapToImage(System.Drawing.Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, bitmap.RawFormat);
                Image image = Image.FromStream(ms);
                ms.Flush();
                return image;
            }
        }
        /// <summary>
        /// byte[] 转换 Bitmap
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static Bitmap BytesToBitmap(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                return new Bitmap((Image)new Bitmap(stream));
            }
        }
        /// <summary>
        /// Bitmap转byte[]
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static byte[] BitmapToBytes(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, bitmap.RawFormat);
                byte[] byteImage = ms.ToArray();
                ms.Flush();
                return byteImage;
            }
        }

        #endregion

        #region 旋转 http://blog.csdn.net/jayzai/article/details/50332913 

        /// <summary>  
        /// 获取原图旋转角度(IOS和Android相机拍的照片)  
        /// </summary>  
        /// <param name="path">图片路径</param>
        /// <returns></returns>
        public static int ReadPictureDegree(string path)
        {
            int rotate = 0;
            using (var image = System.Drawing.Image.FromFile(path))
            {
                foreach (var prop in image.PropertyItems)
                {
                    if (prop.Id == 0x112)
                    {
                        if (prop.Value[0] == 6)
                            rotate = 90;
                        if (prop.Value[0] == 8)
                            rotate = -90;
                        if (prop.Value[0] == 3)
                            rotate = 180;
                        prop.Value[0] = 1;
                    }
                }
            }
            return rotate;
        }
        /// <summary>  
        /// 获取原图旋转角度(IOS和Android相机拍的照片)  
        /// </summary>  
        /// <param name="image">图片对象</param>
        /// <returns></returns>
        public static int ReadPictureDegree(Image image)
        {
            int rotate = 0;
            foreach (var prop in image.PropertyItems)
            {
                if (prop.Id == 0x112)
                {
                    if (prop.Value[0] == 6)
                        rotate = 90;
                    if (prop.Value[0] == 8)
                        rotate = -90;
                    if (prop.Value[0] == 3)
                        rotate = 180;
                    prop.Value[0] = 1;
                }
            }

            return rotate;
        }

        /// <summary>
        /// 旋转
        /// </summary>
        /// <param name="oldPath">原图路径</param>
        /// <param name="newPath">要保存的路径</param>
        /// <param name="rotateFlipType">图像旋转量</param>  
        /// <returns></returns>  
        public static void KiRotate(string oldPath, string newPath, RotateFlipType rotateFlipType)
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(oldPath))
                {
                    bitmap.RotateFlip(rotateFlipType);
                    bitmap.Save(newPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 旋转
        /// </summary>
        /// <param name="original">原图对象</param>
        /// <param name="newPath">要保存的路径</param>
        /// <param name="rotateFlipType">图像旋转量</param>  
        /// <returns></returns>  
        public static void KiRotate(Image original, string newPath, RotateFlipType rotateFlipType)
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(original))
                {
                    bitmap.RotateFlip(rotateFlipType);
                    bitmap.Save(newPath);
                }
            }
            catch (Exception ex)
            {
                WriteLogHelper.WriteError(ex);
                throw;
            }
        }

        #endregion

        #region 调整大小 https://gist.github.com/nuintun/6f53784464d5ecda1be9

        /// <summary>
        /// Resize图片
        /// </summary>
        /// <param name="original">原始Bitmap</param>
        /// <param name="width">新的宽度</param>
        /// <param name="height">新的高度</param>
        /// <param name="Mode">保留着，暂时未用</param>
        /// <returns>处理以后的图片</returns>
        public static Bitmap ResizeImage(Bitmap original, int width, int height, int Mode)
        {
            try
            {
                Bitmap b = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(b);

                // 插值算法的质量
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(original, new Rectangle(0, 0, width, height), new Rectangle(0, 0, original.Width, original.Height), GraphicsUnit.Pixel);
                g.Dispose();

                return b;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 缩放图片
        /// </summary>
        /// <param name="original">原始图片</param>
        /// <param name="width">新的宽度</param>
        /// <param name="height">新的高度</param>
        /// <returns>处理以后的图片</returns>
        public static Bitmap ResizeImage(Bitmap original, int width, int height)
        {
            try
            {
                // 生成新画布
                Bitmap image = new Bitmap(width, height);
                // 获取GDI+绘图图画
                Graphics graph = Graphics.FromImage(image);
                // 插值算法的质量
                graph.CompositingQuality = CompositingQuality.HighQuality;
                graph.SmoothingMode = SmoothingMode.HighQuality;
                graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // 缩放图片
                graph.DrawImage(original, new Rectangle(0, 0, width, height),
                    new Rectangle(0, 0, original.Width, original.Height), GraphicsUnit.Pixel);
                // 保存绘制结果
                graph.Save();
                // 释放画笔内存
                graph.Dispose();
                // 返回缩放图片
                return image;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 缩放并补白图片
        /// </summary>
        /// <param name="original">原始图片</param>
        /// <param name="width">新的宽度</param>
        /// <param name="height">新的高度</param>
        /// <param name="margin">补白宽度</param>
        /// <returns>处理以后的图片</returns>
        public static Bitmap FillerImage(Bitmap original, int width, int height, int margin)
        {
            try
            {
                // 生成新画布
                Bitmap image = new Bitmap(original.Width + 2 * margin, original.Height + 2 * margin);
                // 获取GDI+绘图图画
                Graphics graph = Graphics.FromImage(image);
                // 定义画笔
                SolidBrush brush = new SolidBrush(Color.White);
                // 绘制背景色
                graph.FillRectangle(brush, new Rectangle(0, 0, image.Width, image.Height));
                // 叠加图片
                graph.DrawImageUnscaled(original, margin, margin);
                // 保存绘制结果
                graph.Save();
                // 释放GDI+绘图图画内存
                graph.Dispose();
                // 释放画笔内存
                brush.Dispose();
                // 缩放并返回处理后的图片
                return ResizeImage(image, width, height);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 剪裁 http://blog.csdn.net/ki1381/article/details/1584804

        /// <summary>
        /// 剪裁 -- 用GDI+
        /// </summary>
        /// <param name="b">原始Bitmap</param>
        /// <param name="startX">开始坐标X</param>
        /// <param name="startY">开始坐标Y</param>
        /// <param name="iWidth">宽度</param>
        /// <param name="iHeight">高度</param>
        /// <returns>剪裁后的Bitmap，失败返回null</returns>
        public static Bitmap KiCut(Bitmap b, int startX, int startY, int iWidth, int iHeight)
        {
            if (b == null)
            {
                return null;
            }

            int w = b.Width;
            int h = b.Height;

            if (startX >= w || startY >= h)
            {
                return null;
            }

            if (startX + iWidth > w)
            {
                iWidth = w - startX;
            }

            if (startY + iHeight > h)
            {
                iHeight = h - startY;
            }

            try
            {
                Bitmap bmpOut = new Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb);

                Graphics g = Graphics.FromImage(bmpOut);
                g.DrawImage(b, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(startX, startY, iWidth, iHeight), GraphicsUnit.Pixel);
                g.Dispose();

                return bmpOut;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        /// <summary>
        /// 将图片对象保存为图片文件
        /// </summary>
        /// <param name="image">图片对象</param>
        /// <param name="filePath">要保存的路径，可以是绝对路径或相对路径</param>
        /// <param name="imageFormat">要保存的图片格式，默认为jpg</param>
        public static void SaveImage(Bitmap image, string filePath, ImageFormat imageFormat = null)
        {
            string dir = System.IO.Path.GetDirectoryName(filePath);
            //如果文件夹不存在，则创建
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            image.Save(fs, imageFormat ?? ImageFormat.Jpeg);
            fs.Close();
            image.Dispose();
        }

        #region 生成二维码 

        ///// <summary>
        ///// 生成二维码图片
        ///// </summary>
        ///// <param name="strCode">要生成的文字或者数字，支持中文。如： "4408810820 深圳－广州" 或者：4444444444</param>
        ///// <param name="size">大小尺寸</param>
        ///// <returns>二维码图片</returns>
        ///// <remarks>http://www.cnblogs.com/judy0605/p/3340350.html http://www.cnblogs.com/jys509/p/4592539.html http://blog.csdn.net/lybwwp/article/details/18444369 </remarks>
        //public Bitmap CreateQrCode(string strCode, int size)
        //{
        //    //创建二维码生成类  
        //    QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
        //    //设置编码模式  ,三种模式：BYTE ，ALPHA_NUMERIC，NUMERIC
        //    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
        //    //设置编码测量度(每个小方格的宽度)，比如4 
        //    qrCodeEncoder.QRCodeScale = size;
        //    //设置编码版本(二维码版本号)，比如8
        //    //字符串较长的情况下，用ThoughtWorks.QRCode生成二维码时出现“索引超出了数组界限”的错误。
        //    //解决方法：将 QRCodeVersion 改为0。
        //    qrCodeEncoder.QRCodeVersion = 0;
        //    //设置编码错误纠正，大小：L M Q H
        //    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
        //    //生成二维码图片
        //    System.Drawing.Bitmap image = qrCodeEncoder.Encode(strCode);
        //    return image;
        //}

        #endregion

        #region 验证码

        /// <summary>
        /// 创建验证码图片
        /// </summary>
        /// <param name="verificationText">验证码字符串</param>
        /// <returns>图片</returns>
        /// <remarks>http://www.cnblogs.com/novawu/archive/2010/04/16/1713445.html</remarks>
        public static Bitmap CreateVerificationImage(string verificationText)
        {
            int randAngle = 45; //随机转动角度
            int mapwidth = (int)(verificationText.Length * 16);
            Bitmap map = new Bitmap(mapwidth, 22);//创建图片背景
            Graphics graph = Graphics.FromImage(map);
            graph.Clear(Color.AliceBlue);//清除画面，填充背景
            graph.DrawRectangle(new Pen(Color.Black, 0), 0, 0, map.Width - 1, map.Height - 1);//画一个边框
            //graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//模式

            Random rand = new Random();

            //背景噪点生成
            Pen blackPen = new Pen(Color.LightGray, 0);
            for (int i = 0; i < 50; i++)
            {
                int x = rand.Next(0, map.Width);
                int y = rand.Next(0, map.Height);
                graph.DrawRectangle(blackPen, x, y, 1, 1);
            }


            //验证码旋转，防止机器识别
            char[] chars = verificationText.ToCharArray();//拆散字符串成单字符数组

            //文字距中
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            //定义颜色
            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
            //定义字体
            string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };
            int cindex = rand.Next(7);

            for (int i = 0; i < chars.Length; i++)
            {
                int findex = rand.Next(5);

                Font f = new System.Drawing.Font(font[findex], 14, System.Drawing.FontStyle.Bold);//字体样式(参数2为字体大小)
                Brush b = new System.Drawing.SolidBrush(c[cindex]);
                //Brush b = new LinearGradientBrush(new Point(0, 0), new Point(1, 1), Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)));  //使字变彩色

                Point dot = new Point(14, 14);
                //graph.DrawString(dot.X.ToString(),fontstyle,new SolidBrush(Color.Black),10,150);//测试X坐标显示间距的
                float angle = rand.Next(-randAngle, randAngle);//转动的度数

                graph.TranslateTransform(dot.X, dot.Y);//移动光标到指定位置
                graph.RotateTransform(angle);
                graph.DrawString(chars[i].ToString(), f, b, 1, 1, format);
                //graph.DrawString(chars[i].ToString(),fontstyle,new SolidBrush(Color.Blue),1,1,format);
                graph.RotateTransform(-angle);//转回去
                graph.TranslateTransform(-2, -dot.Y);//移动光标到指定位置，每个字符紧凑显示，避免被软件识别
            }
            //生成图片
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            map.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            graph.Dispose();
            ms.Dispose();
            return map;
        }
        /// <summary>
        /// 创建验证码图片
        /// </summary>
        /// <param name="verificationText">验证码字符串</param>
        /// <param name="width">图片宽度,95</param>
        /// <param name="height">图片长度,30</param>
        /// <returns>图片</returns>
        public static Bitmap CreateVerificationImage(string verificationText, int width, int height)
        {
            int randAngle = 45; //随机转动角度
            Font font = new Font("Arial", 14, FontStyle.Bold);
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            //文字距中
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            //随机数产生器
            Random random = new Random();
            g.Clear(Color.White);
            Random rand = new Random();
            for (int i = 0; i < verificationText.Length; i++)
            {
                Point dot = new Point(14, 14);
                Brush brush = new LinearGradientBrush(new Point(0, 0), new Point(1, 1), Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)), Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));
                float angle = rand.Next(-randAngle, randAngle);//转动的度数
                g.TranslateTransform(dot.X, dot.Y);//移动光标到指定位置
                g.RotateTransform(angle);
                g.DrawString(verificationText[i].ToString(), font, brush, 1, 1, format);
                g.RotateTransform(-angle);//转回去
                g.TranslateTransform(-2, -dot.Y);//移动光标到指定位置，每个字符紧凑显示，避免被软件识别

            }
            g.Dispose();
            return bitmap;
        }
        #endregion
    }
}