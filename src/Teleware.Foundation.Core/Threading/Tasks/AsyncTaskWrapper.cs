using System;
using System.Threading.Tasks;

namespace Teleware.Foundation.Threading.Tasks
{
    /// <summary>
    /// 将回调式的异步方法转为<see cref="Task"/>
    /// </summary>
    public static class AsyncTaskWrapperBuilder
    {
        #region Action WrapAndRun

        /// <summary>
        /// 转换为<see cref="Task"/>并直接运行
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <returns></returns>
        public static Task WrapAndRunAction<TSource>(TSource source, Action<TSource, Action, Action<Exception>> invokeAction)
        {
            return new AsyncWrapperA<TSource>(source, invokeAction).Invoke();
        }

        /// <summary>
        /// 转换为<see cref="Task"/>并直接运行
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="source"></param>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public static Task WrapAndRunAction<TSource, T1>(TSource source, Action<TSource, T1, Action, Action<Exception>> invokeAction, T1 arg1)
        {
            return new AsyncWrapperA<TSource, T1>(source, invokeAction).Invoke(arg1);
        }

        /// <summary>
        /// 转换为<see cref="Task"/>并直接运行
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="source"></param>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public static Task WrapAndRunAction<TSource, T1, T2>(TSource source, Action<TSource, T1, T2, Action, Action<Exception>> invokeAction, T1 arg1, T2 arg2)
        {
            return new AsyncWrapperA<TSource, T1, T2>(source, invokeAction).Invoke(arg1, arg2);
        }

        /// <summary>
        /// 转换为<see cref="Task"/>并直接运行
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="source"></param>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        public static Task WrapAndRunAction<TSource, T1, T2, T3>(TSource source, Action<TSource, T1, T2, T3, Action, Action<Exception>> invokeAction, T1 arg1, T2 arg2, T3 arg3)
        {
            return new AsyncWrapperA<TSource, T1, T2, T3>(source, invokeAction).Invoke(arg1, arg2, arg3);
        }

        /// <summary>
        /// 转换为<see cref="Task"/>并直接运行
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="source"></param>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <returns></returns>
        public static Task WrapAndRunAction<TSource, T1, T2, T3, T4>(TSource source, Action<TSource, T1, T2, T3, T4, Action, Action<Exception>> invokeAction, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return new AsyncWrapperA<TSource, T1, T2, T3, T4>(source, invokeAction).Invoke(arg1, arg2, arg3, arg4);
        }

        /// <summary>
        /// 转换为<see cref="Task"/>并直接运行
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="source"></param>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <returns></returns>
        public static Task WrapAndRunAction<TSource, T1, T2, T3, T4, T5>(TSource source, Action<TSource, T1, T2, T3, T4, T5, Action, Action<Exception>> invokeAction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return new AsyncWrapperA<TSource, T1, T2, T3, T4, T5>(source, invokeAction).Invoke(arg1, arg2, arg3, arg4, arg5);
        }

        #endregion Action WrapAndRun

        #region Action Wrap

        /// <summary>
        /// 转换为<see cref="Task"/>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <returns></returns>
        public static Func<TSource, Task> WrapAction<TSource>(Action<TSource, Action, Action<Exception>> invokeAction)
        {
            return (source) => new AsyncWrapperA<TSource>(source, invokeAction).Invoke();
        }

        /// <summary>
        /// 转换为<see cref="Task"/>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <returns></returns>
        public static Func<TSource, T1, Task> WrapAction<TSource, T1>(Action<TSource, T1, Action, Action<Exception>> invokeAction)
        {
            return (source, arg1) => new AsyncWrapperA<TSource, T1>(source, invokeAction).Invoke(arg1);
        }

        /// <summary>
        /// 转换为<see cref="Task"/>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <returns></returns>
        public static Func<TSource, T1, T2, Task> WrapAction<TSource, T1, T2>(Action<TSource, T1, T2, Action, Action<Exception>> invokeAction)
        {
            return (source, arg1, arg2) => new AsyncWrapperA<TSource, T1, T2>(source, invokeAction).Invoke(arg1, arg2);
        }

