using System;
using System.Linq.Expressions;
using Persistence.Models;

namespace Persistence.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<RepositoryResult> AddAsync(TEntity entity);
    Task<RepositoryResult<IEnumerable<TEntity>>> GetAllAsync();
    Task<RepositoryResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task<RepositoryResult> UpdateAsync(TEntity entity);
    Task<RepositoryResult> DeleteAsync(TEntity entity);
    Task<RepositoryResult> AlreadyExistsAsync(Expression<Func<TEntity, bool>> predicate);

}
