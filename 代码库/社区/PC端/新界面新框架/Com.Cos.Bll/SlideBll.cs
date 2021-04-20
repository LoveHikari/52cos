using System;
using System.Collections.Generic;
using System.Data;
using Com.Cos.Db;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    /// <summary>
    /// 首页幻灯片
    /// </summary>
    public class SlideBll
    {
        #region instance
        private volatile static SlideBll _instance = null;
        private static readonly object lockHelper = new object();
        private SlideBll() { }
        public static SlideBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new SlideBll();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            try
            {
                return SlideDb.Instance.GetList(Top, strWhere, filedOrder);
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
                return SlideDb.Instance.GetList(strWhere);
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
        /// <param name="id">id</param>
        /// <param name="status">状态码：1或0</param>
        /// <returns></returns>
        public bool UpdateStatus(string id, string status)
        {
            try
            {
                return SlideDb.Instance.UpdateStatus(id, status);
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
        public DataTable GetList(IDictionary<string, string> strWhere)
        {
            try
            {
                return SlideDb.Instance.GetList(strWhere);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}