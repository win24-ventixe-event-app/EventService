using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Interfaces;
using Persistence.Models;

namespace Persistence.Repositories;

public class EventRepository(DataContext context) : BaseRepository<EventEntity>(context) 
    , IEventRepository
{
    public override async Task<RepositoryResult<IEnumerable<EventEntity>>> GetAllAsync(EventEntity entity)
    {
        try
        {
            var entities = await _dbSet.Include(x => x.Packages).ToListAsync();
            return new RepositoryResult<IEnumerable<EventEntity>>
            {
                Success = true,
                Status = RepositoryStatusCode.Success,
                Result = entities
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResult<IEnumerable<EventEntity>>
            {
                Success = false,
                Status = RepositoryStatusCode.Failed,
                ErrorMessage = ex.Message
            };
        }
    }

    public override async Task<RepositoryResult<EventEntity>> GetAsync(Expression<Func<EventEntity, bool>> predicate)
    {
        try
        {
            var entity = await _dbSet.Include(x => x.Packages).FirstOrDefaultAsync(predicate);
            if (entity == null)
            {
                return new RepositoryResult<EventEntity>
                {
                    Success = false,
                    Status = RepositoryStatusCode.NotFound,
                    ErrorMessage = "Entity not found"
                };
            }
            return new RepositoryResult<EventEntity>
            {
                Success = true,
                Status = RepositoryStatusCode.Success,
                Result = entity
            };
        }
        catch (Exception)
        {
            return new RepositoryResult<EventEntity>
            {
                Success = false,
                Status = RepositoryStatusCode.Failed,
                ErrorMessage = "An error occurred while retrieving the entity"
            };
        }
    }
}
