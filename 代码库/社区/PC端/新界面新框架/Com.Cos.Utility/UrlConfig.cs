using System;

namespace Com.Cos.Utility
{
    public class UrlConfig
    {
        private static UrlConfig instance;
        public static UrlConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UrlConfig();
                }
                return instance;
            }
        }

        public string _Web_sq { get; set; }

        //配置文件地址
        private string ConfigPath = @"{0}config\config.ini";

        public UrlConfig()
        {
            ConfigPath = string.Format(ConfigPath, AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
            Initialization ini = new Initialization(ConfigPath);

            this._Web_sq = ini.IniReadValue("UrlConfig", "web_sq");
        }
    }
}