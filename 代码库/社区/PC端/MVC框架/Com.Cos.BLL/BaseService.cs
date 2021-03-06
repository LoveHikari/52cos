using System;
using System.Collections;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Com.Cos.IBLL;
using Com.Cos.IDAL;

namespace Com.Cos.BLL
{
    /// <summary>
    /// 服务基类
    /// <remarks>创建：2014.02.03</remarks>
    /// </summary>
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        protected IBaseRepository<T> CurrentRepository { get; set; }

        protected BaseService(IBaseRepository<T> currentRepository) { CurrentRepository = currentRepository; }

        #region 方法

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        public virtual T Add(T entity) { return CurrentRepository.Add(entity); }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        public virtual bool Update(T entity) { return CurrentRepository.Update(entity); }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        public virtual bool Delete(T entity) { return CurrentRepository.Delete(entity); }
        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>记录数</returns>
        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            return CurrentRepository.Count(predicate);
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        public virtual bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return CurrentRepository.Exist(anyLambda);
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>实体</returns>
        public virtual T Find(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentRepository.Find(whereLambda);
        }

        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> FindList()
        {
            return CurrentRepository.FindList();
        }

        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <param name="whereLamdba">查询表达式</param>
        /// <returns></returns>
        public virtual IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba)
        {
            return CurrentRepository.FindList(whereLamdba);
        }
        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <param name="whereLamdba">查询表达式</param>
        /// <param name="orderName">排序名称</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        public virtual IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            return CurrentRepository.FindList(whereLamdba, orderName, isAsc);
        }
        /// <summary>
        /// 查找分页数据列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="whereLamdba">查询表达式</param>
        /// <param name="orderName">排序名称</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        public virtual IQueryable<T> FindPageList(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, whereLamdba, orderName, isAsc);
        }

        #endregion


    }
}