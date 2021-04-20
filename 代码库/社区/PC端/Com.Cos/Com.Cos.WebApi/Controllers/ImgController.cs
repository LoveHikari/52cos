using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Config;
using Com.Cos.Infrastructure.Tencent;
using Com.Cos.WebApi.ResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Com.Cos.WebApi.Controllers
{
    /// <summary>
    /// 图片控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/Imgs")]
    public class ImgController : Controller
    {
        private readonly IImgService _imgService;
        private readonly ICosFileStatService _cosFileStatService;

        public ImgController(IImgService imgService,ICosFileStatService cosFileStatService)
        {
            _imgService = imgService;
            _cosFileStatService = cosFileStatService;
        }

        /// <summary>
        /// 保存图片，并返回id
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        // POST /api/Imgs
        [HttpPost, MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Post([FromForm]List<IFormFile> files)
        {
            MessageBase2 result = new MessageBase2();
            StringBuilder sb = new StringBuilder();
            foreach (IFormFile file in files)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Value.Trim('"');
                var ext = System.IO.Path.GetExtension(fileName);
                fileName = SysHelper.RandomFileName() + ext; //文件名

                Stream st = file.OpenReadStream();
                string md5 = System.DEncryptHelper.MD5Encrypt(st);
                int id = await _imgService.FindAsync(md5);
                if (id > 0)
                {
                    sb.Append(id + ",");
                    continue;
                }
                st.Seek(0L, SeekOrigin.Begin);
                Image image = Image.FromStream(st);
                int width = image.Width;  //图片宽度
                int height = image.Height;  //图片高度

                int thumbWidth = 320;  //缩略图宽度
                double prop = thumbWidth.ToDouble() / width;
                int thumbHeight = Math.Ceiling(height * prop).ToInt32();  //缩略图高度
                QCloudHelper qCloud = new QCloudHelper();

                var b = qCloud.UploadFile("/upload/photo/", fileName, st);
                var cosDto = new CosFileStatDto()
                {
                    AccessUrl = b.AccessUrl,
                    Url = b.Url,
                    SourceUrl = b.SourceUrl,
                    ResourcePath = b.ResourcePath
                };
                await _cosFileStatService.AddAsync(cosDto);

                ImgDto dto = new ImgDto()
                {
                    ImgPath = OtherConfig.ImgWebDir + fileName,
                    ThumbPath = OtherConfig.ImgWebDir + fileName + "/320",
                    Md5 = md5,
                    Width = width,
                    Height = height,
                    ThumbWidth = thumbWidth,
                    ThumbHeight = thumbHeight
                };
                id = await _imgService.AddAsync(dto);
                sb.Append(id + ",");
            }

            result.Data =  sb.ToString().TrimEnd(',');
            result.Success = Permanent.SUCCESS;
            return result;
        }
    }
}