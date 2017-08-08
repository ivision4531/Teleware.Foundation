using System;
using System.Collections.Generic;
using System.Text;

namespace Teleware.Foundation.Hosting
{
    /// <summary>
    /// 常用环境名
    /// </summary>
    public static class EnvironmentName
    {
        /// <summary>
        /// 开发环境
        /// </summary>
        public const string Development = "Development";

        /// <summary>
        /// 预演环境（正式上线前）
        /// </summary>
        public const string Staging = "Staging";

        /// <summary>
        /// 生产环境
        /// </summary>
        public const string Production = "Production";
    }
}