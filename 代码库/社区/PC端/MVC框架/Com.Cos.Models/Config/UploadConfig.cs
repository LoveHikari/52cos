using System.Configuration;

namespace Com.Cos.Models.Config
{
    /// <summary>
    /// 上传设置配置节
    /// <remarks>
    /// 创建：2014.03.09
    /// </remarks>
    /// </summary>
    public class UploadConfig : ConfigurationSection
    {
        #region instance
        private static volatile UploadConfig _instance = null;
        private static readonly object lockHelper = new object();
        private UploadConfig() { }
        public static UploadConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = ConfigurationManager.GetSection("UploadConfig") as UploadConfig;
                    }
                }
                return _instance;
            }
        }
        #endregion

        private static ConfigurationProperty _property = new ConfigurationProperty(string.Empty, typeof(KeyValueElementCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);
        /// <summary>
        /// 配置列表
        /// </summary>
        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        private KeyValueElementCollection KeyValues
        {
            get { return (KeyValueElementCollection)base[_property]; }
            set { base[_property] = value; }
        }
        /// <summary>
        /// 最大大小
        /// </summary>
        public int MaxSize
        {
            get
            {
                int _value = 0;
                if (KeyValues["MaxSize"] != null) int.TryParse(KeyValues["MaxSize"].Value, out _value);
                return _value;
            }
            set
            {
                if (KeyValues["MaxSize"] == null) KeyValues["MaxSize"] = new KeyValueElement() { Key = "MaxSize", Value = value.ToString() };
                else KeyValues["MaxSize"].Value = value.ToString();
            }
        }

        /// <summary>
        /// 上传目录
        /// 为应用程序目录起的文件夹名，前面不带~/
        /// </summary>
        public string Path
        {
            get
            {
                if (KeyValues["Path"] == null) return "Upload";
                return KeyValues["Path"].Value;
            }
            set
            {
                if (KeyValues["Path"] == null) KeyValues["Path"] = new KeyValueElement() { Key = "Path", Value = value };
                else KeyValues["Path"].Value = value;
            }
        }

        /// <summary>
        /// 允许上传的图片类型文件扩展，多个用“,”隔开
        /// </summary>
        public string ImageExt
        {
            get
            {
                if (KeyValues["ImageExt"] == null) return string.Empty;
                return KeyValues["ImageExt"].Value;
            }
            set
            {
                if (KeyValues["ImageExt"] == null) KeyValues["ImageExt"] = new KeyValueElement() { Key = "ImageExt", Value = value };
                else KeyValues["ImageExt"].Value = value;
            }
        }

        /// <summary>
        /// 允许上传的Flash类型文件扩展，多个用“,”隔开
        /// </summary>
        public string FlashExt
        {
            get
            {
                if (KeyValues["FlashExt"] == null) return string.Empty;
                return KeyValues["FlashExt"].Value;
            }
            set
            {
                if (KeyValues["FlashExt"] == null) KeyValues["FlashExt"] = new KeyValueElement() { Key = "FlashExt", Value = value };
                else KeyValues["FlashExt"].Value = value;
            }
        }

        /// <summary>
        /// 允许上传的媒体类型文件扩展，多个用“,”隔开
        /// </summary>
        public string MediaExt
        {
            get
            {
                if (KeyValues["MediaExt"] == null) return string.Empty;
                return KeyValues["MediaExt"].Value;
            }
            set
            {
                if (KeyValues["MediaExt"] == null) KeyValues["MediaExt"] = new KeyValueElement() { Key = "MediaExt", Value = value };
                else KeyValues["MediaExt"].Value = value;
            }
        }

        /// <summary>
        /// 允许上传的文件类型文件扩展，多个用“,”隔开
        /// </summary>
        public string FileExt
        {
            get
            {
                if (KeyValues["FileExt"] == null) return string.Empty;
                return KeyValues["FileExt"].Value;
            }
            set
            {
                if (KeyValues["FileExt"] == null) KeyValues["FileExt"] = new KeyValueElement() { Key = "FileExt", Value = value };
                else KeyValues["FileExt"].Value = value;
            }
        }
        /// <summary>
        /// 图片上传根路径
        /// </summary>
        public string ImgRootPath
        {
            get
            {
                if (KeyValues["ImgRootPath"] == null) return string.Empty;
                return KeyValues["ImgRootPath"].Value;
            }
            set
            {
                if (KeyValues["ImgRootPath"] == null) KeyValues["ImgRootPath"] = new KeyValueElement() { Key = "ImgRootPath", Value = value };
                else KeyValues["ImgRootPath"].Value = value;
            }
        }
        /// <summary>
        /// 图片上传路径
        /// </summary>
        public string ImgPath
        {
            get
            {
                if (KeyValues["ImgPath"] == null) return string.Empty;
                return KeyValues["ImgPath"].Value;
            }
            set
            {
                if (KeyValues["ImgPath"] == null) KeyValues["ImgPath"] = new KeyValueElement() { Key = "ImgPath", Value = value };
                else KeyValues["ImgPath"].Value = value;
            }
        }

        /// <summary>
        /// 头像上传路径
        /// </summary>
        public string PortraitPath
        {
            get
            {
                if (KeyValues["PortraitPath"] == null) return string.Empty;
                return KeyValues["PortraitPath"].Value;
            }
            set
            {
                if (KeyValues["PortraitPath"] == null) KeyValues["PortraitPath"] = new KeyValueElement() { Key = "PortraitPath", Value = value };
                else KeyValues["PortraitPath"].Value = value;
            }
        }
    }
}
