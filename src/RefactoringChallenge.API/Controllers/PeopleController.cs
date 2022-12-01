using Microsoft.AspNetCore.Mvc;
using RefactoringChallenge.API.Database;
using RefactoringChallenge.API.Services;

namespace RefactoringChallenge.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly Context Database;

    public PeopleController(Context database)
    {
        Database = database;
    }
    
    [HttpGet("{id}")]
    public Task<Person> Get(string id)
    {
        PeopleServce a = new PeopleServce(Database);
        return a.Get(id);
    }
}