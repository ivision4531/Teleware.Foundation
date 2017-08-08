using System;
using Teleware.Foundation.Assertion.Exceptions;


namespace Teleware.Foundation.Assertion
{
    /// <summary>
    /// 断言检查核心方法
    /// </summary>
    public static class AssertCore
    {
        /// <summary>
        /// 测试值是否符合条件，如果不符合，则抛出<see cref="AssertingException"/>
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="tester">测试方法，如果返回false则测试不通过</param>
        /// <param name="exceptionMessage">异常信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象。</param>
        /// <returns>返回原值</returns>
        public static T ShouldBe<T>(
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
                var exception = new AssertingException(exceptionMessage);
                throw exception;
            }
            return obj;
        }

        /// <summary>
        /// 测试值是否符合条件，如果不符合，则抛出<paramref name="exceptionFactory"/>创建的异常
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="tester">测试方法，如果返回false则测试不通过</param>
        /// <param name="exceptionFactory">异常工厂方法</param>
        /// <param name="exceptionMessage">异常信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象。</param>
        /// <returns>返回原值</returns>
        public static T ShouldBe<T, TException>(
            this T obj,
            Func<T, bool> tester,
            Func<string, TException> exceptionFactory,
            string exceptionMessage,
            params object[] messageArgs)
            where TException : Exception
        {
            if (!tester(obj))
            {
                if (messageArgs.Length > 0)
                {
                    exceptionMessage = string.Format(exceptionMessage, messageArgs);
                }
                var exception = exceptionFactory(exceptionMessage);
                throw exception;
            }
            return obj;
        }

        /// <summary>
        /// 测试值是否符合条件，如果不符合，则抛出<paramref name="exceptionFactory"/>创建的异常
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="tester">测试方法，如果返回false则测试不通过</param>
        /// <param name="exceptionFactory">异常工厂方法</param>
        /// <returns>返回原值</returns>
        public static T ShouldBe<T, TException>(
            this T obj,
            Func<T, bool> tester,
            Func<TException> exceptionFactory)
            where TException : Exception
        {
            if (!tester(obj))
            {
                var exception = exceptionFactory();
                throw exception;
            }
            return obj;
        }

        /// <summary>
        /// 测试值是不否符合条件，如果符合，则抛出<see cref="AssertingException"/>
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="tester">测试方法，如果返回true则测试不通过</param>
        /// <param name="exceptionMessage">异常信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象。</param>
        /// <returns>返回原值</returns>
        public static T ShouldNotBe<T>(
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
                var exception = new AssertingException(exceptionMessage);
                throw exception;
            }
            return obj;
        }

        /// <summary>
        /// 测试值是否不符合条件，如果符合，则抛出<paramref name="exceptionFactory"/>创建的异常
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="tester">测试方法，如果返回true则测试不通过</param>
        /// <param name="exceptionFactory">异常工厂方法</param>
        /// <param name="exceptionMessage">异常信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象。</param>
        /// <returns>返回原值</returns>
        public static T ShouldNotBe<T, TException>(
            this T obj,
            Func<T, bool> tester,
            Func<string, TException> exceptionFactory,
            string exceptionMessage,
            params object[] messageArgs)
            where TException : Exception
        {
            if (tester(obj))
            {
                if (messageArgs.Length > 0)
                {
                    exceptionMessage = string.Format(exceptionMessage, messageArgs);
                }
                var exception = exceptionFactory(exceptionMessage);
                throw exception;
            }
            return obj;
        }

        /// <summary>
        /// 测试值是否不符合条件，如果符合，则抛出<paramref name="exceptionFactory"/>创建的异常
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="tester">测试方法，如果返回true则测试不通过</param>
        /// <param name="exceptionFactory">异常工厂方法</param>
        /// <returns>返回原值</returns>
        public static T ShouldNotBe<T, TException>(
            this T obj,
            Func<T, bool> tester,
            Func<TException> exceptionFactory)
            where TException : Exception
        {
            if (tester(obj))
            {
                var exception = exceptionFactory();
                throw exception;
            }
            return obj;
        }
    }
}