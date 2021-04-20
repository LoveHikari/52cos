using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Com.Cos.BLL;
using Com.Cos.Common;
using Com.Cos.IBLL;
using Com.Cos.Models;

namespace Com.Cos.Web.Controllers
{
    public class ImgController : Controller
    {
        private IImgService _imgService;

        public ImgController()
        {
            _imgService = new ImgService();
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: Img/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string bigImgs = collection.Get("BigImg");  //大图base64，以逗号隔开
                string smallImgs = collection.Get("SmallImg");  //缩略图base64，以逗号隔开
                List<string> bigImgList = bigImgs.Split("data:", StringSplitOptions.RemoveEmptyEntries).ToList();  //大图base64列表，缺少头部data:
                List<string> smallImgList = smallImgs.Split("data:", StringSplitOptions.RemoveEmptyEntries).ToList();  //缩略图base64列表，缺少头部data:
                string imgIds = "";
                for (int i = 0; i < bigImgList.Count; i++)
                {
                    string img1 = "data:" + bigImgList[i].TrimEnd(',');
                    string img2 = "data:" + smallImgList[i].TrimEnd(',');
                    string md5 = Com.Cos.Common.DEncryptUtils.MD5Encrypt(img1);
                    //判断图片是否已经存在,如果已经保存则直接使用不再保存
                    Img oImg = _imgService.Find(md5);
                    if (oImg == null)
                    {
                        //获取文件名，文件名=时间戳+随机数
                        int timeStamp = Com.Cos.Common.DateTimeHelper.ConvertDateTimeInt(DateTime.Now);
                        Random ro = new Random();
                        string tt = timeStamp.ToString() + ro.Next();  // 文件名
                        oImg = new Img
                        {
                            ImgBigUrl = Com.Cos.Common.UploadFile.UploadImg(img1, "D:\\ftp\\web\\img.52cos.cn", "upload\\photo\\", tt),
                            ImgSmallUrl = Com.Cos.Common.UploadFile.UploadImg(img2, "D:\\ftp\\web\\img.52cos.cn", "upload\\photo\\", tt + "320x180"),
                            Md5 = md5,
                            AddTime = DateTime.Now,
                            Status = 1
                        };
                        oImg = _imgService.Add(oImg);
                    }

                    imgIds += oImg.Id + ",";
                    System.Threading.Thread.Sleep(1);
                }

                return Json(new Dictionary<string, string>() { { "status", "success" }, { "message", "图片保存成功" }, { "imgIds", imgIds.TrimEnd(',') } });
            }
            catch (Exception ex)
            {
                Com.Cos.Common.WriteLogHelper.WriteError(ex);
                return Json(new Dictionary<string, string>() { { "status", "error" }, { "message", ex.Message } });
            }
        }

    }
}
