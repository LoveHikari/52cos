using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    public class WorksDb
    {
        #region instance
        private volatile static WorksDb _instance = null;
        private static readonly object lockHelper = new object();
        private WorksDb() { }
        public static WorksDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new WorksDb();
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
        public int Add(WorksEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_works(");
            strSql.Append("User_id,WorksTitle,WorksType,Type2,OriginaWorks,OriginaRole,coser,Photography,Makeup,Late,Third,Painter,LabelDesc,WorksContent,Root,Keep,Watermark,ReleaseTime,UpdateTime,GoodNo,Status,reward,cover,worksExcerpt,source,sourceUrl,Sticky,Recommend)");
            strSql.Append(" values (");
            strSql.Append("@User_id,@WorksTitle,@WorksType,@Type2,@OriginaWorks,@OriginaRole,@coser,@Photography,@Makeup,@Late,@Third,@Painter,@LabelDesc,@WorksContent,@Root,@Keep,@Watermark,@ReleaseTime,@UpdateTime,@GoodNo,@Status,@reward,@cover,@worksExcerpt,@source,@sourceUrl,@Sticky,@Recommend)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@User_id", SqlDbType.VarChar,50),
                    new SqlParameter("@WorksTitle", SqlDbType.Text,16),
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
                    new SqlParameter("@WorksContent", SqlDbType.Text,16),
                    new SqlParameter("@Root", SqlDbType.VarChar,1),
                    new SqlParameter("@Keep", SqlDbType.VarChar,1),
                    new SqlParameter("@Watermark", SqlDbType.VarChar,1),
                    new SqlParameter("@ReleaseTime", SqlDbType.DateTime,8),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
                    new SqlParameter("@GoodNo", SqlDbType.Int,4),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@reward", SqlDbType.Int,4),
                    new SqlParameter("@cover", SqlDbType.VarChar,50),
                    new SqlParameter("@worksExcerpt", SqlDbType.Text,16),
                    new SqlParameter("@source", SqlDbType.VarChar,50),
                    new SqlParameter("@sourceUrl", SqlDbType.VarChar,50),
                    new SqlParameter("@Sticky", SqlDbType.VarChar,50),
                    new SqlParameter("@Recommend", SqlDbType.VarChar,50)};
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
            parameters[26].Value = model.Sticky;
            parameters[27].Value = model.Recommend;

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
        public bool Update(WorksEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sns_works set ");
            strSql.Append("User_id=@User_id,");
            strSql.Append("WorksTitle=@WorksTitle,");
            strSql.Append("WorksType=@WorksType,");
            strSql.Append("Type2=@Type2,");
            strSql.Append("OriginaWorks=@OriginaWorks,");
            strSql.Append("OriginaRole=@OriginaRole,");
            strSql.Append("coser=@coser,");
            strSql.Append("Photography=@Photography,");
            strSql.Append("Makeup=@Makeup,");
            strSql.Append("Late=@Late,");
            strSql.Append("Third=@Third,");
            strSql.Append("Painter=@Painter,");
            strSql.Append("LabelDesc=@LabelDesc,");
            strSql.Append("WorksContent=@WorksContent,");
            strSql.Append("Root=@Root,");
            strSql.Append("Keep=@Keep,");
            strSql.Append("Watermark=@Watermark,");
            strSql.Append("ReleaseTime=@ReleaseTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("GoodNo=@GoodNo,");
            strSql.Append("Status=@Status,");
            strSql.Append("reward=@reward,");
            strSql.Append("cover=@cover,");
            strSql.Append("worksExcerpt=@worksExcerpt,");
            strSql.Append("source=@source,");
            strSql.Append("sourceUrl=@sourceUrl,");
            strSql.Append("Sticky=@Sticky,");
            strSql.Append("Recommend=@Recommend");
            strSql.Append(" where WorksId=@WorksId");
            SqlParameter[] parameters = {
                    new SqlParameter("@User_id", SqlDbType.VarChar,50),
                    new SqlParameter("@WorksTitle", SqlDbType.Text,16),
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
                    new SqlParameter("@WorksContent", SqlDbType.Text,16),
                    new SqlParameter("@Root", SqlDbType.VarChar,1),
                    new SqlParameter("@Keep", SqlDbType.VarChar,1),
                    new SqlParameter("@Watermark", SqlDbType.VarChar,1),
                    new SqlParameter("@ReleaseTime", SqlDbType.DateTime,8),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime,8),
                    new SqlParameter("@GoodNo", SqlDbType.Int,4),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@reward", SqlDbType.Int,4),
                    new SqlParameter("@cover", SqlDbType.VarChar,50),
                    new SqlParameter("@worksExcerpt", SqlDbType.Text,16),
                    new SqlParameter("@source", SqlDbType.VarChar,50),
                    new SqlParameter("@sourceUrl", SqlDbType.VarChar,50),
                    new SqlParameter("@Sticky", SqlDbType.VarChar,50),
                    new SqlParameter("@Recommend", SqlDbType.VarChar,50),
                    new SqlParameter("@WorksId", SqlDbType.Int,4)};
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
            parameters[26].Value = model.Sticky;
            parameters[27].Value = model.Recommend;
            parameters[28].Value = model.WorksId;

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
        public bool Delete(int WorksId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sns_works ");
            strSql.Append(" where WorksId=@WorksId");
            SqlParameter[] parameters = {
                new SqlParameter("@WorksId", SqlDbType.Int,4)
            };
            parameters[0].Value = WorksId;
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
        public bool DeleteList(string WorksIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sns_works ");
            strSql.Append(" where WorksId in (" + WorksIdlist + ")  ");
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
        public WorksEntity GetModel(int WorksId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 WorksId,User_id,WorksTitle,WorksType,Type2,OriginaWorks,OriginaRole,coser,Photography,Makeup,Late,Third,Painter,LabelDesc,WorksContent,Root,Keep,Watermark,ReleaseTime,UpdateTime,GoodNo,Status,reward,cover,worksExcerpt,source,sourceUrl,Sticky,Recommend from sns_works ");
            strSql.Append(" where WorksId=@WorksId");
            SqlParameter[] parameters = {
                new SqlParameter("@WorksId", SqlDbType.Int,4)
            };
            parameters[0].Value = WorksId;
            WorksEntity model = new WorksEntity();
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
        public WorksEntity DataRowToModel(DataRow row)
        {
            WorksEntity model = new WorksEntity();
            if (row != null)
            {
                if (row["WorksId"] != null && row["WorksId"].ToString() != "")
                {
                    model.WorksId = int.Parse(row["WorksId"].ToString());
                }
                if (row["User_id"] != null)
                {
                    model.User_id = row["User_id"].ToString();
                }
                if (row["WorksTitle"] != null)
                {
                    model.WorksTitle = row["WorksTitle"].ToString();
                }
                if (row["WorksType"] != null)
                {
                    model.WorksType = row["WorksType"].ToString();
                }
                if (row["Type2"] != null)
                {
                    model.Type2 = row["Type2"].ToString();
                }
                if (row["OriginaWorks"] != null)
                {
                    model.OriginaWorks = row["OriginaWorks"].ToString();
                }
                if (row["OriginaRole"] != null)
                {
                    model.OriginaRole = row["OriginaRole"].ToString();
                }
                if (row["coser"] != null)
                {
                    model.coser = row["coser"].ToString();
                }
                if (row["Photography"] != null)
                {
                    model.Photography = row["Photography"].ToString();
                }
                if (row["Makeup"] != null)
                {
                    model.Makeup = row["Makeup"].ToString();
                }
                if (row["Late"] != null)
                {
                    model.Late = row["Late"].ToString();
                }
                if (row["Third"] != null)
                {
                    model.Third = row["Third"].ToString();
                }
                if (row["Painter"] != null)
                {
                    model.Painter = row["Painter"].ToString();
                }
                if (row["LabelDesc"] != null)
                {
                    model.LabelDesc = row["LabelDesc"].ToString();
                }
                if (row["WorksContent"] != null)
                {
                    model.WorksContent = row["WorksContent"].ToString();
                }
                if (row["Root"] != null)
                {
                    model.Root = row["Root"].ToString();
                }
                if (row["Keep"] != null)
                {
                    model.Keep = row["Keep"].ToString();
                }
                if (row["Watermark"] != null)
                {
                    model.Watermark = row["Watermark"].ToString();
                }
                if (row["ReleaseTime"] != null && row["ReleaseTime"].ToString() != "")
                {
                    model.ReleaseTime = DateTime.Parse(row["ReleaseTime"].ToString());
                }
                if (row["UpdateTime"] != null && row["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
                }
                if (row["GoodNo"] != null && row["GoodNo"].ToString() != "")
                {
                    model.GoodNo = int.Parse(row["GoodNo"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["reward"] != null && row["reward"].ToString() != "")
                {
                    model.reward = int.Parse(row["reward"].ToString());
                }
                if (row["cover"] != null)
                {
                    model.cover = row["cover"].ToString();
                }
                if (row["worksExcerpt"] != null)
                {
                    model.worksExcerpt = row["worksExcerpt"].ToString();
                }
                if (row["source"] != null)
                {
                    model.source = row["source"].ToString();
                }
                if (row["sourceUrl"] != null)
                {
                    model.sourceUrl = row["sourceUrl"].ToString();
                }
                if (row["Sticky"] != null)
                {
                    model.Sticky = row["Sticky"].ToString();
                }
                if (row["Recommend"] != null)
                {
                    model.Recommend = row["Recommend"].ToString();
                }
            }
            return model;
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" WorksId,User_id,WorksTitle,WorksType,Type2,OriginaWorks,OriginaRole,coser,Photography,Makeup,Late,Third,Painter,LabelDesc,WorksContent,Root,Keep,Watermark,ReleaseTime,UpdateTime,GoodNo,Status,reward,cover,worksExcerpt,source,sourceUrl,Sticky,Recommend ");
            strSql.Append(" FROM sns_works ");
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
            strSql.Append("select count(1) FROM sns_works ");
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
			parameters[0].Value = "sns_works";
			parameters[1].Value = "WorksId";
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
                            SELECT m.User_id,m.User_name,m.Portrait,m.nickname,o.WorksTitle,o.WorksType,o.type2,o.cover,o.ReleaseTime,o.WorksContent,o.WorksId,o.GoodNo,o.status,o.UpdateTime,o.Sticky,o.Recommend FROM sns_works o
                            LEFT JOIN dbo.cos_member m ON m.User_id = o.User_id) n where status='1' ");
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
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(@" FROM(
                            SELECT m.User_id,m.User_name,m.Email,m.Portrait,m.nickname,o.WorksTitle,o.Type2,o.UpdateTime,o.WorksType,o.cover,o.ReleaseTime,o.WorksContent,o.WorksId,o.GoodNo,o.status,o.Sticky,o.Recommend FROM sns_works o
                            LEFT JOIN dbo.cos_member m ON m.User_id = o.User_id) n where 1=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append("ORDER BY ReleaseTime DESC");
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
                strSql.Append("order by n.WorksId desc");
            }
            strSql.Append(")AS Row, n.*  from(");
            strSql.Append(@"SELECT m.User_id,m.User_name,m.Email,m.Portrait,m.nickname,o.WorksTitle,o.Type2,o.UpdateTime,o.WorksType,o.cover,o.ReleaseTime,o.WorksContent,o.WorksId,o.GoodNo,o.status FROM sns_works o
                            LEFT JOIN dbo.cos_member m ON m.User_id = o.User_id) n where status='1'");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" ) tt");
            strSql.AppendFormat(" WHERE tt.Row between {0} and {1}", startIndex, endIndex);
            return SqlHelper.Instance.ExecSqlDataTable(strSql.ToString());
        }
        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(IDictionary<string, string> strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(@" FROM(
                            SELECT m.User_id,m.User_name,m.Email,m.Portrait,m.nickname,o.WorksTitle,o.Type2,o.UpdateTime,o.WorksType,o.cover,o.ReleaseTime,o.WorksContent,o.WorksId,o.GoodNo,o.status FROM sns_works o
                            LEFT JOIN dbo.cos_member m ON m.User_id = o.User_id) n where 1=1 and status='1' ");
            if (strWhere.ContainsKey("title"))
            {
                strSql.AppendFormat(" and WorksTitle like '%{0}%'", strWhere["title"]);
            }
            if (strWhere.ContainsKey("type"))
            {
                strSql.AppendFormat(" and WorksType='{0}'", strWhere["type"]);
            }
            if (strWhere.ContainsKey("nickname"))
            {
                strSql.AppendFormat(" and nickname like '%{0}%'", strWhere["nickname"]);
            }
            if (strWhere.ContainsKey("email"))
            {
                strSql.AppendFormat(" and Email like '%{0}%'", strWhere["email"]);
            }
            if (strWhere.ContainsKey("time"))
            {
                strSql.AppendFormat(" and ReleaseTime between '{0}' and '{1}'", strWhere["time"] + " 00:00:00", strWhere["time"] + " 23:59:59");
            }
            strSql.Append(" ORDER BY ReleaseTime DESC");
            return SqlHelper.Instance.ExecSqlDataTable(strSql.ToString());
        }
        /// <summary>
        /// 随机获得作品
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序</param>
        /// <returns></returns>
        public DataTable GetRandList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(@" FROM(
                        SELECT  m.User_id,m.User_name,m.Portrait,m.nickname,o.WorksTitle,o.WorksType,o.cover,o.ReleaseTime,o.WorksContent,o.WorksId,o.GoodNo,o.status FROM  dbo.sns_works o 
                        JOIN (SELECT RAND()*100 AS nid) t2 ON o.WorksId > t2.nid
                        LEFT JOIN dbo.cos_member m ON m.User_id = o.User_id) n where status='1'");
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
        /// 更新状态
        /// </summary>
        /// <param name="worksId">作品id</param>
        /// <param name="status">状态码：1或0</param>
        /// <returns></returns>
        public bool UpdateStatus(string worksId, string status)
        {
            return UpdateStatus(worksId, "Status", status);
            //string sql = $@"UPDATE sns_works
            //            SET Status='{status}'
            //            WHERE WorksId='{worksId}'";
            //int rows = SqlHelper.Instance.ExecSqlNonQuery(sql);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="worksId">作品id</param>
        /// <param name="statusName">状态名</param>
        /// <param name="status">状态码：1或0</param>
        /// <returns></returns>
        public bool UpdateStatus(string worksId,string statusName, string status)
        {
            string sql = $@"UPDATE sns_works
                        SET {statusName}='{status}'
                        WHERE WorksId='{worksId}'";
            int rows = SqlHelper.Instance.ExecSqlNonQuery(sql);
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
        /// 修改被赞数或打赏数
        /// </summary>
        /// <param name="workId"></param>
        /// <param name="t">被赞数或打赏数对应的字段（GoodNo、reward）</param>
        /// <param name="integral">要修改的数值</param>
        public int UpdateIntegral(string workId, string t, string integral)
        {
            //取原来的值
            string strSql = $@"SELECT {t} FROM sns_works WHERE WorksId='{workId}'";
            int oldValue = (int)SqlHelper.Instance.ExecSqlScalar(strSql);

            //加积分
            string sql = string.Format(@"UPDATE sns_works 
                                SET {2}='{1}'
                                WHERE WorksId='{0}'", workId, Convert.ToInt32(integral) + oldValue, t);
            return SqlHelper.Instance.ExecSqlNonQuery(sql);
        }
    }
}