using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    /// <summary>
    /// 菜单模块表
    /// </summary>
    public class MenuModuleDb
    {
        #region instance
        private volatile static MenuModuleDb _instance = null;
        private static readonly object lockHelper = new object();
        private MenuModuleDb() { }
        public static MenuModuleDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new MenuModuleDb();
                    }
                }
                return _instance;
            }
        }
        #endregion

        #region  自动生成

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MenuModuleEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_menuModule(");
            strSql.Append("RefType,RefTypeDesc,RefHref,RefClass,RefTxt,ParentType,AddTime,Status)");
            strSql.Append(" values (");
            strSql.Append("@RefType,@RefTypeDesc,@RefHref,@RefClass,@RefTxt,@ParentType,@AddTime,@Status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@RefType", SqlDbType.VarChar,50),
                    new SqlParameter("@RefTypeDesc", SqlDbType.VarChar,50),
                    new SqlParameter("@RefHref", SqlDbType.VarChar,50),
                    new SqlParameter("@RefClass", SqlDbType.VarChar,50),
                    new SqlParameter("@RefTxt", SqlDbType.VarChar,50),
                    new SqlParameter("@ParentType", SqlDbType.VarChar,50),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.RefType;
            parameters[1].Value = model.RefTypeDesc;
            parameters[2].Value = model.RefHref;
            parameters[3].Value = model.RefClass;
            parameters[4].Value = model.RefTxt;
            parameters[5].Value = model.ParentType;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.Status;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(MenuModuleEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sns_menuModule set ");
            strSql.Append("RefType=@RefType,");
            strSql.Append("RefTypeDesc=@RefTypeDesc,");
            strSql.Append("RefHref=@RefHref,");
            strSql.Append("RefClass=@RefClass,");
            strSql.Append("RefTxt=@RefTxt,");
            strSql.Append("ParentType=@ParentType,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Status=@Status");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@RefType", SqlDbType.VarChar,50),
                    new SqlParameter("@RefTypeDesc", SqlDbType.VarChar,50),
                    new SqlParameter("@RefHref", SqlDbType.VarChar,50),
                    new SqlParameter("@RefClass", SqlDbType.VarChar,50),
                    new SqlParameter("@RefTxt", SqlDbType.VarChar,50),
                    new SqlParameter("@ParentType", SqlDbType.VarChar,50),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.RefType;
            parameters[1].Value = model.RefTypeDesc;
            parameters[2].Value = model.RefHref;
            parameters[3].Value = model.RefClass;
            parameters[4].Value = model.RefTxt;
            parameters[5].Value = model.ParentType;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.Id;

            int rows = SqlHelper.Instance.ExecSqlNonQuery(strSql.ToString(), parameters);
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sns_menuModule ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            int rows = SqlHelper.Instance.ExecSqlNonQuery(strSql.ToString(), parameters);
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sns_menuModule ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = SqlHelper.Instance.ExecSqlNonQuery(strSql.ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public MenuModuleEntity GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,RefType,RefTypeDesc,RefHref,RefClass,RefTxt,ParentType,AddTime,Status from sns_menuModule ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            MenuModuleEntity model = new MenuModuleEntity();
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
        public MenuModuleEntity DataRowToModel(DataRow row)
        {
            MenuModuleEntity model = new MenuModuleEntity();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["RefType"] != null)
                {
                    model.RefType = row["RefType"].ToString();
                }
                if (row["RefTypeDesc"] != null)
                {
                    model.RefTypeDesc = row["RefTypeDesc"].ToString();
                }
                if (row["RefHref"] != null)
                {
                    model.RefHref = row["RefHref"].ToString();
                }
                if (row["RefClass"] != null)
                {
                    model.RefClass = row["RefClass"].ToString();
                }
                if (row["RefTxt"] != null)
                {
                    model.RefTxt = row["RefTxt"].ToString();
                }
                if (row["ParentType"] != null)
                {
                    model.ParentType = row["ParentType"].ToString();
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,RefType,RefTypeDesc,RefHref,RefClass,RefTxt,ParentType,AddTime,Status ");
            strSql.Append(" FROM sns_menuModule ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Instance.ExecSqlDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            if (System.Web.HttpContext.Current.Session["MenuModule0001"] == null)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ");
                if (Top > 0)
                {
                    strSql.Append(" top " + Top.ToString());
                }
                strSql.Append(" Id,RefType,RefTypeDesc,RefHref,RefClass,RefTxt,ParentType,AddTime,Status ");
                strSql.Append(" FROM sns_menuModule ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
                System.Web.HttpContext.Current.Session["MenuModule0001"] = SqlHelper.Instance.ExecSqlDataSet(strSql.ToString());
            }
            return System.Web.HttpContext.Current.Session["MenuModule0001"] as DataSet;
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM sns_menuModule ");
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
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from sns_menuModule T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return SqlHelper.Instance.ExecSqlDataSet(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "sns_menuModule";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion
    }
}