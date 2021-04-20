using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    public class ReplyDb
    {
        #region instance
        private volatile static ReplyDb _instance = null;
        private static readonly object lockHelper = new object();
        private ReplyDb() { }
        public static ReplyDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new ReplyDb();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ReplyEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_reply(");
            strSql.Append("type,workId,User_id,ReplyContent,ReleaseTime,Status)");
            strSql.Append(" values (");
            strSql.Append("@type,@workId,@User_id,@ReplyContent,@ReleaseTime,@Status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@type", SqlDbType.VarChar,50),
                    new SqlParameter("@workId", SqlDbType.VarChar,50),
                    new SqlParameter("@User_id", SqlDbType.VarChar,50),
                    new SqlParameter("@ReplyContent", SqlDbType.Text),
                    new SqlParameter("@ReleaseTime", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.type;
            parameters[1].Value = model.workId;
            parameters[2].Value = model.User_id;
            parameters[3].Value = model.ReplyContent;
            parameters[4].Value = model.ReleaseTime;
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
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT * FROM(
                        SELECT m.*,r.ReplyId,r.type,r.workId,r.ReplyContent,r.ReleaseTime FROM dbo.sns_reply r
                        LEFT JOIN dbo.cos_member m ON r.User_id = m.User_id) n");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Instance.ExecSqlDataTable(strSql.ToString());
        }
        /// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ReplyId,type,workId,User_id,ReplyContent,ReleaseTime,Status ");
            strSql.Append(" FROM sns_reply ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.Instance.ExecSqlDataTable(strSql.ToString());
        }
        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="worksId">作品id</param>
        /// <param name="status">状态码：1或0</param>
        /// <returns></returns>
        public bool UpdateStatus(string worksId, string status)
        {
            string sql = $@"UPDATE dbo.sns_reply
                        SET Status='{status}'
                        WHERE workId='{worksId}'";
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
                strSql.Append("order by T.ReplyId desc");
            }
            strSql.Append(")AS Row, T.*  from sns_reply T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return SqlHelper.Instance.ExecSqlDataSet(strSql.ToString());
        }
        /// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM sns_reply ");
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
    }
}