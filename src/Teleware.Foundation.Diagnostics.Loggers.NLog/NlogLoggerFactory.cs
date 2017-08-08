using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleware.Foundation.Diagnostics.Loggers.NLog
{
    /// <summary>
    /// 基于NLog的日志记录器工厂
    /// </summary>
    public class NLogLoggerFactory : ILoggerFactory
    {
        private static ConcurrentDictionary<string, ILogger> _cache = new ConcurrentDictionary<string, ILogger>();
        private readonly NLogLoggerManager _innerLogManager;

        internal NLogLoggerFactory(NLogLoggerManager innerLogManager)
        {
            _innerLogManager = innerLogManager;
        }

        /// <summary>
        /// 创建日志记录器
        /// </summary>
        /// <param name="loggerName">日志分组名</param>
        /// <returns></returns>
        public ILogger CreateLogger(string loggerName)
        {
            return _cache.GetOrAdd(loggerName, (name) => new NLogLoggerImpl(name, _innerLogManager));
        }
    }
}