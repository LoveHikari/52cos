using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    public class WorkImgDb
    {
        #region instance
        private volatile static WorkImgDb _instance = null;
        private static readonly object lockHelper = new object();
        private WorkImgDb() { }
        public static WorkImgDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new WorkImgDb();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(WorkImgEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_workImg(");
            strSql.Append("workId,ImgId,Status)");
            strSql.Append(" values (");
            strSql.Append("@workId,@ImgId,@Status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@workId", SqlDbType.VarChar,50),
                    new SqlParameter("@ImgId", SqlDbType.VarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.workId;
            parameters[1].Value = model.ImgId;
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