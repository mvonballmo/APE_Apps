// <copyright file="SQLiteDataStore{T}.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Albums.Services
{
  public class SQLServerDataStore<T> : IDataStore<T>
    where T : new()
  {
    public SQLServerDataStore()
    {
      _connection = new SqlConnection("Server=.\\SQLExpress;Database=myDataBase;Integrated Security=true");
    }

    public async Task Initialize()
    {
      using (var cmd = _connection.CreateCommand())
      {
        // Here, we just do a sanity check that we've connected to the right
        // database. You can execute whatever you want to check the database
        // (or nothing at all, but it's probably best to do some sort of
        // check).
        //
        // You could also call a stored procedure and check the result, so that
        // you put the logic in the database instead of here.

        cmd.CommandText = "SELECT COUNT(*) FROM Users";
        var result = await cmd.ExecuteScalarAsync();

        if (result is int rowCount && rowCount == 0)
        {
          throw new InvalidOperationException("The Users table should contain at least one user; database schema is misconfigured.");
        }
      }
    }

    public async Task<bool> AddItemAsync(T item)
    {
      // Here, you probably want to call a stored procedure, passing parameters.
      // See <https://stackoverflow.com/questions/15262387/how-to-create-c-sharp-method-with-sqlconnection-executing-stored-procedure-with> for examples

      // You will need to figure out how to map "item" to the parameters of your
      // SP. Maybe you have to make a object-specific implementation because
      // you don't have access to the properties of T here.

      // Anyway, this is how to call a stored procedure with SQL Server

      using (var cmd = _connection.CreateCommand())
      {
        var parameters = new Dictionary<string, object>
        {
          { "@param1", 1 },
          { "@param2", "text" },
          { "@param3", true }
        };

        cmd.CommandText = "AddItem";
        cmd.Parameters.AddRange(parameters.Select(l => new SqlParameter(l.Key, l.Value)).ToArray());
        cmd.CommandType = CommandType.StoredProcedure;

        return await cmd.ExecuteNonQueryAsync() == 1;
      }
    }

    public async Task<bool> DeleteItemAsync(string id)
    {
      using (var cmd = _connection.CreateCommand())
      {
        var parameters = new Dictionary<string, object>
        {
          { "@idParameter", id },
        };

        cmd.CommandText = "DeleteItem";
        cmd.Parameters.AddRange(parameters.Select(l => new SqlParameter(l.Key, l.Value)).ToArray());
        cmd.CommandType = CommandType.StoredProcedure;

        return await cmd.ExecuteNonQueryAsync() == 1;
      }
    }

    public async Task<T> GetItemAsync(string id)
    {
      // As with the "Add" function, you're going to have to figure out how to convert
      // what you get back from the stored procedure to the target object. You could
      // return JSON from the server (like a REST service) and then convert it to the
      // target object here with JsonConvert. See below.

      using (var cmd = _connection.CreateCommand())
      {
        var parameters = new Dictionary<string, object>
        {
          { "@idParameter", id },
        };

        cmd.CommandText = "GetItem";
        cmd.Parameters.AddRange(parameters.Select(l => new SqlParameter(l.Key, l.Value)).ToArray());
        cmd.CommandType = CommandType.StoredProcedure;

        var result = await cmd.ExecuteScalarAsync();

        if (result is string jsonText)
        {
          return JsonConvert.DeserializeObject<T>(jsonText);
        }

        throw new InvalidOperationException("SP did not return text.");
      }
    }

    public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
    {
      // Very much like the Get() method

      using (var cmd = _connection.CreateCommand())
      {
        cmd.CommandText = "GetItems";
        cmd.CommandType = CommandType.StoredProcedure;

        var result = await cmd.ExecuteScalarAsync();

        if (result is string jsonText)
        {
          return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonText);
        }

        throw new InvalidOperationException("SP did not return text.");
      }
    }

    public async Task<bool> UpdateItemAsync(T item)
    {
      using (var cmd = _connection.CreateCommand())
      {
        var parameters = new Dictionary<string, object>
        {
          { "@param1", 1 },
          { "@param2", "text" },
          { "@param3", true }
        };

        cmd.CommandText = "UpdateItem";
        cmd.Parameters.AddRange(parameters.Select(l => new SqlParameter(l.Key, l.Value)).ToArray());
        cmd.CommandType = CommandType.StoredProcedure;

        return await cmd.ExecuteNonQueryAsync() == 1;
      }
    }

    private SqlConnection _connection;

    /// <summary>
    /// Gets the static path to the database. The <see cref="Environment.SpecialFolder"/> is used to resolve the right path.
    /// </summary>
    private static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Albums.db3");
  }
}
