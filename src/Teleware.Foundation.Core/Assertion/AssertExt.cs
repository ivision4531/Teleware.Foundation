using System;
using System.Collections.Generic;
using System.Linq;
using Teleware.Foundation.Assertion.Exceptions;
using Teleware.Foundation.Util;

namespace Teleware.Foundation.Assertion
{
    /// <summary>
    /// 断言检查核心扩展
    /// </summary>
    public static class AssertExt
    {
        /// <summary>
        /// 检查值是否为默认值，如果是，则抛出<see cref="AssertingException"/>
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="exceptionMessage">错误信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象</param>
        public static T ShouldNotDefault<T>(this T obj, string exceptionMessage, params object[] messageArgs)
        {
            return obj.ShouldNotBe(Objects.IsDefault<T>, exceptionMessage, messageArgs);
        }

        /// <summary>
        /// 检查值是否为默认值，如果是，则抛出<paramref name="exceptionFactory"/>创建的异常
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="exceptionFactory">异常工厂方法</param>
        public static T ShouldNotDefault<T, TException>(this T obj, Func<TException> exceptionFactory)
            where TException : Exception
        {
            return obj.ShouldNotBe(Objects.IsDefault<T>, exceptionFactory);
        }

        /// <summary>
        /// 检查值是否为默认值，如果是，则抛出<paramref name="exceptionFactory"/>创建的异常
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="exceptionFactory">异常工厂方法</param>
        /// <param name="exceptionMessage">错误信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象</param>
        public static T ShouldNotDefault<T, TException>(this T obj, Func<string, TException> exceptionFactory, string exceptionMessage, params object[] messageArgs)
            where TException : Exception
        {
            return obj.ShouldNotBe(Objects.IsDefault<T>, exceptionFactory, exceptionMessage, messageArgs);
        }

        /// <summary>
        /// 检查值是否为true，如果不是，则抛出<see cref="AssertingException"/>
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="exceptionMessage">错误信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象</param>
        public static bool ShouldBeTrue(this bool obj, string exceptionMessage, params object[] messageArgs)
        {
            return obj.ShouldBe(b => b == true, exceptionMessage, messageArgs);
        }

        /// <summary>
        /// 检查值是否为true，如果不是，则抛出<paramref name="exceptionFactory"/>创建的异常
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="exceptionFactory">异常工厂方法</param>
        /// <param name="exceptionMessage">错误信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象</param>
        public static bool ShouldBeTrue<TException>(this bool obj, Func<string, TException> exceptionFactory, string exceptionMessage, params object[] messageArgs)
            where TException : Exception
        {
            return obj.ShouldBe(b => b == true, exceptionFactory, exceptionMessage, messageArgs);
        }

        /// <summary>
        /// 检查值是否为true，如果不是，则抛出<paramref name="exceptionFactory"/>创建的异常
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="exceptionFactory">异常工厂方法</param>
        public static bool ShouldBeTrue<TException>(this bool obj, Func<TException> exceptionFactory)
            where TException : Exception
        {
            return obj.ShouldBe(b => b == true, exceptionFactory);
        }

        /// <summary>
        /// 检查值是否为false，如果不是，则抛出<see cref="AssertingException"/>
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="exceptionMessage">错误信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象</param>
        public static bool ShouldBeFalse(this bool obj, string exceptionMessage, params object[] messageArgs)
        {
            return obj.ShouldNotBe(b => b == true, exceptionMessage, messageArgs);
        }

        /// <summary>
        /// 检查值是否为false，如果不是，则抛出<paramref name="exceptionFactory"/>创建的异常
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="exceptionFactory">异常工厂方法</param>
        /// <param name="exceptionMessage">错误信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象</param>
        public static bool ShouldBeFalse<TException>(this bool obj, Func<string, TException> exceptionFactory, string exceptionMessage, params object[] messageArgs)
            where TException : Exception
        {
            return obj.ShouldNotBe(b => b == true, exceptionFactory, exceptionMessage, messageArgs);
        }

        /// <summary>
        /// 检查值是否为false，如果不是，则抛出<paramref name="exceptionFactory"/>创建的异常
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="exceptionFactory">异常工厂方法</param>
        public static bool ShouldBeFalse<TException>(this bool obj, Func<TException> exceptionFactory)
            where TException : Exception
        {
            return obj.ShouldNotBe(b => b == true, exceptionFactory);
        }

        /// <summary>
        /// 检查值是否为空集合，如果是，则抛出<see cref="AssertingException"/>
        /// </summary>
        /// <param name="obj">需要测试的集合</param>
        /// <param name="exceptionMessage">错误信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象</param>
        public static IEnumerable<T> ShouldAny<T>(this IEnumerable<T> obj, string exceptionMessage, params object[] messageArgs)
        {
            return obj.ShouldBe(e => e.Any() == true, exceptionMessage, messageArgs);
        }

        /// <summary>
        /// 检查值是否为空集合，如果是，则抛出<paramref name="exceptionFactory"/>创建的异常
        /// </summary>
        /// <param name="obj">需要测试的集合</param>
        /// <param name="exceptionFactory">异常工厂方法</param>
        public static IEnumerable<T> ShouldAny<T, TException>(this IEnumerable<T> obj, Func<TException> exceptionFactory)
            where TException : Exception
        {
            return obj.ShouldBe(e => e.Any() == true, exceptionFactory);
        }

        /// <summary>
        /// 检查值是否为空集合，如果是，则抛出<paramref name="exceptionFactory"/>创建的异常
        /// </summary>
        /// <param name="obj">需要测试的集合</param>
        /// <param name="exceptionFactory">异常工厂方法</param>
        /// <param name="exceptionMessage">异常信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象</param>
        public static IEnumerable<T> ShouldAny<T, TException>(this IEnumerable<T> obj, Func<string, TException> exceptionFactory, string exceptionMessage, params object[] messageArgs)
            where TException : Exception
        {
            return obj.ShouldBe(e => e.Any() == true, exceptionFactory, exceptionMessage, messageArgs);
        }

        /// <summary>
        /// 检查值是否为空集合，如果是，则抛出<see cref="AssertingException"/>
        /// </summary>
        /// <param name="obj">需要测试的集合</param>
        /// <param name="exceptionMessage">错误信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象</param>
        public static IQueryable<T> ShouldAny<T>(this IQueryable<T> obj, string exceptionMessage, params object[] messageArgs)
        {
            return obj.ShouldBe(e => e.Any() == true, exceptionMessage, messageArgs);
        }

        /// <summary>
        /// 检查值是否为空集合，如果是，则抛出<paramref name="exceptionFactory"/>创建的异常
        /// </summary>
        /// <param name="obj">需要测试的集合</param>
        /// <param name="exceptionFactory">异常工厂方法</param>
        public static IQueryable<T> ShouldAny<T, TException>(this IQueryable<T> obj, Func<TException> exceptionFactory)
            where TException : Exception
        {
            return obj.ShouldBe(e => e.Any() == true, exceptionFactory);
        }

        /// <summary>
        /// 检查值是否为空集合，如果是，则抛出<paramref name="exceptionFactory"/>创建的异常
        /// </summary>
        /// <param name="obj">需要测试的集合</param>
        /// <param name="exceptionFactory">异常工厂方法</param>
        /// <param name="exceptionMessage">异常信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象</param>
        public static IQueryable<T> ShouldAny<T, TException>(this IQueryable<T> obj, Func<string, TException> exceptionFactory, string exceptionMessage, params object[] messageArgs)
            where TException : Exception
        {
            return obj.ShouldBe(e => e.Any() == true, exceptionFactory, exceptionMessage, messageArgs);
        }
    }
}