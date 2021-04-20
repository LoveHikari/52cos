using System;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    /// <summary>
    /// 充值交易记录表
    /// </summary>
    public class TransactionsBll
    {
        #region instance
        private volatile static TransactionsBll _instance = null;
        private static readonly object lockHelper = new object();
        private TransactionsBll() { }
        public static TransactionsBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new TransactionsBll();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TransactionsEntity model)
        {
            try
            {
                return TransactionsDb.Instance.Add(model);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}