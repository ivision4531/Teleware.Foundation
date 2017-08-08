using System;
using Teleware.Foundation.Assertion.Exceptions;

namespace Teleware.Foundation.Assertion
{
    /// <summary>
    /// 断言检查核心方法
    /// </summary>
    public static class ClientAssertCore
    {
        /// <summary>
        /// 测试值是否符合条件，如果不符合，则抛出<see cref="ClientAssertingException"/>
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="tester">测试方法，如果返回false则测试不通过</param>
        /// <param name="exceptionMessage">异常信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象。</param>
        /// <returns>返回原值</returns>
        public static T ShouldBeClient<T>(
            this T obj,
            Func<T, bool> tester,
            string exceptionMessage,
            params object[] messageArgs)
        {
            if (!tester(obj))
            {
                if (messageArgs.Length > 0)
                {
                    exceptionMessage = string.Format(exceptionMessage, messageArgs);
                }
                var exception = new ClientAssertingException(exceptionMessage);
                throw exception;
            }
            return obj;
        }

        /// <summary>
        /// 测试值是不否符合条件，如果符合，则抛出<see cref="ClientAssertingException"/>
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="tester">测试方法，如果返回true则测试不通过</param>
        /// <param name="exceptionMessage">异常信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象。</param>
        /// <returns>返回原值</returns>
        public static T ShouldNotBeClient<T>(
            this T obj,
            Func<T, bool> tester,
            string exceptionMessage,
            params object[] messageArgs)
        {
            if (tester(obj))
            {
                if (messageArgs.Length > 0)
                {
                    exceptionMessage = string.Format(exceptionMessage, messageArgs);
                }
                var exception = new ClientAssertingException(exceptionMessage);
                throw exception;
            }
            return obj;
        }
    }
}