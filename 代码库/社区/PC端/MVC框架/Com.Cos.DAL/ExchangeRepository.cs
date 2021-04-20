using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Com.Cos.IDAL;
using Com.Cos.Models;
using Com.Cos.Common;

namespace Com.Cos.DAL
{
    partial class ExchangeRepository : BaseRepository<Exchange>, IExchangeRepository
    {
        /// <summary>
        /// 查询前几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public object FindList(int top)
        {
            var v = from e in NContext.Exchanges
                    join u in NContext.Members on e.UserId equals u.User_id.ToString()
                    where e.Status == 1
                    orderby e.AddTime descending
                    select new
                    {
                        Id = e.Id,
                        Portrait = u.Portrait,
                        Nickname = u.nickname,
                        Title = e.Title,
                        Official = e.Official,
                        Examine = e.Examine,
                        Cover = e.Cover,
                        ImgList = e.ImgList
                    };
            return v.Take(top).AsEnumerable().Select(g => g.ToDynamic()); ;
        }
        /// <summary>
        /// 随机查询前几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public object FindRanList(int top)
        {
            var v = from e in NContext.Exchanges
                    join u in NContext.Members on e.UserId equals u.User_id.ToString()
                    where e.Status == 1
                    orderby Guid.NewGuid()
                    select new
                    {
                        Id = e.Id,
                        Portrait = u.Portrait,
                        Nickname = u.nickname,
                        Title = e.Title,
                        Official = e.Official,
                        Examine = e.Examine,
                        Cover = e.Cover,
                        ImgList = e.ImgList
                    };
            return v.Take(top).AsEnumerable().Select(g => g.ToDynamic());
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
        public IQueryable<dynamic> FindPageList(int pageIndex, int pageSize, string examineId, string classId, out int totalRecord)
        {
            var list = from e in NContext.Exchanges
                       join u in NContext.Members on e.UserId equals u.User_id.ToString()
                       where e.Status == 1 && (string.IsNullOrEmpty(examineId) || e.Examine == examineId) && (string.IsNullOrEmpty(classId) || e.ClassId == classId)
                       orderby e.AddTime descending
                       select new
                       {
                           Id = e.Id,
                           Cover = e.Cover,
                           Nickname = u.nickname,
                           Portrait = u.Portrait,
                           Title = e.Title,
                           ItemName = e.ItemName,
                           ItemCharacter = e.ItemCharacter,
                           Constitute = e.Constitute,
                           Source = e.Source,
                           Price = e.Price,
                           ClassId = e.ClassId,
                           Describe = e.Describe,
                           Valuation1 = e.Valuation1,
                           Valuation2 = e.Valuation2,
                           Valuation3 = e.Valuation3,
                           Certificate = e.Certificate,
                           ImgList = e.ImgList,
                           AddTime = e.AddTime

                       };
            totalRecord = list.Count();
            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return list;
        }

        public DataTable GetAllExchange()
        {
            string sql = @"SELECT ex.Id,ex.Title,ex.AddTime,
                        ex.Official,ex.Price,
                        ec.ClassName,
                        m.nickname,
						CASE WHEN (ex.Examine=1 OR ex.Examine IS NULL OR ex.Examine='') AND (ex.Official IS NULL OR ex.Official='') THEN ISNULL(ee.ExamineName,'审核中')
						WHEN (ex.Examine=1 OR ex.Examine IS NULL OR ex.Examine='') AND (ex.Official IS NOT NULL and ex.Official<>'') THEN '已审核'
						WHEN ee.ExamineName IS NULL THEN '审核中'
						ELSE ee.ExamineName END ExamineName
                        FROM dbo.sns_exchange AS ex
                        LEFT JOIN dbo.sns_exchangeClass AS ec ON ex.ClassId=ec.ClassId
                        LEFT JOIN dbo.cos_member AS m ON m.User_id=ex.UserId
                        LEFT JOIN dbo.sns_exchangeExamine AS ee ON ee.ExamineId=ex.Examine";
            var list = NContext.Database.SqlQueryForDataTable(sql);
            return list;
        }
    }
}