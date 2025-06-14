using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        
        optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=event-database;User Id=sa;Password=CodeGuruOzzy2025!?;TrustServerCertificate=True");
        return new DataContext(optionsBuilder.Options);
    }

    
}
