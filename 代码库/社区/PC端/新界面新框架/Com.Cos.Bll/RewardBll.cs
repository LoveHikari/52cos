using System;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    /// <summary>
    /// 打赏表
    /// </summary>
    public class RewardBll
    {
        #region instance
        private volatile static RewardBll _instance = null;
        private static readonly object lockHelper = new object();
        private RewardBll() { }
        public static RewardBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new RewardBll();
                    }
                }
                return _instance;
            }
        }
        #endregion
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
                return RewardDb.Instance.UpdateStatus(worksId, status);
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
        public int Add(RewardEntity model)
        {
            try
            {
                return RewardDb.Instance.Add(model);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}