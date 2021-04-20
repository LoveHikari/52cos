using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    /// <summary>
    /// 出租表
    /// </summary>
    public class RentDb
    {
        #region instance
        private volatile static RentDb _instance = null;
        private static readonly object lockHelper = new object();
        private RentDb() { }
        public static RentDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new RentDb();
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
        public int Add(RentEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_rent(");
            strSql.Append("UserId,Title,Describe,ItemName,Cover,Certificate,Imgs,Source,Constitute,Price,Official,RentPerson,AddTime,EnterTime,Examine,Status)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@Title,@Describe,@ItemName,@Cover,@Certificate,@Imgs,@Source,@Constitute,@Price,@Official,@RentPerson,@AddTime,@EnterTime,@Examine,@Status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.VarChar,50),
                    new SqlParameter("@Title", SqlDbType.VarChar,500),
                    new SqlParameter("@Describe", SqlDbType.Text),
                    new SqlParameter("@ItemName", SqlDbType.VarChar,500),
                    new SqlParameter("@Cover", SqlDbType.VarChar,50),
                    new SqlParameter("@Certificate", SqlDbType.VarChar,50),
                    new SqlParameter("@Imgs", SqlDbType.VarChar,500),
                    new SqlParameter("@Source", SqlDbType.VarChar,500),
                    new SqlParameter("@Constitute", SqlDbType.VarChar,500),
                    new SqlParameter("@Price", SqlDbType.VarChar,50),
                    new SqlParameter("@Official", SqlDbType.VarChar,50),
                    new SqlParameter("@RentPerson", SqlDbType.VarChar,50),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@EnterTime", SqlDbType.DateTime),
                    new SqlParameter("@Examine", SqlDbType.VarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Describe;
            parameters[3].Value = model.ItemName;
            parameters[4].Value = model.Cover;
            parameters[5].Value = model.Certificate;
            parameters[6].Value = model.Imgs;
            parameters[7].Value = model.Source;
            parameters[8].Value = model.Constitute;
            parameters[9].Value = model.Price;
            parameters[10].Value = model.Official;
            parameters[11].Value = model.RentPerson;
            parameters[12].Value = model.AddTime;
            parameters[13].Value = model.EnterTime;
            parameters[14].Value = model.Examine;
            parameters[15].Value = model.Status;

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
        public bool Update(RentEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sns_rent set ");
            strSql.Append("UserId=@UserId,");
            strSql.Append("Title=@Title,");
            strSql.Append("Describe=@Describe,");
            strSql.Append("ItemName=@ItemName,");
            strSql.Append("Cover=@Cover,");
            strSql.Append("Certificate=@Certificate,");
            strSql.Append("Imgs=@Imgs,");
            strSql.Append("Source=@Source,");
            strSql.Append("Constitute=@Constitute,");
            strSql.Append("Price=@Price,");
            strSql.Append("Official=@Official,");
            strSql.Append("RentPerson=@RentPerson,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("EnterTime=@EnterTime,");
            strSql.Append("Examine=@Examine,");
            strSql.Append("Status=@Status");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.VarChar,50),
                    new SqlParameter("@Title", SqlDbType.VarChar,500),
                    new SqlParameter("@Describe", SqlDbType.Text),
                    new SqlParameter("@ItemName", SqlDbType.VarChar,500),
                    new SqlParameter("@Cover", SqlDbType.VarChar,50),
                    new SqlParameter("@Certificate", SqlDbType.VarChar,50),
                    new SqlParameter("@Imgs", SqlDbType.VarChar,500),
                    new SqlParameter("@Source", SqlDbType.VarChar,500),
                    new SqlParameter("@Constitute", SqlDbType.VarChar,500),
                    new SqlParameter("@Price", SqlDbType.VarChar,50),
                    new SqlParameter("@Official", SqlDbType.VarChar,50),
                    new SqlParameter("@RentPerson", SqlDbType.VarChar,50),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@EnterTime", SqlDbType.DateTime),
                    new SqlParameter("@Examine", SqlDbType.VarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Describe;
            parameters[3].Value = model.ItemName;
            parameters[4].Value = model.Cover;
            parameters[5].Value = model.Certificate;
            parameters[6].Value = model.Imgs;
            parameters[7].Value = model.Source;
            parameters[8].Value = model.Constitute;
            parameters[9].Value = model.Price;
            parameters[10].Value = model.Official;
            parameters[11].Value = model.RentPerson;
            parameters[12].Value = model.AddTime;
            parameters[13].Value = model.EnterTime;
            parameters[14].Value = model.Examine;
            parameters[15].Value = model.Status;
            parameters[16].Value = model.Id;

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
            strSql.Append("delete from sns_rent ");
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
            strSql.Append("delete from sns_rent ");
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
        public RentEntity GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,UserId,Title,Describe,ItemName,Cover,Certificate,Imgs,Source,Constitute,Price,Official,RentPerson,AddTime,EnterTime,Examine,Status from sns_rent ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            RentEntity model = new RentEntity();
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
        public RentEntity DataRowToModel(DataRow row)
        {
            RentEntity model = new RentEntity();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["UserId"] != null)
                {
                    model.UserId = row["UserId"].ToString();
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Describe"] != null)
                {
                    model.Describe = row["Describe"].ToString();
                }
                if (row["ItemName"] != null)
                {
                    model.ItemName = row["ItemName"].ToString();
                }
                if (row["Cover"] != null)
                {
                    model.Cover = row["Cover"].ToString();
                }
                if (row["Certificate"] != null)
                {
                    model.Certificate = row["Certificate"].ToString();
                }
                if (row["Imgs"] != null)
                {
                    model.Imgs = row["Imgs"].ToString();
                }
                if (row["Source"] != null)
                {
                    model.Source = row["Source"].ToString();
                }
                if (row["Constitute"] != null)
                {
                    model.Constitute = row["Constitute"].ToString();
                }
                if (row["Price"] != null)
                {
                    model.Price = row["Price"].ToString();
                }
                if (row["Official"] != null)
                {
                    model.Official = row["Official"].ToString();
                }
                if (row["RentPerson"] != null)
                {
                    model.RentPerson = row["RentPerson"].ToString();
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
                }
                if (row["EnterTime"] != null && row["EnterTime"].ToString() != "")
                {
                    model.EnterTime = DateTime.Parse(row["EnterTime"].ToString());
                }
                if (row["Examine"] != null)
                {
                    model.Examine = row["Examine"].ToString();
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
            strSql.Append("select Id,UserId,Title,Describe,ItemName,Cover,Certificate,Imgs,Source,Constitute,Price,Official,RentPerson,AddTime,EnterTime,Examine,Status ");
            strSql.Append(" FROM sns_rent ");
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,UserId,Title,Describe,ItemName,Cover,Certificate,Imgs,Source,Constitute,Price,Official,RentPerson,AddTime,EnterTime,Examine,Status ");
            strSql.Append(" FROM sns_rent ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.Instance.ExecSqlDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM sns_rent ");
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
            strSql.Append(")AS Row, T.*  from sns_rent T ");
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
			parameters[0].Value = "sns_rent";
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