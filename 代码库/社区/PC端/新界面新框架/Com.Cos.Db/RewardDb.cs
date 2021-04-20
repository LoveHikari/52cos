using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    /// <summary>
    /// 数据访问类：打赏表
    /// </summary>
    public class RewardDb
    {
        #region instance
        private volatile static RewardDb _instance = null;
        private static readonly object lockHelper = new object();
        private RewardDb() { }
        public static RewardDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new RewardDb();
                    }
                }
                return _instance;
            }
        }
        #endregion
        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="worksId">作品id</param>
        /// <param name="status">状态码：1或0</param>
        /// <returns></returns>
        public bool UpdateStatus(string worksId, string status)
        {
            string sql = $@"UPDATE dbo.sns_reward
                        SET Status='{status}'
                        WHERE worksId='{worksId}'";
            int rows = SqlHelper.Instance.ExecSqlNonQuery(sql);
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
		/// 增加一条数据
		/// </summary>
		public int Add(RewardEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_reward(");
            strSql.Append("User_id,worksId,rewardMoney,Status)");
            strSql.Append(" values (");
            strSql.Append("@User_id,@worksId,@rewardMoney,@Status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@User_id", SqlDbType.VarChar,50),
                    new SqlParameter("@worksId", SqlDbType.VarChar,50),
                    new SqlParameter("@rewardMoney", SqlDbType.Int,4),
                    new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.User_id;
            parameters[1].Value = model.worksId;
            parameters[2].Value = model.rewardMoney;
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
    }
}