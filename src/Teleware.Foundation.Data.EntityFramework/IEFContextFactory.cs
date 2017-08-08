using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleware.Data.Impl;

namespace Teleware.Data
{
    /// <summary>
    /// EF上下文工厂
    /// </summary>
    public interface IEFContextFactory
    {
        /// <summary>
        /// 创建<see cref="DbContext"/>实例
        /// </summary>
        /// <param name="connectionName">连接名</param>
        /// <returns></returns>
        DbContext CreateContext(string connectionName);
    }
}