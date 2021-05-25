// <copyright file="IAlbumSaver.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Albums.Models;

namespace Albums.Services
{
  public interface IAlbumSaver
  {
    Task<bool> TrySaveAsync(Album album);
  }
}
