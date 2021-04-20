using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Cos.Bll;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Web.Service.HomeManage
{
    /// <summary>
    /// UploadImgs 的摘要说明
    /// 上传图片
    /// </summary>
    public class UploadImgs : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string img = context.Request.Form["b"]; //原图base64
            string img2 = context.Request.Form["b2"]; //缩略图base64
            string s = "{\"status\":\"error\"}";

            //获取时间戳
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            Random ro = new Random();
            string tt = Convert.ToInt64(ts.TotalSeconds).ToString() + ro.Next();

            ImgEntity imgEntity = new ImgEntity();
            imgEntity.ImgUrl = UploadFile.UploadImg(img, "Upload\\COS\\", tt);
            imgEntity.addtime = DateTime.Now;
            imgEntity.Status = 1;
            if ((imgEntity.ImgId = ImgBll.Instance.Add(imgEntity)) > 0)
            {
                SmallImgEntity smallImgEntity = new SmallImgEntity();
                smallImgEntity.ImgUrl = UploadFile.UploadImg(img2, "Upload\\COS\\", tt+"320x180");
                smallImgEntity.addtime = DateTime.Now;
                smallImgEntity.Status = 1;
                if ((smallImgEntity.ImgId = SmallImgBll.Instance.Add(smallImgEntity)) > 0)
                {
                    s = "{\"status\":\"success\",\"imgid\":\""+imgEntity.ImgId+"\",\"img2id\":\""+smallImgEntity.ImgId+"\",\"img\":\""+imgEntity.ImgUrl.Replace("\\","\\\\")+"\",\"img2\":\""+smallImgEntity.ImgUrl.Replace("\\", "\\\\") + "\"}";
                }
                else
                {
                    s = "{\"status\":\"error\"}";
                }
            }
            else
            {
                s = "{\"status\":\"error\"}";
            }


            context.Response.ContentType = "text/plain";
            context.Response.Write(s);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}