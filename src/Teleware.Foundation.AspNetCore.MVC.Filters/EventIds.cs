using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleware.Foundation.Exceptions;

namespace Teleware.Foundation.AspNetCore.MVC.Filters
{
    /// <summary>
    /// 事件日志Id
    /// </summary>
    public static class EventIds
    {
        /// <summary>
        /// <see cref="ClientNoticeableException"/>事件日志Id
        /// </summary>
        public const int ClientNoticeableExceptionEventId = 1000;

        /// <summary>
        /// <see cref="HttpClientNoticeableException"/>事件日志Id
        /// </summary>
        public const int HttpClientNoticeableExceptionEventId = 1050;

        /// <summary>
        /// 未知异常事件日志Id
        /// </summary>
        public const int UnknownExceptionEventId = 2000;
    }
}