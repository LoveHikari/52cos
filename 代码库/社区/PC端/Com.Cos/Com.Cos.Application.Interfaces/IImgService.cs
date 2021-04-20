using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 缩略图业务接口
    /// </summary>
    public interface IImgService : IBaseService<Img>
    {
        Task<int> FindAsync(string md5);
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<int> AddAsync(ImgDto dto);
    }
}