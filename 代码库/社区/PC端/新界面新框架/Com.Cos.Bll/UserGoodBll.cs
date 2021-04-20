using System;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    public class UserGoodBll
    {
        #region instance
        private volatile static UserGoodBll _instance = null;
        private static readonly object lockHelper = new object();
        private UserGoodBll() { }
        public static UserGoodBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new UserGoodBll();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="userId">会员id</param>
        /// <param name="workId">作品id</param>
        /// <returns></returns>
        public bool ExistsByUserId(string userId, string workId)
        {
            try
            {
                return UserGoodDb.Instance.ExistsByUserId(userId, workId);
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
        public int Add(UserGoodEntity model)
        {
            try
            {
                return UserGoodDb.Instance.Add(model);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}