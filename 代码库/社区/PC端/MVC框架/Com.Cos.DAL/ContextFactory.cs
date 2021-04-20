using System.Runtime.Remoting.Messaging;

namespace Com.Cos.DAL
{
    /// <summary>
    /// 上下文简单工厂
    /// <remarks>
    /// 创建：2014.02.05
    /// </remarks>
    /// </summary>
    public class ContextFactory
    {

        /// <summary>
        /// 获取当前数据上下文
        /// </summary>
        /// <returns></returns>
        public static CosDbContext GetCurrentContext()
        {
            CosDbContext nContext = CallContext.GetData("CosContext") as CosDbContext;
            if (nContext == null)
            {
                nContext = new CosDbContext();
                CallContext.SetData("CosContext", nContext);
            }
            return nContext;
        }
    }
}