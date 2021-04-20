using Com.Cos.Models;

namespace Com.Cos.IBLL
{
    public interface IImgService:IBaseService<Img>
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="id">图片id</param>
        /// <returns>实体</returns>
        Img Find(int id);

        Img Find(string md5);
    }
}