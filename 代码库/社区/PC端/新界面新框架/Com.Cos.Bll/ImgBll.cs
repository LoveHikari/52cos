using System;
using Com.Cos.Db;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Bll
{
    public class ImgBll
    {
        #region instance
        private volatile static ImgBll _instance = null;
        private static readonly object lockHelper = new object();
        private ImgBll() { }
        public static ImgBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new ImgBll();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ImgEntity model)
        {
            try
            {
                return ImgDb.Instance.Add(model);
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
        public ImgEntity GetModel(int imgId)
        {
            try
            {
                return ImgDb.Instance.GetModel(imgId);
            }
            catch (Exception ex)
            {

                WriteLog.WriteError(ex);
                throw ex;
            }
        }
    }
}