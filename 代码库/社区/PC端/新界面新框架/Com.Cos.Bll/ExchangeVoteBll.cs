﻿using System;
using System.Data;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;
using System.Collections.Generic;

namespace Com.Cos.Bll
{
    /// <summary>
    /// 分享投票记录表
    /// </summary>
    public class ExchangeVoteBll
    {
        #region instance
        private volatile static ExchangeVoteBll _instance = null;
        private static readonly object lockHelper = new object();
        private ExchangeVoteBll() { }
        public static ExchangeVoteBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new ExchangeVoteBll();
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
        public int Add(ExchangeVoteEntity model)
        {
            try
            {
                return ExchangeVoteDb.Instance.Add(model);
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
        public bool Update(ExchangeVoteEntity model)
        {
            try
            {
                return ExchangeVoteDb.Instance.Update(model);
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
                return ExchangeVoteDb.Instance.Delete(Id);
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
                return ExchangeVoteDb.Instance.DeleteList(Idlist);
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
        public ExchangeVoteEntity GetModel(int Id)
        {

            try
            {
                return ExchangeVoteDb.Instance.GetModel(Id);
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
                return ExchangeVoteDb.Instance.GetList(strWhere);
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
                return ExchangeVoteDb.Instance.GetList(Top, strWhere, filedOrder);
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
        public List<ExchangeVoteEntity> GetModelList(string strWhere)
        {
            try
            {
                DataSet ds = ExchangeVoteDb.Instance.GetList(strWhere);
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
        public List<ExchangeVoteEntity> DataTableToList(DataTable dt)
        {
            try
            {
                List<ExchangeVoteEntity> modelList = new List<ExchangeVoteEntity>();
                int rowsCount = dt.Rows.Count;
                if (rowsCount > 0)
                {
                    ExchangeVoteEntity model;
                    for (int n = 0; n < rowsCount; n++)
                    {
                        model = ExchangeVoteDb.Instance.DataRowToModel(dt.Rows[n]);
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
                return ExchangeVoteDb.Instance.GetRecordCount(strWhere);
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
                return ExchangeVoteDb.Instance.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
        //return ExchangeVoteDb.Instance.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="exId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateStatus(string exId, int status)
        {
            try
            {
                return ExchangeVoteDb.Instance.UpdateStatus(exId, status);
            }
            catch (System.Exception ex)
            {
                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}