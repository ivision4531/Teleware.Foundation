using System;

namespace Teleware.Foundation.Diagnostics
{
    /// <summary>
    /// 表示一个日志记录器
    /// </summary>
    public interface ILogger
    {
        #region TRACE 0

        /// <summary>
        /// 输出 Trace (0) 日志
        /// </summary>
        /// <remarks>
        /// For information that is valuable only to a developer debugging an issue. These messages may contain sensitive application data and so should not be enabled in a production environment.
        /// </remarks>
        void Trace(int eventId, string message);

        /// <summary>
        /// 输出 Trace (0) 日志
        /// </summary>
        /// <remarks>
        /// For information that is valuable only to a developer debugging an issue. These messages may contain sensitive application data and so should not be enabled in a production environment.
        /// </remarks>
        void Trace(int eventId, Exception exception, string message);

        #endregion TRACE 0

        #region DEBUG 1

        /// <summary>
        /// 输出 Debug (1) 日志
        /// </summary>
        /// <remarks>
        /// For information that has short-term usefulness during development and debugging.
        /// </remarks>
        void Debug(int eventId, string message);

        /// <summary>
        /// 输出 Debug (1) 日志
        /// </summary>
        /// <remarks>
        /// For information that has short-term usefulness during development and debugging.
        /// </remarks>
        void Debug(int eventId, Exception exception, string message);

        #endregion DEBUG 1

        #region INFO 2

        /// <summary>
        /// 输出 Info (2) 日志
        /// </summary>
        /// <remarks>
        /// For tracking the general flow of the application.
        /// </remarks>
        void Info(int eventId, string message);

        /// <summary>
        /// 输出 Info (2) 日志
        /// </summary>
        /// <remarks>
        /// For tracking the general flow of the application.
        /// </remarks>
        void Info(int eventId, Exception exception, string message);

        #endregion INFO 2

        #region WARN 3

        /// <summary>
        /// 输出 Warn (3) 日志
        /// </summary>
        /// <remarks>
        /// For abnormal or unexpected events in the application flow.
        /// </remarks>
        void Warn(int eventId, string message);

        /// <summary>
        /// 输出 Warn (3) 日志
        /// </summary>
        /// <remarks>
        /// For abnormal or unexpected events in the application flow.
        /// </remarks>
        void Warn(int eventId, Exception exception, string message);

        #endregion WARN 3

        #region ERROR 4

        /// <summary>
        /// 输出 Error (4) 日志
        /// </summary>
        /// <remarks>
        /// For errors and exceptions that cannot be handled. These messages indicate a failure in the current activity or operation (such as the current HTTP request), not an application-wide failure.
        /// </remarks>
        void Error(int eventId, string message);

        /// <summary>
        /// 输出 Error (4) 日志
        /// </summary>
        /// <remarks>
        /// For errors and exceptions that cannot be handled. These messages indicate a failure in the current activity or operation (such as the current HTTP request), not an application-wide failure.
        /// </remarks>
        void Error(int eventId, Exception exception, string message);

        #endregion ERROR 4

        #region FATAL 5

        /// <summary>
        /// 输出 Fatal (5) 日志
        /// </summary>
        /// <remarks>
        /// For failures that require immediate attention.
        /// </remarks>
        void Fatal(int eventId, string message);

        /// <summary>
        /// 输出 Fatal (5) 日志
        /// </summary>
        /// <remarks>
        /// For failures that require immediate attention.
        /// </remarks>
        void Fatal(int eventId, Exception exception, string message);

        #endregion FATAL 5
    }

    /// <summary>
    /// 表示一个日志记录器
    /// </summary>
    /// <typeparam name="TClass">生成日志的类</typeparam>
    public interface ILogger<TClass> : ILogger
    {
    }
}