using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using Teleware.Foundation.Data;

namespace Teleware.Foundation.AspNetCore.MVC.Filters
{
    /// <summary>
    /// 工作单元（Unit of Work）拦截器
    /// </summary>
    /// <remarks>
    /// 每个请求执行完成后，由此拦截器负责提交工作单元
    /// 如果请求执行发生异常，则什么也不做(放弃提交)
    /// </remarks>
    public class UnitOfWorkCommitFilter : IAsyncActionFilter
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
        /// 执行拦截
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var executedContext = await next();
            if (executedContext.Exception == null)
            {
                await _uow.CommitAsync();
            }
        }
    }
}