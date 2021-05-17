// <copyright file="ItemMockDataStore.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Albums.Models;

namespace Albums.Services
{
  public class ItemMockDataStore : MockDataStore<Item>
  {
    public ItemMockDataStore()
    {
      Items = new List<Item>()
      {
        new Item { Text = "First item", Description = "This is an item description." },
        new Item { Text = "Second item", Description = "This is an item description." },
        new Item { Text = "Third item", Description = "This is an item description." },
        new Item { Text = "Fourth item", Description = "This is an item description." },
        new Item { Text = "Fifth item", Description = "This is an item description." },
        new Item { Text = "Sixth item", Description = "This is an item description." }
      };
    }
  }
}