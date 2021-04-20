using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Com.Cos.Domain;
using Com.Cos.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure;

namespace Com.Cos.Repository
{
    /// <summary>
    /// 仓储基类
    /// </summary>
    /// <typeparam name="TAggregateRoot">类型</typeparam>
    public class BaseRepository<TAggregateRoot> : IBaseRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        protected IDbContext NContext;

        public BaseRepository(IDbContext dbContext)
        {
            NContext = dbContext;
        }

        #region 方法

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        public TAggregateRoot Add(TAggregateRoot entity)
        {
            NContext.Entry<TAggregateRoot>(entity).State = EntityState.Added;
            int i =  NContext.SaveChanges();
            return entity;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        public async Task<TAggregateRoot> AddAsync(TAggregateRoot entity)
        {
            NContext.Entry<TAggregateRoot>(entity).State = EntityState.Added;
            int i = await NContext.SaveChangesAsync();
            return entity;
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>记录数</returns>
        public int Count(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return NContext.Set<TAggregateRoot>().Count(predicate);
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>记录数</returns>
        public async Task<int> CountAsync(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return await NContext.Set<TAggregateRoot>().CountAsync(predicate);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        public bool Update(TAggregateRoot entity)
        {
            NContext.Set<TAggregateRoot>().Attach(entity);
            NContext.Entry<TAggregateRoot>(entity).State = EntityState.Modified;
            return  NContext.SaveChanges() > 0;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        public async Task<bool> UpdateAsync(TAggregateRoot entity)
        {
            NContext.Set<TAggregateRoot>().Attach(entity);
            NContext.Entry<TAggregateRoot>(entity).State = EntityState.Modified;
            return await NContext.SaveChangesAsync() > 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        public  bool Delete(TAggregateRoot entity)
        {
            NContext.Set<TAggregateRoot>().Attach(entity);
            NContext.Entry<TAggregateRoot>(entity).State = EntityState.Deleted;
            return  NContext.SaveChanges() > 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        public async Task<bool> DeleteAsync(TAggregateRoot entity)
        {
            NContext.Set<TAggregateRoot>().Attach(entity);
            NContext.Entry<TAggregateRoot>(entity).State = EntityState.Deleted;
            return await NContext.SaveChangesAsync() > 0;
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        public bool Exist(Expression<Func<TAggregateRoot, bool>> anyLambda)
        {
            return NContext.Set<TAggregateRoot>().Any(anyLambda);
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        public async Task<bool> ExistAsync(Expression<Func<TAggregateRoot, bool>> anyLambda)
        {
            return await NContext.Set<TAggregateRoot>().AnyAsync(anyLambda);
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>实体</returns>
        public TAggregateRoot Find(Expression<Func<TAggregateRoot, bool>> whereLambda)
        {
            TAggregateRoot entity = NContext.Set<TAggregateRoot>().FirstOrDefault<TAggregateRoot>(whereLambda);
            return entity;
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>实体</returns>
        public async Task<TAggregateRoot> FindAsync(Expression<Func<TAggregateRoot, bool>> whereLambda)
        {
            TAggregateRoot entity = await NContext.Set<TAggregateRoot>().FirstOrDefaultAsync<TAggregateRoot>(whereLambda);
            return entity;
        }
        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<TAggregateRoot> FindList()
        {
            var list = NContext.Set<TAggregateRoot>();
            return list;
        }

        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <param name="whereLamdba">查询表达式</param>
        /// <returns></returns>
        public IQueryable<TAggregateRoot> FindList(Expression<Func<TAggregateRoot, bool>> whereLamdba)
        {
            var list = NContext.Set<TAggregateRoot>().Where(whereLamdba);
            return list;
        }
        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <param name="whereLamdba">查询表达式</param>
        /// <param name="orderName">排序名称</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        public IQueryable<TAggregateRoot> FindList(Expression<Func<TAggregateRoot, bool>> whereLamdba, string orderName, bool isAsc)
        {
            var list = NContext.Set<TAggregateRoot>().Where(whereLamdba);
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
        public IQueryable<TAggregateRoot> FindPageList(int pageIndex, int pageSize, Expression<Func<TAggregateRoot, bool>> whereLamdba, string orderName, bool isAsc)
        {
            var list = FindPageList(pageIndex, pageSize, out _, whereLamdba, orderName, isAsc);
            return list;
        }
        /// <summary>
        /// 查找分页数据列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="whereLamdba">查询表达式</param>
        /// <param name="orderName">排序名称</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns>数据,数据总数,总页数,上一页,下一页</returns>
        public (IQueryable<TAggregateRoot> list, int totalRecord, int pageCount, int prevPage, int nextPage) FindPageList2(int pageIndex, int pageSize,
            Expression<Func<TAggregateRoot, bool>> whereLamdba, string orderName, bool isAsc)
        {
            int totalRecord;
            var list = FindPageList(pageIndex, pageSize, out totalRecord,  whereLamdba,  orderName, isAsc);
            int pageCount = Convert.ToInt32(Math.Ceiling(totalRecord / Convert.ToDouble(pageSize)));
            int prevPage = pageIndex > 0 ? pageIndex - 1 : 0;
            int nextPage = pageIndex < pageCount ? pageIndex + 1 : 0;
            return (list, totalRecord, pageCount, prevPage, nextPage);
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
        protected IQueryable<TAggregateRoot> OrderBy(IQueryable<TAggregateRoot> source, string propertyName, bool isAsc)
        {
            if (source == null) throw new ArgumentNullException("source", "不能为空");
            if (string.IsNullOrEmpty(propertyName)) return source;
            var parameter = Expression.Parameter(source.ElementType);
            var property = Expression.Property(parameter, propertyName);
            if (property == null) throw new ArgumentNullException("propertyName", "属性不存在");
            var lambda = Expression.Lambda(property, parameter);
            var methodName = isAsc ? "OrderBy" : "OrderByDescending";
            var resultExpression = Expression.Call(typeof(Queryable), methodName, new Type[] { source.ElementType, property.Type }, source.Expression, Expression.Quote(lambda));
            return source.Provider.CreateQuery<TAggregateRoot>(resultExpression);
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
        private IQueryable<TAggregateRoot> FindPageList(int pageIndex, int pageSize, out int totalRecord, Expression<Func<TAggregateRoot, bool>> whereLamdba, string orderName, bool isAsc)
        {
            var list = NContext.Set<TAggregateRoot>().Where<TAggregateRoot>(whereLamdba);
            totalRecord = list.Count();
            list = OrderBy(list, orderName, isAsc).Skip<TAggregateRoot>((pageIndex - 1) * pageSize).Take<TAggregateRoot>(pageSize);

            return list;
        }
    }
}