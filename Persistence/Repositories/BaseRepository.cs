
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Models;

namespace Persistence.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) where TEntity : class
{
    protected readonly DataContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public virtual async Task<RepositoryResult> AddAsync(TEntity entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return new RepositoryResult
            {
                Success = true,
                Status = RepositoryStatusCode.Success
            };
        }

        catch (Exception ex)
        {
            return new RepositoryResult
            {
                Success = false,
                Status = RepositoryStatusCode.Failed,
                ErrorMessage = ex.Message
            };

        }
    }
    public virtual async Task<RepositoryResult<IEnumerable<TEntity>>> GetAllAsync(TEntity entity)
    {
        try
        {
            var entities = await _dbSet.ToListAsync();
            return new RepositoryResult<IEnumerable<TEntity>>
            {
                Success = true,
                Status = RepositoryStatusCode.Success,
                Result = entities
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResult<IEnumerable<TEntity>>
            {
                Success = false,
                Status = RepositoryStatusCode.Failed,
                ErrorMessage = ex.Message
            };
        }
    }
    public virtual async Task<RepositoryResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var entity = await _dbSet.FirstOrDefaultAsync(predicate);
            if (entity == null)
            {
                return new RepositoryResult<TEntity>
                {
                    Success = false,
                    Status = RepositoryStatusCode.NotFound,
                    ErrorMessage = "Entity not found"
                };
            }
            return new RepositoryResult<TEntity>
            {
                Success = true,
                Status = RepositoryStatusCode.Success,
                Result = entity
            };
        }
        catch (Exception)
        {
            return new RepositoryResult<TEntity>
            {
                Success = false,
                Status = RepositoryStatusCode.Failed,
                ErrorMessage = "An error occurred while retrieving the entity"
            };
        }

    }
    public virtual async Task<RepositoryResult> UpdateAsync(TEntity entity)
    {
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return new RepositoryResult
            {
                Success = true,
                Status = RepositoryStatusCode.Success
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResult
            {
                Success = false,
                Status = RepositoryStatusCode.Failed,
                ErrorMessage = ex.Message
            };
        }
    }
    public virtual async Task<RepositoryResult> DeleteAsync(TEntity entity)
    {
        try
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return new RepositoryResult
            {
                Success = true,
                Status = RepositoryStatusCode.Success
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResult
            {
                Success = false,
                Status = RepositoryStatusCode.Failed,
                ErrorMessage = ex.Message
            };
        }
    }
    public virtual async Task<RepositoryResult> AlreadyExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var exists = await _dbSet.AnyAsync(predicate);
            return new RepositoryResult
            {
                Success = exists,
                Status = exists ? RepositoryStatusCode.Success : RepositoryStatusCode.NotFound,
                ErrorMessage = exists ? null : "Entity already exists"
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResult
            {
                Success = false,
                Status = RepositoryStatusCode.Failed,
                ErrorMessage = ex.Message
            };
        }
    }
}
