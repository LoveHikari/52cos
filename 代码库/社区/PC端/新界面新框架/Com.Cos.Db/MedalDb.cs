using System.Data;
using System.Text;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    public class MedalDb
    {
        #region instance
        private volatile static MedalDb _instance = null;
        private static readonly object lockHelper = new object();
        private MedalDb() { }
        public static MedalDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new MedalDb();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,RefText,RefDesc,imgUrl,access,addtime,Status ");
            strSql.Append(" FROM sns_medal where status='1' ");
            return SqlHelper.Instance.ExecSqlDataTable(strSql.ToString());
        }
    }
}