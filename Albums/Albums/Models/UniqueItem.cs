// <copyright file="UniqueItem.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;

namespace Albums.Models
{
  public class UniqueItem
  {
    public string Id { get; set; } = Guid.NewGuid().ToString();
  }
}