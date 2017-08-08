using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Teleware.Foundation.Options;
using Teleware.Foundation.Assertion;
using System.Data.Entity;
using Teleware.Foundation.Diagnostics;

namespace Teleware.Data.Impl
{
    /// <summary>
    /// 基于Oracle数据库的EF上下文工厂
    /// </summary>
    public class OracleEFContextFactory : IEFContextFactory
    {
        private readonly DatabaseOptions _configure;
        private readonly Lazy<IEnumerable<IDbObjConfiguration>> _dbConfigurations;
        private readonly ILogger<OracleEFContext> _logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configureOptions"></param>
        /// <param name="dbConfigurations"></param>
        /// <param name="logger"></param>
        public OracleEFContextFactory(
            IOptions<DatabaseOptions> configureOptions,
            Lazy<IEnumerable<IDbObjConfiguration>> dbConfigurations,
            ILogger<OracleEFContext> logger)
        {
            _configure = configureOptions.Value;
            _dbConfigurations = dbConfigurations;
            _logger = logger;
        }

        /// <inheritdoc/>
        public DbContext CreateContext(string connectionName)
        {
            var connString = _configure.GetConnectionString(connectionName);
            connString.ProviderName.ShouldBe(pn => pn == "Oracle.ManagedDataAccess.Client", $"不支持的ProviderName: {connString.ProviderName}");
            string schema = GetSchema(connString);
            return new OracleEFContext(new Oracle.ManagedDataAccess.Client.OracleConnection(connString.ConnectionString), schema, _dbConfigurations, _logger);
        }

        private static string GetSchema(ConnectionStringConfig connString)
        {
            return connString.Schema ?? GetUserIdAsSchema(connString.ConnectionString);
        }

        private static string GetUserIdAsSchema(string connectionString)
        {
            const string userIdRegex = "User Id=(?<schema>[^;]*);";
            var item = Regex.Match(connectionString, userIdRegex, RegexOptions.IgnoreCase);
            var schema = item.Groups["schema"].Value;
            return schema;
        }
    }
}