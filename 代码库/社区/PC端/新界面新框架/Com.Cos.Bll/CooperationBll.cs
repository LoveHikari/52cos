using System;
using System.Data;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    /// <summary>
    /// 合作表摘要说明
    /// </summary>
    public class CooperationBll
    {
        #region instance
        private volatile static CooperationBll _instance = null;
        private static readonly object lockHelper = new object();
        private CooperationBll() { }
        public static CooperationBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new CooperationBll();
                    }
                }
                return _instance;
            }
        }
        #endregion
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序</param>
        /// <returns></returns>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            try
            {
                return CooperationDb.Instance.GetList(Top, strWhere, filedOrder);
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
        public int Add(CooperationEntity model)
        {
            try
            {
                return CooperationDb.Instance.Add(model);
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
        public CooperationEntity GetModel(int id)
        {
            try
            {
                return CooperationDb.Instance.GetModel(id);
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
                return CooperationDb.Instance.GetList(strWhere);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            try
            {
                return CooperationDb.Instance.GetRecordCount(strWhere);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            try
            {
                return CooperationDb.Instance.GetListByPage(strWhere, orderby, startIndex, endIndex);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}