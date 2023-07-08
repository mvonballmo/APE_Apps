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
      Connection = new SQLiteAsyncConnection(options);
    }

    public virtual async Task Initialize()
    {
      // Check whether our table already exists. If not, we're creating it here.
      if (Connection.TableMappings.All(x => !x.TableName.Equals(typeof(T).Name, StringComparison.InvariantCultureIgnoreCase)))
      {
        await Connection.CreateTableAsync<T>();
      }
    }

    public async Task<bool> AddItemAsync(T item)
    {
      return await Connection.InsertAsync(item) == 1;
    }

    public async Task<bool> DeleteItemAsync(string id)
    {
      return await Connection.DeleteAsync<T>(id) == 1;
    }

    public Task<T> GetItemAsync(string id)
    {
      return Connection.GetAsync<T>(id);
    }

    public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
    {
      return await Connection.Table<T>().ToListAsync();
    }

    public async Task<bool> UpdateItemAsync(T item)
    {
      return await Connection.UpdateAsync(item) == 1;
    }

    protected SQLiteAsyncConnection Connection { get; private set; }

    /// <summary>
    /// Gets the static path to the database. The <see cref="Environment.SpecialFolder"/> is used to resolve the right path.
    /// </summary>
    private static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Albums.db3");
  }
}
