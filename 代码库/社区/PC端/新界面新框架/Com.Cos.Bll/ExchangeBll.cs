using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    /// <summary>
    /// 交换
    /// </summary>
    public class ExchangeBll
    {
        #region instance
        private volatile static ExchangeBll _instance = null;
        private static readonly object lockHelper = new object();
        private ExchangeBll() { }
        public static ExchangeBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new ExchangeBll();
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
        public int Add(ExchangeEntity model)
        {
            try
            {
                return ExchangeDb.Instance.Add(model);
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
        public bool Update(ExchangeEntity model)
        {
            try
            {
                return ExchangeDb.Instance.Update(model);
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
                return ExchangeDb.Instance.Delete(Id);
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
                return ExchangeDb.Instance.DeleteList(Idlist);
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
        public ExchangeEntity GetModel(int Id)
        {

            try
            {
                return ExchangeDb.Instance.GetModel(Id);
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
                return ExchangeDb.Instance.GetList(strWhere);
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
                return ExchangeDb.Instance.GetList(Top, strWhere, filedOrder);
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
        public List<ExchangeEntity> GetModelList(string strWhere)
        {
            try
            {
                DataSet ds = ExchangeDb.Instance.GetList(strWhere);
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
        public List<ExchangeEntity> DataTableToList(DataTable dt)
        {
            try
            {
                List<ExchangeEntity> modelList = new List<ExchangeEntity>();
                int rowsCount = dt.Rows.Count;
                if (rowsCount > 0)
                {
                    ExchangeEntity model;
                    for (int n = 0; n < rowsCount; n++)
                    {
                        model = ExchangeDb.Instance.DataRowToModel(dt.Rows[n]);
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
                return ExchangeDb.Instance.GetRecordCount(strWhere);
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
                return ExchangeDb.Instance.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return ExchangeDb.Instance.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        /// <param name="Top">前几行</param>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序</param>
        /// <returns></returns>
        public DataSet GetList2(int Top, string strWhere, string filedOrder)
        {
            try
            {
                return ExchangeDb.Instance.GetList2(Top, strWhere, filedOrder);
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
        public DataSet GetListByPage2(string strWhere, string orderby, int startIndex, int endIndex)
        {
            try
            {
                return ExchangeDb.Instance.GetListByPage2(strWhere, orderby, startIndex, endIndex);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}