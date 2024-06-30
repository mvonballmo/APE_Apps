using SQLite;

namespace Core;

public class SettingsModel
{
    [PrimaryKey]
    [AutoIncrement]
    [NotNull]
    public int? Id { get; set; }

    public string FirstName { get; set; } = "Hans";

    public string LastName { get; set; } = "Muster";

    public int Count { get; set; } = 1;
}