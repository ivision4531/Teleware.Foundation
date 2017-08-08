using System;
using System.Collections.Generic;
using System.Linq;

namespace Teleware.Foundation.Util.ObjectConverters
{
    /// <summary>
    /// 类型转换器工厂基类
    /// </summary>
    /// <typeparam name="TSource">源类型</typeparam>
    /// <typeparam name="TTarget">目标类型</typeparam>
    public abstract class AbstractObjectConverterConfigFatory<TSource, TTarget> : IObjectConverterConfigFatory
    {
        /// <inheritdoc/>
        public IEnumerable<IObjectConverterConfig> GetConfigs()
        {
            yield return GetSourceToTargetConfig();
            yield return GetTargetToSourceConfig();
        }

        /// <summary>
        /// 获取从源类型转换为目标类型的配置
        /// </summary>
        /// <returns></returns>
        public IObjectConverterConfig GetSourceToTargetConfig()
        {
            return new InnerObjectConvertConfig<TSource, TTarget>(
                s => Convert(s),
                (s, t) => Convert(s, t),
                sQuery => Convert(sQuery));
        }

        /// <summary>
        /// 获取从目标类型转换为源类型的配置
        /// </summary>
        /// <returns></returns>
        public IObjectConverterConfig GetTargetToSourceConfig()
        {
            return new InnerObjectConvertConfig<TTarget, TSource>(
                t => ConvertBack(t),
                (t, s) => ConvertBack(t, s),
                tQuery => ConvertBack(tQuery));
        }

        /// <summary>
        /// 转换为目标类型
        /// </summary>
        /// <param name="sourceObj">源类型的实例</param>
        /// <returns>目标类型的实例</returns>
        protected abstract TTarget Convert(TSource sourceObj);

        /// <summary>
        /// 转换为目标类型
        /// </summary>
        /// <param name="sourceObj">源类型的实例</param>
        /// <param name="targetObj">当前已存在的目标类型实例</param>
        /// <returns>
        /// 返回<paramref name="targetObj"/>
        /// </returns>
        protected abstract TTarget Convert(TSource sourceObj, TTarget targetObj);

        /// <summary>
        /// 转换为目标类型的查询
        /// </summary>
        /// <param name="sourceQuery">源类型的查询</param>
        /// <returns>
        /// 返回目标类型的查询
        /// </returns>
        protected abstract IQueryable<TTarget> Convert(IQueryable<TSource> sourceQuery);

        /// <summary>
        /// 转换为源类型
        /// </summary>
        /// <param name="targetObj"></param>
        /// <returns>目标类型的实例</returns>
        protected abstract TSource ConvertBack(TTarget targetObj);

        /// <summary>
        /// 转换为源类型
        /// </summary>
        /// <param name="targetObj">目标类型的实例</param>
        /// <param name="sourceObj">当前已存在的源类型实例</param>
        /// <returns>返回<paramref name="sourceObj"/></returns>
        protected abstract TSource ConvertBack(TTarget targetObj, TSource sourceObj);

        /// <summary>
        /// 转换为源类型
        /// </summary>
        /// <param name="targetQuery">目标类型的查询</param>
        /// <returns>
        /// 返回源类型的查询
        /// </returns>
        protected abstract IQueryable<TSource> ConvertBack(IQueryable<TTarget> targetQuery);
    }

    internal class InnerObjectConvertConfig<TSource, TTarget> : IObjectConverterConfig<TSource, TTarget>
    {
        private readonly Func<TSource, TTarget> _convertFunc1;
        private readonly Func<TSource, TTarget, TTarget> _convertFunc2;
        private readonly Func<IQueryable<TSource>, IQueryable<TTarget>> _convertFunc3;

        public InnerObjectConvertConfig(Func<TSource, TTarget> convertFunc1, Func<TSource, TTarget, TTarget> convertFunc2, Func<IQueryable<TSource>, IQueryable<TTarget>> convertFunc3)
        {
            Source = typeof(TSource);
            Target = typeof(TTarget);
            _convertFunc1 = convertFunc1;
            _convertFunc2 = convertFunc2;
            _convertFunc3 = convertFunc3;
        }

        public Type Source { get; }

        public Type Target { get; }

        public IQueryable Convert(IQueryable sourceQuery)
        {
            return Convert((IQueryable<TSource>)sourceQuery);
        }

        public object Convert(object sourceObj)
        {
            return Convert((TSource)sourceObj);
        }

        public object Convert(object sourceObj, object existingTargetObj)
        {
            return Convert((TSource)sourceObj, (TTarget)existingTargetObj);
        }

        public TTarget Convert(TSource sourceObj)
        {
            return _convertFunc1(sourceObj);
        }

        public TTarget Convert(TSource sourceObj, TTarget existingTargetObj)
        {
            return _convertFunc2(sourceObj, existingTargetObj);
        }

        public IQueryable<TTarget> Convert(IQueryable<TSource> sourceQuery)
        {
            return _convertFunc3(sourceQuery);
        }
    }
}