using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Teleware.Foundation.Domain.Entity;

namespace Teleware.Foundation.Data
{
    /// <summary>
    /// 表示一个具有基本CRUD操作的数据仓库
    /// </summary>
    /// <typeparam name="TEntity">数据库实体类型</typeparam>
    /// <typeparam name="TId">Id类型</typeparam>
    public interface ICRUDRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// 添加新项
        /// </summary>
        /// <param name="item">新项</param>
        void Add(TEntity item);

        /// <summary>
        /// 更新现有项
        /// </summary>
        /// <param name="item">现有项</param>
        void Update(TEntity item);

        /// <summary>
        /// 删除现有项
        /// </summary>
        /// <param name="item">现有项</param>
        void Remove(TEntity item);

        /// <summary>
        /// 查找符合条件的特定项
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns>符合条件的数据集合(延迟执行)</returns>
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 查找所有项
        /// </summary>
        /// <returns>符合条件的数据集合(延迟执行)</returns>
        IQueryable<TEntity> Query();

        /// <summary>
        /// 查找符合条件的特定项
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns>符合条件的数据集合(立即执行)</returns>
        TEntity[] Find(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 查找符合条件的特定项
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns>符合条件的数据集合(立即执行)</returns>
        Task<TEntity[]> FindAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 根据Id获取特定项
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>符合主键的项，如果不存在则返回null</returns>
        TEntity Get(TId id);

        /// <summary>
        /// 根据Id获取特定项
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>符合主键的项，如果不存在则返回null</returns>
        Task<TEntity> GetAsync(TId id);
    }

    /// <summary>
    /// 表示一个具有基本CRUD操作的数据仓库
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface ICRUDRepository<TEntity> : ICRUDRepository<TEntity, string>
        where TEntity : class, IAggregateRoot<string>
    {
    }
}