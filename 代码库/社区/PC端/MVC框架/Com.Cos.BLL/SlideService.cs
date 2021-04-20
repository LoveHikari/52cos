using System;
using System.Linq;
using System.Linq.Expressions;
using Com.Cos.IBLL;
using Com.Cos.IDAL;
using Com.Cos.Models;
using Com.Cos.DAL;

namespace Com.Cos.BLL
{
    public class SlideService:BaseService<Slide>, ISlideService
    {
        public SlideService() : base(RepositoryFactory.SlideRepository)
        {
        }
        /// <summary>
        /// 查找首页轮播列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<Slide> Find(int sign)
        {
            return CurrentRepository.FindList(s => s.Sign == sign && s.Status == 1, "weight", false);
        }
    }
}