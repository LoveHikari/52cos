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
    /// 数据访问类:sns_systemMessage
    /// 系统信息表
    /// </summary>
    public partial class SystemMessageDb
    {
        #region  instance
        private volatile static SystemMessageDb _instance = null;
        private static readonly object lockHelper = new object();
        public SystemMessageDb() { }
        public static SystemMessageDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new SystemMessageDb();
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
        public int Add(SystemMessageEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_systemMessage(");
            strSql.Append("RefType,RefTypeDesc,Title,Stitle,Body,SmallBody,AddTime,Status)");
            strSql.Append(" values (");
            strSql.Append("@RefType,@RefTypeDesc,@Title,@Stitle,@Body,@SmallBody,@AddTime,@Status)");
            strSql.Append(";select @@IDENTITY");
            strSql.Append(";select LAST_INSERT_ROWID()");
            SqlParameter[] parameters = {
                    new SqlParameter("@RefType", SqlDbType.VarChar,50),
                    new SqlParameter("@RefTypeDesc", SqlDbType.VarChar,50),
                    new SqlParameter("@Title", SqlDbType.VarChar,50),
                    new SqlParameter("@Stitle", SqlDbType.VarChar,50),
                    new SqlParameter("@Body", SqlDbType.Text,16),
                    new SqlParameter("@SmallBody", SqlDbType.Text,16),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.RefType;
            parameters[1].Value = model.RefTypeDesc;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Stitle;
            parameters[4].Value = model.Body;
            parameters[5].Value = model.SmallBody;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.Status;

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
        public bool Update(SystemMessageEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sns_systemMessage set ");
            strSql.Append("RefType=@RefType,");
            strSql.Append("RefTypeDesc=@RefTypeDesc,");
            strSql.Append("Title=@Title,");
            strSql.Append("Stitle=@Stitle,");
            strSql.Append("Body=@Body,");
            strSql.Append("SmallBody=@SmallBody,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Status=@Status");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@RefType", SqlDbType.VarChar,50),
                    new SqlParameter("@RefTypeDesc", SqlDbType.VarChar,50),
                    new SqlParameter("@Title", SqlDbType.VarChar,50),
                    new SqlParameter("@Stitle", SqlDbType.VarChar,50),
                    new SqlParameter("@Body", SqlDbType.Text,16),
                    new SqlParameter("@SmallBody", SqlDbType.Text,16),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.RefType;
            parameters[1].Value = model.RefTypeDesc;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Stitle;
            parameters[4].Value = model.Body;
            parameters[5].Value = model.SmallBody;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.Id;

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
            strSql.Append("delete from sns_systemMessage ");
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
            strSql.Append("delete from sns_systemMessage ");
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
        public SystemMessageEntity GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,RefType,RefTypeDesc,Title,Stitle,Body,SmallBody,AddTime,Status from sns_systemMessage ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;
            SystemMessageEntity model = new SystemMessageEntity();
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
        public SystemMessageEntity DataRowToModel(DataRow row)
        {
            SystemMessageEntity model = new SystemMessageEntity();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["RefType"] != null)
                {
                    model.RefType = row["RefType"].ToString();
                }
                if (row["RefTypeDesc"] != null)
                {
                    model.RefTypeDesc = row["RefTypeDesc"].ToString();
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Stitle"] != null)
                {
                    model.Stitle = row["Stitle"].ToString();
                }
                if (row["Body"] != null)
                {
                    model.Body = row["Body"].ToString();
                }
                if (row["SmallBody"] != null)
                {
                    model.SmallBody = row["SmallBody"].ToString();
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
            strSql.Append("select Id,RefType,RefTypeDesc,Title,Stitle,Body,SmallBody,AddTime,Status ");
            strSql.Append(" FROM sns_systemMessage ");
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
            strSql.Append(" Id,RefType,RefTypeDesc,Title,Stitle,Body,SmallBody,AddTime,Status ");
            strSql.Append(" FROM sns_systemMessage ");
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
            strSql.Append("select count(1) FROM sns_systemMessage ");
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
            strSql.Append(")AS Row, T.*  from sns_systemMessage T ");
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
			parameters[0].Value = "sns_systemMessage";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return SqlHelper.Instance.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" Id,RefType,RefTypeDesc,Title,Stitle,Body,SmallBody,AddTime,Status ");
            strSql.Append(" FROM sns_systemMessage ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.Instance.ExecSqlDataSet(strSql.ToString());
        }
    }
}

