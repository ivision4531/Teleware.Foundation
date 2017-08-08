using Microsoft.Extensions.Caching.Memory;
using System;

namespace Teleware.Foundation.Caching.CacheProviders
{
    /// <summary>
    /// 基于内存的缓存源
    /// </summary>
    public class MemoryCacheProvider : ICacheProvider
    {
        private IMemoryCache _cache;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache"></param>
        public MemoryCacheProvider(IMemoryCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// 缓存中是否有特定的Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exist(string key)
        {
            return _cache.TryGetValue(key, out object item);
        }

        /// <summary>
        /// 尝试获取缓存数据
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">Key</param>
        /// <param name="value">缓存数据</param>
        /// <returns>如果存在数据，则返回true。如果数据不存在，则返回false。</returns>
        public bool TryGet<T>(string key, out T value)
        {
            var exists = _cache.TryGetValue(key, out object item);
            if (exists)
            {
                value = ((MemoryCacheItem<T>)item).Value;
                return true;
            }
            else
            {
                value = default(T);
                return false;
            }
        }

        /// <summary>
        /// 尝试获取数据，如果数据不存在，则创建之
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">Key</param>
        /// <param name="valueFactory">缓存数据生成方法</param>
        /// <param name="policy">缓存策略</param>
        /// <returns></returns>
        public T GetValueOrDefault<T>(string key, Func<T> valueFactory, CachePolicy? policy = null)
        {
            var cachedItem = _cache.Get(key) as MemoryCacheItem<T>;
            if (cachedItem == null)
            {
                lock (_cache)
                {
                    cachedItem = _cache.Get(key) as MemoryCacheItem<T>;
                    if (cachedItem == null)
                    {
                        var item = valueFactory();
                        Set<T>(key, item, policy);
                        return item;
                    }
                }
            }
            return cachedItem.Value;
        }

        /// <summary>
        /// 设置缓存项
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">Key</param>
        /// <param name="item">缓存数据</param>
        /// <param name="policy">缓存策略</param>
        public void Set<T>(string key, T item, CachePolicy? policy = null)
        {
            var cacheItem = new MemoryCacheItem<T>
            {
                Value = item
            };
            MemoryCacheEntryOptions opt = new MemoryCacheEntryOptions();

            var entry = _cache.CreateEntry(key);
            entry.Value = item;
            if (policy != null)
            {
                opt.AbsoluteExpirationRelativeToNow = policy.Value.AbsoluteExpiration;
                opt.SlidingExpiration = policy.Value.SlidingExpiration;
            }

            _cache.Set(key, cacheItem, opt);
        }

        ///// <inheritdoc/>
        //public string ProviderName
        //{
        //    get { return "Memory"; }
        //}

        /// <summary>
        /// 删除缓存项
        /// </summary>
        /// <param name="cacheKey"></param>
        public void RemoveKey(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }

        ///// <inheritdoc/>
        //public void EnsureInited()
        //{
        //}
        private class MemoryCacheItem<T>
        {
            public T Value { get; set; }
        }
    }
}