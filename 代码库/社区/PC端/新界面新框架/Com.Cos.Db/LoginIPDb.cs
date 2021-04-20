using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    public class LoginIPDb
    {
        #region instance
        private volatile static LoginIPDb _instance = null;
        private static readonly object lockHelper = new object();
        private LoginIPDb() { }
        public static LoginIPDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new LoginIPDb();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool ExistsIp(string userId, DateTime nowTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from cos_loginIP");
            strSql.Append(" where User_id=@User_id and LastTime>=@StartTime and LastTime<=@EndTime");
            SqlParameter[] parameters = {
                    new SqlParameter("@User_id", SqlDbType.VarChar,50),
                    new SqlParameter("@StartTime", SqlDbType.DateTime),
                    new SqlParameter("@EndTime", SqlDbType.DateTime)
            };
            parameters[0].Value = userId;
            parameters[1].Value = nowTime.ToString("yyyy-MM-dd 00:00:00");
            parameters[2].Value = nowTime.ToString("yyyy-MM-dd 23:59:59");

            int i = Convert.ToInt32(SqlHelper.Instance.ExecSqlScalar(strSql.ToString(), parameters));
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LoginIPEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into cos_loginIP(");
            strSql.Append("User_id,Last_ip,Lastddress,Status,LastTime)");
            strSql.Append(" values (");
            strSql.Append("@User_id,@Last_ip,@Lastddress,@Status,@LastTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@User_id", SqlDbType.VarChar,50),
                    new SqlParameter("@Last_ip", SqlDbType.VarChar,50),
                    new SqlParameter("@Lastddress", SqlDbType.VarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@LastTime", SqlDbType.DateTime)};
            parameters[0].Value = model.User_id;
            parameters[1].Value = model.Last_ip;
            parameters[2].Value = model.Lastddress;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.LastTime;

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
    }
}