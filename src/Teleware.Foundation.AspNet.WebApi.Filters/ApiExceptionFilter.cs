using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Teleware.Foundation.Diagnostics;
using Teleware.Foundation.Exceptions;
using Teleware.Foundation.Hosting;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace Teleware.Foundation.AspNet.WebApi.Filters
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
    public class ApiExceptionFilter : IAutofacExceptionFilter
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
        /// 处理异常响应
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (_env.IsDevelopment())
            {
                HandleDevelopmentException(actionExecutedContext);
            }
            else
            {
                HandleProductionException(actionExecutedContext);
            }
            return Task.FromResult(0);
        }

        private void HandleDevelopmentException(HttpActionExecutedContext context)
        {
            switch (context.Exception)
            {
                case HttpClientNoticeableException httpClientException:
                    _logger.Debug(EventIds.HttpClientNoticeableExceptionEventId, context.Exception, context.Exception.Message);
                    context.Response = context.Request.CreateResponse((HttpStatusCode)(httpClientException.StatusCode), new
                    {
                        message = httpClientException.Message,
                        stackTrace = httpClientException.StackTrace
                    });
                    context.Exception = null;
                    break;

                case ClientNoticeableException clientException:
                    _logger.Debug(EventIds.ClientNoticeableExceptionEventId, context.Exception, context.Exception.Message);
                    context.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest, new
                    {
                        message = clientException.Message,
                        stackTrace = clientException.StackTrace
                    });
                    context.Exception = null;
                    break;

                default:
                    _logger.Error(EventIds.UnknownExceptionEventId, context.Exception, context.Exception.Message);
                    context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, new
                    {
                        message = "服务端发生异常，请联系管理员",
                        stackTrace = context.Exception.StackTrace
                    });
                    context.Exception = null;
                    break;
            }
        }

        private void HandleProductionException(HttpActionExecutedContext context)
        {
            switch (context.Exception)
            {
                case HttpClientNoticeableException httpClientException:
                    _logger.Debug(EventIds.HttpClientNoticeableExceptionEventId, context.Exception, context.Exception.Message);
                    context.Response = context.Request.CreateResponse((HttpStatusCode)(httpClientException.StatusCode), new
                    {
                        message = httpClientException.Message,
                    });
                    context.Exception = null;
                    break;

                case ClientNoticeableException clientException:
                    _logger.Debug(EventIds.ClientNoticeableExceptionEventId, context.Exception, context.Exception.Message);
                    context.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest, new
                    {
                        message = clientException.Message,
                    });
                    context.Exception = null;
                    break;

                default:
                    _logger.Error(EventIds.UnknownExceptionEventId, context.Exception, context.Exception.Message);
                    context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, new
                    {
                        message = "服务端发生异常，请联系管理员",
                    });
                    context.Exception = null;
                    break;
            }
        }
    }
}