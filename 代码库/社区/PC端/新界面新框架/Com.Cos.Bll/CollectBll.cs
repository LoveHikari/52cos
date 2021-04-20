using System;
using System.Data;
using System.Collections.Generic;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;
namespace Com.Cos.Bll
{
    /// <summary>
    /// sns_collect: 收藏表
    /// </summary>
    public partial class CollectBll
    {
        #region  instance
        private volatile static CollectBll _instance = null;
        private static readonly object lockHelper = new object();
        public CollectBll() { }
        public static CollectBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new CollectBll();
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
        public int Add(CollectEntity model)
        {
            try
            {
                return CollectDb.Instance.Add(model);
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
        public bool Update(CollectEntity model)
        {
            try
            {
                return CollectDb.Instance.Update(model);
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

                return CollectDb.Instance.Delete(Id);
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
                return CollectDb.Instance.DeleteList(Idlist);
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
        public CollectEntity GetModel(int Id)
        {
            try
            {

                return CollectDb.Instance.GetModel(Id);
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
                return CollectDb.Instance.GetList(strWhere);
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
        public DataSet GetList(string strWhere, string filedOrder)
        {
            try
            {
                return CollectDb.Instance.GetList(strWhere, filedOrder);
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
                return CollectDb.Instance.GetList(Top, strWhere, filedOrder);
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
        public List<CollectEntity> GetModelList(string strWhere)
        {
            try
            {
                DataSet ds = CollectDb.Instance.GetList(strWhere);
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
        public List<CollectEntity> DataTableToList(DataTable dt)
        {
            try
            {
                List<CollectEntity> modelList = new List<CollectEntity>();
                int rowsCount = dt.Rows.Count;
                if (rowsCount > 0)
                {
                    CollectEntity model;
                    for (int n = 0; n < rowsCount; n++)
                    {
                        model = CollectDb.Instance.DataRowToModel(dt.Rows[n]);
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
                return CollectDb.Instance.GetRecordCount(strWhere);
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
                return CollectDb.Instance.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
        //return CollectDb.Instance.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion
    }
}

