using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure.Interfaces;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 图片仓储
    /// </summary>
    public class ImgRepository:BaseRepository<Img>,IImgRepository
    {
        public ImgRepository(IDbContext nContext) : base(nContext)
        {
        }
    }
}