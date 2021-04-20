using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    /// <summary>
    /// 数据访问类：充值记录表
    /// </summary>
    public class RechargeRecordDb
    {
        #region instance
        private volatile static RechargeRecordDb _instance = null;
        private static readonly object lockHelper = new object();
        private RechargeRecordDb() { }
        public static RechargeRecordDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new RechargeRecordDb();
                    }
                }
                return _instance;
            }
        }
        #endregion
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(RechargeRecordEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_rechargeRecord(");
            strSql.Append("UserId,source,RMB,Cnbi,addTime,OrderNo,OrderName,wareDesc,Status)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@source,@RMB,@Cnbi,@addTime,@OrderNo,@OrderName,@wareDesc,@Status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.VarChar,50),
                    new SqlParameter("@source", SqlDbType.VarChar,50),
                    new SqlParameter("@RMB", SqlDbType.VarChar,50),
                    new SqlParameter("@Cnbi", SqlDbType.VarChar,50),
                    new SqlParameter("@addTime", SqlDbType.DateTime),
                    new SqlParameter("@OrderNo", SqlDbType.VarChar,50),
                    new SqlParameter("@OrderName", SqlDbType.VarChar,50),
                    new SqlParameter("@wareDesc", SqlDbType.VarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = UtilityHelper.SqlNull(model.UserId);
            parameters[1].Value = UtilityHelper.SqlNull(model.source);
            parameters[2].Value = UtilityHelper.SqlNull(model.RMB);
            parameters[3].Value = UtilityHelper.SqlNull(model.Cnbi);
            parameters[4].Value = UtilityHelper.SqlNull(model.addTime);
            parameters[5].Value = UtilityHelper.SqlNull(model.OrderNo);
            parameters[6].Value = UtilityHelper.SqlNull(model.OrderName);
            parameters[7].Value = UtilityHelper.SqlNull(model.wareDesc);
            parameters[8].Value = UtilityHelper.SqlNull(model.Status);

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