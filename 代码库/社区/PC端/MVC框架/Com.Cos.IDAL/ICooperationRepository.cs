using System;
using System.Linq;
using System.Linq.Expressions;
using Com.Cos.Models;

namespace Com.Cos.IDAL
{
    public interface ICooperationRepository : IBaseRepository<Cooperation>
    {
        /// <summary>
        /// 查找分页数据列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <returns></returns>
        IQueryable<dynamic> FindPageList(int pageIndex, int pageSize, out int totalRecord);

        /// <summary>
        /// 查询前几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        object FindList(int top);
    }
}