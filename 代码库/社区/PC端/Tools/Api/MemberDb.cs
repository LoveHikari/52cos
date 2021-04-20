using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using DBHelper;
using Entity;

namespace Api
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

       
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MemberEntity model)
        {
            DataAccess da = new DataAccess("newConnLink");
            da.CreateConnection();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into cos_member(");
            strSql.Append("User_name,Email,Password,Real_name,Gender,Birthday,Phone_tel,Phone_mob,Im_qq,Im_msn,In_skype,Im_yahoo,Im_aliww,Reg_time,Last_login,Last_ip,Logins,Ugrade,Portrait,Outer_id,Activation,Feed_config,Status,reward,CNbi,integral,nickname,ardent,Growth,code)");
            strSql.Append(" values (");
            strSql.Append("@User_name,@Email,@Password,@Real_name,@Gender,@Birthday,@Phone_tel,@Phone_mob,@Im_qq,@Im_msn,@In_skype,@Im_yahoo,@Im_aliww,@Reg_time,@Last_login,@Last_ip,@Logins,@Ugrade,@Portrait,@Outer_id,@Activation,@Feed_config,@Status,@reward,@CNbi,@integral,@nickname,@ardent,@Growth,@code)");
            strSql.Append(";select @@IDENTITY");
            DbParameter[] parameters = {
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
                    new SqlParameter("@code", SqlDbType.VarChar,500)};
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

            object obj = da.ExecuteScalar(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public int Add(ImgEntity model)
        {
            DataAccess da = new DataAccess("newConnLink");
            da.CreateConnection();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_Img(");
            strSql.Append("ImgUrl,addtime,Status)");
            strSql.Append(" values (");
            strSql.Append("@ImgUrl,@addtime,@Status)");
            strSql.Append(";select @@IDENTITY");
            DbParameter[] parameters = {
                    new SqlParameter("@ImgUrl", SqlDbType.VarChar,50),
                    new SqlParameter("@addtime", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.ImgUrl;
            parameters[1].Value = model.addtime;
            parameters[2].Value = model.Status;

            object obj = da.ExecuteScalar(strSql.ToString(), parameters);
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
		/// 增加一条数据
		/// </summary>
		public int Add(WorksEntity model)
        {
            DataAccess da = new DataAccess("newConnLink");
            da.CreateConnection();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_works(");
            strSql.Append("User_id,WorksTitle,WorksType,Type2,OriginaWorks,OriginaRole,coser,Photography,Makeup,Late,Third,Painter,LabelDesc,WorksContent,Root,Keep,Watermark,ReleaseTime,UpdateTime,GoodNo,Status,reward,cover,worksExcerpt,source,sourceUrl)");
            strSql.Append(" values (");
            strSql.Append("@User_id,@WorksTitle,@WorksType,@Type2,@OriginaWorks,@OriginaRole,@coser,@Photography,@Makeup,@Late,@Third,@Painter,@LabelDesc,@WorksContent,@Root,@Keep,@Watermark,@ReleaseTime,@UpdateTime,@GoodNo,@Status,@reward,@cover,@worksExcerpt,@source,@sourceUrl)");
            strSql.Append(";select @@IDENTITY");
            DbParameter[] parameters = {
                    new SqlParameter("@User_id", SqlDbType.VarChar,50),
                    new SqlParameter("@WorksTitle", SqlDbType.Text),
                    new SqlParameter("@WorksType", SqlDbType.VarChar,50),
                    new SqlParameter("@Type2", SqlDbType.VarChar,50),
                    new SqlParameter("@OriginaWorks", SqlDbType.VarChar,50),
                    new SqlParameter("@OriginaRole", SqlDbType.VarChar,50),
                    new SqlParameter("@coser", SqlDbType.VarChar,50),
                    new SqlParameter("@Photography", SqlDbType.VarChar,50),
                    new SqlParameter("@Makeup", SqlDbType.VarChar,50),
                    new SqlParameter("@Late", SqlDbType.VarChar,50),
                    new SqlParameter("@Third", SqlDbType.VarChar,50),
                    new SqlParameter("@Painter", SqlDbType.VarChar,50),
                    new SqlParameter("@LabelDesc", SqlDbType.VarChar,50),
                    new SqlParameter("@WorksContent", SqlDbType.Text),
                    new SqlParameter("@Root", SqlDbType.VarChar,1),
                    new SqlParameter("@Keep", SqlDbType.VarChar,1),
                    new SqlParameter("@Watermark", SqlDbType.VarChar,1),
                    new SqlParameter("@ReleaseTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@GoodNo", SqlDbType.Int,4),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@reward", SqlDbType.Int,4),
                    new SqlParameter("@cover", SqlDbType.VarChar,50),
                    new SqlParameter("@worksExcerpt", SqlDbType.Text),
                    new SqlParameter("@source", SqlDbType.VarChar,50),
                    new SqlParameter("@sourceUrl", SqlDbType.VarChar,50)};
            parameters[0].Value = model.User_id;
            parameters[1].Value = model.WorksTitle;
            parameters[2].Value = model.WorksType;
            parameters[3].Value = model.Type2;
            parameters[4].Value = model.OriginaWorks;
            parameters[5].Value = model.OriginaRole;
            parameters[6].Value = model.coser;
            parameters[7].Value = model.Photography;
            parameters[8].Value = model.Makeup;
            parameters[9].Value = model.Late;
            parameters[10].Value = model.Third;
            parameters[11].Value = model.Painter;
            parameters[12].Value = model.LabelDesc;
            parameters[13].Value = model.WorksContent;
            parameters[14].Value = model.Root;
            parameters[15].Value = model.Keep;
            parameters[16].Value = model.Watermark;
            parameters[17].Value = model.ReleaseTime;
            parameters[18].Value = model.UpdateTime;
            parameters[19].Value = model.GoodNo;
            parameters[20].Value = model.Status;
            parameters[21].Value = model.reward;
            parameters[22].Value = model.cover;
            parameters[23].Value = model.worksExcerpt;
            parameters[24].Value = model.source;
            parameters[25].Value = model.sourceUrl;

            object obj = da.ExecuteScalar(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
    }
}
