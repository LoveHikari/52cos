using Com.Cos.DAL;
using Com.Cos.IBLL;
using Com.Cos.IDAL;
using Com.Cos.Models;

namespace Com.Cos.BLL
{
    public class ImgService:BaseService<Img>,IImgService
    {
        public ImgService() : base(RepositoryFactory.ImgRepository)
        {
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="id">图片id</param>
        /// <returns>实体</returns>
        public Img Find(int id)
        {
            return CurrentRepository.Find(s => s.Id == id);
        }

        public Img Find(string md5)
        {
            return CurrentRepository.Find(s => s.Md5 == md5);
        }
    }
}