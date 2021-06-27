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
      _connection = new SQLiteConnection(options);

      // Check whether our table already exists. If not, we're creating it here.
      if (_connection.TableMappings.All(x => !x.TableName.Equals(typeof(T).Name, StringComparison.InvariantCultureIgnoreCase)))
      {
        _connection.CreateTable<T>();
      }
    }

    public Task<bool> AddItemAsync(T item)
    {
      var itemInsertedCount = _connection.Insert(item);

      return Task.FromResult(itemInsertedCount == 1);
    }

    public Task<bool> DeleteItemAsync(string id)
    {
      var itemDeletedCount = _connection.Delete<T>(id);

      return Task.FromResult(itemDeletedCount == 1);
    }

    public Task<T> GetItemAsync(string id)
    {
      var result = _connection.Get<T>(id);

      return Task.FromResult(result);
    }

    public Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
    {
      IEnumerable<T> allItems = _connection.Table<T>().ToList();

      return Task.FromResult(allItems);
    }

    public Task<bool> UpdateItemAsync(T item)
    {
      var itemUpdatedCount = _connection.Update(item);

      return Task.FromResult(itemUpdatedCount == 1);
    }

    private SQLiteConnection _connection;

    /// <summary>
    /// Gets the static path to the database. The <see cref="Environment.SpecialFolder"/> is used to resolve the right path.
    /// </summary>
    private static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Albums.db3");
  }
}
