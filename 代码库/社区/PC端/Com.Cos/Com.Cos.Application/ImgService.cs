using System;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Interfaces;
using Com.Cos.Repository;

namespace Com.Cos.Application
{
    /// <summary>
    /// 缩略图业务
    /// </summary>
    public class ImgService : BaseService<Img>, IImgService
    {
        private readonly IImgRepository _imgRepository;
        public ImgService(CosDbContext dbContext) : base(dbContext)
        {
            _imgRepository = RepositoryFactory.CreateObj<ImgRepository>(dbContext);
        }

        public async Task<int> FindAsync(string md5)
        {
            var model = await _imgRepository.FindAsync(i => i.Md5 == md5);
            return model?.Id ?? 0;
        }
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(ImgDto dto)
        {
            var model = new Img()
            {
                ImgBigUrl = dto.ImgPath,
                ImgSmallUrl =dto.ThumbPath,
                Md5 = dto.Md5,
                BigSize = dto.Width + "X" +dto.Height,
                SmallSize = dto.ThumbWidth + "X" + dto.ThumbHeight,
                AddTime = DateTime.Now,
                Status = 1
            };
            model = await _imgRepository.AddAsync(model);
            return model?.Id ?? 0;
        }
    }
}