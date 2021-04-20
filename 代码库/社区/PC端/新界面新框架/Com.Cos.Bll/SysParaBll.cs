using System;
using System.Data;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    public class SysParaBll
    {
        #region instance

        private volatile static SysParaBll _instance = null;
        private static readonly object lockHelper = new object();

        private SysParaBll()
        {
        }

        public static SysParaBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new SysParaBll();
                    }
                }
                return _instance;
            }
        }

        #endregion

        /// <summary>
        /// 获得全部系统信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllSysPara()
        {
            try
            {
                return SysParaDb.Instance.GetAllSysPara();
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }

        }
        /// <summary>
        /// 获得指定类型的表
        /// </summary>
        /// <param name="refType"></param>
        /// <returns></returns>
        public DataTable GetSysParaTable(string refType)
        {
            try
            {
                return SysParaDb.Instance.GetSysParaTable(refType);
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
                return SysParaDb.Instance.GetList(strWhere);
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
        public SysParaEntity GetModel(int id)
        {
            try
            {
                return SysParaDb.Instance.GetModel(id);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}