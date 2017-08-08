using System;
using System.Linq;

namespace Teleware.Foundation.Util.ObjectConverters
{
    /// <summary>
    /// 描述一个类型转换器配置
    /// </summary>
    public interface IObjectConverterConfig
    {
        /// <summary>
        /// 源类型
        /// </summary>
        Type Source { get; }

        /// <summary>
        /// 目标类型
        /// </summary>
        Type Target { get; }

        /// <summary>
        /// 转换为目标类型
        /// </summary>
        /// <param name="sourceObj">源类型的实例</param>
        /// <returns>目标类型的实例</returns>
        object Convert(object sourceObj);

        /// <summary>
        /// 转换为目标类型
        /// </summary>
        /// <param name="sourceObj">源类型的实例</param>
        /// <param name="targetObj">当前已存在的目标类型实例</param>
        /// <returns>
        /// 返回<paramref name="targetObj"/>
        /// </returns>
        object Convert(object sourceObj, object targetObj);

        /// <summary>
        /// 转换为目标类型的查询
        /// </summary>
        /// <param name="sourceQuery">源类型的查询</param>
        /// <returns>目标类型的查询</returns>
        IQueryable Convert(IQueryable sourceQuery);
    }

    /// <summary>
    /// 类型转换器配置
    /// </summary>
    public interface IObjectConverterConfig<in TSource, TTarget> : IObjectConverterConfig
    {
        /// <summary>
        /// 转换为目标类型
        /// </summary>
        /// <param name="sourceObj">源类型的实例</param>
        /// <returns>目标类型的实例</returns>
        TTarget Convert(TSource sourceObj);

        /// <summary>
        /// 转换为目标类型
        /// </summary>
        /// <param name="sourceObj">源类型的实例</param>
        /// <param name="targetObj">目标类型的实例</param>
        /// <returns>目标类型的实例</returns>
        TTarget Convert(TSource sourceObj, TTarget targetObj);

        /// <summary>
        /// 转换为目标类型的查询
        /// </summary>
        /// <param name="sourceQuery">源类型的查询</param>
        /// <returns>目标类型的查询</returns>
        IQueryable<TTarget> Convert(IQueryable<TSource> sourceQuery);
    }
}