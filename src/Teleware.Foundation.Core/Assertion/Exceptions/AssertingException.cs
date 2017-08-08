using System;
using Teleware.Foundation.Exceptions;

namespace Teleware.Foundation.Assertion.Exceptions
{
    /// <summary>
    /// 业务断言异常
    /// </summary>
    public class AssertingException : BusinessException
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AssertingException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public AssertingException(string message, Exception innerException)
           : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// 客户端业务断言异常
    /// </summary>
    public class ClientAssertingException : ClientNoticeableException
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ClientAssertingException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ClientAssertingException(string message, Exception innerException)
           : base(message, innerException)
        {
        }
    }
}