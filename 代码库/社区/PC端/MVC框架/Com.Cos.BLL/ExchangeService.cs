using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Com.Cos.Common;
using Com.Cos.DAL;
using Com.Cos.IBLL;
using Com.Cos.IDAL;
using Com.Cos.Models;

namespace Com.Cos.BLL
{
    public class ExchangeService : BaseService<Exchange>, IExchangeService
    {
        public ExchangeService() : base(RepositoryFactory.ExchangeRepository)
        {
        }
        /// <summary>
        /// 查询前几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public IEnumerable<dynamic> FindList(int top)
        {
            return (IEnumerable<dynamic>)((IExchangeRepository)CurrentRepository).FindList(top);
        }
        /// <summary>
        /// 随机查询前几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public IEnumerable<dynamic> FindRanList(int top)
        {
            return (IEnumerable<dynamic>)((IExchangeRepository)CurrentRepository).FindRanList(top);
        }
        /// <summary>
        /// 根据id获得实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Exchange Find(int id)
        {
            return CurrentRepository.Find(ex => ex.Id == id);
        }
        /// <summary>
        /// 查找分页数据列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="examineId">兑换状态id</param>
        /// <param name="classId">兑换分类id</param>
        /// <param name="totalRecord">总记录数</param>
        /// <returns></returns>
        public IQueryable<dynamic> FindPageList(int pageIndex, int pageSize,string examineId,string classId, out int totalRecord)
        {
            return ((IExchangeRepository)CurrentRepository).FindPageList(pageIndex, pageSize, examineId, classId, out totalRecord);
        }

        public DataTable GetAllExchange()
        {
            return ((IExchangeRepository) CurrentRepository).GetAllExchange();

        }
    }
}