using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Com.Cos.Infrastructure
{
    public class ConfigurationManager
    {
        private static readonly IConfiguration Config;
        static ConfigurationManager()
        {
            // Microsoft.Extensions.Configuration扩展包提供的
            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection() //将配置文件的数据加载到内存中
                .SetBasePath(Directory.GetCurrentDirectory()) //指定配置文件所在的目录
#if DEBUG
                .Add(new JsonConfigurationSource { Path = "appsettings.Development.json", Optional = false, ReloadOnChange = true });
#else
                .Add(new JsonConfigurationSource {Path = "appsettings.json", Optional = false, ReloadOnChange = true});
#endif

            Config = builder.Build();
        }
        public static T GetAppSettings<T>(string key) where T : class, new()
        {
            var appconfig = new ServiceCollection()
                .AddOptions()
                .Configure<T>(Config.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;

            return appconfig;
        }

        public static IConfiguration AppSettings => Config;

        public static string Get(string key)
        {
            return Config[key];
        }
    }
}