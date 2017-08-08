using System.Threading.Tasks;
using Teleware.Foundation.Domain.Entity;
using Teleware.Foundation.Domain;

namespace Teleware.Foundation.Domain.Impl
{
    /// <summary>
    /// 实现了基于GUID的Id生成器
    /// </summary>
    public class GuidIdGenerator<TEntity> : IIdGenerator<TEntity>
        where TEntity : IEntity<string>
    {
        /// <inheritdoc/>
        public string Next()
        {
            return System.Guid.NewGuid().ToString();
        }

        /// <inheritdoc/>
        public Task<string> NextAsync()
        {
            return Task.FromResult(Next());
        }
    }
}