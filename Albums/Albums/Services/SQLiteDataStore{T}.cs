// <copyright file="SQLiteDataStore{T}.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace Albums.Services
{
  public class SQLiteDataStore<T> : IDataStore<T>
    where T : new()
  {
    public SQLiteDataStore()
    {
      var options = new SQLiteConnectionString(DatabasePath);
      _connection = new SQLiteAsyncConnection(options);
    }

    public async Task Initialize()
    {
      // Check whether our table already exists. If not, we're creating it here.
      if (_connection.TableMappings.All(x => !x.TableName.Equals(typeof(T).Name, StringComparison.InvariantCultureIgnoreCase)))
      {
        await _connection.CreateTableAsync<T>();
      }
    }

    public async Task<bool> AddItemAsync(T item)
    {
      return await _connection.InsertAsync(item) == 1;
    }

    public async Task<bool> DeleteItemAsync(string id)
    {
      return await _connection.DeleteAsync<T>(id) == 1;
    }

    public Task<T> GetItemAsync(string id)
    {
      return _connection.GetAsync<T>(id);
    }

    public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
    {
      return await _connection.Table<T>().ToListAsync();
    }

    public async Task<bool> UpdateItemAsync(T item)
    {
      return await _connection.UpdateAsync(item) == 1;
    }

    private SQLiteAsyncConnection _connection;

    /// <summary>
    /// Gets the static path to the database. The <see cref="Environment.SpecialFolder"/> is used to resolve the right path.
    /// </summary>
    private static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Albums.db3");
  }
}
