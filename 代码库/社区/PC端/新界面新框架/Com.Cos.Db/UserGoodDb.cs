using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    /// <summary>
    /// 数据访问类：点赞关联表
    /// </summary>
    public class UserGoodDb
    {
        #region instance
        private volatile static UserGoodDb _instance = null;
        private static readonly object lockHelper = new object();
        private UserGoodDb() { }
        public static UserGoodDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new UserGoodDb();
                    }
                }
                return _instance;
            }
        }
        #endregion
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="userId">会员id</param>
        /// <param name="workId">作品id</param>
        /// <returns></returns>
		public bool ExistsByUserId(string userId, string workId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sns_userGood");
            strSql.Append(" where status='1' and User_id=@User_id and WorkId=@WorkId");
            SqlParameter[] parameters = {
                    new SqlParameter("@User_id", SqlDbType.VarChar,50),
                    new SqlParameter("@WorkId", SqlDbType.VarChar,50)
            };
            parameters[0].Value = userId;
            parameters[1].Value = workId;
            if (int.Parse(SqlHelper.Instance.ExecSqlScalar(strSql.ToString(), parameters).ToString()) > 0)
            {
                return true;
            }
            return false;
            
        }
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(UserGoodEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_userGood(");
            strSql.Append("User_id,WorkId,Status)");
            strSql.Append(" values (");
            strSql.Append("@User_id,@WorkId,@Status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@User_id", SqlDbType.VarChar,50),
                    new SqlParameter("@WorkId", SqlDbType.VarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.User_id;
            parameters[1].Value = model.WorkId;
            parameters[2].Value = model.Status;

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