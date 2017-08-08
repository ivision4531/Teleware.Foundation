using System;

namespace Teleware.Foundation.Caching
{
    /// <summary>
    /// 缓存策略
    /// </summary>
    public struct CachePolicy
    {
        /// <summary>
        /// 缓存项存活时间
        /// </summary>
        public Nullable<TimeSpan> AbsoluteExpiration
        {
            get;
            set;
        }

        /// <summary>
        /// 缓存滑动过期时间
        /// </summary>
        public Nullable<TimeSpan> SlidingExpiration
        {
            get; set;
        }
    }
}