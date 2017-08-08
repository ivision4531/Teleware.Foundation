using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleware.Foundation.Diagnostics;

namespace Teleware.Foundation.Diagnostics
{
    /// <summary>
    /// 表示一个日志记录器工厂
    /// </summary>
    public interface ILoggerFactory
    {
        /// <summary>
        /// 创建日志记录器
        /// </summary>
        /// <param name="loggerName">记录器名</param>
        /// <returns></returns>
        ILogger CreateLogger(string loggerName);
    }
}