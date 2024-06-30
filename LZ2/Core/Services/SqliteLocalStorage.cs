using Core.Models;
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
                !x.TableName.Equals(nameof(Person), StringComparison.InvariantCultureIgnoreCase)))
        {
            await _connection.CreateTableAsync<Person>();
        }
    }

    public async Task<bool> Delete(Person person)
    {
        return await _connection.DeleteAsync<Person>(person.Id) == 1;
    }

    /// <inheritdoc/>
    public Task<List<Person>> LoadAll()
    {
        return _connection.Table<Person>().ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAll()
    {
        return await _connection.DeleteAllAsync<Person>() >= 0;
    }

    /// <inheritdoc/>
    public async Task<bool> Save(Person person)
    {
        return await _connection.InsertOrReplaceAsync(person) == 1;
    }

    /// <inheritdoc/>
    public async Task<Person?> TryLoad(int id)
    {
        return await _connection.FindAsync<Person?>(id);
    }
}