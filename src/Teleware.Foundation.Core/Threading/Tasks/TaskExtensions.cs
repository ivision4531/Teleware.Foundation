using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleware.Foundation.Core.Threading.Tasks
{
    /// <summary>
    /// 异步任务相关扩展
    /// </summary>
    [Obsolete("搞错表空间了")]
    public static class TaskExtensions
    {
        /// <summary>
        /// 将一系列的<see cref="Task{T}"/>转换为单个异步调用
        /// </summary>
        /// <typeparam name="T">异步执行结果</typeparam>
        public static async Task<T[]> ToTask<T>(this IEnumerable<Task<T>> tasks)
        {
            var taskArray = tasks.ToArray();
            var results = new T[taskArray.Length];
            for (int i = 0; i < taskArray.Length; i++)
            {
                results[i] = await taskArray[i];
            }
            return results;
        }
    }
}

namespace Teleware.Foundation.Threading.Tasks
{
    /// <summary>
    /// 异步任务相关扩展
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// 将一系列的<see cref="Task{T}"/>转换为单个异步调用
        /// </summary>
        /// <typeparam name="T">异步执行结果</typeparam>
        public static async Task<T[]> ToTask<T>(this IEnumerable<Task<T>> tasks)
        {
            var taskArray = tasks.ToArray();
            var results = new T[taskArray.Length];
            for (int i = 0; i < taskArray.Length; i++)
            {
                results[i] = await taskArray[i];
            }
            return results;
        }
    }
}