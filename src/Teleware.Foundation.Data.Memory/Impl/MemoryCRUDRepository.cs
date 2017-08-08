using System;
using System.Collections.Generic;
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
    /// 基于内存的具有基本CRUD操作的数据仓库
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public class MemoryCRUDRepository<TEntity, TId> : ICRUDRepository<TEntity, TId> where TEntity : class, IAggregateRoot<TId>
    {
        private MemoryUnitOfWork MUnitOfWork
        {
            get;
            set;
        }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return MUnitOfWork;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unitOfWork"></param>
        public MemoryCRUDRepository(IUnitOfWork unitOfWork)
        {
            MUnitOfWork = unitOfWork as MemoryUnitOfWork;
        }

        /// <inheritdoc/>
        public void Add(TEntity item)
        {
            item.GetEventPostBox().Post(new EntityCreatedEvent(item));
            MUnitOfWork.Items.Add(item);
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
            MUnitOfWork.Items.Remove(item);
            MUnitOfWork.RemovedItems.Add(item);
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
            return Query().Where(filter);
        }

        /// <inheritdoc/>
        public IQueryable<TEntity> Query()
        {
            return MUnitOfWork.Items.OfType<TEntity>().AsQueryable();
        }

        /// <inheritdoc/>
        public TEntity Get(TId id)
        {
            return MUnitOfWork.Items.OfType<TEntity>().FirstOrDefault(item => item.Id.Equals(id));
        }

        /// <inheritdoc/>
        public Task<TEntity> GetAsync(TId id)
        {
            return Task.FromResult(Get(id));
        }
    }

    /// <summary>
    /// 基于EF的具有基本CRUD操作的数据仓库
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class MemoryCRUDRepository<TEntity> : MemoryCRUDRepository<TEntity, string>, ICRUDRepository<TEntity>
        where TEntity : class, IAggregateRoot<string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unitOfWork"></param>
        public MemoryCRUDRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}