        /// <summary>
        /// 转换为<see cref="Task"/>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <returns></returns>
        public static Func<TSource, T1, T2, T3, Task> WrapAction<TSource, T1, T2, T3>(Action<TSource, T1, T2, T3, Action, Action<Exception>> invokeAction)
        {
            return (source, arg1, arg2, arg3) => new AsyncWrapperA<TSource, T1, T2, T3>(source, invokeAction).Invoke(arg1, arg2, arg3);
        }

        /// <summary>
        /// 转换为<see cref="Task"/>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <returns></returns>
        public static Func<TSource, T1, T2, T3, T4, Task> WrapAction<TSource, T1, T2, T3, T4>(Action<TSource, T1, T2, T3, T4, Action, Action<Exception>> invokeAction)
        {
            return (source, arg1, arg2, arg3, arg4) => new AsyncWrapperA<TSource, T1, T2, T3, T4>(source, invokeAction).Invoke(arg1, arg2, arg3, arg4);
        }

        /// <summary>
        /// 转换为<see cref="Task"/>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <returns></returns>
        public static Func<TSource, T1, T2, T3, T4, T5, Task> WrapAction<TSource, T1, T2, T3, T4, T5>(Action<TSource, T1, T2, T3, T4, T5, Action, Action<Exception>> invokeAction)
        {
            return (source, arg1, arg2, arg3, arg4, arg5) => new AsyncWrapperA<TSource, T1, T2, T3, T4, T5>(source, invokeAction).Invoke(arg1, arg2, arg3, arg4, arg5);
        }

        #endregion Action Wrap

        #region Func WrapAndRun

        /// <summary>
        /// 转换为<see cref="Task{TReturn}"/>并直接运行
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="source"></param>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <returns></returns>
        public static Task<TReturn> WrapAndRunFunc<TSource, TReturn>(TSource source, Action<TSource, Action<TReturn>, Action<Exception>> invokeAction)
        {
            return new AsyncWrapperF<TSource, TReturn>(source, invokeAction).Invoke();
        }

        /// <summary>
        /// 转换为<see cref="Task{TReturn}"/>并直接运行
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="source"></param>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public static Task<TReturn> WrapAndRunFunc<TSource, T1, TReturn>(TSource source, Action<TSource, T1, Action<TReturn>, Action<Exception>> invokeAction, T1 arg1)
        {
            return new AsyncWrapperF<TSource, T1, TReturn>(source, invokeAction).Invoke(arg1);
        }

        /// <summary>
        /// 转换为<see cref="Task{TReturn}"/>并直接运行
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="source"></param>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public static Task<TReturn> WrapAndRunFunc<TSource, T1, T2, TReturn>(TSource source, Action<TSource, T1, T2, Action<TReturn>, Action<Exception>> invokeAction, T1 arg1, T2 arg2)
        {
            return new AsyncWrapperF<TSource, T1, T2, TReturn>(source, invokeAction).Invoke(arg1, arg2);
        }

        /// <summary>
        /// 转换为<see cref="Task{TReturn}"/>并直接运行
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="source"></param>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        public static Task<TReturn> WrapAndRunFunc<TSource, T1, T2, T3, TReturn>(TSource source, Action<TSource, T1, T2, T3, Action<TReturn>, Action<Exception>> invokeAction, T1 arg1, T2 arg2, T3 arg3)
        {
            return new AsyncWrapperF<TSource, T1, T2, T3, TReturn>(source, invokeAction).Invoke(arg1, arg2, arg3);
        }

        /// <summary>
        /// 转换为<see cref="Task{TReturn}"/>并直接运行
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="source"></param>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <returns></returns>
        public static Task<TReturn> WrapAndRunFunc<TSource, T1, T2, T3, T4, TReturn>(TSource source, Action<TSource, T1, T2, T3, T4, Action<TReturn>, Action<Exception>> invokeAction, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return new AsyncWrapperF<TSource, T1, T2, T3, T4, TReturn>(source, invokeAction).Invoke(arg1, arg2, arg3, arg4);
        }

