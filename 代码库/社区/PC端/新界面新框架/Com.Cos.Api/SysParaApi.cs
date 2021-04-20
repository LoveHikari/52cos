using System.Data;
using Com.Cos.Bll;

namespace Com.Cos.Api
{
    public class SysParaApi
    {
        /// <summary>
        /// 获得审核标志文本
        /// </summary>
        /// <param name="examine">审核标志</param>
        /// <returns></returns>
        protected static string GetExamineText(string examine)
        {
            DataTable sysTable = SysParaBll.Instance.GetSysParaTable("examine");
            var records = sysTable.AsEnumerable().Where(a => a["RefValue"].ToString() == examine);
            DataTable rsl = records.AsDataView().ToTable();
            return rsl.Rows[0]["RefText"].ToString();
        }
    }
}