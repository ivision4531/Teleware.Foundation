using System;
using System.Collections.Generic;

namespace Teleware.Foundation.Options
{
    /// <summary>
    /// 数据库配置
    /// </summary>
    public class DatabaseOptions
    {
        /// <summary>
        /// 所有数据库连接配置
        /// </summary>
        public Dictionary<string, ConnectionStringConfig> ConnectionStrings { get; set; }

        /// <summary>
        /// 获取特定数据库连接配置
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public ConnectionStringConfig GetConnectionString(string connectionName)
        {
            if (ConnectionStrings == null)
            {
                throw new NullReferenceException("未读取到 Database:ConnectionStrings 配置");
            }
            ConnectionStringConfig value;
            if (!ConnectionStrings.TryGetValue(connectionName, out value))
            {
                throw new NullReferenceException($"未读取到 Database:ConnectionStrings:{connectionName} 配置");
            }
            return value;
        }
    }

    /// <summary>
    /// 连接字符串配置
    /// </summary>
    public class ConnectionStringConfig
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 数据库驱动ProviderName
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// 数据库架构
        /// </summary>
        public string Schema { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{ConnectionString}, {ProviderName}";
        }
    }
}