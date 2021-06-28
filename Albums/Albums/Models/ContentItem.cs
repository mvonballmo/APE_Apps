// <copyright file="ContentItem.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

namespace Albums.Models
{
  public class ContentItem : UniqueItem
  {
    public string Title { get; set; }

    public string Description { get; set; }

    public override string ToString()
    {
      return $"{Title}: {Description}";
    }
  }
}
