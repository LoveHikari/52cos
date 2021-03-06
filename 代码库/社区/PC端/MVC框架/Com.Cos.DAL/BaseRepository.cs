using Com.Cos.IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Com.Cos.Common;
using System.Collections;

namespace Com.Cos.DAL
{
    /// <summary>
    /// 仓储基类
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected CosDbContext NContext = ContextFactory.GetCurrentContext();

        #region 方法

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        public T Add(T entity)
        {
            NContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
            NContext.SaveChanges();
            return entity;
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>记录数</returns>
        public int Count(Expression<Func<T, bool>> predicate)
        {
            return NContext.Set<T>().Count(predicate);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        public bool Update(T entity)
        {
            NContext.Set<T>().Attach(entity);
            NContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return NContext.SaveChanges() > 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        public bool Delete(T entity)
        {
            NContext.Set<T>().Attach(entity);
            NContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            return NContext.SaveChanges() > 0;
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return NContext.Set<T>().Any(anyLambda);
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>实体</returns>
        public T Find(Expression<Func<T, bool>> whereLambda)
        {
            T entity = NContext.Set<T>().FirstOrDefault<T>(whereLambda);
            return entity;
        }

        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> FindList()
        {
            var list = NContext.Set<T>();
            return list;
        }

        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <param name="whereLamdba">查询表达式</param>
        /// <returns></returns>
        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba)
        {
            var list = NContext.Set<T>().Where(whereLamdba);
            return list;
        }
        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <param name="whereLamdba">查询表达式</param>
        /// <param name="orderName">排序名称</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            var list = NContext.Set<T>().Where(whereLamdba);
            list = OrderBy(list, orderName, isAsc);
            return list;
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
        public IQueryable<T> FindPageList(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            var list = NContext.Set<T>().Where<T>(whereLamdba);
            totalRecord = list.Count();
            list = OrderBy(list, orderName, isAsc).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);

            return list;
        }


        #endregion

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="source">原IQueryable</param>
        /// <param name="propertyName">排序属性名</param>
        /// <param name="isAsc">是否正序</param>
        /// <returns>排序后的IQueryable<T></returns>
        internal IQueryable<T> OrderBy(IQueryable<T> source, string propertyName, bool isAsc)
        {
            if (source == null) throw new ArgumentNullException("source", "不能为空");
            if (string.IsNullOrEmpty(propertyName)) return source;
            var parameter = Expression.Parameter(source.ElementType);
            var property = Expression.Property(parameter, propertyName);
            if (property == null) throw new ArgumentNullException("propertyName", "属性不存在");
            var lambda = Expression.Lambda(property, parameter);
            var methodName = isAsc ? "OrderBy" : "OrderByDescending";
            var resultExpression = Expression.Call(typeof(Queryable), methodName, new Type[] { source.ElementType, property.Type }, source.Expression, Expression.Quote(lambda));
            return source.Provider.CreateQuery<T>(resultExpression);
        }


    }
}