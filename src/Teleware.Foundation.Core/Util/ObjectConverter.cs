using System;
using System.Collections.Generic;
using System.Linq;

namespace Teleware.Foundation.Util.ObjectConverters
{
    /// <summary>
    /// 类型转换器
    /// </summary>
    public class ObjectConverter
    {
        private readonly Dictionary<Tuple<Type, Type>, IObjectConverterConfig> _objectConverters;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="objectConverterFatories"></param>
        public ObjectConverter(IEnumerable<IObjectConverterConfigFatory> objectConverterFatories)
        {
            _objectConverters = new Dictionary<Tuple<Type, Type>, IObjectConverterConfig>();
            foreach (var objectConverterConfigFatory in objectConverterFatories)
            {
                foreach (var config in objectConverterConfigFatory.GetConfigs())
                {
                    this._objectConverters.Add(Tuple.Create(config.Source, config.Target), config);
                }
            }
        }

        /// <summary>
        /// 转换类型
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <param name="sourceObj">源类型的实例</param>
        /// <returns></returns>
        public IConvertContext<TSource> Convert<TSource>(TSource sourceObj)
        {
            return new ConvertContext<TSource>(sourceObj, _objectConverters);
        }

        /// <summary>
        /// 转换查询类型
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <param name="souceQuery">源类型查询</param>
        /// <returns></returns>
        public IQueryableConvertContext<TSource> Convert<TSource>(IQueryable<TSource> souceQuery)
        {
            return new QuerableConvertcontext<TSource>(souceQuery, _objectConverters);
        }

        /// <summary>
        /// 转换可枚举类型
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <param name="sourceEnumerable">源类型集合</param>
        /// <returns></returns>
        public IEnumerableConvertContext<TSource> Convert<TSource>(IEnumerable<TSource> sourceEnumerable)
        {
            return new EnumerableConvertcontext<TSource>(sourceEnumerable, _objectConverters);
        }
    }

