using System;
using System.Collections.Generic;

namespace Teleware.Foundation.Collections.Generic
{
    /// <summary>
    /// 通用比较器
    /// </summary>
    /// <typeparam name="T">要比较的元素的类型</typeparam>
    /// <typeparam name="TKey">要用于比较的元素键的类型</typeparam>
    public class GeneralEqualityComparer<T, TKey> : IEqualityComparer<T>
    {
        private readonly Func<TKey, TKey, bool> _comparer;
        private readonly Func<T, int> _hashCodeGetter;
        private readonly Func<T, TKey> _keySelector;

        /// <summary>
        /// 构造函数, 采用元素键直接进行比较以及获取哈希值操作
        /// </summary>
        /// <param name="keySelector">元素键选择器</param>
        public GeneralEqualityComparer(Func<T, TKey> keySelector)
            : this(
                  keySelector,
                  ((a, b) => a.Equals(b)),
                  (item) => keySelector(item).GetHashCode())
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="keySelector">元素键选择器</param>
        /// <param name="comparer">元素键比较器</param>
        /// <param name="hashCodeGetter">元素哈希值获取器</param>
        public GeneralEqualityComparer(
            Func<T, TKey> keySelector,
            Func<TKey, TKey, bool> comparer,
            Func<T, int> hashCodeGetter)
        {
            _keySelector = keySelector;
            _comparer = comparer;
            _hashCodeGetter = hashCodeGetter;
        }

        /// <summary>
        /// 确定指定的对象是否相等
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(T x, T y)
        {
            var leftKey = _keySelector(x);
            var rightKey = _keySelector(y);
            return _comparer(leftKey, rightKey);
        }

        /// <summary>
        /// 返回指定对象的哈希代码
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(T obj)
        {
            return _hashCodeGetter(obj);
        }
    }
}