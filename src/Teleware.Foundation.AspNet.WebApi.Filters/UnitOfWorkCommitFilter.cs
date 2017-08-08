using Autofac.Integration.WebApi;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Teleware.Foundation.Data;

namespace Teleware.Foundation.AspNet.WebApi.Filters
{
    /// <summary>
    /// 工作单元（Unit of Work）拦截器
    /// </summary>
    /// <remarks>
    /// 每个请求执行完成后，由此拦截器负责提交工作单元
    /// 如果请求执行发生异常，则什么也不做(放弃提交)
    /// </remarks>
    public class UnitOfWorkCommitFilter : IAutofacActionFilter
    {
        private readonly IUnitOfWorkCoordinator _uow;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="uow">工作单元协调器，如果有多个工作单元则通过协调器保证一同提交</param>
        public UnitOfWorkCommitFilter(IUnitOfWorkCoordinator uow)
        {
            _uow = uow;
        }

        /// <summary>
        /// 请求完成后提交工作单元中的当前工作
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception == null && actionExecutedContext.Response.IsSuccessStatusCode == true)
            {
                return _uow.CommitAsync();
            }
            else
            {
                return Task.FromResult(0);
            }
        }

        /// <summary>
        /// 什么都不做
        /// </summary>
        /// <param name="actionContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}