using System;
using System.Data.Common;
using Teleware.Foundation.Options;
using Teleware.Foundation.Assertion;
namespace Teleware.Foundation.Data.Extensions
{
    /// <summary>
    /// 数据库配置扩展类
    /// </summary>
    public static class DatabaseExtension
    {
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="dbConfig"></param>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public static DbConnection GetDbConnection(this DatabaseOptions dbConfig, string connectionName = "Default")
        {
            // TODO: 等待.Net core拿出查询DbProviderFactory的方案
            var connectionConfig = dbConfig.GetConnectionString(connectionName);
            connectionConfig.ProviderName.ShouldBe(c => c == "Oracle.ManagedDataAccess.Client",()=>new ArgumentException($"连接字符串 {connectionName} 的ProviderName必须为 Oracle.ManagedDataAccess.Client", nameof(connectionName)));
            var conn = Oracle.ManagedDataAccess.Client.OracleClientFactory.Instance.CreateConnection();
            conn.ConnectionString = connectionConfig.ConnectionString;
            return conn;
        }
    }

}
