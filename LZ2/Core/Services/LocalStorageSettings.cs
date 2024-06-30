namespace Core.Services;

public class LocalStorageSettings
{
    /// <summary>
    /// Gets the static path to the database. The <see cref="Environment.SpecialFolder"/> is used to resolve the right path.
    /// </summary>
    public string DatabasePath =>
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            DatabaseFilename);

    public string DatabaseFilename { get; set; } = "Maui2024.db3";
}