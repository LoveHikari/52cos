using System;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    /// <summary>
    /// 充值记录表
    /// </summary>
    public class RechargeRecordBll
    {
        #region instance
        private volatile static RechargeRecordBll _instance = null;
        private static readonly object lockHelper = new object();
        private RechargeRecordBll() { }
        public static RechargeRecordBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new RechargeRecordBll();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(RechargeRecordEntity model)
        {
            try
            {
                return RechargeRecordDb.Instance.Add(model);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}