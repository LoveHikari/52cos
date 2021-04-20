using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Com.Cos.Entity;
using System.Web;
using System.Web.SessionState;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    public class SysParaDb
    {
        #region instance
        private volatile static SysParaDb _instance = null;
        private static readonly object lockHelper = new object();
        private SysParaDb() { }
        public static SysParaDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new SysParaDb();
                    }
                }
                return _instance;
            }
        }
        #endregion
        /// <summary>
        /// 获得全部系统信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllSysPara()
        {
            if (HttpContext.Current.Session["sysPara"] == null)
            {
                string sql = @"SELECT * FROM cos_sysPara where status='1'";
                HttpContext.Current.Session["sysPara"] = SqlHelper.Instance.ExecSqlDataTable(sql);
            }
            return HttpContext.Current.Session["sysPara"] as DataTable;
        }
        /// <summary>
        /// 获得指定类型的表
        /// </summary>
        /// <param name="refType"></param>
        /// <returns></returns>
        public DataTable GetSysParaTable(string refType)
        {
            DataTable sysPara = GetAllSysPara();
            IEnumerable<DataRow> query = from r in sysPara.AsEnumerable()
                                         where r.Field<string>("RefType") == refType
                                         select r;
            if (query.Any())
            {
                return query.CopyToDataTable();
            }
            else
            {
                return sysPara.Clone();
            }
            

        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,RefType,RefTypeDesc,RefValue,RefText,RefDesc,Status ");
            strSql.Append(" FROM cos_sysPara ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Instance.ExecSqlDataTable(strSql.ToString());
        }
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SysParaEntity GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,RefType,RefTypeDesc,RefValue,RefText,RefDesc,Status from cos_sysPara ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            SysParaEntity model = new SysParaEntity();
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
        /// 得到一个对象实体
        /// </summary>
        private SysParaEntity DataRowToModel(DataRow row)
        {
            SysParaEntity model = new SysParaEntity();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["RefType"] != null)
                {
                    model.RefType = row["RefType"].ToString();
                }
                if (row["RefTypeDesc"] != null)
                {
                    model.RefTypeDesc = row["RefTypeDesc"].ToString();
                }
                if (row["RefValue"] != null)
                {
                    model.RefValue = row["RefValue"].ToString();
                }
                if (row["RefText"] != null)
                {
                    model.RefText = row["RefText"].ToString();
                }
                if (row["RefDesc"] != null)
                {
                    model.RefDesc = row["RefDesc"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
            }
            return model;
        }
    }
}