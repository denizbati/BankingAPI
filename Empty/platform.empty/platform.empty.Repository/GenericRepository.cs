
using Banking.Domain.Entities;
using Banking.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Banking.Repository
{
    internal abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _entities;

        protected GenericRepository(DbContext context)
        {
            _entities = context.Set<TEntity>();
            _dbContext = context;
        }

        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _entities.SingleOrDefaultAsync(f => f.Id == id && f.IsActive, cancellationToken);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _entities.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _entities.SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _entities.Where(f => f.IsActive).Where(predicate).ToArrayAsync(cancellationToken);
        }

      

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _entities.Where(predicate).Where(s => s.IsActive).CountAsync(cancellationToken);
        }
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _entities.Where(s => s.IsActive).AnyAsync(predicate, cancellationToken);
        }

        public async Task<TEntity> AddEntity(TEntity entity, CancellationToken cancellationToken)
        {
            return (await _entities.AddAsync(entity, cancellationToken)).Entity;
        }
        public async Task AddRangeEntity(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public async Task AddRangeEntity(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            await _entities.AddRangeAsync(entities, cancellationToken);
        }

        public TEntity UpdateEntity(TEntity entity)
        {
            var entityEntry = _entities.Update(entity);
            return entityEntry.Entity;
        }

        public void DeleteEntity(TEntity entity)
        {
            entity.SetIsActive(false);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
