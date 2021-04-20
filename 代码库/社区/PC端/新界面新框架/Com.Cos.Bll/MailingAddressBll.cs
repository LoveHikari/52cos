using System;
using System.Collections.Generic;
using System.Data;
using Com.Cos.Entity;
using Com.Cos.Db;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    /// <summary>
    /// 通讯地址表
    /// </summary>
    public class MailingAddressBll
    {
        #region instance
        private volatile static MailingAddressBll _instance = null;
        private static readonly object lockHelper = new object();
        private MailingAddressBll() { }
        public static MailingAddressBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new MailingAddressBll();
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
        public int Add(MailingAddressEntity model)
        {
            try
            {
                return MailingAddressDb.Instance.Add(model);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MailingAddressEntity model)
        {
            try
            {
                return MailingAddressDb.Instance.Update(model);
            }
            catch (Exception ex)
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
                return MailingAddressDb.Instance.Delete(Id);
            }
            catch (Exception ex)
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
                return MailingAddressDb.Instance.DeleteList(Idlist);
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
        public MailingAddressEntity GetModel(int Id)
        {

            try
            {
                return MailingAddressDb.Instance.GetModel(Id);
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
        public DataSet GetList(string strWhere)
        {
            try
            {
                return MailingAddressDb.Instance.GetList(strWhere);
            }
            catch (Exception ex)
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
                return MailingAddressDb.Instance.GetList(Top, strWhere, filedOrder);
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
        public List<MailingAddressEntity> GetModelList(string strWhere)
        {
            try
            {
                DataSet ds = MailingAddressDb.Instance.GetList(strWhere);
                return DataTableToList(ds.Tables[0]);
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
        public List<MailingAddressEntity> DataTableToList(DataTable dt)
        {
            try
            {
                List<MailingAddressEntity> modelList = new List<MailingAddressEntity>();
                int rowsCount = dt.Rows.Count;
                if (rowsCount > 0)
                {
                    MailingAddressEntity model;
                    for (int n = 0; n < rowsCount; n++)
                    {
                        model = MailingAddressDb.Instance.DataRowToModel(dt.Rows[n]);
                        if (model != null)
                        {
                            modelList.Add(model);
                        }
                    }
                }
                return modelList;
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
        public DataSet GetAllList()
        {
            try
            {
                return GetList("");
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
        public int GetRecordCount(string strWhere)
        {
            try
            {
                return MailingAddressDb.Instance.GetRecordCount(strWhere);
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            try
            {
                return MailingAddressDb.Instance.GetListByPage(strWhere, orderby, startIndex, endIndex);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
        #endregion  BasicMethod
    }
}