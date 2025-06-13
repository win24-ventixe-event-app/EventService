
namespace Persistence.Models;

public enum RepositoryStatusCode
{
    Success = 200,
    NotFound = 404,
    Failed = 500,
    Invalid = 400,
    
}
public class RepositoryResult
{
    public bool Success { get; set; }
    public RepositoryStatusCode? Status { get; set; }
    public string? ErrorMessage { get; set; }
}

public class RepositoryResult<T> : RepositoryResult where T : class
{
    public T? Result { get; set; }
}