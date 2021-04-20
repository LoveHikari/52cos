using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    /// <summary>
    /// 数据访问类:活动表
    /// </summary>
    public class ActivityDb
    {
        #region instance
        private volatile static ActivityDb _instance = null;
        private static readonly object lockHelper = new object();
        private ActivityDb() { }
        public static ActivityDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new ActivityDb();
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
            strSql.Append(" * ");
            strSql.Append(@" FROM(
                        SELECT m.nickname,m.Portrait,a.* FROM dbo.sns_activity a
                        LEFT JOIN cos_member m ON CAST(m.User_id AS VARCHAR(50))=a.User_id) n
                        WHERE Status='1' ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            return SqlHelper.Instance.ExecSqlDataTable(strSql.ToString());
        }

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ActivityEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_activity(");
            strSql.Append("User_id,title,starttime,endtime,enrollEnd,contacts,phone,qq,cover,cont,RMBBudget,limitPerson,prov,city,dist,ReleaseTime,Status,excerpt)");
            strSql.Append(" values (");
            strSql.Append("@User_id,@title,@starttime,@endtime,@enrollEnd,@contacts,@phone,@qq,@cover,@cont,@RMBBudget,@limitPerson,@prov,@city,@dist,@ReleaseTime,@Status,@excerpt)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@User_id", SqlDbType.VarChar,50),
                    new SqlParameter("@title", SqlDbType.VarChar,50),
                    new SqlParameter("@starttime", SqlDbType.DateTime),
                    new SqlParameter("@endtime", SqlDbType.DateTime),
                    new SqlParameter("@enrollEnd", SqlDbType.DateTime),
                    new SqlParameter("@contacts", SqlDbType.VarChar,50),
                    new SqlParameter("@phone", SqlDbType.VarChar,50),
                    new SqlParameter("@qq", SqlDbType.VarChar,50),
                    new SqlParameter("@cover", SqlDbType.VarChar,500),
                    new SqlParameter("@cont", SqlDbType.Text),
                    new SqlParameter("@RMBBudget", SqlDbType.VarChar,50),
                    new SqlParameter("@limitPerson", SqlDbType.VarChar,50),
                    new SqlParameter("@prov", SqlDbType.VarChar,50),
                    new SqlParameter("@city", SqlDbType.VarChar,50),
                    new SqlParameter("@dist", SqlDbType.VarChar,50),
                    new SqlParameter("@ReleaseTime", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@excerpt", SqlDbType.Text)};
            parameters[0].Value = model.User_id;
            parameters[1].Value = model.title;
            parameters[2].Value = model.starttime;
            parameters[3].Value = model.endtime;
            parameters[4].Value = model.enrollEnd;
            parameters[5].Value = model.contacts;
            parameters[6].Value = model.phone;
            parameters[7].Value = model.qq;
            parameters[8].Value = model.cover;
            parameters[9].Value = model.cont;
            parameters[10].Value = model.RMBBudget;
            parameters[11].Value = model.limitPerson;
            parameters[12].Value = model.prov;
            parameters[13].Value = model.city;
            parameters[14].Value = model.dist;
            parameters[15].Value = model.ReleaseTime;
            parameters[16].Value = model.Status;
            parameters[17].Value = model.excerpt;

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
		/// 得到一个对象实体
		/// </summary>
		public ActivityEntity GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,User_id,title,starttime,endtime,enrollEnd,contacts,phone,qq,cover,cont,RMBBudget,limitPerson,prov,city,dist,ReleaseTime,Status,excerpt from sns_activity ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            ActivityEntity model = new ActivityEntity();
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
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM sns_activity ");
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
        /// 得到一个对象实体
        /// </summary>
        private ActivityEntity DataRowToModel(DataRow row)
        {
            ActivityEntity model = new ActivityEntity();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["User_id"] != null)
                {
                    model.User_id = row["User_id"].ToString();
                }
                if (row["title"] != null)
                {
                    model.title = row["title"].ToString();
                }
                if (row["starttime"] != null && row["starttime"].ToString() != "")
                {
                    model.starttime = DateTime.Parse(row["starttime"].ToString());
                }
                if (row["endtime"] != null && row["endtime"].ToString() != "")
                {
                    model.endtime = DateTime.Parse(row["endtime"].ToString());
                }
                if (row["enrollEnd"] != null && row["enrollEnd"].ToString() != "")
                {
                    model.enrollEnd = DateTime.Parse(row["enrollEnd"].ToString());
                }
                if (row["contacts"] != null)
                {
                    model.contacts = row["contacts"].ToString();
                }
                if (row["phone"] != null)
                {
                    model.phone = row["phone"].ToString();
                }
                if (row["qq"] != null)
                {
                    model.qq = row["qq"].ToString();
                }
                if (row["cover"] != null)
                {
                    model.cover = row["cover"].ToString();
                }
                if (row["cont"] != null)
                {
                    model.cont = row["cont"].ToString();
                }
                if (row["RMBBudget"] != null)
                {
                    model.RMBBudget = row["RMBBudget"].ToString();
                }
                if (row["limitPerson"] != null)
                {
                    model.limitPerson = row["limitPerson"].ToString();
                }
                if (row["prov"] != null)
                {
                    model.prov = row["prov"].ToString();
                }
                if (row["city"] != null)
                {
                    model.city = row["city"].ToString();
                }
                if (row["dist"] != null)
                {
                    model.dist = row["dist"].ToString();
                }
                if (row["ReleaseTime"] != null && row["ReleaseTime"].ToString() != "")
                {
                    model.ReleaseTime = DateTime.Parse(row["ReleaseTime"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["excerpt"] != null)
                {
                    model.excerpt = row["excerpt"].ToString();
                }
            }
            return model;
        }
        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,User_id,title,starttime,endtime,enrollEnd,contacts,phone,qq,cover,cont,RMBBudget,limitPerson,prov,city,dist,ReleaseTime,Status,excerpt ");
            strSql.Append(" FROM sns_activity ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Instance.ExecSqlDataTable(strSql.ToString());
        }
        /// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by n." + orderby);
            }
            else
            {
                strSql.Append("order by n.id desc");
            }
            strSql.Append(")AS Row, n.*  from (");
            strSql.Append(@"SELECT m.nickname,m.Portrait,a.* FROM dbo.sns_activity a
                        LEFT JOIN cos_member m ON m.User_id=a.User_id) n
                        WHERE Status='1'");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" ) tt");
            strSql.AppendFormat(" WHERE tt.Row between {0} and {1}", startIndex, endIndex);
            return SqlHelper.Instance.ExecSqlDataTable(strSql.ToString());
        }
    }
}