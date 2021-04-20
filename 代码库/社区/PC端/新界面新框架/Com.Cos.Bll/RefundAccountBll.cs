using System;
using System.Data;
using System.Collections.Generic;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;
namespace Com.Cos.Bll
{
    /// <summary>
    /// sns_refundAccount: 退款账号表
    /// </summary>
    public partial class RefundAccountBll
    {
        #region  instance
        private volatile static RefundAccountBll _instance = null;
        private static readonly object lockHelper = new object();
        public RefundAccountBll() { }
        public static RefundAccountBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new RefundAccountBll();
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
        public int Add(RefundAccountEntity model)
        {
            try
            {
                return RefundAccountDb.Instance.Add(model);
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
        public bool Update(RefundAccountEntity model)
        {
            try
            {
                return RefundAccountDb.Instance.Update(model);
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

                return RefundAccountDb.Instance.Delete(Id);
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
                return RefundAccountDb.Instance.DeleteList(Idlist);
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
        public RefundAccountEntity GetModel(int Id)
        {
            try
            {

                return RefundAccountDb.Instance.GetModel(Id);
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
                return RefundAccountDb.Instance.GetList(strWhere);
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
                return RefundAccountDb.Instance.GetList(strWhere, filedOrder);
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
                return RefundAccountDb.Instance.GetList(Top, strWhere, filedOrder);
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
        public List<RefundAccountEntity> GetModelList(string strWhere)
        {
            try
            {
                DataSet ds = RefundAccountDb.Instance.GetList(strWhere);
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
        public List<RefundAccountEntity> DataTableToList(DataTable dt)
        {
            try
            {
                List<RefundAccountEntity> modelList = new List<RefundAccountEntity>();
                int rowsCount = dt.Rows.Count;
                if (rowsCount > 0)
                {
                    RefundAccountEntity model;
                    for (int n = 0; n < rowsCount; n++)
                    {
                        model = RefundAccountDb.Instance.DataRowToModel(dt.Rows[n]);
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
                return RefundAccountDb.Instance.GetRecordCount(strWhere);
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
                return RefundAccountDb.Instance.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
        //return RefundAccountDb.Instance.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion
    }
}

