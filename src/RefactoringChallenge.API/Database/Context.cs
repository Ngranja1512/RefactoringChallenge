using Microsoft.EntityFrameworkCore;

namespace RefactoringChallenge.API.Database;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }
    
    public DbSet<Person> People { get; set; }
    
    public Task<int> SaveChangesAsync() => base.SaveChangesAsync();
}