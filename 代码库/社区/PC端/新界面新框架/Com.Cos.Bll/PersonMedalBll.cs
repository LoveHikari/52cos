using System;
using System.Data;
using Com.Cos.Db;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    public class PersonMedalBll
    {
        #region instance
        private volatile static PersonMedalBll _instance = null;
        private static readonly object lockHelper = new object();
        private PersonMedalBll() { }
        public static PersonMedalBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new PersonMedalBll();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            try
            {
                return PersonMedalDb.Instance.GetList(strWhere);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}