        /// <summary>
        /// 转换为<see cref="Task{TReturn}"/>并直接运行
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="source"></param>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <returns></returns>
        public static Task<TReturn> WrapAndRunFunc<TSource, T1, T2, T3, T4, T5, TReturn>(TSource source, Action<TSource, T1, T2, T3, T4, T5, Action<TReturn>, Action<Exception>> invokeAction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return new AsyncWrapperF<TSource, T1, T2, T3, T4, T5, TReturn>(source, invokeAction).Invoke(arg1, arg2, arg3, arg4, arg5);
        }

        #endregion Func WrapAndRun

        #region Func Wrap

        /// <summary>
        /// 转换为<see cref="Task{TReturn}"/>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <returns></returns>
        public static Func<TSource, Task<TReturn>> WrapFunc<TSource, TReturn>(Action<TSource, Action<TReturn>, Action<Exception>> invokeAction)
        {
            return (source) => new AsyncWrapperF<TSource, TReturn>(source, invokeAction).Invoke();
        }

        /// <summary>
        /// 转换为<see cref="Task{TReturn}"/>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <returns></returns>
        public static Func<TSource, T1, Task<TReturn>> WrapFunc<TSource, T1, TReturn>(Action<TSource, T1, Action<TReturn>, Action<Exception>> invokeAction)
        {
            return (source, arg1) => new AsyncWrapperF<TSource, T1, TReturn>(source, invokeAction).Invoke(arg1);
        }

        /// <summary>
        /// 转换为<see cref="Task{TReturn}"/>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <returns></returns>
        public static Func<TSource, T1, T2, Task<TReturn>> WrapFunc<TSource, T1, T2, TReturn>(Action<TSource, T1, T2, Action<TReturn>, Action<Exception>> invokeAction)
        {
            return (source, arg1, arg2) => new AsyncWrapperF<TSource, T1, T2, TReturn>(source, invokeAction).Invoke(arg1, arg2);
        }

        /// <summary>
        /// 转换为<see cref="Task{TReturn}"/>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <returns></returns>
        public static Func<TSource, T1, T2, T3, Task<TReturn>> WrapFunc<TSource, T1, T2, T3, TReturn>(Action<TSource, T1, T2, T3, Action<TReturn>, Action<Exception>> invokeAction)
        {
            return (source, arg1, arg2, arg3) => new AsyncWrapperF<TSource, T1, T2, T3, TReturn>(source, invokeAction).Invoke(arg1, arg2, arg3);
        }

        /// <summary>
        /// 转换为<see cref="Task{TReturn}"/>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <returns></returns>
        public static Func<TSource, T1, T2, T3, T4, Task<TReturn>> WrapFunc<TSource, T1, T2, T3, T4, TReturn>(Action<TSource, T1, T2, T3, T4, Action<TReturn>, Action<Exception>> invokeAction)
        {
            return (source, arg1, arg2, arg3, arg4) => new AsyncWrapperF<TSource, T1, T2, T3, T4, TReturn>(source, invokeAction).Invoke(arg1, arg2, arg3, arg4);
        }

        /// <summary>
        /// 转换为<see cref="Task{TReturn}"/>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="invokeAction">执行方法，包括成功回调与失败回调</param>
        /// <returns></returns>
        public static Func<TSource, T1, T2, T3, T4, T5, Task<TReturn>> WrapFunc<TSource, T1, T2, T3, T4, T5, TReturn>(Action<TSource, T1, T2, T3, T4, T5, Action<TReturn>, Action<Exception>> invokeAction)
        {
            return (source, arg1, arg2, arg3, arg4, arg5) => new AsyncWrapperF<TSource, T1, T2, T3, T4, T5, TReturn>(source, invokeAction).Invoke(arg1, arg2, arg3, arg4, arg5);
        }

        #endregion Func Wrap

        #region Action wrappers

        internal class AsyncWrapperA<TSource>
        {
            private readonly TSource _source;
            private readonly Action<TSource, Action, Action<Exception>> _invokeAction;

            public AsyncWrapperA(TSource source, Action<TSource, Action, Action<Exception>> invokeAction)
            {
                _source = source;
                _invokeAction = invokeAction;
            }

