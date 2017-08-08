using System;

namespace Teleware.Foundation.Data.Exceptions
{
    /// <summary>
    /// 开放式并发冲突异常
    /// </summary>
    public class OptimisticConcurrencyException : Exception
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="msg">错误消息</param>
        /// <param name="innerException">内部异常</param>
        public OptimisticConcurrencyException(string msg, Exception innerException) : base(msg, innerException)
        {
        }
    }
}