// <copyright file="MockDataStore{T}.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albums.Models;

namespace Albums.Services
{
  public class MockDataStore<T> : IDataStore<T>
    where T : UniqueItem
  {
    protected List<T> Items { get; set; }

    public async Task<bool> AddItemAsync(T item)
    {
      Items.Add(item);

      return await Task.FromResult(true);
    }

    public async Task<bool> UpdateItemAsync(T item)
    {
      var oldItem = Items.Where((T arg) => arg.Id == item.Id).FirstOrDefault();
      Items.Remove(oldItem);
      Items.Add(item);

      return await Task.FromResult(true);
    }

    public async Task<bool> DeleteItemAsync(string id)
    {
      var oldItem = Items.Where((T arg) => arg.Id == id).FirstOrDefault();
      Items.Remove(oldItem);

      return await Task.FromResult(true);
    }

    public async Task<T> GetItemAsync(string id)
    {
      return await Task.FromResult(Items.FirstOrDefault(s => s.Id == id));
    }

    public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
    {
      return await Task.FromResult(Items);
    }
  }
}