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
    public Task Initialize()
    {
      return Task.CompletedTask;
    }

    public async Task<bool> AddItemAsync(T item)
    {
      Items.Add(item);

      return await Task.FromResult(true);
    }

    public async Task<bool> UpdateItemAsync(T item)
    {
      var oldItem = Items.FirstOrDefault(arg => arg.Id == item.Id);
      Items.Remove(oldItem);
      Items.Add(item);

      return await Task.FromResult(true);
    }

    public async Task<bool> DeleteItemAsync(string id)
    {
      var oldItem = Items.FirstOrDefault(arg => arg.Id == id);
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

    protected List<T> Items { get; set; }
  }
}