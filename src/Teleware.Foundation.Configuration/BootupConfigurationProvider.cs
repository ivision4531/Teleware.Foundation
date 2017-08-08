using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Teleware.Foundation.Hosting;

namespace Teleware.Foundation.Configuration
{
    /// <summary>
    /// 默认启动配置提供者
    /// </summary>
    /// <remarks>
    /// 默认载入<see cref="IEnvironment.ContentRootPath"/>下的bootup.json
    /// 以及bootup.{EnvironmentName}.json文件
    /// </remarks>
    public class BootupConfigurationProvider : IBootupConfigurationProvider
    {
        private readonly IConfigurationRoot _bootupConfiguration;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="env">当前环境</param>
        public BootupConfigurationProvider(IEnvironment env)
        {
            var bootupConfigurationBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("bootup.json", false, false)
                .AddJsonFile($"bootup.{env.EnvironmentName}.json", true, false);
            _bootupConfiguration = bootupConfigurationBuilder.Build();
        }

        /// <summary>
        /// 获取启动配置
        /// </summary>
        /// <returns></returns>
        public IConfigurationRoot GetBootupConfiguration()
        {
            return _bootupConfiguration;
        }
    }
}