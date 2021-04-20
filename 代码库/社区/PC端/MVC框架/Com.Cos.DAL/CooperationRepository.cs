using System;
using System.Linq;
using System.Linq.Expressions;
using Com.Cos.Common;
using Com.Cos.IDAL;
using Com.Cos.Models;

namespace Com.Cos.DAL
{
    public class CooperationRepository : BaseRepository<Cooperation>, ICooperationRepository
    {
        /// <summary>
        /// 查找分页数据列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <returns></returns>
        public IQueryable<dynamic> FindPageList(int pageIndex, int pageSize, out int totalRecord)
        {
            var list = from c in NContext.Cooperations
                    join u in NContext.Members on c.UserId equals u.User_id.ToString()
                    where c.Status == 1
                    orderby c.ReleaseTime descending 
                    select new
                    {
                        Id = c.Id,
                        Cover = c.Cover,
                        Cont = c.Cont,
                        Nickname = u.nickname,
                        Portrait = u.Portrait,
                        ReleaseTime = c.ReleaseTime,
                        Title = c.Title,
                        Will = c.Will,
                        ImgList = c.ImgList
                    };
            totalRecord = list.Count();
            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return list;
        }

        /// <summary>
        /// 查询前几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public object FindList(int top)
        {
            var list = from c in NContext.Cooperations
                       join u in NContext.Members on c.UserId equals u.User_id.ToString()
                       where c.Status == 1
                       orderby c.ReleaseTime descending
                       select new
                       {
                           Id = c.Id,
                           Cover = c.Cover,
                           Cont = c.Cont,
                           Nickname = u.nickname,
                           Portrait = u.Portrait,
                           ReleaseTime = c.ReleaseTime,
                           Title = c.Title,
                           Will = c.Will,
                           ImgList = c.ImgList,
                           Address = c.Address,
                           Budget = c.RMBBudget,
                           EnrollEnd = c.EnrollEnd
                       };
            return list.Take(top).AsEnumerable().Select(g => g.ToDynamic());
        }
    }
}