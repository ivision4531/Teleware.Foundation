using System;

namespace Teleware.Foundation.Caching
{
    /// <summary>
    /// 缓存源
    /// </summary>
    public interface ICacheProvider
    {
        ///// <summary>
        ///// 缓存源名称
        ///// </summary>
        //string ProviderName { get; }

        ///// <summary>
        ///// 确保已正确初始化
        ///// </summary>
        //void EnsureInited();

        /// <summary>
        /// 缓存中是否有特定的Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Exist(string key);

        /// <summary>
        /// 尝试获取缓存数据
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">Key</param>
        /// <param name="value">缓存数据</param>
        /// <returns>如果存在数据，则返回true。如果数据不存在，则返回false。</returns>
        bool TryGet<T>(string key, out T value);

        /// <summary>
        /// 尝试获取数据，如果数据不存在，则创建之
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">Key</param>
        /// <param name="valueFactory">缓存数据生成方法</param>
        /// <param name="policy">缓存策略</param>
        /// <returns></returns>
        T GetValueOrDefault<T>(string key, Func<T> valueFactory, CachePolicy? policy = null);

        /// <summary>
        /// 设置缓存项
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">Key</param>
        /// <param name="item">缓存数据</param>
        /// <param name="policy">缓存策略</param>
        void Set<T>(string key, T item, CachePolicy? policy = null);

        /// <summary>
        /// 删除缓存项
        /// </summary>
        /// <param name="cacheKey"></param>
        void RemoveKey(string cacheKey);
    }
}