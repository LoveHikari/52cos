using System;
using System.Data;
using System.Reflection;
using System.Text;

namespace Com.Cos.Utility
{
    /// <summary>
    /// 其他工具类
    /// </summary>
    public class UtilityHelper
    {
        /// <summary>
        /// 将null转为dbnull
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object SqlNull(object obj)
        {
            if (obj == null)
                return DBNull.Value;

            return obj;
        }

        /// <summary>
        /// 返回随机积分
        /// </summary>
        /// <returns></returns>
        public static int ReturnRandomIntegral()
        {
            Random ran = new Random();
            int randKey = ran.Next(1, 601304088);
            if (randKey == 300652044 )
            {
                return 5;
            }
            else if (randKey > 150326022 && randKey <= 450978066) //50%
            {
                return 2;
            }
            else if(randKey <= 150326022) //25%
            {
                return 1;
            }
            else //25%
            {
                return ran.Next(3, 4);
            }
        }

        /// <summary>
        /// 获取至今的时间差
        /// </summary>
        /// <param name="releaseTime">发布时间</param>
        /// <returns></returns>
        public static string GetTime(string releaseTime)
        {
            if (string.IsNullOrEmpty(releaseTime))
            {
                return "";
            }
            DateTime dt = Convert.ToDateTime(releaseTime);
            DateTime nowDt = DateTime.Now;
            TimeSpan ts = nowDt - dt;

            if (ts.Days >= 365)
            {
                return ts.Days / 365 + "年前";
            }
            if (ts.Days >= 30)
            {
                return ts.Days / 30 + "月前";
            }
            if (ts.Days >= 1)
            {
                return ts.Days + "天前";
            }
            if (ts.Hours >= 1)
            {
                return ts.Hours + "小时前";
            }
            if (ts.Minutes >= 1)
            {
                return ts.Minutes + "分钟前";
            }
            return ts.Seconds + "秒前";
        }
        ///// <summary>
        ///// 转Json
        ///// </summary>
        ///// <param name="obj">数据</param>
        ///// <returns></returns>
        //public static string ToJson(object obj)
        //{
        //    Type[] entityTypes = Assembly.Load("Com.Cos.Entity").GetTypes();  //Com.Cos.Entity下的所有类
        //    StringBuilder sb = new StringBuilder();
        //    if (obj.GetType() == typeof(DataTable))
        //    {
        //        DataTable dt = obj as DataTable;
        //        sb.Append("{");
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            sb.AppendFormat("\"{0}\": [", i);
        //            sb.Append("{");
        //            for (int j = 0; j < dt.Columns.Count; j++)
        //            {
        //                sb.AppendFormat("\"{0}\": \"{1}\",", dt.Columns[j].ColumnName, dt.Rows[i][j]);
        //            }
        //            sb.Remove(sb.ToString().Length - 1, 1);
        //            sb.Append("}");
        //            sb.Append("],");
        //        }
        //        sb.Remove(sb.ToString().Length - 1, 1);
        //        sb.Append("}");
        //    }
        //    if (Array.IndexOf(entityTypes, obj.GetType()) != -1)
        //    {
        //        sb.Append("{");
        //        foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
        //        {
        //            sb.AppendFormat("\"{0}\": \"{1}\",", propertyInfo.Name, propertyInfo.GetValue(obj));
        //        }
        //        sb.Remove(sb.ToString().Length - 1, 1);
        //        sb.Append("}");
        //    }
        //    if (obj is int)
        //    {
        //        sb.Append("{");
        //        sb.AppendFormat("\"vaule\": \"{0}\"", obj);
        //        sb.Append("}");
        //    }
        //    if (obj is bool)
        //    {
        //        sb.Append("{");
        //        sb.AppendFormat("\"status\": \"{0}\"", obj);
        //        sb.Append("}");
        //    }
        //    return sb.ToString();
        //}
    }
}
