using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Utility
{
    /***
     * title:ini文件操作
     * date:2016-03-16
     * author:YUXIAOWEI
     ***/
    /// <summary>
    /// 读写ini文件，需要绝对路径
    /// </summary>
    public class Initialization
    {
        //文件INI名稱
        private string Path;
        // 声明INI文件的写操作函数 WritePrivateProfileString() 
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        // 声明INI文件的读操作函数 GetPrivateProfileString()  
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        // 類的構造函數，傳遞INI文件名，需要绝对路径
        public Initialization(string inipath)
        {
            Path = inipath;
        }
        /// <summary>
        /// //寫INI文件
        /// </summary>
        /// <param name="Section">配置节</param>
        /// <param name="Key">键名</param>
        /// <param name="Value">键值</param>
        public void IniWriteValue(string Section, string Key, string Value)
        {
            CreateConfig();
            // section=配置节，key=键名，value=键值，path=路径
            WritePrivateProfileString(Section, Key, Value, this.Path);
        }
        /// <summary>
        /// //讀取指定INI文件
        /// </summary>
        /// <param name="Section">配置节</param>
        /// <param name="Key">键名</param>
        /// <returns>键值</returns>
        public string IniReadValue(string Section, string Key)
        {
            // 每次从ini中读取多少字节 
            StringBuilder temp = new StringBuilder(255);
            // section=配置节，key=键名，temp=上面，path=路径  
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.Path);
            return temp.ToString();
        }

        /// <summary>
        /// 判断配置文件是否存在，不存在则创建
        /// </summary>
        private void CreateConfig()
        {
            if (!File.Exists(this.Path))
            {
                StreamWriter sw = File.CreateText(this.Path);
                sw.Write("#表格配置档案");
                sw.Close();
            }
        }
    }
}
