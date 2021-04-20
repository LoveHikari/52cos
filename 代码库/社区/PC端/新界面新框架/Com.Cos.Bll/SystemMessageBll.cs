using System;
using System.Data;
using System.Collections.Generic;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;
namespace Com.Cos.Bll
{
    /// <summary>
    /// sns_systemMessage
    /// 系统信息表
    /// </summary>
    public partial class SystemMessageBll
    {
        #region  instance
        private volatile static SystemMessageBll _instance = null;
        private static readonly object lockHelper = new object();
        public SystemMessageBll() { }
        public static SystemMessageBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new SystemMessageBll();
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
        public int Add(SystemMessageEntity model)
        {
            try
            {
                return SystemMessageDb.Instance.Add(model);
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
        public bool Update(SystemMessageEntity model)
        {
            try
            {
                return SystemMessageDb.Instance.Update(model);
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
        public bool Delete(int Id)
        {
            try
            {

                return SystemMessageDb.Instance.Delete(Id);
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
        public bool DeleteList(string Idlist)
        {
            try
            {
                return SystemMessageDb.Instance.DeleteList(Idlist);
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
        public SystemMessageEntity GetModel(int Id)
        {
            try
            {

                return SystemMessageDb.Instance.GetModel(Id);
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
                return SystemMessageDb.Instance.GetList(strWhere);
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
                return SystemMessageDb.Instance.GetList(Top, strWhere, filedOrder);
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
        public List<SystemMessageEntity> GetModelList(string strWhere)
        {
            try
            {
                DataSet ds = SystemMessageDb.Instance.GetList(strWhere);
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
        public List<SystemMessageEntity> DataTableToList(DataTable dt)
        {
            try
            {
                List<SystemMessageEntity> modelList = new List<SystemMessageEntity>();
                int rowsCount = dt.Rows.Count;
                if (rowsCount > 0)
                {
                    SystemMessageEntity model;
                    for (int n = 0; n < rowsCount; n++)
                    {
                        model = SystemMessageDb.Instance.DataRowToModel(dt.Rows[n]);
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
                return SystemMessageDb.Instance.GetRecordCount(strWhere);
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
                return SystemMessageDb.Instance.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
        //return SystemMessageDb.Instance.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string filedOrder)
        {
            try
            {
                return SystemMessageDb.Instance.GetList(strWhere, filedOrder);
            }
            catch (System.Exception ex)
            {
                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}

