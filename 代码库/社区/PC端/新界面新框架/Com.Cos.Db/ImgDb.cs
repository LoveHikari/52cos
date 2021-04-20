using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    public class ImgDb
    {
        #region instance
        private volatile static ImgDb _instance = null;
        private static readonly object lockHelper = new object();
        private ImgDb() { }
        public static ImgDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new ImgDb();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ImgEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_Img(");
            strSql.Append("ImgUrl,addtime,Status)");
            strSql.Append(" values (");
            strSql.Append("@ImgUrl,@addtime,@Status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@ImgUrl", SqlDbType.VarChar,50),
                    new SqlParameter("@addtime", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.ImgUrl;
            parameters[1].Value = model.addtime;
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
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ImgEntity GetModel(int imgId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ImgId,ImgUrl,addtime,Status from sns_Img ");
            strSql.Append(" where ImgId=@ImgId");
            SqlParameter[] parameters = {
                    new SqlParameter("@ImgId", SqlDbType.Int,4)
            };
            parameters[0].Value = imgId;

            ImgEntity model = new ImgEntity();
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
        private ImgEntity DataRowToModel(DataRow row)
        {
            ImgEntity model = new ImgEntity();
            if (row != null)
            {
                if (row["ImgId"] != null && row["ImgId"].ToString() != "")
                {
                    model.ImgId = int.Parse(row["ImgId"].ToString());
                }
                if (row["ImgUrl"] != null)
                {
                    model.ImgUrl = row["ImgUrl"].ToString();
                }
                if (row["addtime"] != null && row["addtime"].ToString() != "")
                {
                    model.addtime = DateTime.Parse(row["addtime"].ToString());
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