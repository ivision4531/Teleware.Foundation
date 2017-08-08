using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Teleware.Foundation.Data;
using Teleware.Foundation.Domain;
using Teleware.Foundation.Domain.Entity;
using Teleware.Foundation.Domain.Event.Events;

namespace Teleware.Data.Impl
{
    /// <summary>
    /// 基于EF的具有基本CRUD操作的数据仓库
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public class EFCRUDRepository<TEntity, TId> : ICRUDRepository<TEntity, TId> where TEntity : class, IAggregateRoot<TId>
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

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return EFUnitOfWork;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unitOfWork"></param>
        public EFCRUDRepository(IUnitOfWork unitOfWork)
        {
            EFUnitOfWork = unitOfWork as EFUnitOfWork;
        }

        /// <inheritdoc/>
        public void Add(TEntity item)
        {
            item.GetEventPostBox().Post(new EntityCreatedEvent(item));
            Context.Set<TEntity>().Add(item);
        }

        /// <inheritdoc/>
        public void Update(TEntity item)
        {
            item.GetEventPostBox().Post(new EntityUpdatedEvent(item));
        }

        /// <inheritdoc/>
        public void Remove(TEntity item)
        {
            item.GetEventPostBox().Post(new EntityRemovedEvent(item));
            Context.Set<TEntity>().Remove(item);
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
            return Query().Where(filter);
        }

        /// <inheritdoc/>
        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }

        /// <inheritdoc/>
        public TEntity Get(TId id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        /// <inheritdoc/>
        public Task<TEntity> GetAsync(TId id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }
    }

    /// <summary>
    /// 基于EF的具有基本CRUD操作的数据仓库
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class EFCRUDRepository<TEntity> : EFCRUDRepository<TEntity, string>, ICRUDRepository<TEntity>
        where TEntity : class, IAggregateRoot<string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unitOfWork"></param>
        public EFCRUDRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}