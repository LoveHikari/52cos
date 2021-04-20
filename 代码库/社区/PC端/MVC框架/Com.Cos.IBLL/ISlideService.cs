using System;
using System.Linq;
using System.Linq.Expressions;
using Com.Cos.Models;

namespace Com.Cos.IBLL
{
    public interface ISlideService : IBaseService<Slide>
    {

        /// <summary>
        /// 查找首页轮播列表
        /// </summary>
        /// <returns></returns>
        IQueryable<Slide> Find(int sign);
    }
}