using RefactoringChallenge.API.Database;

namespace RefactoringChallenge.API.Services;

public class PeopleServce
{
    private readonly Context Database;

    public PeopleServce(Context context)
    {
        Database = context;
    }

    public async Task<Person> Get(string id)
    {
        return Database.People.First(p => p.id == id);
    }
}