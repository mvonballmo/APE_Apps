using SQLite;

namespace Core.Models;

public class Person
{
    [PrimaryKey]
    [AutoIncrement]
    [NotNull]
    public int? Id { get; set; }

    public string FirstName { get; set; } = "Hans";

    public string LastName { get; set; } = "Muster";

    public int Age { get; set; } = 1;
}