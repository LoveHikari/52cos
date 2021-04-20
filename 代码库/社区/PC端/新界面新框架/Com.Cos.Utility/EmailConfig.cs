using System;

namespace Com.Cos.Utility
{
    public class EmailConfig
    {
        private static EmailConfig instance;
        public static EmailConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmailConfig();
                }
                return instance;
            }
        }

        public string _EmailName { get; set; }
        public string _EmailUserName { get; set; }
        public string _EmailPassword { get; set; }
        public string _EmailAgreement { get; set; }
        public string _EmailRegisterTitle { get; set; }
        public string _EmailBody { get; set; }
        //配置文件地址
        private string ConfigPath = @"{0}config\config.ini";

        public EmailConfig()
        {
            ConfigPath = string.Format(ConfigPath, AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
            Initialization ini = new Initialization(ConfigPath);

            this._EmailName = ini.IniReadValue("EmailConfig", "name");
            this._EmailUserName = DEncryptUtils.DESDecrypt(ini.IniReadValue("EmailConfig", "username")).Replace("\0", "");
            this._EmailPassword = DEncryptUtils.DESDecrypt(ini.IniReadValue("EmailConfig", "password")).Replace("\0", "");
            this._EmailAgreement = ini.IniReadValue("EmailConfig", "agreement");
            this._EmailRegisterTitle = ini.IniReadValue("EmailConfig", "registertitle");
            //********************************************************************************************************
            this._EmailBody = FileOperate.ReadFile($"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}config\\emailbody.ini");
        }
    }
}