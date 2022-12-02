using Microsoft.EntityFrameworkCore;
using RefactoringChallenge.API.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Setting and providing db context
builder.Services.AddDbContext<Context>(options =>
{
    options.UseInMemoryDatabase("RefactoringChallenge_InMemoryDB");
});
builder.Services.AddScoped<AppDbContextInitializer>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Initialize database
using (var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<AppDbContextInitializer>();
    await initializer.SeedAsync();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
