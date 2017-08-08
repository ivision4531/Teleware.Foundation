using System.Collections.Generic;

namespace Teleware.Foundation.Util.ObjectConverters
{
    /// <summary>
    /// 描述一个类型转换器配置工厂
    /// </summary>
    public interface IObjectConverterConfigFatory
    {
        /// <summary>
        /// 获取类型转换器配置
        /// </summary>
        /// <returns>一系列的类型转换器(<see cref="IObjectConverterConfig"/>)</returns>
        IEnumerable<IObjectConverterConfig> GetConfigs();
    }
}