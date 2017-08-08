using System;

namespace Teleware.Foundation.Hosting.Application
{
    /// <summary>
    /// 程序执行环境
    /// </summary>
    public class ApplicationEnvironment : IEnvironment
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="environmentName">环境名</param>
        /// <param name="contentRootPath">资源根路径</param>
        /// <remarks>
        /// 根据当前进程中的环境变量 ASPNETCORE_ENVIRONMENT 决定当前环境，默认为 Development
        /// </remarks>
        public ApplicationEnvironment(string environmentName = null, string contentRootPath = null)
        {
            EnvironmentName = environmentName
                ?? System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                ?? Teleware.Foundation.Hosting.EnvironmentName.Development;
            ContentRootPath = contentRootPath ?? System.AppContext.BaseDirectory;
        }

        /// <summary>
        /// 当前环境名
        /// </summary>
        public string EnvironmentName { get; }

        /// <summary>
        /// 资源根路径
        /// </summary>
        public string ContentRootPath { get; }
    }
}