using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using Com.Cos.Models;

namespace Com.Cos.IDAL
{
    public interface IExchangeRepository :IBaseRepository<Exchange>
    {
        /// <summary>
        /// 查询前几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        object FindList(int top);
        /// <summary>
        /// 随机查询前几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        object FindRanList(int top);
        /// <summary>
        /// 查找分页数据列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="examineId"></param>
        /// <param name="classId"></param>
        /// <param name="totalRecord">总记录数</param>
        /// <returns></returns>
        IQueryable<dynamic> FindPageList(int pageIndex, int pageSize, string examineId, string classId, out int totalRecord);

        DataTable GetAllExchange();
    }
}