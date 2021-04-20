using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    /// <summary>
    /// 数据访问类：积分变更记录表
    /// </summary>
    public class IntegralChangeDb
    {
        #region instance
        private volatile static IntegralChangeDb _instance = null;
        private static readonly object lockHelper = new object();
        private IntegralChangeDb() { }
        public static IntegralChangeDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new IntegralChangeDb();
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
        public int Add(IntegralChangeEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_IntegralChange(");
            strSql.Append("UserId,source,ShenJia,Cnbi,integral,Growth,Bean,Status,ardent,AddTime)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@source,@ShenJia,@Cnbi,@integral,@Growth,@Bean,@Status,@ardent,@AddTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.VarChar,50),
                    new SqlParameter("@source", SqlDbType.VarChar,50),
                    new SqlParameter("@ShenJia", SqlDbType.Money,8),
                    new SqlParameter("@Cnbi", SqlDbType.VarChar,50),
                    new SqlParameter("@integral", SqlDbType.Int,4),
                    new SqlParameter("@Growth", SqlDbType.Int,4),
                    new SqlParameter("@Bean", SqlDbType.VarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@ardent", SqlDbType.Int,4),
                    new SqlParameter("@AddTime", SqlDbType.DateTime)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.source;
            parameters[2].Value = model.ShenJia;
            parameters[3].Value = model.Cnbi;
            parameters[4].Value = model.integral;
            parameters[5].Value = model.Growth;
            parameters[6].Value = model.Bean;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.ardent;
            parameters[9].Value = model.AddTime;

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
        public bool Update(IntegralChangeEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sns_IntegralChange set ");
            strSql.Append("UserId=@UserId,");
            strSql.Append("source=@source,");
            strSql.Append("ShenJia=@ShenJia,");
            strSql.Append("Cnbi=@Cnbi,");
            strSql.Append("integral=@integral,");
            strSql.Append("Growth=@Growth,");
            strSql.Append("Bean=@Bean,");
            strSql.Append("Status=@Status,");
            strSql.Append("ardent=@ardent,");
            strSql.Append("AddTime=@AddTime");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.VarChar,50),
                    new SqlParameter("@source", SqlDbType.VarChar,50),
                    new SqlParameter("@ShenJia", SqlDbType.Money,8),
                    new SqlParameter("@Cnbi", SqlDbType.VarChar,50),
                    new SqlParameter("@integral", SqlDbType.Int,4),
                    new SqlParameter("@Growth", SqlDbType.Int,4),
                    new SqlParameter("@Bean", SqlDbType.VarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@ardent", SqlDbType.Int,4),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.source;
            parameters[2].Value = model.ShenJia;
            parameters[3].Value = model.Cnbi;
            parameters[4].Value = model.integral;
            parameters[5].Value = model.Growth;
            parameters[6].Value = model.Bean;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.ardent;
            parameters[9].Value = model.AddTime;
            parameters[10].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sns_IntegralChange ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sns_IntegralChange ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public IntegralChangeEntity GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,UserId,source,ShenJia,Cnbi,integral,Growth,Bean,Status,ardent,AddTime from sns_IntegralChange ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            IntegralChangeEntity model = new IntegralChangeEntity();
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
        public IntegralChangeEntity DataRowToModel(DataRow row)
        {
            IntegralChangeEntity model = new IntegralChangeEntity();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["UserId"] != null)
                {
                    model.UserId = row["UserId"].ToString();
                }
                if (row["source"] != null)
                {
                    model.source = row["source"].ToString();
                }
                if (row["ShenJia"] != null && row["ShenJia"].ToString() != "")
                {
                    model.ShenJia = decimal.Parse(row["ShenJia"].ToString());
                }
                if (row["Cnbi"] != null)
                {
                    model.Cnbi = row["Cnbi"].ToString();
                }
                if (row["integral"] != null && row["integral"].ToString() != "")
                {
                    model.integral = int.Parse(row["integral"].ToString());
                }
                if (row["Growth"] != null && row["Growth"].ToString() != "")
                {
                    model.Growth = int.Parse(row["Growth"].ToString());
                }
                if (row["Bean"] != null)
                {
                    model.Bean = row["Bean"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["ardent"] != null && row["ardent"].ToString() != "")
                {
                    model.ardent = int.Parse(row["ardent"].ToString());
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
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
            strSql.Append("select id,UserId,source,ShenJia,Cnbi,integral,Growth,Bean,Status,ardent,AddTime ");
            strSql.Append(" FROM sns_IntegralChange ");
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
            strSql.Append(" id,UserId,source,ShenJia,Cnbi,integral,Growth,Bean,Status,ardent,AddTime ");
            strSql.Append(" FROM sns_IntegralChange ");
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
            strSql.Append("select count(1) FROM sns_IntegralChange ");
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from sns_IntegralChange T ");
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
			parameters[0].Value = "sns_IntegralChange";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion
    }
}