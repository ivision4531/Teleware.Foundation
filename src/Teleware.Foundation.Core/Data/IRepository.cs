using Teleware.Foundation.Domain.Entity;

namespace Teleware.Foundation.Data
{
    /// <summary>
    /// 表示一个数据仓库
    /// </summary>
    public interface IRepository
    {
    }

    /// <summary>
    /// 表示一个数据仓库
    /// </summary>
    /// <typeparam name="TEntity">数据库实体类型</typeparam>
    /// <typeparam name="TId">Id类型</typeparam>
    public interface IRepository<TEntity, TId> : IRepository
        where TEntity : class, IAggregateRoot<TId>
    {
    }
}