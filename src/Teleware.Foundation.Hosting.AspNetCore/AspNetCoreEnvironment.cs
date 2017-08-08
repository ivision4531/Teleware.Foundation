using Microsoft.AspNetCore.Hosting;
using System;
using Teleware.Foundation.Hosting;

namespace Teleware.Foundation.Hosting.AspNetCore
{
    /// <summary>
    /// AspNetCore执行环境
    /// </summary>
    public class AspNetCoreEnvironment : IEnvironment
    {
        private readonly IHostingEnvironment _env;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="env">ASP.net core环境</param>
        public AspNetCoreEnvironment(IHostingEnvironment env)
        {
            _env = env;
        }

        /// <summary>
        /// 当前环境名
        /// </summary>
        public string EnvironmentName => _env.EnvironmentName;

        /// <summary>
        /// 资源根路径
        /// </summary>
        public string ContentRootPath => _env.ContentRootPath;
    }
}