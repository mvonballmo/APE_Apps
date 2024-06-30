using SQLite;

namespace Core.Services;

public class SqliteLocalStorage : ILocalStorage
{
    private readonly SQLiteAsyncConnection _connection;

    public SqliteLocalStorage(LocalStorageSettings settings)
    {
        var options = new SQLiteConnectionString(settings.DatabasePath);
        _connection = new SQLiteAsyncConnection(options);
    }

    public async Task Initialize()
    {
        // Check whether our table already exists. If not, we're creating it here.
        if (_connection.TableMappings.All(x =>
                !x.TableName.Equals(nameof(SettingsModel), StringComparison.InvariantCultureIgnoreCase)))
        {
            await _connection.CreateTableAsync<SettingsModel>();
        }
    }

    public async Task<bool> Delete(SettingsModel settingsModel)
    {
        return await _connection.DeleteAsync<SettingsModel>(settingsModel.Id) == 1;
    }

    /// <inheritdoc/>
    public Task<List<SettingsModel>> LoadAll()
    {
        return _connection.Table<SettingsModel>().ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAll()
    {
        return await _connection.DeleteAllAsync<SettingsModel>() >= 0;
    }

    /// <inheritdoc/>
    public async Task<bool> Save(SettingsModel settingsModel)
    {
        return await _connection.InsertOrReplaceAsync(settingsModel) == 1;
    }

    /// <inheritdoc/>
    public async Task<SettingsModel?> TryLoad(int id)
    {
        return await _connection.FindAsync<SettingsModel?>(id);
    }
}