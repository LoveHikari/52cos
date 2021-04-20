using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    /// <summary>
    /// 数据访问类:交换
    /// </summary>
    public class ExchangeDb
    {
        #region instance
        private volatile static ExchangeDb _instance = null;
        private static readonly object lockHelper = new object();
        private ExchangeDb() { }
        public static ExchangeDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new ExchangeDb();
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
        public int Add(ExchangeEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_exchange(");
            strSql.Append("UserId,Title,Describe,ItemName,Cover,Certificate,Imgs,Source,Constitute,Price,Valuation1,Valuation2,Valuation3,Vote1,Vote2,Vote3,Official,ExchangePerson,AddTime,EnterTime,ClassId,Examine,Status)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@Title,@Describe,@ItemName,@Cover,@Certificate,@Imgs,@Source,@Constitute,@Price,@Valuation1,@Valuation2,@Valuation3,@Vote1,@Vote2,@Vote3,@Official,@ExchangePerson,@AddTime,@EnterTime,@ClassId,@Examine,@Status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.VarChar,50),
                    new SqlParameter("@Title", SqlDbType.VarChar,50),
                    new SqlParameter("@Describe", SqlDbType.Text,16),
                    new SqlParameter("@ItemName", SqlDbType.VarChar,50),
                    new SqlParameter("@Cover", SqlDbType.VarChar,50),
                    new SqlParameter("@Certificate", SqlDbType.VarChar,50),
                    new SqlParameter("@Imgs", SqlDbType.VarChar,50),
                    new SqlParameter("@Source", SqlDbType.VarChar,50),
                    new SqlParameter("@Constitute", SqlDbType.VarChar,50),
                    new SqlParameter("@Price", SqlDbType.VarChar,50),
                    new SqlParameter("@Valuation1", SqlDbType.VarChar,50),
                    new SqlParameter("@Valuation2", SqlDbType.VarChar,50),
                    new SqlParameter("@Valuation3", SqlDbType.VarChar,50),
                    new SqlParameter("@Vote1", SqlDbType.Int,4),
                    new SqlParameter("@Vote2", SqlDbType.Int,4),
                    new SqlParameter("@Vote3", SqlDbType.Int,4),
                    new SqlParameter("@Official", SqlDbType.VarChar,50),
                    new SqlParameter("@ExchangePerson", SqlDbType.VarChar,50),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@EnterTime", SqlDbType.DateTime,8),
                    new SqlParameter("@ClassId", SqlDbType.VarChar,50),
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
            parameters[10].Value = model.Valuation1;
            parameters[11].Value = model.Valuation2;
            parameters[12].Value = model.Valuation3;
            parameters[13].Value = model.Vote1;
            parameters[14].Value = model.Vote2;
            parameters[15].Value = model.Vote3;
            parameters[16].Value = model.Official;
            parameters[17].Value = model.ExchangePerson;
            parameters[18].Value = model.AddTime;
            parameters[19].Value = model.EnterTime;
            parameters[20].Value = model.ClassId;
            parameters[21].Value = model.Examine;
            parameters[22].Value = model.Status;

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
        public bool Update(ExchangeEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sns_exchange set ");
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
            strSql.Append("Valuation1=@Valuation1,");
            strSql.Append("Valuation2=@Valuation2,");
            strSql.Append("Valuation3=@Valuation3,");
            strSql.Append("Vote1=@Vote1,");
            strSql.Append("Vote2=@Vote2,");
            strSql.Append("Vote3=@Vote3,");
            strSql.Append("Official=@Official,");
            strSql.Append("ExchangePerson=@ExchangePerson,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("EnterTime=@EnterTime,");
            strSql.Append("ClassId=@ClassId,");
            strSql.Append("Examine=@Examine,");
            strSql.Append("Status=@Status");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.VarChar,50),
                    new SqlParameter("@Title", SqlDbType.VarChar,50),
                    new SqlParameter("@Describe", SqlDbType.Text,16),
                    new SqlParameter("@ItemName", SqlDbType.VarChar,50),
                    new SqlParameter("@Cover", SqlDbType.VarChar,50),
                    new SqlParameter("@Certificate", SqlDbType.VarChar,50),
                    new SqlParameter("@Imgs", SqlDbType.VarChar,50),
                    new SqlParameter("@Source", SqlDbType.VarChar,50),
                    new SqlParameter("@Constitute", SqlDbType.VarChar,50),
                    new SqlParameter("@Price", SqlDbType.VarChar,50),
                    new SqlParameter("@Valuation1", SqlDbType.VarChar,50),
                    new SqlParameter("@Valuation2", SqlDbType.VarChar,50),
                    new SqlParameter("@Valuation3", SqlDbType.VarChar,50),
                    new SqlParameter("@Vote1", SqlDbType.Int,4),
                    new SqlParameter("@Vote2", SqlDbType.Int,4),
                    new SqlParameter("@Vote3", SqlDbType.Int,4),
                    new SqlParameter("@Official", SqlDbType.VarChar,50),
                    new SqlParameter("@ExchangePerson", SqlDbType.VarChar,50),
                    new SqlParameter("@AddTime", SqlDbType.DateTime,8),
                    new SqlParameter("@EnterTime", SqlDbType.DateTime,8),
                    new SqlParameter("@ClassId", SqlDbType.VarChar,50),
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
            parameters[10].Value = model.Valuation1;
            parameters[11].Value = model.Valuation2;
            parameters[12].Value = model.Valuation3;
            parameters[13].Value = model.Vote1;
            parameters[14].Value = model.Vote2;
            parameters[15].Value = model.Vote3;
            parameters[16].Value = model.Official;
            parameters[17].Value = model.ExchangePerson;
            parameters[18].Value = model.AddTime;
            parameters[19].Value = model.EnterTime;
            parameters[20].Value = model.ClassId;
            parameters[21].Value = model.Examine;
            parameters[22].Value = model.Status;
            parameters[23].Value = model.Id;

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
            strSql.Append("delete from sns_exchange ");
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
            strSql.Append("delete from sns_exchange ");
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
        public ExchangeEntity GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,UserId,Title,Describe,ItemName,Cover,Certificate,Imgs,Source,Constitute,Price,Valuation1,Valuation2,Valuation3,Vote1,Vote2,Vote3,Official,ExchangePerson,AddTime,EnterTime,ClassId,Examine,Status from sns_exchange ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;
            ExchangeEntity model = new ExchangeEntity();
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
        public ExchangeEntity DataRowToModel(DataRow row)
        {
            ExchangeEntity model = new ExchangeEntity();
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
                if (row["Valuation1"] != null)
                {
                    model.Valuation1 = row["Valuation1"].ToString();
                }
                if (row["Valuation2"] != null)
                {
                    model.Valuation2 = row["Valuation2"].ToString();
                }
                if (row["Valuation3"] != null)
                {
                    model.Valuation3 = row["Valuation3"].ToString();
                }
                if (row["Vote1"] != null && row["Vote1"].ToString() != "")
                {
                    model.Vote1 = int.Parse(row["Vote1"].ToString());
                }
                if (row["Vote2"] != null && row["Vote2"].ToString() != "")
                {
                    model.Vote2 = int.Parse(row["Vote2"].ToString());
                }
                if (row["Vote3"] != null && row["Vote3"].ToString() != "")
                {
                    model.Vote3 = int.Parse(row["Vote3"].ToString());
                }
                if (row["Official"] != null)
                {
                    model.Official = row["Official"].ToString();
                }
                if (row["ExchangePerson"] != null)
                {
                    model.ExchangePerson = row["ExchangePerson"].ToString();
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
                }
                if (row["EnterTime"] != null && row["EnterTime"].ToString() != "")
                {
                    model.EnterTime = DateTime.Parse(row["EnterTime"].ToString());
                }
                if (row["ClassId"] != null)
                {
                    model.ClassId = row["ClassId"].ToString();
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
            strSql.Append("select Id,UserId,Title,Describe,ItemName,Cover,Certificate,Imgs,Source,Constitute,Price,Valuation1,Valuation2,Valuation3,Vote1,Vote2,Vote3,Official,ExchangePerson,AddTime,EnterTime,ClassId,Examine,Status ");
            strSql.Append(" FROM sns_exchange ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Instance.ExecSqlDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" Id,UserId,Title,Describe,ItemName,Cover,Certificate,Imgs,Source,Constitute,Price,Valuation1,Valuation2,Valuation3,Vote1,Vote2,Vote3,Official,ExchangePerson,AddTime,EnterTime,ClassId,Examine,Status ");
            strSql.Append(" FROM sns_exchange ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
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
            strSql.Append(" Id,UserId,Title,Describe,ItemName,Cover,Certificate,Imgs,Source,Constitute,Price,Valuation1,Valuation2,Valuation3,Vote1,Vote2,Vote3,Official,ExchangePerson,AddTime,EnterTime,ClassId,Examine,Status ");
            strSql.Append(" FROM sns_exchange ");
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
            strSql.Append("select count(1) FROM sns_exchange ");
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
            strSql.Append(")AS Row, T.*  from sns_exchange T ");
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
			parameters[0].Value = "sns_exchange";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return SqlHelper.Instance.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        /// <param name="Top">前几行</param>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序</param>
        /// <returns></returns>
        public DataSet GetList2(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" b.nickname,b.Portrait, a.* ");
            strSql.Append(" FROM sns_exchange a LEFT JOIN dbo.cos_member b ON a.UserId=b.User_id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.Instance.ExecSqlDataSet(strSql.ToString());
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage2(string strWhere, string orderby, int startIndex, int endIndex)
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
            strSql.Append(")AS Row, T.*,a.nickname,a.Portrait  from sns_exchange T ");
            strSql.Append(" LEFT JOIN dbo.cos_member a ON a.User_id=t.UserId" );
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return SqlHelper.Instance.ExecSqlDataSet(strSql.ToString());
        }
    }
}