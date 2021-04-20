using System;
using System.Data;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    public class QuickNavigationBll
    {
        #region instance
        private volatile static QuickNavigationBll _instance = null;
        private static readonly object lockHelper = new object();
        private QuickNavigationBll() { }
        public static QuickNavigationBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new QuickNavigationBll();
                    }
                }
                return _instance;
            }
        }
        #endregion
        #region 自动生成

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            try
            {
                return QuickNavigationDb.Instance.GetList(strWhere);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public QuickNavigationEntity GetModel(int Id)
        {
            try
            {
                return QuickNavigationDb.Instance.GetModel(Id);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
        #endregion
    }
}