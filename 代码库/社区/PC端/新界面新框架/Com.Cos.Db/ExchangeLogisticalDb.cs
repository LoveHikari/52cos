using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    /// <summary>
    /// 分享物流表
    /// </summary>
    public class ExchangeLogisticalDb
    {
        #region instance
        private volatile static ExchangeLogisticalDb _instance = null;
        private static readonly object lockHelper = new object();
        private ExchangeLogisticalDb() { }
        public static ExchangeLogisticalDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new ExchangeLogisticalDb();
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
        public int Add(ExchangeLogisticalEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_exchangeLogistical(");
            strSql.Append("UserId,ExId,LogisticalName,LogisticalNo,AddTime,Status)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@ExId,@LogisticalName,@LogisticalNo,@AddTime,@Status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.VarChar,50),
                    new SqlParameter("@ExId", SqlDbType.VarChar,50),
                    new SqlParameter("@LogisticalName", SqlDbType.VarChar,50),
                    new SqlParameter("@LogisticalNo", SqlDbType.VarChar,50),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.ExId;
            parameters[2].Value = model.LogisticalName;
            parameters[3].Value = model.LogisticalNo;
            parameters[4].Value = model.AddTime;
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
        public bool Update(ExchangeLogisticalEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sns_exchangeLogistical set ");
            strSql.Append("UserId=@UserId,");
            strSql.Append("ExId=@ExId,");
            strSql.Append("LogisticalName=@LogisticalName,");
            strSql.Append("LogisticalNo=@LogisticalNo,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Status=@Status");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.VarChar,50),
                    new SqlParameter("@ExId", SqlDbType.VarChar,50),
                    new SqlParameter("@LogisticalName", SqlDbType.VarChar,50),
                    new SqlParameter("@LogisticalNo", SqlDbType.VarChar,50),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.ExId;
            parameters[2].Value = model.LogisticalName;
            parameters[3].Value = model.LogisticalNo;
            parameters[4].Value = model.AddTime;
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
            strSql.Append("delete from sns_exchangeLogistical ");
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
            strSql.Append("delete from sns_exchangeLogistical ");
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
        public ExchangeLogisticalEntity GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,UserId,ExId,LogisticalName,LogisticalNo,AddTime,Status from sns_exchangeLogistical ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            ExchangeLogisticalEntity model = new ExchangeLogisticalEntity();
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
        public ExchangeLogisticalEntity DataRowToModel(DataRow row)
        {
            ExchangeLogisticalEntity model = new ExchangeLogisticalEntity();
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
                if (row["LogisticalName"] != null)
                {
                    model.LogisticalName = row["LogisticalName"].ToString();
                }
                if (row["LogisticalNo"] != null)
                {
                    model.LogisticalNo = row["LogisticalNo"].ToString();
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

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,UserId,ExId,LogisticalName,LogisticalNo,AddTime,Status ");
            strSql.Append(" FROM sns_exchangeLogistical ");
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
            strSql.Append(" Id,UserId,ExId,LogisticalName,LogisticalNo,AddTime,Status ");
            strSql.Append(" FROM sns_exchangeLogistical ");
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
            strSql.Append("select count(1) FROM sns_exchangeLogistical ");
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
            strSql.Append(")AS Row, T.*  from sns_exchangeLogistical T ");
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
			parameters[0].Value = "sns_exchangeLogistical";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="exId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateStatus(string exId, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sns_exchangeLogistical set ");
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