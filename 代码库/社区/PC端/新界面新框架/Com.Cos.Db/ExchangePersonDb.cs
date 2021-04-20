using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    /// <summary>
    /// 数据访问类：兑换人员表
    /// </summary>
    public class ExchangePersonDb
    {
        #region instance
        private volatile static ExchangePersonDb _instance = null;
        private static readonly object lockHelper = new object();
        private ExchangePersonDb() { }
        public static ExchangePersonDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new ExchangePersonDb();
                    }
                }
                return _instance;
            }
        }
        #endregion

        #region  自动生成

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ExchangePersonEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_exchangePerson(");
            strSql.Append("UserId,ExId,AddTime,Address,Examine,Status)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@ExId,@AddTime,@Address,@Examine,@Status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.VarChar,50),
                    new SqlParameter("@ExId", SqlDbType.VarChar,50),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@Address", SqlDbType.VarChar,500),
                    new SqlParameter("@Examine", SqlDbType.VarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.ExId;
            parameters[2].Value = model.AddTime;
            parameters[3].Value = model.Address;
            parameters[4].Value = model.Examine;
            parameters[5].Value = model.Status;

            object obj = SqlHelper.Instance.ExecSqlScalar(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ExchangePersonEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sns_exchangePerson set ");
            strSql.Append("UserId=@UserId,");
            strSql.Append("ExId=@ExId,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Address=@Address,");
            strSql.Append("Examine=@Examine,");
            strSql.Append("Status=@Status");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.VarChar,50),
                    new SqlParameter("@ExId", SqlDbType.VarChar,50),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@Address", SqlDbType.VarChar,500),
                    new SqlParameter("@Examine", SqlDbType.VarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.ExId;
            parameters[2].Value = model.AddTime;
            parameters[3].Value = model.Address;
            parameters[4].Value = model.Examine;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.Id;

            int rows = SqlHelper.Instance.ExecSqlNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sns_exchangePerson ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            int rows = SqlHelper.Instance.ExecSqlNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sns_exchangePerson ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = SqlHelper.Instance.ExecSqlNonQuery(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ExchangePersonEntity GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,UserId,ExId,AddTime,Address,Examine,Status from sns_exchangePerson ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            ExchangePersonEntity model = new ExchangePersonEntity();
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
        private ExchangePersonEntity DataRowToModel(DataRow row)
        {
            ExchangePersonEntity model = new ExchangePersonEntity();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["UserId"] != null)
                {
                    model.UserId = row["UserId"].ToString();
                }
                if (row["ExId"] != null)
                {
                    model.ExId = row["ExId"].ToString();
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["Examine"] != null)
                {
                    model.Examine = row["Examine"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,UserId,ExId,AddTime,Address,Examine,Status ");
            strSql.Append(" FROM sns_exchangePerson ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Instance.ExecSqlDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,UserId,ExId,AddTime,Address,Examine,Status ");
            strSql.Append(" FROM sns_exchangePerson ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.Instance.ExecSqlDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM sns_exchangePerson ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = SqlHelper.Instance.ExecSqlScalar(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from sns_exchangePerson T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return SqlHelper.Instance.ExecSqlDataSet(strSql.ToString());
        }
        #endregion

        /// <summary>
        /// 获得数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序</param>
        /// <returns></returns>
        public DataSet GetList(string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(@"ep.id,ep.ExId,m.User_id,m.nickname,ep.Examine,e.Title,
                            ma.Address, ma.City, ma.County, ma.Phone, ma.Province,m.Portrait,e.Cover,e.AddTime ReleaseTime,ep.AddTime ");
            strSql.Append(@" FROM dbo.sns_exchangePerson ep
                            LEFT JOIN dbo.cos_member m ON ep.UserId = m.User_id
                            LEFT JOIN dbo.sns_exchange e ON e.Id = ep.ExId
                            LEFT JOIN dbo.sns_mailingAddress ma ON ma.Id = ep.Address where 1=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.Instance.ExecSqlDataSet(strSql.ToString());
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="exId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateStatus(string exId, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sns_exchangePerson set ");
            strSql.Append("Status=@Status");
            strSql.Append(" where ExId=@ExId");
            SqlParameter[] parameters =
            {
                new SqlParameter("@ExId", SqlDbType.VarChar, 50),
                new SqlParameter("@Status", SqlDbType.Int, 4)
            };
            parameters[0].Value = exId;
            parameters[1].Value = status;

            int rows = SqlHelper.Instance.ExecSqlNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}