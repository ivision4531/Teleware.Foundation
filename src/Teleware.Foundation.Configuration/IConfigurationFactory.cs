using Microsoft.Extensions.Configuration;

namespace Teleware.Foundation.Configuration
{
    /// <summary>
    /// 定义一个配置工厂
    /// </summary>
    public interface IConfigurationFactory
    {
        /// <summary>
        /// 获取配置根节点
        /// </summary>
        /// <returns></returns>
        IConfigurationRoot GetConfigurationRoot();
    }
}