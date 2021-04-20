using System;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    public class LoginIPBll
    {
        #region instance
        private volatile static LoginIPBll _instance = null;
        private static readonly object lockHelper = new object();
        private LoginIPBll() { }
        public static LoginIPBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new LoginIPBll();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsIp(string userId, DateTime nowTime)
        {
            try
            {
                return LoginIPDb.Instance.ExistsIp(userId, nowTime);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LoginIPEntity model)
        {
            try
            {
                return LoginIPDb.Instance.Add(model);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}