// <copyright file="IDataStore.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Albums.Services
{
  public interface IDataStore<T>
  {
    Task Initialize();

    Task<bool> AddItemAsync(T item);

    Task<bool> UpdateItemAsync(T item);

    Task<bool> DeleteItemAsync(string id);

    Task<T> GetItemAsync(string id);

    Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
  }
}
