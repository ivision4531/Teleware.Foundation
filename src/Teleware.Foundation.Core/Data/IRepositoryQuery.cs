using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Teleware.Foundation.Domain.Entity;

namespace Teleware.Foundation.Data
{
    /// <summary>
    /// 表示一个快速数据查询器
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryQuery<TEntity>
        where TEntity : IEntity
    {
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
        /// 查找符合条件的特定项
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns>符合条件的数据集合(延迟执行)</returns>
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter);
    }
}