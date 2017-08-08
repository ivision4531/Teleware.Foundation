using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class EFRepositoryQuery<TEntity> : IRepositoryQuery<TEntity> where TEntity : class, IEntity
    {
        private EFUnitOfWork EFUnitOfWork
        {
            get;
            set;
        }

        private DbContext Context
        {
            get
            {
                return EFUnitOfWork.Context;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unitOfWork"></param>
        public EFRepositoryQuery(IUnitOfWork unitOfWork)
        {
            EFUnitOfWork = unitOfWork as EFUnitOfWork;
        }

        /// <inheritdoc/>
        public TEntity[] Find(Expression<Func<TEntity, bool>> filter)
        {
            return Query(filter).ToArray();
        }

        /// <inheritdoc/>
        public Task<TEntity[]> FindAsync(Expression<Func<TEntity, bool>> filter)
        {
            return Query(filter).ToArrayAsync();
        }

        /// <inheritdoc/>
        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter)
        {
            return Context.Set<TEntity>().Where(filter).AsNoTracking();
        }
    }
}