            public Task Invoke()
            {
                TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
                _invokeAction(_source, () => tcs.SetResult(1), (e) => tcs.SetException(e));
                return tcs.Task;
            }
        }

        internal class AsyncWrapperA<TSource, T1>
        {
            private readonly TSource _source;
            private readonly Action<TSource, T1, Action, Action<Exception>> _invokeAction;

            public AsyncWrapperA(TSource source, Action<TSource, T1, Action, Action<Exception>> invokeAction)
            {
                _source = source;
                _invokeAction = invokeAction;
            }

            public Task Invoke(T1 t1)
            {
                TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
                _invokeAction(_source, t1, () => tcs.SetResult(1), (e) => tcs.SetException(e));
                return tcs.Task;
            }
        }

        internal class AsyncWrapperA<TSource, T1, T2>
        {
            private readonly TSource _source;
            private readonly Action<TSource, T1, T2, Action, Action<Exception>> _invokeAction;

            public AsyncWrapperA(TSource source, Action<TSource, T1, T2, Action, Action<Exception>> invokeAction)
            {
                _source = source;
                _invokeAction = invokeAction;
            }

            public Task Invoke(T1 arg1, T2 arg2)
            {
                TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
                _invokeAction(_source, arg1, arg2, () => tcs.SetResult(1), (e) => tcs.SetException(e));
                return tcs.Task;
            }
        }

        internal class AsyncWrapperA<TSource, T1, T2, T3>
        {
            private readonly TSource _source;
            private readonly Action<TSource, T1, T2, T3, Action, Action<Exception>> _invokeAction;

            public AsyncWrapperA(TSource source, Action<TSource, T1, T2, T3, Action, Action<Exception>> invokeAction)
            {
                _source = source;
                _invokeAction = invokeAction;
            }

            public Task Invoke(T1 arg1, T2 arg2, T3 arg3)
            {
                TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
                _invokeAction(_source, arg1, arg2, arg3, () => tcs.SetResult(1), (e) => tcs.SetException(e));
                return tcs.Task;
            }
        }

        internal class AsyncWrapperA<TSource, T1, T2, T3, T4>
        {
            private readonly TSource _source;
            private readonly Action<TSource, T1, T2, T3, T4, Action, Action<Exception>> _invokeAction;

            public AsyncWrapperA(TSource source, Action<TSource, T1, T2, T3, T4, Action, Action<Exception>> invokeAction)
            {
                _source = source;
                _invokeAction = invokeAction;
            }

            public Task Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            {
                TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
                _invokeAction(_source, arg1, arg2, arg3, arg4, () => tcs.SetResult(1), (e) => tcs.SetException(e));
                return tcs.Task;
            }
        }

        internal class AsyncWrapperA<TSource, T1, T2, T3, T4, T5>
        {
            private readonly TSource _source;
            private readonly Action<TSource, T1, T2, T3, T4, T5, Action, Action<Exception>> _invokeAction;

            public AsyncWrapperA(TSource source, Action<TSource, T1, T2, T3, T4, T5, Action, Action<Exception>> invokeAction)
            {
                _source = source;
                _invokeAction = invokeAction;
            }

            public Task Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            {
                TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
                _invokeAction(_source, arg1, arg2, arg3, arg4, arg5, () => tcs.SetResult(1), (e) => tcs.SetException(e));
                return tcs.Task;
            }
        }

        #endregion Action wrappers

        #region Func wrappers

        internal class AsyncWrapperF<TSource, TReturn>
        {
            private readonly TSource _source;
            private readonly Action<TSource, Action<TReturn>, Action<Exception>> _invokeAction;

            public AsyncWrapperF(TSource source, Action<TSource, Action<TReturn>, Action<Exception>> invokeAction)
            {
                _source = source;
                _invokeAction = invokeAction;
            }

            public Task<TReturn> Invoke()
            {
                TaskCompletionSource<TReturn> tcs = new TaskCompletionSource<TReturn>();
                _invokeAction(_source, (ret) => tcs.SetResult(ret), (e) => tcs.SetException(e));
                return tcs.Task;
            }
        }

