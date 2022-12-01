using System.ComponentModel.DataAnnotations;

namespace RefactoringChallenge.API.Database;

public class Person
{
    [Key]
    public string id { get; set; }
    public string Name { get; set; }
    public float Age { get; set; }
}