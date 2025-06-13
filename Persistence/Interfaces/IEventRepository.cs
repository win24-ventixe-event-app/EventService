using System;
using System.Linq.Expressions;
using Persistence.Entities;
using Persistence.Models;

namespace Persistence.Interfaces;

public interface IEventRepository
{
    Task<RepositoryResult<IEnumerable<EventEntity>>> GetAllAsync(EventEntity entity);
    Task<RepositoryResult<EventEntity>> GetAsync(Expression<Func<EventEntity, bool>> predicate);
   
    
}
