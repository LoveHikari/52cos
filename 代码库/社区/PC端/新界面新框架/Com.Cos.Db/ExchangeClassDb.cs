using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Com.Cos.Entity;
using Com.Cos.Utility;

//Please add references
namespace Com.Cos.Db
{
    /// <summary>
    /// 数据访问类:sns_exchangeClass
    /// 兑换分类表
    /// </summary>
    public partial class ExchangeClassDb
    {
        #region  instance
        private volatile static ExchangeClassDb _instance = null;
        private static readonly object lockHelper = new object();
        public ExchangeClassDb() { }
        public static ExchangeClassDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new ExchangeClassDb();
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
        public int Add(ExchangeClassEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_exchangeClass(");
            strSql.Append("ClassName,ClassId,Reserved,Status)");
            strSql.Append(" values (");
            strSql.Append("@ClassName,@ClassId,@Reserved,@Status)");
            strSql.Append(";select @@IDENTITY");
            strSql.Append(";select LAST_INSERT_ROWID()");
            SqlParameter[] parameters = {
                    new SqlParameter("@ClassName", SqlDbType.VarChar,50),
                    new SqlParameter("@ClassId", SqlDbType.Int,4),
                    new SqlParameter("@Reserved", SqlDbType.VarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.ClassId;
            parameters[2].Value = model.Reserved;
            parameters[3].Value = model.Status;

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
        public bool Update(ExchangeClassEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sns_exchangeClass set ");
            strSql.Append("ClassName=@ClassName,");
            strSql.Append("ClassId=@ClassId,");
            strSql.Append("Reserved=@Reserved,");
            strSql.Append("Status=@Status");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@ClassName", SqlDbType.VarChar,50),
                    new SqlParameter("@ClassId", SqlDbType.Int,4),
                    new SqlParameter("@Reserved", SqlDbType.VarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.ClassId;
            parameters[2].Value = model.Reserved;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.Id;

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
            strSql.Append("delete from sns_exchangeClass ");
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
            strSql.Append("delete from sns_exchangeClass ");
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
        public ExchangeClassEntity GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,ClassName,ClassId,Reserved,Status from sns_exchangeClass ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;
            ExchangeClassEntity model = new ExchangeClassEntity();
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
        public ExchangeClassEntity DataRowToModel(DataRow row)
        {
            ExchangeClassEntity model = new ExchangeClassEntity();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["ClassName"] != null)
                {
                    model.ClassName = row["ClassName"].ToString();
                }
                if (row["ClassId"] != null && row["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(row["ClassId"].ToString());
                }
                if (row["Reserved"] != null)
                {
                    model.Reserved = row["Reserved"].ToString();
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
            strSql.Append("select Id,ClassName,ClassId,Reserved,Status ");
            strSql.Append(" FROM sns_exchangeClass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Instance.ExecSqlDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" Id,ClassName,ClassId,Reserved,Status ");
            strSql.Append(" FROM sns_exchangeClass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
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
            strSql.Append(" Id,ClassName,ClassId,Reserved,Status ");
            strSql.Append(" FROM sns_exchangeClass ");
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
            strSql.Append("select count(1) FROM sns_exchangeClass ");
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
            strSql.Append(")AS Row, T.*  from sns_exchangeClass T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return SqlHelper.Instance.ExecSqlDataSet(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "sns_exchangeClass";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return SqlHelper.Instance.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion
    }
}

