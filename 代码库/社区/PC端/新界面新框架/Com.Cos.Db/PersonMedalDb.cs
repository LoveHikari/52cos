using System.Data;
using System.Text;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    public class PersonMedalDb
    {
        #region instance
        private volatile static PersonMedalDb _instance = null;
        private static readonly object lockHelper = new object();
        private PersonMedalDb() { }
        public static PersonMedalDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new PersonMedalDb();
                    }
                }
                return _instance;
            }
        }
        #endregion
        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select m.imgUrl,m.RefText,m.RefDesc ");
            strSql.Append(@" FROM dbo.sns_personMedal pm
                            LEFT JOIN dbo.sns_medal m ON pm.medalId = m.id where m.status='1' ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return SqlHelper.Instance.ExecSqlDataTable(strSql.ToString());
        }
    }
}