using System;
using System.Data;
using Com.Cos.Db;
using Com.Cos.Entity;
using System.Collections.Generic;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    /// <summary>
    /// 积分变更记录表
    /// </summary>
    public class IntegralChangeBll
    {
        #region instance
        private volatile static IntegralChangeBll _instance = null;
        private static readonly object lockHelper = new object();
        private IntegralChangeBll() { }
        public static IntegralChangeBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new IntegralChangeBll();
                    }
                }
                return _instance;
            }
        }
        #endregion

        #region  自动生成
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(IntegralChangeEntity model)
        {
            try
            {
                return IntegralChangeDb.Instance.Add(model);
            }
            catch (System.Exception ex)
            {
                WriteLog.WriteError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(IntegralChangeEntity model)
        {
            try
            {
                return IntegralChangeDb.Instance.Update(model);
            }
            catch (System.Exception ex)
            {
                WriteLog.WriteError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            try
            {
                return IntegralChangeDb.Instance.Delete(id);
            }
            catch (System.Exception ex)
            {
                WriteLog.WriteError(ex);
                throw ex;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            try
            {
                return IntegralChangeDb.Instance.DeleteList(idlist);
            }
            catch (System.Exception ex)
            {
                WriteLog.WriteError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public IntegralChangeEntity GetModel(int id)
        {

            try
            {
                return IntegralChangeDb.Instance.GetModel(id);
            }
            catch (System.Exception ex)
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
                return IntegralChangeDb.Instance.GetList(strWhere);
            }
            catch (System.Exception ex)
            {
                WriteLog.WriteError(ex);
                throw ex;
            }
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            try
            {
                return IntegralChangeDb.Instance.GetList(Top, strWhere, filedOrder);
            }
            catch (System.Exception ex)
            {
                WriteLog.WriteError(ex);
                throw ex;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<IntegralChangeEntity> GetModelList(string strWhere)
        {
            try
            {
                DataSet ds = IntegralChangeDb.Instance.GetList(strWhere);
                return DataTableToList(ds.Tables[0]);
            }
            catch (System.Exception ex)
            {
                WriteLog.WriteError(ex);
                throw ex;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<IntegralChangeEntity> DataTableToList(DataTable dt)
        {
            try
            {
                List<IntegralChangeEntity> modelList = new List<IntegralChangeEntity>();
                int rowsCount = dt.Rows.Count;
                if (rowsCount > 0)
                {
                    IntegralChangeEntity model;
                    for (int n = 0; n < rowsCount; n++)
                    {
                        model = IntegralChangeDb.Instance.DataRowToModel(dt.Rows[n]);
                        if (model != null)
                        {
                            modelList.Add(model);
                        }
                    }
                }
                return modelList;
            }
            catch (System.Exception ex)
            {
                WriteLog.WriteError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            try
            {
                return GetList("");
            }
            catch (System.Exception ex)
            {
                WriteLog.WriteError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            try
            {
                return IntegralChangeDb.Instance.GetRecordCount(strWhere);
            }
            catch (System.Exception ex)
            {
                WriteLog.WriteError(ex);
                throw ex;
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            try
            {
                return IntegralChangeDb.Instance.GetListByPage(strWhere, orderby, startIndex, endIndex);
            }
            catch (System.Exception ex)
            {
                WriteLog.WriteError(ex);
                throw ex;
            }
        }
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return IntegralChangeDb.Instance.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion
    }
}