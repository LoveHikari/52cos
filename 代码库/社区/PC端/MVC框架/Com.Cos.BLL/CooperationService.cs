using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Com.Cos.DAL;
using Com.Cos.IBLL;
using Com.Cos.IDAL;
using Com.Cos.Models;

namespace Com.Cos.BLL
{
    public class CooperationService : BaseService<Cooperation>, ICooperationService
    {
        public CooperationService() : base(RepositoryFactory.CooperationRepository)
        {
        }

        /// <summary>
        /// 查找分页数据列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <returns></returns>
        public IQueryable<dynamic> FindPageList(int pageIndex, int pageSize, out int totalRecord)
        {
            return ((CooperationRepository) CurrentRepository).FindPageList(pageIndex, pageSize, out totalRecord);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="id">合作id</param>
        /// <returns>实体</returns>
        public Cooperation Find(int id)
        {
            return CurrentRepository.Find(coo => coo.Id == id);
        }

        /// <summary>
        /// 查询前几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public IEnumerable<dynamic> FindList(int top)
        {
            return (IEnumerable<dynamic>)((CooperationRepository)CurrentRepository).FindList(top);
        }
    }
}