        internal class AsyncWrapperF<TSource, T1, TReturn>
        {
            private readonly TSource _source;
            private readonly Action<TSource, T1, Action<TReturn>, Action<Exception>> _invokeAction;

            public AsyncWrapperF(TSource source, Action<TSource, T1, Action<TReturn>, Action<Exception>> invokeAction)
            {
                _source = source;
                _invokeAction = invokeAction;
            }

            public Task<TReturn> Invoke(T1 arg1)
            {
                TaskCompletionSource<TReturn> tcs = new TaskCompletionSource<TReturn>();
                _invokeAction(_source, arg1, (ret) => tcs.SetResult(ret), (e) => tcs.SetException(e));
                return tcs.Task;
            }
        }

        internal class AsyncWrapperF<TSource, T1, T2, TReturn>
        {
            private readonly TSource _source;
            private readonly Action<TSource, T1, T2, Action<TReturn>, Action<Exception>> _invokeAction;

            public AsyncWrapperF(TSource source, Action<TSource, T1, T2, Action<TReturn>, Action<Exception>> invokeAction)
            {
                _source = source;
                _invokeAction = invokeAction;
            }

            public Task<TReturn> Invoke(T1 arg1, T2 arg2)
            {
                TaskCompletionSource<TReturn> tcs = new TaskCompletionSource<TReturn>();
                _invokeAction(_source, arg1, arg2, (ret) => tcs.SetResult(ret), (e) => tcs.SetException(e));
                return tcs.Task;
            }
        }

        internal class AsyncWrapperF<TSource, T1, T2, T3, TReturn>
        {
            private readonly TSource _source;
            private readonly Action<TSource, T1, T2, T3, Action<TReturn>, Action<Exception>> _invokeAction;

            public AsyncWrapperF(TSource source, Action<TSource, T1, T2, T3, Action<TReturn>, Action<Exception>> invokeAction)
            {
                _source = source;
                _invokeAction = invokeAction;
            }

            public Task<TReturn> Invoke(T1 arg1, T2 arg2, T3 arg3)
            {
                TaskCompletionSource<TReturn> tcs = new TaskCompletionSource<TReturn>();
                _invokeAction(_source, arg1, arg2, arg3, (ret) => tcs.SetResult(ret), (e) => tcs.SetException(e));
                return tcs.Task;
            }
        }

        internal class AsyncWrapperF<TSource, T1, T2, T3, T4, TReturn>
        {
            private readonly TSource _source;
            private readonly Action<TSource, T1, T2, T3, T4, Action<TReturn>, Action<Exception>> _invokeAction;

            public AsyncWrapperF(TSource source, Action<TSource, T1, T2, T3, T4, Action<TReturn>, Action<Exception>> invokeAction)
            {
                _source = source;
                _invokeAction = invokeAction;
            }

            public Task<TReturn> Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            {
                TaskCompletionSource<TReturn> tcs = new TaskCompletionSource<TReturn>();
                _invokeAction(_source, arg1, arg2, arg3, arg4, (ret) => tcs.SetResult(ret), (e) => tcs.SetException(e));
                return tcs.Task;
            }
        }

        internal class AsyncWrapperF<TSource, T1, T2, T3, T4, T5, TReturn>
        {
            private readonly TSource _source;
            private readonly Action<TSource, T1, T2, T3, T4, T5, Action<TReturn>, Action<Exception>> _invokeAction;

            public AsyncWrapperF(TSource source, Action<TSource, T1, T2, T3, T4, T5, Action<TReturn>, Action<Exception>> invokeAction)
            {
                _source = source;
                _invokeAction = invokeAction;
            }

            public Task<TReturn> Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            {
                TaskCompletionSource<TReturn> tcs = new TaskCompletionSource<TReturn>();
                _invokeAction(_source, arg1, arg2, arg3, arg4, arg5, (ret) => tcs.SetResult(ret), (e) => tcs.SetException(e));
                return tcs.Task;
            }
        }

        #endregion Func wrappers
    }
}