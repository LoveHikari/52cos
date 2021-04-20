
/***
 * title:获得ip类
 * date:2016-04-26
 * author:YUXIAOWEI
 ***/

using System.Xml;

namespace Com.Cos.Utility
{
    public static class IpHelper
    {
        #region 获得用户IP
        /// <summary>
        /// 获得用户IP
        /// </summary>
        public static string GetUserIp()
        {
            string ip;
            string[] temp;
            bool isErr = false;
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_ForWARDED_For"] == null)
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            else
                ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_ForWARDED_For"].ToString();
            if (ip.Length > 15)
                isErr = true;
            else
            {
                temp = ip.Split('.');
                if (temp.Length == 4)
                {
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (temp[i].Length > 3) isErr = true;
                    }
                }
                else
                    isErr = true;
            }

            if (isErr)
                return "1.1.1.1";
            else
                return ip;
        }
        #endregion

        /// <summary>  
        /// 根据IP 获取物理地址  
        /// </summary>  
        /// <param name="strIP"></param>  
        /// <returns></returns>  
        public static string GetstringIpAddress(string strIP)//strIP为IP  
        {
            string sURL = "http://www.youdao.com/smartresult-xml/search.s?type=ip&q=" + strIP + "";//youdao的URL  
            string stringIpAddress = "";
            using (XmlReader read = XmlReader.Create(sURL))//获取youdao返回的xml格式文件内容  
            {
                while (read.Read())
                {
                    switch (read.NodeType)
                    {
                        case XmlNodeType.Text://取xml格式文件当中的文本内容  
                            if (string.Format("{0}", read.Value).ToString().Trim() != strIP)
                            {
                                stringIpAddress = string.Format("{0}", read.Value).ToString().Trim();//赋值  
                            }
                            break;
                            //other  
                    }
                }
            }
            return stringIpAddress;
        }
    }
}