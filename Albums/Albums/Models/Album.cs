// <copyright file="Album.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

namespace Albums.Models
{
  // TODO Extract base class for common properties

  public class Album
  {
    public string Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
  }
}
