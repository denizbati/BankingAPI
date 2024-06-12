using Banking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Repository.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> AddEntity(TEntity entity, CancellationToken cancellationToken);
        Task AddRangeEntity(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
        TEntity UpdateEntity(TEntity entity);
        void DeleteEntity(TEntity entity);

        protected Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        protected Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        protected Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        protected Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        protected Task<IEnumerable<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        protected Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        protected Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    }
}
