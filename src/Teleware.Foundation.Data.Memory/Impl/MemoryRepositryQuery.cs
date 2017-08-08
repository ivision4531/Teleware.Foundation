using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Teleware.Foundation.Data;
using Teleware.Foundation.Domain;
using Teleware.Foundation.Domain.Entity;

namespace Teleware.Data.Impl
{
    /// <summary>
    /// 基于EF的快速数据查询器
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class MemoryRepositoryQuery<TEntity> : IRepositoryQuery<TEntity> where TEntity : class, IEntity
    {
        private MemoryUnitOfWork UnitOfWork
        {
            get;
            set;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unitOfWork"></param>
        public MemoryRepositoryQuery(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork as MemoryUnitOfWork;
        }

        /// <inheritdoc/>
        public TEntity[] Find(Expression<Func<TEntity, bool>> filter)
        {
            return Query(filter).ToArray();
        }

        /// <inheritdoc/>
        public Task<TEntity[]> FindAsync(Expression<Func<TEntity, bool>> filter)
        {
            return Task.FromResult(Query(filter).ToArray());
        }

        /// <inheritdoc/>
        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter)
        {
            return UnitOfWork.Items.OfType<TEntity>().AsQueryable().Where(filter);
        }
    }
}