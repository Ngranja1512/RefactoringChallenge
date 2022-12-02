using Microsoft.EntityFrameworkCore;

namespace RefactoringChallenge.API.Database;

public class AppDbContextInitializer
{
    private readonly ILogger<AppDbContextInitializer> _logger;
    private readonly Context _context;

    public AppDbContextInitializer(ILogger<AppDbContextInitializer> logger, Context context)
    {
        _logger = logger;
        _context = context;
    }
    
    public static List<Person> _people = new()
    {
        new() { id = "U1", Name = "Vahid", Age = 28 },
        new() { id = "U2", Name = "Andreas", Age = 32 },
        new() { id = "U3", Name = "Emilie", Age = 32 },
        new() { id = "U4", Name = "Johanna", Age = 24 },
        new() { id = "U5", Name = "Alberta", Age = 18 }
    };
    
    private async Task TrySeedAsync()
    {
        await _context.People.AddRangeAsync(_people);
        await _context.SaveChangesAsync();
    }
    
    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }
}