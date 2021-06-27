// <copyright file="UniqueItem.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using SQLite;

namespace Albums.Models
{
  public class UniqueItem
  {
    // Another way to create a primary key is to use an integer and ask the database to auto-increment it
    // [PrimaryKey, AutoIncrement]
    // public int Id { get; set; }

    [PrimaryKey]
    public string Id { get; set; } = Guid.NewGuid().ToString();
  }
}