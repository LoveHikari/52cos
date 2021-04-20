using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    /// <summary>
    /// 数据访问类:快捷导航表
    /// </summary>
    public class QuickNavigationDb
    {
        #region instance
        private volatile static QuickNavigationDb _instance = null;
        private static readonly object lockHelper = new object();
        private QuickNavigationDb() { }
        public static QuickNavigationDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new QuickNavigationDb();
                    }
                }
                return _instance;
            }
        }
        #endregion
        #region 自动生成
        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,SmallTitle,Title,Cont,Link,AddTime,Status ");
            strSql.Append(" FROM sns_quickNavigation ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Instance.ExecSqlDataSet(strSql.ToString());
        }
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public QuickNavigationEntity GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,SmallTitle,Title,Cont,Link,AddTime,Status from sns_quickNavigation ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            QuickNavigationEntity model = new QuickNavigationEntity();
            DataSet ds = SqlHelper.Instance.ExecSqlDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private QuickNavigationEntity DataRowToModel(DataRow row)
        {
            QuickNavigationEntity model = new QuickNavigationEntity();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["SmallTitle"] != null)
                {
                    model.SmallTitle = row["SmallTitle"].ToString();
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Cont"] != null)
                {
                    model.Cont = row["Cont"].ToString();
                }
                if (row["Link"] != null)
                {
                    model.Link = row["Link"].ToString();
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
            }
            return model;
        }
        #endregion
    }
}