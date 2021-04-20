using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Com.Cos.Models;

namespace Com.Cos.IBLL
{
    public interface IExchangeService:IBaseService<Exchange>
    {
        /// <summary>
        /// 查询前几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        IEnumerable<dynamic> FindList(int top);

        /// <summary>
        /// 随机查询前几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        IEnumerable<dynamic> FindRanList(int top);
        /// <summary>
        /// 根据id获得实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Exchange Find(int id);
        /// <summary>
        /// 查找分页数据列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="examineId">兑换状态id</param>
        /// <param name="classId">兑换分类id</param>
        /// <param name="totalRecord">总记录数</param>
        /// <returns></returns>
        IQueryable<dynamic> FindPageList(int pageIndex, int pageSize, string examineId, string classId, out int totalRecord);

        DataTable GetAllExchange();
    }
}