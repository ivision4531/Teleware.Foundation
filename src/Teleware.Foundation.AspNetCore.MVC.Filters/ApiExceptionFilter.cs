using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleware.Foundation.Diagnostics;
using Teleware.Foundation.Exceptions;
using Teleware.Foundation.Hosting;

namespace Teleware.Foundation.AspNetCore.MVC.Filters
{
    /// <summary>
    /// 异常拦截器
    /// </summary>
    /// <remarks>
    /// 1. 记录异常日志
    /// 2. 如果为<exception cref="HttpClientNoticeableException">HttpClientNoticeableException</exception>，则返回错误详细信息，并设置Http状态码
    /// 3. 如果为<exception cref="ClientNoticeableException">ClientNoticeableException</exception>，则返回错误详细信息
    /// 4. 如果为其他类型的异常，则返回默认结果
    /// </remarks>
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger;
        private readonly IEnvironment _env;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="env">当前运行时环境</param>
        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger, IEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            if (_env.IsDevelopment())
            {
                HandleDevelopmentException(context);
            }
            else
            {
                HandleProductionException(context);
            }
        }

        private void HandleDevelopmentException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case HttpClientNoticeableException httpClientException:
                    _logger.Debug(EventIds.HttpClientNoticeableExceptionEventId, context.Exception, context.Exception.Message);
                    context.Result = new ObjectResult(new
                    {
                        message = httpClientException.Message,
                        stackTrace = httpClientException.StackTrace
                    })
                    {
                        StatusCode = httpClientException.StatusCode
                    };
                    context.ExceptionHandled = true;
                    break;

                case ClientNoticeableException clientException:
                    _logger.Debug(EventIds.ClientNoticeableExceptionEventId, context.Exception, context.Exception.Message);
                    context.Result = new ObjectResult(new
                    {
                        message = clientException.Message,
                        stackTrace = clientException.StackTrace
                    })
                    {
                        StatusCode = 400
                    };
                    context.ExceptionHandled = true;
                    break;

                default:
                    _logger.Error(EventIds.ClientNoticeableExceptionEventId, context.Exception, context.Exception.Message);
                    context.Result = new ObjectResult(new
                    {
                        message = "服务端发生异常，请联系管理员",
                        stackTrace = context.Exception.StackTrace
                    })
                    {
                        StatusCode = 500
                    };
                    context.ExceptionHandled = true;
                    break;
            }
        }

        private void HandleProductionException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case HttpClientNoticeableException httpClientException:
                    _logger.Debug(EventIds.HttpClientNoticeableExceptionEventId, context.Exception, context.Exception.Message);
                    context.Result = new ObjectResult(new
                    {
                        message = httpClientException.Message,
                    })
                    {
                        StatusCode = httpClientException.StatusCode
                    };
                    context.ExceptionHandled = true;
                    break;

                case ClientNoticeableException clientException:
                    _logger.Debug(EventIds.ClientNoticeableExceptionEventId, context.Exception, context.Exception.Message);
                    context.Result = new ObjectResult(new
                    {
                        message = clientException.Message,
                    })
                    {
                        StatusCode = 400
                    };
                    context.ExceptionHandled = true;
                    break;

                default:
                    _logger.Error(EventIds.UnknownExceptionEventId, context.Exception, context.Exception.Message);
                    context.Result = new ObjectResult(new
                    {
                        message = "服务端发生异常，请联系管理员",
                    })
                    {
                        StatusCode = 500
                    };
                    context.ExceptionHandled = true;
                    break;
            }
        }
    }
}