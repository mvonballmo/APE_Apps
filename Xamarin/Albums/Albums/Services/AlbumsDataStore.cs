// <copyright file="AlbumsDataStore.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Albums.Models;

namespace Albums.Services
{
  public class AlbumsDataStore : SQLiteDataStore<Album>
  {
    public AlbumsDataStore(IWebService<Album> albumsWebService)
    {
      _albumsWebService = albumsWebService;
    }

    public override async Task Initialize()
    {
      await base.Initialize();

      var initialAlbums = await _albumsWebService.Get();

      await Connection.InsertAllAsync(initialAlbums);
    }

    private readonly IWebService<Album> _albumsWebService;
  }
}