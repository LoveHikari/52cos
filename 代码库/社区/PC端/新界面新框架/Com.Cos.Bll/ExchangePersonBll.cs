using System;
using System.Data;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    /// <summary>
    /// 兑换人员表
    /// </summary>
    public class ExchangePersonBll
    {
        #region instance
        private volatile static ExchangePersonBll _instance = null;
        private static readonly object lockHelper = new object();
        private ExchangePersonBll() { }
        public static ExchangePersonBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new ExchangePersonBll();
                    }
                }
                return _instance;
            }
        }
        #endregion
        #region 自动生成

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ExchangePersonEntity model)
        {
            try
            {
                return ExchangePersonDb.Instance.Add(model);
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
        public DataSet GetList(string strWhere)
        {
            try
            {
                return ExchangePersonDb.Instance.GetList(strWhere);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
        #endregion

        /// <summary>
        /// 获得数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序</param>
        /// <returns></returns>
        public DataSet GetList(string strWhere, string filedOrder)
        {
            try
            {
                return ExchangePersonDb.Instance.GetList(strWhere, filedOrder);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="exId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateStatus(string exId, int status)
        {
            try
            {
                return ExchangeVoteDb.Instance.UpdateStatus(exId, status);
            }
            catch (System.Exception ex)
            {
                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}