using Microsoft.Extensions.Configuration;
using System.IO;

namespace Teleware.Foundation.Configuration
{
    /// <summary>
    /// 启动配置提供者
    /// </summary>
    /// <remarks>
    /// 启动配置用于初始化组件注册、日志配置文件、配置文件位置等的配置，启动时读取一次，不刷新
    /// </remarks>
    public interface IBootupConfigurationProvider
    {
        /// <summary>
        /// 获取启动配置
        /// </summary>
        /// <returns></returns>
        IConfigurationRoot GetBootupConfiguration();
    }

    /// <summary>
    /// 启动配置相关扩展
    /// </summary>
    public static class BootupConfigurationProviderExtensions
    {
        /// <summary>
        /// 读取Autofac配置
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static IConfiguration GetAutofacConfiguration(this IBootupConfigurationProvider provider)
        {
            return provider.GetBootupConfiguration().GetSection("Autofac");
        }

        /// <summary>
        /// 读取NLog配置文件位置
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static string GetNLogConfigFilePath(this IBootupConfigurationProvider provider)
        {
            var configurationSection = provider.GetBootupConfiguration().GetSection("Configuration");
            var configurationRootPath = configurationSection.GetSection("ConfigurationRootPath").Value;
            var configurationFileName = configurationSection.GetSection("NLog").Value;
            if (configurationFileName == null)
            {
                return null;
            }
            else
            {
                return Path.Combine(configurationRootPath, configurationFileName);
            }
        }
    }
}