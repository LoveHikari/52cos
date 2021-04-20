using Com.Cos.Entity;
using System;
using System.Data;
using Com.Cos.Db;
using System.Collections.Generic;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    public class MemberBll
    {
        #region instance

        private volatile static MemberBll _instance = null;
        private static readonly object lockHelper = new object();

        private MemberBll()
        {
        }

        public static MemberBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new MemberBll();
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
        public int Add(MemberEntity model)
        {
            try
            {
                return MemberDb.Instance.Add(model);
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
        public bool Update(MemberEntity model)
        {
            try
            {
                return MemberDb.Instance.Update(model);
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
        public bool Delete(int User_id)
        {

            try
            {
                return MemberDb.Instance.Delete(User_id);
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
        public bool DeleteList(string User_idlist)
        {
            try
            {
                return MemberDb.Instance.DeleteList(User_idlist);
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
        public MemberEntity GetModel(int User_id)
        {

            try
            {
                return MemberDb.Instance.GetModel(User_id);
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
                return MemberDb.Instance.GetList(strWhere);
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
                return MemberDb.Instance.GetList(Top, strWhere, filedOrder);
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
        public List<MemberEntity> GetModelList(string strWhere)
        {
            try
            {
                DataSet ds = MemberDb.Instance.GetList(strWhere);
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
        public List<MemberEntity> DataTableToList(DataTable dt)
        {
            try
            {
                List<MemberEntity> modelList = new List<MemberEntity>();
                int rowsCount = dt.Rows.Count;
                if (rowsCount > 0)
                {
                    MemberEntity model;
                    for (int n = 0; n < rowsCount; n++)
                    {
                        model = MemberDb.Instance.DataRowToModel(dt.Rows[n]);
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
                return MemberDb.Instance.GetRecordCount(strWhere);
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
                return MemberDb.Instance.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
        //return MemberDb.Instance.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion

        /// <summary>
        /// 修改积分或热心或成长值或CN币
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="t">积分或热心或成长值或CN币或身家或剩余兑换次数或押金对应的字段（integral、ardent、Growth、Cnbi、Shenjia、RemainingConversions、Deposit）</param>
        /// <param name="integral">要修改的数值</param>
        public int UpdateIntegral(string userId, string t, string integral)
        {
            try
            {
                return MemberDb.Instance.UpdateIntegral(userId, t, integral);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
        /// <summary>
        /// 修改会员时间
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="money">金额</param>
        /// <returns></returns>
        public int UpdateVip(string userId, string money)
        {
            try
            {
                return MemberDb.Instance.UpdateVip(userId, money);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}