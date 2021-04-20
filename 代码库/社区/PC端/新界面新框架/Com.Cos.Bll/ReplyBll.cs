using System;
using System.Data;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    public class ReplyBll
    {
        #region instance
        private volatile static ReplyBll _instance = null;
        private static readonly object lockHelper = new object();
        private ReplyBll() { }
        public static ReplyBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new ReplyBll();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ReplyEntity model)
        {
            try
            {
                return ReplyDb.Instance.Add(model);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            try
            {
                return ReplyDb.Instance.GetList(strWhere);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            try
            {
                return ReplyDb.Instance.GetList(Top, strWhere, filedOrder);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="worksId">作品id</param>
        /// <param name="status">状态码：1或0</param>
        /// <returns></returns>
        public bool UpdateStatus(string worksId, string status)
        {
            try
            {
                return ReplyDb.Instance.UpdateStatus(worksId, status);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            try
            {
                return ReplyDb.Instance.GetListByPage(strWhere, orderby, startIndex, endIndex);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            try
            {
                return ReplyDb.Instance.GetRecordCount(strWhere);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}