using System;

namespace Com.Cos.Utility
{
    /// <summary>
    /// 时间提取类
    /// </summary>
    public class DateFormat
    {
        /// <summary>
        /// 获取当日所在的周的开始日期和结束日期
        /// </summary>
        /// <param name="dtNow">当前日期（年月日）</param>
        /// <param name="dtWeekSt">开始日期</param>
        /// <param name="dtWeekEd">结束日期</param>
        public static void ReturnDateWeek(DateTime dtNow, out DateTime dtWeekSt, out DateTime dtWeekEd)
        {
            //今天是星期几
            int iNowOfWeek = (int)dtNow.DayOfWeek;
            dtWeekSt = dtNow.AddDays(0 - iNowOfWeek);
            dtWeekEd = dtNow.AddDays(6 - iNowOfWeek);
        }

        /// <summary>
        /// 返回某年某月的第一天和最后一天
        /// </summary>
        /// <param name="month">当前月份</param>
        /// <param name="firstDay">第一天yyyy-MM-dd</param>
        /// <param name="lastDay">最后一天yyyy-MM-dd</param>
        public static void ReturnDateMonth(int year, int month, out string firstDay, out string lastDay)
        {

            year = DateTime.Now.Year + month / 12;
            if (month != 12)
            {
                month = month % 12;
            }
            switch (month)
            {
                case 1:
                    firstDay = DateTime.Now.ToString(year + "-0" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-0" + month + "-31");
                    break;
                case 2:
                    firstDay = DateTime.Now.ToString(year + "-0" + month + "-01");
                    if (DateTime.IsLeapYear(DateTime.Now.Year))
                        lastDay = DateTime.Now.ToString(year + "-0" + month + "-29");
                    else
                        lastDay = DateTime.Now.ToString(year + "-0" + month + "-28");
                    break;
                case 3:
                    firstDay = DateTime.Now.ToString(year + "-0" + month + "-01");
                    lastDay = DateTime.Now.ToString("yyyy-0" + month + "-31");
                    break;
                case 4:
                    firstDay = DateTime.Now.ToString(year + "-0" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-0" + month + "-30");
                    break;
                case 5:
                    firstDay = DateTime.Now.ToString(year + "-0" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-0" + month + "-31");
                    break;
                case 6:
                    firstDay = DateTime.Now.ToString(year + "-0" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-0" + month + "-30");
                    break;
                case 7:
                    firstDay = DateTime.Now.ToString(year + "-0" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-0" + month + "-31");
                    break;
                case 8:
                    firstDay = DateTime.Now.ToString(year + "-0" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-0" + month + "-31");
                    break;
                case 9:
                    firstDay = DateTime.Now.ToString(year + "-0" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-0" + month + "-30");
                    break;
                case 10:
                    firstDay = DateTime.Now.ToString(year + "-" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-" + month + "-31");
                    break;
                case 11:
                    firstDay = DateTime.Now.ToString(year + "-" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-" + month + "-30");
                    break;
                default:
                    firstDay = DateTime.Now.ToString(year + "-" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-" + month + "-31");
                    break;
            }
        }

        /// <summary>
        /// 取指定日期是一年中的第几周
        /// </summary>
        /// <param name="dtNow">给定的日期(年月日)</param>
        /// <returns>一年中的第几周</returns>
        public static int GetWeekOfYear(DateTime dtNow)
        {
            //一.找到第一周的最后一天（先获取1月1日是星期几，从而得知第一周周末是几）
            int firstWeekend = 7 - Convert.ToInt32(DateTime.Parse(dtNow.Year + "-1-1").DayOfWeek);

            //二.获取今天是一年当中的第几天
            int currentDay = dtNow.DayOfYear;

            //三.（今天 减去 第一周周末）/7 等于 距第一周有多少周 再加上第一周的1 就是今天是今年的第几周了
            //    刚好考虑了惟一的特殊情况就是，今天刚好在第一周内，那么距第一周就是0 再加上第一周的1 最后还是1
            return Convert.ToInt32(Math.Ceiling((currentDay - firstWeekend) / 7.0)) + 1;
        }

        /// <summary>
        /// 取指定日期是一年中的第几周,并返回该周第一天和最后一天
        /// </summary>
        /// <param name="dtNow">给定的日期(年月日)</param>
        /// <returns>GetWeekDay[0]=周次;GetWeekDay[1]=该周第一天;GetWeekDay[2]=该周最后一天</returns>
        public static string[] GetWeekDay(DateTime dtNow)
        {
            string[] inti = new string[3];
            DateTime day = DateTime.Parse(dtNow.Year + "-1-1");  //一年的第一天
            int weekday = (int)day.DayOfWeek; //一年的第一天是星期几
            int DayCount = dtNow.DayOfYear;  //今天是一年中的第几天
            int i = Convert.ToInt32(Math.Ceiling((DayCount - 7 + weekday) / 7.0)) + 1;  //第几周
            inti[0] = i.ToString();

            //今天是星期几
            int iNowOfWeek = (int)dtNow.DayOfWeek;
            inti[1] = dtNow.AddDays(0 - iNowOfWeek).ToString();
            inti[2] = dtNow.AddDays(6 - iNowOfWeek).ToString();
            return inti;
        }
        /// <summary>  
        /// 用年份和第几周来获得一周开始和结束的时间,这里用星期一做开始。  
        /// </summary>  
        public static void GetWeek(int year, int weekNum, out DateTime weekStart, out DateTime weekeEnd)
        {
            var dateTime = new DateTime(year, 1, 1);
            dateTime = dateTime.AddDays(7 * weekNum);
            weekStart = dateTime.AddDays(-(int)dateTime.DayOfWeek + (int)DayOfWeek.Monday);
            weekeEnd = dateTime.AddDays((int)DayOfWeek.Saturday - (int)dateTime.DayOfWeek + 1);
        }
        /// <summary>
        /// 某日期是当月的第几周
        /// </summary>
        /// <param name="day">给定的日期(年月日)</param>
        /// <returns>第几周</returns>
        public static int GetWeekOfMonth(DateTime day)
        {
            DateTime FirstofMonth;
            FirstofMonth = Convert.ToDateTime(day.Date.Year + "-" + day.Date.Month + "-" + 1);
            int i = (int)FirstofMonth.Date.DayOfWeek;
            if (i == 0)
            {
                i = 7;
            }
            return (day.Date.Day + i - 1) / 7 + 1;
        }

        /// <summary>
        /// 某日期是当月的第几周,并返回该周的第一天和最后一天
        /// </summary>
        /// <param name="day">给定日期（年月日）</param>
        /// <returns>GetWeekOfDay[0]=周次;GetWeekOfDay[1]=该周第一天;GetWeekOfDay[2]=该周最后一天</returns>
        public static string[] GetWeekOfDay(DateTime day)
        {
            string[] inti = new string[3];
            DateTime dtWeekSt, dtWeekEd;
            inti[0] = GetWeekOfMonth(day).ToString();
            ReturnDateWeek(day, out dtWeekSt, out dtWeekEd);
            inti[1] = dtWeekSt.ToString();
            inti[2] = dtWeekEd.ToString();
            return inti;

        }
        /// <summary>
        /// 获取当日所在的月的开始日期和结束日期
        /// </summary>
        /// <param name="dtNow">当前日期</param>
        /// <param name="dtMonthSt">月初</param>
        /// <param name="dtMonthEd">月末</param>
        public static void ReturnDatetMonth(DateTime dtNow, out DateTime dtMonthSt, out DateTime dtMonthEd)
        {
            dtMonthSt = dtNow.AddDays(1 - dtNow.Day);  //本月月初  
            dtMonthEd = dtMonthSt.AddMonths(1).AddDays(-1);  //本月月末  
            //dtMonthEd = dtMonthSt.AddDays((dtNow.AddMonths(1) - dtNow).Days - 1);  //本月月末
        }
        /// <summary>
        /// 获取当日所在的季度的开始日期和结束日期
        /// </summary>
        /// <param name="dtNow">当前日期</param>
        /// <param name="dtQuarterSt">本季度初</param>
        /// <param name="dtQuarterEd">本季度末</param>
        public static void ReturnDatetQuarter(DateTime dtNow, out DateTime dtQuarterSt, out DateTime dtQuarterEd)
        {
            dtQuarterSt = dtNow.AddMonths(0 - (dtNow.Month - 1) % 3).AddDays(1 - dtNow.Day);  //本季度初
            dtQuarterEd = dtQuarterSt.AddMonths(3).AddDays(-1);  //本季度末
        }
        /// <summary>
        /// 获取当日所在的年的开始日期和结束日期
        /// </summary>
        /// <param name="dtNow">当前日期</param>
        /// <param name="dtYearSt">年初</param>
        /// <param name="dtYearEd">年末</param>
        public static void ReturnDatetYear(DateTime dtNow, out DateTime dtYearSt, out DateTime dtYearEd)
        {
            dtYearSt = new DateTime(dtNow.Year, 1, 1);  //本年年初  
            dtYearEd = new DateTime(dtNow.Year, 12, 31);  //本年年末
        }
    }
}