    /// <summary>
    /// 类型转换失败异常
    /// </summary>
    public class ObjectConverterException : Exception
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ObjectConverterException(Type source, Type target)
            : base($"不支持将 {source} 转换为 {target}")
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ObjectConverterException(Type source, Type target, Exception innerException)
            : base($"将 {source} 转换为 {target} 失败", innerException)
        {
        }
    }

    /// <summary>
    /// 类型转化上下文
    /// </summary>
    /// <typeparam name="TSource">源类型</typeparam>
    public interface IConvertContext<TSource>
    {
        /// <summary>
        /// 转换为目标类型
        /// </summary>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <returns>目标类型实例</returns>
        TTarget To<TTarget>();

        /// <summary>
        /// 将值赋予现有目标类型
        /// </summary>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <param name="targetObj">现有目标类型实例</param>
        /// <returns><paramref name="targetObj"/></returns>
        TTarget To<TTarget>(TTarget targetObj);
    }

    internal class ConvertContext<TSource> : IConvertContext<TSource>
    {
        private readonly TSource _sourceObj;
        private readonly Dictionary<Tuple<Type, Type>, IObjectConverterConfig> _objectConverters;

        public ConvertContext(TSource sourceObj, Dictionary<Tuple<Type, Type>, IObjectConverterConfig> _objectConverters)
        {
            _sourceObj = sourceObj;
            this._objectConverters = _objectConverters;
        }

        public TTarget To<TTarget>()
        {
            IObjectConverterConfig<TSource, TTarget> mapper = GetObjectResolverConfig<TTarget>();
            try
            {
                return mapper.Convert(_sourceObj);
            }
            catch (Exception e)
            {
                throw new ObjectConverterException(typeof(TSource), typeof(TTarget), e);
            }
        }

        public TTarget To<TTarget>(TTarget targetObj)
        {
            IObjectConverterConfig mapper = GetObjectResolverConfig<TTarget>();
            try
            {
                return (TTarget)mapper.Convert(_sourceObj, targetObj);
            }
            catch (Exception e)
            {
                throw new ObjectConverterException(typeof(TSource), typeof(TTarget), e);
            }
        }

        private IObjectConverterConfig<TSource, TTarget> GetObjectResolverConfig<TTarget>()
        {
            if (this._objectConverters.TryGetValue(Tuple.Create(typeof(TSource), typeof(TTarget)), out IObjectConverterConfig converter))
            {
                return (IObjectConverterConfig<TSource, TTarget>)converter;
            }
            else
            {
                throw new ObjectConverterException(typeof(TSource), typeof(TTarget));
            }
        }
    }

    /// <summary>
    /// 查询类型转化上下文
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public interface IQueryableConvertContext<TSource>
    {
        /// <summary>
        /// 转换为目标类型的查询
        /// </summary>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <returns></returns>
        IQueryable<TTarget> To<TTarget>();
    }

    internal class QuerableConvertcontext<TSource> : IQueryableConvertContext<TSource>
    {
        private readonly IQueryable<TSource> _sourceQuery;
        private readonly Dictionary<Tuple<Type, Type>, IObjectConverterConfig> _objectConverters;

        public QuerableConvertcontext(IQueryable<TSource> sourceQuery, Dictionary<Tuple<Type, Type>, IObjectConverterConfig> _objectConverters)
        {
            _sourceQuery = sourceQuery;
            this._objectConverters = _objectConverters;
        }

        /// <summary>
        /// 转换为目标类型的查询
        /// </summary>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <returns></returns>
        public IQueryable<TTarget> To<TTarget>()
        {
            IObjectConverterConfig mapper = GetObjectResolverConfig<TTarget>();
            try
            {
                return (IQueryable<TTarget>)mapper.Convert(_sourceQuery);
            }
            catch (Exception e)
            {
                throw new ObjectConverterException(typeof(TSource), typeof(TTarget), e);
            }
        }

        private IObjectConverterConfig<TSource, TTarget> GetObjectResolverConfig<TTarget>()
        {
            if (this._objectConverters.TryGetValue(Tuple.Create(typeof(TSource), typeof(TTarget)), out IObjectConverterConfig converter))
            {
                return (IObjectConverterConfig<TSource, TTarget>)converter;
            }
            else
            {
                throw new ObjectConverterException(typeof(TSource), typeof(TTarget));
            }
        }
    }

    /// <summary>
    /// 可枚举类型转化上下文
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public interface IEnumerableConvertContext<TSource>
    {
        /// <summary>
        /// 转换为目标类型的查询
        /// </summary>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <returns></returns>
        IEnumerable<TTarget> To<TTarget>();
    }

    internal class EnumerableConvertcontext<TSource> : IEnumerableConvertContext<TSource>
    {
        private readonly IEnumerable<TSource> _sourceEnumerable;
        private readonly Dictionary<Tuple<Type, Type>, IObjectConverterConfig> _objectConverters;

        public EnumerableConvertcontext(IEnumerable<TSource> sourceEnumerable, Dictionary<Tuple<Type, Type>, IObjectConverterConfig> _objectConverters)
        {
            _sourceEnumerable = sourceEnumerable;
            this._objectConverters = _objectConverters;
        }

        /// <summary>
        /// 转换为目标类型的查询
        /// </summary>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <returns></returns>
        public IEnumerable<TTarget> To<TTarget>()
        {
            IObjectConverterConfig<TSource, TTarget> mapper = GetObjectResolverConfig<TTarget>();
            try
            {
                return _sourceEnumerable.Select(item => mapper.Convert(item));
            }
            catch (Exception e)
            {
                throw new ObjectConverterException(typeof(TSource), typeof(TTarget), e);
            }
        }

        private IObjectConverterConfig<TSource, TTarget> GetObjectResolverConfig<TTarget>()
        {
            if (this._objectConverters.TryGetValue(Tuple.Create(typeof(TSource), typeof(TTarget)), out IObjectConverterConfig converter))
            {
                return (IObjectConverterConfig<TSource, TTarget>)converter;
            }
            else
            {
                throw new ObjectConverterException(typeof(TSource), typeof(TTarget));
            }
        }
    }
}