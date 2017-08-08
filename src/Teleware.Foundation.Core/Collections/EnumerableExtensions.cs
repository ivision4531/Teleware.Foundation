using System;
using System.Collections;
using System.Collections.Generic;

namespace Teleware.Foundation.Collections
{
    /// <summary>
    /// IEnumerable 扩展
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// 对每个元素分别执行操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action">操作</param>
        public static void Each<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            var enumerator = source.GetEnumerator();
            int i = 0;
            while (enumerator.MoveNext())
            {
                i += 1;
                action(enumerator.Current, i);
            }
        }

        /// <summary>
        /// 对每个元素分别执行操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action">操作</param>
        public static void Each<T>(this IEnumerable<T> source, Action<T> action)
        {
            var enumerator = source.GetEnumerator();

            while (enumerator.MoveNext())
            {
                action(enumerator.Current);
            }
        }


        /// <summary>
        /// 将列表分隔为多个分区
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="size">分区大小</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> PartitionBy<T>(this IList<T> source, int size)
        {
            return new Partition<T>(source, size);
        }
    }

    /// <summary>
    /// 分区集合
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Partition<T> : IEnumerable<IEnumerable<T>>
    {
        private readonly IList<T> _source;
        private readonly int _size;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="source"></param>
        /// <param name="size"></param>
        public Partition(IList<T> source, int size)
        {
            _source = source;
            _size = size;
        }

        /// <summary>
        /// 获取迭代器
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IEnumerable<T>> GetEnumerator()
        {
            var current = 0;
            while (current < _source.Count)
            {
                yield return new PartitionSection<T>(_source, current, _size);
                current += _size;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    /// <summary>
    /// 表示一个分区
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal struct PartitionSection<T> : IEnumerable<T>
    {
        private readonly IList<T> _source;
        private readonly int _from;
        private readonly int _size;

        /// <summary>
        /// 构造实例
        /// </summary>
        /// <param name="source"></param>
        /// <param name="from"></param>
        /// <param name="size"></param>
        public PartitionSection(IList<T> source, int from, int size)
        {
            if (from >= source.Count)
            {
                throw new ArgumentOutOfRangeException("from", "from 不能超过数组长度");
            }
            _source = source;
            _from = from;
            _size = size;
        }

        /// <summary>
        /// 获取迭代器
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            var count = 0;
            var current = count + _from;
            var end = _size + _from;
            while (current < _source.Count && current < end)
            {
                yield return _source[current];
                current++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}