using System;

namespace Com.Cos.Application.DTO
{
    public class ImgDto
    {
        public string ImgPath { get; set; }
        public string ThumbPath { get; set; }
        public string Md5 { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int ThumbWidth { get; set; }
        public int ThumbHeight { get; set; }
    }
}