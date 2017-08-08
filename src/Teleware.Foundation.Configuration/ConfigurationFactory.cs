using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileSystemGlobbing;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using Teleware.Foundation.Hosting;
using Winton.Extensions.Configuration.Consul;

namespace Teleware.Foundation.Configuration
{
    /// <summary>
    /// 默认配置工厂
    /// </summary>
    public class ConfigurationFactory : IConfigurationFactory,IDisposable
    {
        private readonly IBootupConfigurationProvider _bootupProvider;
        private readonly IEnvironment _env;
        private readonly ConfigFactoryOptions _configOptions;
        private readonly string _configRootFullPath;
        private IConfigurationRoot _configuration;
        private CancellationTokenSource _consulCancellationTokenSource;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bootupProvider">启动配置提供者</param>
        /// <param name="env">当前环境</param>
        public ConfigurationFactory(IBootupConfigurationProvider bootupProvider, IEnvironment env)
        {
            _bootupProvider = bootupProvider;
            _env = env;
            _configOptions = new ConfigFactoryOptions();
            ConfigurationBinder.Bind(bootupProvider.GetBootupConfiguration().GetSection("Configuration"), _configOptions);
            _configRootFullPath = System.IO.Path.Combine(env.ContentRootPath, _configOptions.ConfigurationRootPath);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            // 实际环境中，基本上到这里程序将停止了。此时是否释放不重要
            _consulCancellationTokenSource?.Dispose();
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public IConfigurationRoot GetConfigurationRoot()
        {
            if (_configuration == null)
            {
                if (!Directory.Exists(_configRootFullPath))
                {
                    Directory.CreateDirectory(_configRootFullPath);
                }
                var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(_configRootFullPath);

                foreach (var jsonConfig in _configOptions.Json)
                {
                    var jsonFileMatcher = new Microsoft.Extensions.FileSystemGlobbing.Matcher();
                    var jsonFiles = jsonFileMatcher
                        .AddInclude(jsonConfig.Include)
                        .AddExclude(jsonConfig.Exclude)
                        .GetResultsInFullPath(_configRootFullPath);

                    foreach (var jsonFile in jsonFiles)
                    {
                        configurationBuilder.AddJsonFile(jsonFile, jsonConfig.Optional, jsonConfig.ReloadOnChange);
                    }
                }

                if (_configOptions.Consul?.Enable ?? false)
                {
                    if (_configOptions.Consul.Name == null)
                    {
                        throw new ArgumentException("Name is required when reading from consul");
                    }
                    _consulCancellationTokenSource = new CancellationTokenSource();
                    configurationBuilder.AddConsul($"{_configOptions.Consul.Name}.{_env.EnvironmentName}", _consulCancellationTokenSource.Token);
                }
                
                _configuration = configurationBuilder.Build();
            }

            return _configuration;
        }

        private class ConfigFactoryOptions
        {
            public string ConfigurationRootPath { get; set; }
            public JsonConfigFactoryOptions[] Json { get; set; }
            public ConsulConfigFactoryOption Consul { get; set; }
        }

        private class ConsulConfigFactoryOption
        {
            public bool Enable { get; set; }
            public string Name { get; set; }
        }

        private class JsonConfigFactoryOptions
        {
            public string Include { get; set; }
            public string Exclude { get; set; }
            public bool Optional { get; set; }
            public bool ReloadOnChange { get; set; }
        }
    }
}