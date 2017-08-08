namespace Teleware.Foundation.Hosting
{
    /// <summary>
    /// 提供当前执行环境相关信息
    /// </summary>
    /// <remarks>
    /// 在ASP.net core环境中此接口将对接 Microsoft.AspNetCore.Hosting.IHostingEnvironment
    /// </remarks>
    public interface IEnvironment
    {
        /// <summary>
        /// 当前环境名
        /// </summary>
        string EnvironmentName { get; }

        /// <summary>
        /// 资源根路径
        /// </summary>
        string ContentRootPath { get; }
    }
}