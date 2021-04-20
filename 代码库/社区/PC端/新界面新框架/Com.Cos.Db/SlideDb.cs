using System.Collections.Generic;
using System.Data;
using System.Text;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    /// <summary>
    /// 数据访问类：首页幻灯片
    /// </summary>
    public class SlideDb
    {
        #region instance
        private volatile static SlideDb _instance = null;
        private static readonly object lockHelper = new object();
        private SlideDb() { }
        public static SlideDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new SlideDb();
                    }
                }
                return _instance;
            }
        }
        #endregion
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
            strSql.Append(" Id,ImgText,ImgUrl,ImgHref,weight,AddTime,Sign,Status ");
            strSql.Append(" FROM sns_slide ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.Instance.ExecSqlDataTable(strSql.ToString());
        }
        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,ImgText,ImgUrl,ImgHref,weight,AddTime,Sign,Status ");
            strSql.Append(" FROM sns_slide ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Instance.ExecSqlDataTable(strSql.ToString());
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="status">状态码：1或0</param>
        /// <returns></returns>
        public bool UpdateStatus(string id, string status)
        {
            string sql = $@"UPDATE sns_slide
                        SET Status='{status}'
                        WHERE Id='{id}'";
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
		/// 获得数据列表
		/// </summary>
        public DataTable GetList(IDictionary<string, string> strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,ImgText,ImgUrl,ImgHref,weight,AddTime,Sign,Status ");
            strSql.Append(" FROM sns_slide where 1=1");
            if (strWhere.ContainsKey("Sign"))
            {
                strSql.AppendFormat(" and Sign='{0}'", strWhere["Sign"]);
            }
            if (strWhere.ContainsKey("Text"))
            {
                strSql.AppendFormat(" and ImgText like '%{0}%'", strWhere["Text"]);
            }
            if (strWhere.ContainsKey("Time"))
            {
                strSql.AppendFormat(" and AddTime between '{0}' and '{1}'", strWhere["Time"] + " 00:00:00", strWhere["Time"] + " 23:59:59");
            }
            return SqlHelper.Instance.ExecSqlDataTable(strSql.ToString());
        }
    }
}