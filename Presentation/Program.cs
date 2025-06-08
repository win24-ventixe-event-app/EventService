using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Server=localhost,1433;Database=EventManagementDB;User Id=sa;Password=CodeGuruOzzy2025!?;TrustServerCertificate=True"));
var app = builder.Build();
app.MapOpenApi();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
