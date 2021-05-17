// <copyright file="Item.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

namespace Albums.Models
{
  public class Item : UniqueItem
  {
    public string Text { get; set; }

    public string Description { get; set; }
  }
}