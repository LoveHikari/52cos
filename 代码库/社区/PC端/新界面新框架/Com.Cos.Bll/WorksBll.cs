using System;
using System.Collections.Generic;
using System.Data;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    public class WorksBll
    {
        #region instance
        private volatile static WorksBll _instance = null;
        private static readonly object lockHelper = new object();
        private WorksBll() { }
        public static WorksBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new WorksBll();
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
        public int Add(WorksEntity model)
        {
            try
            {
                return WorksDb.Instance.Add(model);
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
        public bool Update(WorksEntity model)
        {
            try
            {
                return WorksDb.Instance.Update(model);
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
        public bool Delete(int WorksId)
        {
            try
            {

                return WorksDb.Instance.Delete(WorksId);
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
        public bool DeleteList(string WorksIdlist)
        {
            try
            {
                return WorksDb.Instance.DeleteList(WorksIdlist);
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
        public WorksEntity GetModel(int WorksId)
        {
            try
            {

                return WorksDb.Instance.GetModel(WorksId);
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
        public DataTable GetList(string strWhere)
        {
            try
            {
                return WorksDb.Instance.GetList(strWhere);
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
                return WorksDb.Instance.GetList(strWhere, filedOrder);
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
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            try
            {
                return WorksDb.Instance.GetList(Top, strWhere, filedOrder);
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
        public List<WorksEntity> DataTableToList(DataTable dt)
        {
            try
            {
                List<WorksEntity> modelList = new List<WorksEntity>();
                int rowsCount = dt.Rows.Count;
                if (rowsCount > 0)
                {
                    WorksEntity model;
                    for (int n = 0; n < rowsCount; n++)
                    {
                        model = WorksDb.Instance.DataRowToModel(dt.Rows[n]);
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
        public DataTable GetAllList()
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
                return WorksDb.Instance.GetRecordCount(strWhere);
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
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            try
            {
                return WorksDb.Instance.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
        //return WorksDb.Instance.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(IDictionary<string, string> strWhere)
        {
            try
            {
                return WorksDb.Instance.GetList(strWhere);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 随机获得作品
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序</param>
        /// <returns></returns>
        public DataTable GetRandList(int Top, string strWhere, string filedOrder)
        {
            try
            {
                return WorksDb.Instance.GetRandList(Top, strWhere, filedOrder);
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
        /// <param name="worksId">作品id</param>
        /// <param name="status">状态码：1或0</param>
        /// <returns></returns>
        public bool UpdateStatus(string worksId, string status)
        {
            try
            {
                return WorksDb.Instance.UpdateStatus(worksId, status);
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
        /// <param name="worksId">作品id</param>
        /// <param name="statusName">状态名</param>
        /// <param name="status">状态码：1或0</param>
        /// <returns></returns>
        public bool UpdateStatus(string worksId, string statusName, string status)
        {
            try
            {
                return WorksDb.Instance.UpdateStatus(worksId, statusName, status);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
        /// <summary>
        /// 修改被赞数或打赏数
        /// </summary>
        /// <param name="workId"></param>
        /// <param name="t">被赞数或打赏数对应的字段（GoodNo、reward）</param>
        /// <param name="integral">要修改的数值</param>
        public int UpdateIntegral(string workId, string t, string integral)
        {
            try
            {
                return WorksDb.Instance.UpdateIntegral(workId, t, integral);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}