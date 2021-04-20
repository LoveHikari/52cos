using System;
using System.Data;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    public class RentPersonBll
    {
        #region instance
        private volatile static RentPersonBll _instance = null;
        private static readonly object lockHelper = new object();
        private RentPersonBll() { }
        public static RentPersonBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new RentPersonBll();
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
        public int Add(RentPersonEntity model)
        {
            try
            {
                return RentPersonDb.Instance.Add(model);
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
                return RentPersonDb.Instance.GetList(strWhere);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
        #endregion

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