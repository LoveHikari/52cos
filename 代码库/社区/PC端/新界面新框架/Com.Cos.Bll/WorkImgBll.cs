using System;
using Com.Cos.Db;
using Com.Cos.Entity;

namespace Com.Cos.Bll
{
    public class WorkImgBll
    {
        #region instance
        private volatile static WorkImgBll _instance = null;
        private static readonly object lockHelper = new object();
        private WorkImgBll() { }
        public static WorkImgBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new WorkImgBll();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WorkImgEntity model)
        {
            try
            {
                return WorkImgDb.Instance.Add(model);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}