using System;
using System.Data;
using Com.Cos.Db;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    public class MedalBll
    {
        #region instance
        private volatile static MedalBll _instance = null;
        private static readonly object lockHelper = new object();
        private MedalBll() { }
        public static MedalBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new MedalBll();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetAllList()
        {
            try
            {
                return MedalDb.Instance.GetAllList();
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}