using Com.Cos.Entity;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    public class MemberDb
    {
        #region instance
        private volatile static MemberDb _instance = null;
        private static readonly object lockHelper = new object();
        private MemberDb() { }
        public static MemberDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new MemberDb();
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
        public int Add(MemberEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into cos_member(");
            strSql.Append("User_name,Email,Password,Real_name,Gender,Birthday,Phone_tel,Phone_mob,Im_qq,Im_msn,In_skype,Im_yahoo,Im_aliww,Reg_time,Last_login,Last_ip,Logins,Ugrade,Portrait,Outer_id,Activation,Feed_config,Status,reward,CNbi,integral,nickname,ardent,Growth,code,Describe,Shenjia,Bean)");
            strSql.Append(" values (");
            strSql.Append("@User_name,@Email,@Password,@Real_name,@Gender,@Birthday,@Phone_tel,@Phone_mob,@Im_qq,@Im_msn,@In_skype,@Im_yahoo,@Im_aliww,@Reg_time,@Last_login,@Last_ip,@Logins,@Ugrade,@Portrait,@Outer_id,@Activation,@Feed_config,@Status,@reward,@CNbi,@integral,@nickname,@ardent,@Growth,@code,@Describe,@Shenjia,@Bean)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@User_name", SqlDbType.VarChar,50),
                    new SqlParameter("@Email", SqlDbType.VarChar,50),
                    new SqlParameter("@Password", SqlDbType.VarChar,50),
                    new SqlParameter("@Real_name", SqlDbType.VarChar,50),
                    new SqlParameter("@Gender", SqlDbType.VarChar,50),
                    new SqlParameter("@Birthday", SqlDbType.VarChar,50),
                    new SqlParameter("@Phone_tel", SqlDbType.VarChar,50),
                    new SqlParameter("@Phone_mob", SqlDbType.VarChar,50),
                    new SqlParameter("@Im_qq", SqlDbType.VarChar,50),
                    new SqlParameter("@Im_msn", SqlDbType.VarChar,50),
                    new SqlParameter("@In_skype", SqlDbType.VarChar,50),
                    new SqlParameter("@Im_yahoo", SqlDbType.VarChar,50),
                    new SqlParameter("@Im_aliww", SqlDbType.VarChar,50),
                    new SqlParameter("@Reg_time", SqlDbType.DateTime),
                    new SqlParameter("@Last_login", SqlDbType.DateTime),
                    new SqlParameter("@Last_ip", SqlDbType.VarChar,50),
                    new SqlParameter("@Logins", SqlDbType.Int,4),
                    new SqlParameter("@Ugrade", SqlDbType.Int,4),
                    new SqlParameter("@Portrait", SqlDbType.VarChar,500),
                    new SqlParameter("@Outer_id", SqlDbType.VarChar,50),
                    new SqlParameter("@Activation", SqlDbType.VarChar,50),
                    new SqlParameter("@Feed_config", SqlDbType.VarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@reward", SqlDbType.Int,4),
                    new SqlParameter("@CNbi", SqlDbType.Int,4),
                    new SqlParameter("@integral", SqlDbType.Int,4),
                    new SqlParameter("@nickname", SqlDbType.VarChar,50),
                    new SqlParameter("@ardent", SqlDbType.Int,4),
                    new SqlParameter("@Growth", SqlDbType.Int,4),
                    new SqlParameter("@code", SqlDbType.VarChar,500),
                    new SqlParameter("@Describe", SqlDbType.Text),
                    new SqlParameter("@Shenjia", SqlDbType.Money,8),
                    new SqlParameter("@Bean", SqlDbType.VarChar,50)};
            parameters[0].Value = model.User_name;
            parameters[1].Value = model.Email;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.Real_name;
            parameters[4].Value = model.Gender;
            parameters[5].Value = model.Birthday;
            parameters[6].Value = model.Phone_tel;
            parameters[7].Value = model.Phone_mob;
            parameters[8].Value = model.Im_qq;
            parameters[9].Value = model.Im_msn;
            parameters[10].Value = model.In_skype;
            parameters[11].Value = model.Im_yahoo;
            parameters[12].Value = model.Im_aliww;
            parameters[13].Value = model.Reg_time;
            parameters[14].Value = model.Last_login;
            parameters[15].Value = model.Last_ip;
            parameters[16].Value = model.Logins;
            parameters[17].Value = model.Ugrade;
            parameters[18].Value = model.Portrait;
            parameters[19].Value = model.Outer_id;
            parameters[20].Value = model.Activation;
            parameters[21].Value = model.Feed_config;
            parameters[22].Value = model.Status;
            parameters[23].Value = model.reward;
            parameters[24].Value = model.CNbi;
            parameters[25].Value = model.integral;
            parameters[26].Value = model.nickname;
            parameters[27].Value = model.ardent;
            parameters[28].Value = model.Growth;
            parameters[29].Value = model.code;
            parameters[30].Value = model.Describe;
            parameters[31].Value = model.Shenjia;
            parameters[32].Value = model.Bean;

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
        public bool Update(MemberEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update cos_member set ");
            strSql.Append("User_name=@User_name,");
            strSql.Append("Email=@Email,");
            strSql.Append("Password=@Password,");
            strSql.Append("Real_name=@Real_name,");
            strSql.Append("Gender=@Gender,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("Phone_tel=@Phone_tel,");
            strSql.Append("Phone_mob=@Phone_mob,");
            strSql.Append("Im_qq=@Im_qq,");
            strSql.Append("Im_msn=@Im_msn,");
            strSql.Append("In_skype=@In_skype,");
            strSql.Append("Im_yahoo=@Im_yahoo,");
            strSql.Append("Im_aliww=@Im_aliww,");
            strSql.Append("Reg_time=@Reg_time,");
            strSql.Append("Last_login=@Last_login,");
            strSql.Append("Last_ip=@Last_ip,");
            strSql.Append("Logins=@Logins,");
            strSql.Append("Ugrade=@Ugrade,");
            strSql.Append("Portrait=@Portrait,");
            strSql.Append("Outer_id=@Outer_id,");
            strSql.Append("Activation=@Activation,");
            strSql.Append("Feed_config=@Feed_config,");
            strSql.Append("Status=@Status,");
            strSql.Append("reward=@reward,");
            strSql.Append("CNbi=@CNbi,");
            strSql.Append("integral=@integral,");
            strSql.Append("nickname=@nickname,");
            strSql.Append("ardent=@ardent,");
            strSql.Append("Growth=@Growth,");
            strSql.Append("code=@code,");
            strSql.Append("Describe=@Describe,");
            strSql.Append("Shenjia=@Shenjia,");
            strSql.Append("Bean=@Bean");
            strSql.Append(" where User_id=@User_id");
            SqlParameter[] parameters = {
                    new SqlParameter("@User_name", SqlDbType.VarChar,50),
                    new SqlParameter("@Email", SqlDbType.VarChar,50),
                    new SqlParameter("@Password", SqlDbType.VarChar,50),
                    new SqlParameter("@Real_name", SqlDbType.VarChar,50),
                    new SqlParameter("@Gender", SqlDbType.VarChar,50),
                    new SqlParameter("@Birthday", SqlDbType.VarChar,50),
                    new SqlParameter("@Phone_tel", SqlDbType.VarChar,50),
                    new SqlParameter("@Phone_mob", SqlDbType.VarChar,50),
                    new SqlParameter("@Im_qq", SqlDbType.VarChar,50),
                    new SqlParameter("@Im_msn", SqlDbType.VarChar,50),
                    new SqlParameter("@In_skype", SqlDbType.VarChar,50),
                    new SqlParameter("@Im_yahoo", SqlDbType.VarChar,50),
                    new SqlParameter("@Im_aliww", SqlDbType.VarChar,50),
                    new SqlParameter("@Reg_time", SqlDbType.DateTime),
                    new SqlParameter("@Last_login", SqlDbType.DateTime),
                    new SqlParameter("@Last_ip", SqlDbType.VarChar,50),
                    new SqlParameter("@Logins", SqlDbType.Int,4),
                    new SqlParameter("@Ugrade", SqlDbType.Int,4),
                    new SqlParameter("@Portrait", SqlDbType.VarChar,500),
                    new SqlParameter("@Outer_id", SqlDbType.VarChar,50),
                    new SqlParameter("@Activation", SqlDbType.VarChar,50),
                    new SqlParameter("@Feed_config", SqlDbType.VarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@reward", SqlDbType.Int,4),
                    new SqlParameter("@CNbi", SqlDbType.Int,4),
                    new SqlParameter("@integral", SqlDbType.Int,4),
                    new SqlParameter("@nickname", SqlDbType.VarChar,50),
                    new SqlParameter("@ardent", SqlDbType.Int,4),
                    new SqlParameter("@Growth", SqlDbType.Int,4),
                    new SqlParameter("@code", SqlDbType.VarChar,500),
                    new SqlParameter("@Describe", SqlDbType.Text),
                    new SqlParameter("@Shenjia", SqlDbType.Money,8),
                    new SqlParameter("@Bean", SqlDbType.VarChar,50),
                    new SqlParameter("@User_id", SqlDbType.Int,4)};
            parameters[0].Value = model.User_name;
            parameters[1].Value = model.Email;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.Real_name;
            parameters[4].Value = model.Gender;
            parameters[5].Value = model.Birthday;
            parameters[6].Value = model.Phone_tel;
            parameters[7].Value = model.Phone_mob;
            parameters[8].Value = model.Im_qq;
            parameters[9].Value = model.Im_msn;
            parameters[10].Value = model.In_skype;
            parameters[11].Value = model.Im_yahoo;
            parameters[12].Value = model.Im_aliww;
            parameters[13].Value = model.Reg_time;
            parameters[14].Value = model.Last_login;
            parameters[15].Value = model.Last_ip;
            parameters[16].Value = model.Logins;
            parameters[17].Value = model.Ugrade;
            parameters[18].Value = model.Portrait;
            parameters[19].Value = model.Outer_id;
            parameters[20].Value = model.Activation;
            parameters[21].Value = model.Feed_config;
            parameters[22].Value = model.Status;
            parameters[23].Value = model.reward;
            parameters[24].Value = model.CNbi;
            parameters[25].Value = model.integral;
            parameters[26].Value = model.nickname;
            parameters[27].Value = model.ardent;
            parameters[28].Value = model.Growth;
            parameters[29].Value = model.code;
            parameters[30].Value = model.Describe;
            parameters[31].Value = model.Shenjia;
            parameters[32].Value = model.Bean;
            parameters[33].Value = model.User_id;

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
        public bool Delete(int User_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from cos_member ");
            strSql.Append(" where User_id=@User_id");
            SqlParameter[] parameters = {
                    new SqlParameter("@User_id", SqlDbType.Int,4)
            };
            parameters[0].Value = User_id;

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
        public bool DeleteList(string User_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from cos_member ");
            strSql.Append(" where User_id in (" + User_idlist + ")  ");
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
        public MemberEntity GetModel(int User_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from cos_member ");
            strSql.Append(" where User_id=@User_id");
            SqlParameter[] parameters = {
                    new SqlParameter("@User_id", SqlDbType.Int,4)
            };
            parameters[0].Value = User_id;

            MemberEntity model = new MemberEntity();
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
        public MemberEntity DataRowToModel(DataRow row)
        {
            MemberEntity model = new MemberEntity();
            if (row != null)
            {
                if (row["User_id"] != null && row["User_id"].ToString() != "")
                {
                    model.User_id = int.Parse(row["User_id"].ToString());
                }
                if (row["User_name"] != null)
                {
                    model.User_name = row["User_name"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["Real_name"] != null)
                {
                    model.Real_name = row["Real_name"].ToString();
                }
                if (row["Gender"] != null)
                {
                    model.Gender = row["Gender"].ToString();
                }
                if (row["Birthday"] != null)
                {
                    model.Birthday = row["Birthday"].ToString();
                }
                if (row["Phone_tel"] != null)
                {
                    model.Phone_tel = row["Phone_tel"].ToString();
                }
                if (row["Phone_mob"] != null)
                {
                    model.Phone_mob = row["Phone_mob"].ToString();
                }
                if (row["Im_qq"] != null)
                {
                    model.Im_qq = row["Im_qq"].ToString();
                }
                if (row["Im_msn"] != null)
                {
                    model.Im_msn = row["Im_msn"].ToString();
                }
                if (row["In_skype"] != null)
                {
                    model.In_skype = row["In_skype"].ToString();
                }
                if (row["Im_yahoo"] != null)
                {
                    model.Im_yahoo = row["Im_yahoo"].ToString();
                }
                if (row["Im_aliww"] != null)
                {
                    model.Im_aliww = row["Im_aliww"].ToString();
                }
                if (row["Reg_time"] != null && row["Reg_time"].ToString() != "")
                {
                    model.Reg_time = DateTime.Parse(row["Reg_time"].ToString());
                }
                if (row["Last_login"] != null && row["Last_login"].ToString() != "")
                {
                    model.Last_login = DateTime.Parse(row["Last_login"].ToString());
                }
                if (row["Last_ip"] != null)
                {
                    model.Last_ip = row["Last_ip"].ToString();
                }
                if (row["Logins"] != null && row["Logins"].ToString() != "")
                {
                    model.Logins = int.Parse(row["Logins"].ToString());
                }
                if (row["Ugrade"] != null && row["Ugrade"].ToString() != "")
                {
                    model.Ugrade = int.Parse(row["Ugrade"].ToString());
                }
                if (row["Portrait"] != null)
                {
                    model.Portrait = row["Portrait"].ToString();
                }
                if (row["Outer_id"] != null)
                {
                    model.Outer_id = row["Outer_id"].ToString();
                }
                if (row["Activation"] != null)
                {
                    model.Activation = row["Activation"].ToString();
                }
                if (row["Feed_config"] != null)
                {
                    model.Feed_config = row["Feed_config"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["reward"] != null && row["reward"].ToString() != "")
                {
                    model.reward = int.Parse(row["reward"].ToString());
                }
                if (row["CNbi"] != null && row["CNbi"].ToString() != "")
                {
                    model.CNbi = int.Parse(row["CNbi"].ToString());
                }
                if (row["integral"] != null && row["integral"].ToString() != "")
                {
                    model.integral = int.Parse(row["integral"].ToString());
                }
                if (row["nickname"] != null)
                {
                    model.nickname = row["nickname"].ToString();
                }
                if (row["ardent"] != null && row["ardent"].ToString() != "")
                {
                    model.ardent = int.Parse(row["ardent"].ToString());
                }
                if (row["Growth"] != null && row["Growth"].ToString() != "")
                {
                    model.Growth = int.Parse(row["Growth"].ToString());
                }
                if (row["code"] != null)
                {
                    model.code = row["code"].ToString();
                }
                if (row["Describe"] != null)
                {
                    model.Describe = row["Describe"].ToString();
                }
                if (!string.IsNullOrEmpty(row["Shenjia"].ToString()))
                {
                    model.Shenjia = decimal.Parse(row["Shenjia"].ToString());
                }                
                if (row["Bean"] != null)
                {
                    model.Bean = row["Bean"].ToString();
                }
                if (row["Stime"] != null && row["Stime"].ToString() != "")
                {
                    model.Stime = DateTime.Parse(row["Stime"].ToString());
                }
                if (row["Etime"] != null && row["Etime"].ToString() != "")
                {
                    model.Etime = DateTime.Parse(row["Etime"].ToString());
                }
                if (row["Lv"] != null && row["Lv"].ToString() != "")
                {
                    model.Lv = int.Parse(row["Lv"].ToString());
                }
                if (row["Conversions"] != null && row["Conversions"].ToString() != "")
                {
                    model.Conversions = int.Parse(row["Conversions"].ToString());
                }
                if (row["RemainingConversions"] != null && row["RemainingConversions"].ToString() != "")
                {
                    model.RemainingConversions = int.Parse(row["RemainingConversions"].ToString());
                }
                if (!string.IsNullOrEmpty(row["Deposit"].ToString()))
                {
                    model.Deposit = decimal.Parse(row["Deposit"].ToString());
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
            strSql.Append("select * ");
            strSql.Append(" FROM cos_member ");
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
            strSql.Append(" User_id,User_name,Email,Password,Real_name,Gender,Birthday,Phone_tel,Phone_mob,Im_qq,Im_msn,In_skype,Im_yahoo,Im_aliww,Reg_time,Last_login,Last_ip,Logins,Ugrade,Portrait,Outer_id,Activation,Feed_config,Status,reward,CNbi,integral,nickname,ardent,Growth,code,Describe,Shenjia,Bean ");
            strSql.Append(" FROM cos_member ");
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
            strSql.Append("select count(1) FROM cos_member ");
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
                strSql.Append("order by T.User_id desc");
            }
            strSql.Append(")AS Row, T.*  from cos_member T ");
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
			parameters[0].Value = "cos_member";
			parameters[1].Value = "User_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion

        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public DataTable GetList(string code)
        //{
        //    string strWhere = "code='" + code + "'";
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select User_id,User_name,Email,Password,Real_name,Gender,Birthday,Phone_tel,Phone_mob,Im_qq,Im_msn,In_skype,Im_yahoo,Im_aliww,Reg_time,Last_login,Last_ip,Logins,Ugrade,Portrait,Outer_id,Activation,Feed_config,Status,reward,CNbi,integral,nickname,ardent,Growth,code ");
        //    strSql.Append(" FROM cos_member ");
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    return SqlHelper.Instance.ExecSqlDataTable(strSql.ToString());
        //}
        /// <summary>
        /// 修改激活状态
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int Update(string userId)
        {
            string sql = $@"UPDATE dbo.cos_member
                            SET Activation='1'
                            WHERE User_id='{userId}'";
            return SqlHelper.Instance.ExecSqlNonQuery(sql);
        }
        /// <summary>
        /// 修改邮箱激活码
        /// </summary>
        /// <param name="oldCode">原来的激活码</param>
        /// <param name="newCode">新的激活码</param>
        /// <returns></returns>
        public int Update(string oldCode, string newCode)
        {
            string sql = $@"UPDATE dbo.cos_member
                            SET Activation='0', code='{newCode}'
                            WHERE code='{oldCode}'";
            return SqlHelper.Instance.ExecSqlNonQuery(sql);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        //public void Add(DataTable dt, string tableName)
        //{
        //    DataFunction.ExecuteNonQuery(dt, tableName);
        //}

        ///// <summary>
        ///// 根据账号获得表
        ///// </summary>
        //public DataTable GetTableByNumber(string number)
        //{
        //    string sql = string.Format(@"SELECT * FROM dbo.cos_member 
        //                                WHERE User_name='{0}'", number);
        //    return DataFunction.FillDataTable(sql).Tables[0];
        //}

        /// <summary>
        /// 根据邮箱密码获得表
        /// </summary>
        public DataTable GetTableByNumberAndPassword(string email, string password)
        {
            string sql = string.Format(@"SELECT * FROM dbo.cos_member 
                                        WHERE Email='{0}' AND Password='{1}'", email, password);
            return SqlHelper.Instance.ExecSqlDataTable(sql);
        }

        ///// <summary>
        ///// 根据用户Id获得用户表
        ///// </summary>
        //public DataTable GetTableById(string userId)
        //{
        //    string sql = string.Format(@"SELECT * FROM dbo.cos_member 
        //                                WHERE User_id='{0}'", userId);
        //    return DataFunction.FillDataTable(sql).Tables[0];
        //}

        ///// <summary>
        ///// 修改个人信息
        ///// </summary>
        ///// <param name="userId"></param>
        ///// <param name="realName"></param>
        ///// <param name="gender"></param>
        ///// <param name="birthday"></param>
        ///// <param name="portrait"></param>
        //public int UpdateMyData(string userId, string realName, string gender, string birthday, string portrait, string nickname)
        //{
        //    string sql = string.Format(@"UPDATE cos_member
        //                            SET Real_name='{0}',Gender='{1}',Birthday='{2}',Portrait='{3}',nickname='{5}'
        //                            WHERE User_id='{4}'", realName, gender, birthday, portrait, userId, nickname);
        //    return DataFunction.ExecuteNonQuery(sql);
        //}

        ///// <summary>
        ///// 根据帖子id删除帖子及其相关信息
        ///// </summary>
        ///// <param name="noteId"></param>
        ///// <returns></returns>
        //public int DeleteNote(string noteId, string userId)
        //{
        //    //1.删除图片
        //    //2.删除回复贴
        //    //3.删除相关打赏信息
        //    //4.删除相关点赞信息
        //    //5.删除帖子
        //    string sql = string.Format(@"UPDATE sns_noteImg
        //                                SET Status='0'
        //                                WHERE NoteId='{0}';
        //                                UPDATE sns_reply
        //                                SET Status='0'
        //                                WHERE NoteId='{0}';
        //                                UPDATE sns_reward
        //                                SET Status='0'
        //                                WHERE NoteId='{0}';
        //                                UPDATE sns_userGood
        //                                SET Status='0'
        //                                WHERE NoteId='{0}';
        //                                UPDATE sns_ordinaryNote
        //                                SET Status='0'
        //                                WHERE NoteId='{0}';", noteId);
        //    DataFunction.ExecuteNonQuery(sql);
        //    //加积分
        //    MemberDb.Instance.UpdateIntegral(userId, "integral", "-1");
        //    //增加记录
        //    IntegralChangeEntity ice = new IntegralChangeEntity();
        //    ice.UserId = userId;
        //    ice.source = "deleteWorks";
        //    ice.Cnbi = 0;
        //    ice.integral = -1;
        //    ice.ardent = 0;
        //    ice.Growth = 0;
        //    ice.Status = 1;
        //    return DbIntegralChange.Instance.Add(ice);
        //}

        /// <summary>
        /// 修改积分或热心或成长值或CN币
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="t">积分或热心或成长值或CN币对应的字段（integral、ardent、Growth、Cnbi）</param>
        /// <param name="integral">要修改的数值</param>
        public int UpdateIntegral(string userId, string t, string integral)
        {
            //取原来的值
            string strSql = $@"SELECT CASE WHEN {t} IS NULL THEN 0 ELSE {t} END {t} FROM cos_member where User_id='{userId}'";
            decimal oldValue = decimal.Parse(SqlHelper.Instance.ExecSqlScalar(strSql).ToString());

            //加积分
            string sql = string.Format(@"UPDATE dbo.cos_member 
                                SET {2}='{1}'
                                WHERE User_id='{0}'", userId, decimal.Parse(integral) + oldValue, t);
            return SqlHelper.Instance.ExecSqlNonQuery(sql);
        }
        /// <summary>
        /// 修改会员时间
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="money">金额</param>
        /// <returns></returns>
        public int UpdateVip(string userId, string money)
        {
            
            DateTime stime = new DateTime();    //开始时间
            DateTime etime = new DateTime();   //结束时间
            int conversions, remainingConversions,addcon = 0;    //总次数，剩余次数,添加次数
            string month = ""; //月数
            if (double.Parse(money) == 20)
            {
                month = "1";
                addcon = 1;
            }
            if (double.Parse(money) == 55)
            {
                month = "6";
                addcon = 4;
            }
            if (double.Parse(money) == 99)
            {
                month = "12";
                addcon = 10;
            }

            DateTime nowTime = DateTime.Now;

            string sql = $"SELECT top 1 Stime,Etime,Conversions,RemainingConversions FROM dbo.cos_member WHERE User_id={userId}";
            DataTable dt = SqlHelper.Instance.ExecSqlDataTable(sql);
            if (!string.IsNullOrEmpty(dt.Rows[0]["Etime"].ToString()))
            {
                stime = DateTime.Parse(dt.Rows[0]["Stime"].ToString());
                etime = DateTime.Parse(dt.Rows[0]["Etime"].ToString());
                conversions = int.Parse(dt.Rows[0]["Conversions"].ToString());
                remainingConversions = int.Parse(dt.Rows[0]["RemainingConversions"].ToString());
                if (etime > nowTime)
                {
                    etime = etime.AddMonths(int.Parse(month));
                    conversions += addcon;
                    remainingConversions += addcon;
                }
                else
                {
                    stime = nowTime;
                    etime = nowTime.AddMonths(int.Parse(month));
                    conversions = addcon;
                    remainingConversions = addcon;
                }
            }
            else
            {
                stime = nowTime;
                etime = nowTime.AddMonths(int.Parse(month));
                conversions = addcon;
                remainingConversions = addcon;
            }

            sql = $"UPDATE dbo.cos_member SET Stime='{stime}',Etime='{etime}',Conversions={conversions},RemainingConversions={remainingConversions},Lv=1 WHERE User_id={userId}";
            return SqlHelper.Instance.ExecSqlNonQuery(sql);
        }
    }
}
