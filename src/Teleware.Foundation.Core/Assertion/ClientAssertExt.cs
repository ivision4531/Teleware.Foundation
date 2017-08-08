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
    public static class ClientAssertExt
    {
        /// <summary>
        /// 检查值是否为默认值，如果是，则抛出<see cref="ClientAssertingException"/>
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="exceptionMessage">错误信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象</param>
        public static T ShouldNotDefaultClient<T>(this T obj, string exceptionMessage, params object[] messageArgs)
        {
            return obj.ShouldNotBeClient(Objects.IsDefault<T>, exceptionMessage, messageArgs);
        }

        /// <summary>
        /// 检查值是否为true，如果不是，则抛出<see cref="ClientAssertingException"/>
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="exceptionMessage">错误信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象</param>
        public static bool ShouldBeTrueClient(this bool obj, string exceptionMessage, params object[] messageArgs)
        {
            return obj.ShouldBeClient(b => b == true, exceptionMessage, messageArgs);
        }

        /// <summary>
        /// 检查值是否为false，如果不是，则抛出<see cref="ClientAssertingException"/>
        /// </summary>
        /// <param name="obj">需要测试的对象</param>
        /// <param name="exceptionMessage">错误信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象</param>
        public static bool ShouldBeFalseClient(this bool obj, string exceptionMessage, params object[] messageArgs)
        {
            return obj.ShouldNotBeClient(b => b == true, exceptionMessage, messageArgs);
        }

        /// <summary>
        /// 检查值是否为空集合，如果是，则抛出<see cref="ClientAssertingException"/>
        /// </summary>
        /// <param name="obj">需要测试的集合</param>
        /// <param name="exceptionMessage">错误信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象</param>
        public static IEnumerable<T> ShouldAnyClient<T>(this IEnumerable<T> obj, string exceptionMessage, params object[] messageArgs)
        {
            return obj.ShouldBeClient(e => e.Any() == true, exceptionMessage, messageArgs);
        }

        /// <summary>
        /// 检查值是否为空集合，如果是，则抛出<see cref="ClientAssertingException"/>
        /// </summary>
        /// <param name="obj">需要测试的集合</param>
        /// <param name="exceptionMessage">错误信息</param>
        /// <param name="messageArgs">一个对象数组，其中包含零个或多个要设置格式的对象</param>
        public static IQueryable<T> ShouldAnyClient<T>(this IQueryable<T> obj, string exceptionMessage, params object[] messageArgs)
        {
            return obj.ShouldBeClient(e => e.Any() == true, exceptionMessage, messageArgs);
        }
    }
}