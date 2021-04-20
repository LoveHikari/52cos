using System;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    public class SmallImgBll
    {
        #region instance
        private volatile static SmallImgBll _instance = null;
        private static readonly object lockHelper = new object();
        private SmallImgBll() { }
        public static SmallImgBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new SmallImgBll();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SmallImgEntity model)
        {
            try
            {
                return SmallImgDb.Instance.Add(model);
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
        public SmallImgEntity GetModel(int imgId)
        {
            try
            {
                return SmallImgDb.Instance.GetModel(imgId);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}